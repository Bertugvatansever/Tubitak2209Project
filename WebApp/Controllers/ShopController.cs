using Gat.BusinessLayer.Abstract;
using Gat.Core.Entity;
using Gat.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Drawing.Printing;
using System.Security.Cryptography.Xml;

namespace WebApp.Controllers
{
    public class ShopController : Controller
    {
        private IProductService _productService;
        private IUserService _userService;
		private IHttpContextAccessor _httpContextAccessor;
        private ICategoryService _categoryService;   
        private IContractService _contractService;
        private IProductOperationsService _productOperationsService;
        private IOrderDetailService _orderDetailService;
        private IOrderService _orderService;
        private IWebHostEnvironment _hostingEnvironment;
        public ShopController(IProductService productService, IHttpContextAccessor httpContextAccessor, ICategoryService categoryService,IUserService userService, IContractService contractService, IProductOperationsService productOperationsService, IOrderDetailService orderDetailService, IOrderService orderService, IWebHostEnvironment hostingEnvironment)
        {
            this._productService = productService;
			this._httpContextAccessor = httpContextAccessor;
            this._categoryService = categoryService;
            this._userService = userService;
            this._contractService = contractService;
            this._productOperationsService = productOperationsService;
            this._orderDetailService = orderDetailService;
            this._orderService = orderService;
            this._hostingEnvironment = hostingEnvironment;
        }

        public static List<Product> productList = new List<Product>();

        //gat sitesi ürün listelenmesi
        public IActionResult Index(int id)
        {
            if (id!=0)
            {
                productCategoryModel filterModel = new productCategoryModel();
                filterModel.Categories = _categoryService.GetList();
                filterModel.Products= _productService.GetList().Where(x=>x.CategoryId==id && x.ProductType== "satılık").ToList();
                //var getCategory= _categoryService.GetByID(id);
                ViewBag.CategoryName = _categoryService.GetList().Where(x => x.Id == id).Select(x => x.CategoryName).FirstOrDefault();
                return View(filterModel);

            }
            else
            {
                productCategoryModel model = new productCategoryModel();
                model.Categories = _categoryService.GetList();

                model.Products = _productService.GetList()
                        .Where(x => x.ProductType == "satılık")
                        .OrderByDescending(x => x.Id)
                        .ToList();


                return View(model);
            }            
            
        }

        public IActionResult ShopDetail(int id)
        {
            productCategoryModel model = new productCategoryModel();
            model.Product = _productService.GetByID(id);
            model.Products = _productService.GetList().Where(x => x.CategoryId == model.Product.CategoryId && x.ProductType==model.Product.ProductType).Take(4).ToList();
            return View(model);
        }

        public IActionResult SearchCode(string code)
        {
            var product = _productService.GetList().Where(x => x.AdvertCode == code).FirstOrDefault();
            int id = product.Id;
            if (product.ProductType== "satılık")
            {
                return RedirectToAction("ShopDetail", new { id = id });
            }
            else if (product.ProductType== "kiralık")
            {
                return RedirectToAction("HireDetail", new { id = id });
            }
            else
            {
                return RedirectToAction("Index", "Main");
            }
            
        }

        public IActionResult HireList(int id)
        {
            if (id != 0)
            {
                productCategoryModel filterModel = new productCategoryModel();
                filterModel.Categories = _categoryService.GetList();
                filterModel.Products = _productService.GetList().Where(x => x.CategoryId == id && x.ProductType == "kiralık").ToList();
                //var getCategory= _categoryService.GetByID(id);
                ViewBag.CategoryName = _categoryService.GetList().Where(x => x.Id == id).Select(x => x.CategoryName).FirstOrDefault();
                return View(filterModel);

            }
            else
            {
                productCategoryModel model = new productCategoryModel();
                model.Categories = _categoryService.GetList();

                model.Products = _productService.GetList()
                        .Where(x => x.ProductType == "kiralık")
                        .OrderByDescending(x => x.Id)
                        .ToList();


                return View(model);
            }            
        }

        public IActionResult HireDetail(int id)
        {
            productCategoryModel model = new productCategoryModel();
            model.Product = _productService.GetByID(id);
            model.Products = _productService.GetList().Where(x => x.CategoryId == model.Product.CategoryId && x.ProductType == model.Product.ProductType).Take(4).ToList();

            var dateHire = _productOperationsService.GetByID(id);
            ViewBag.DateHire = dateHire.DateStart.ToString("dd-MM-yyyy")+ " / "+ dateHire.DateEnd.ToString("dd-MM-yyyy");

            if (TempData.ContainsKey("AppLianceSuccess"))
            {
                ViewBag.AppLianceSuccess = true;
                TempData.Remove("AppLianceSuccess"); // TempData'yi temizle
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult HireDetail(int productId, DateTime startDate, DateTime endDate)
        {
            int? UserId = _httpContextAccessor.HttpContext.Session.GetInt32("UserId");
            var buyerUser = _userService.GetByID((int)UserId);

            var product = _productService.GetByID(productId);

            string privateKey = buyerUser.PrivateKey;
            var buyerAddress = buyerUser.WalletAdress;
            var sellers = new string[] { product.User.WalletAdress };
            var aplianceNames = new string[] { product.ProductName }; // Replace with product names
            var aplianceTypes = new string[] { product.Category.CategoryName }; // Replace with product types
            var buyerName = buyerUser.UserName;
            var buyerSurname = buyerUser.UserSurname;
            var sellerNames = new string[] { product.User.UserName }; // Replace with seller names
            var sellerSurnames = new string[] { product.User.UserSurname }; // Replace with seller surnames
            var endtime = new string[] { endDate.ToString("dd-MM-yyyy") };
            var starttime = new string[] { startDate.ToString("dd-MM-yyyy") };
            var price = new string[] { product.Price.ToString()};

            _contractService.AppLianceHire(privateKey, buyerAddress, sellers, aplianceNames, aplianceTypes,price, buyerName, buyerSurname, sellerNames, sellerSurnames, starttime, endtime);

            ProductOperations productopreration = new ProductOperations();
            productopreration.ProductId = product.Id;
            productopreration.OperationType = "kiralama";
            productopreration.Date = DateTime.Now;
            productopreration.Price = product.Price;
            productopreration.UserId = buyerUser.Id;
            productopreration.DateStart = startDate;
            productopreration.DateEnd = endDate;
            _productOperationsService.Add(productopreration);

            TempData["AppLianceSuccess"] = true;

            return RedirectToAction("HireDetail", new {id= productId });
        }

        public decimal total = 0;
        public IActionResult ShoppingCard(int id)
        {
            if (TempData.ContainsKey("PurchaseSuccess"))
            {
                ViewBag.PurchaseSuccess = true;
                TempData.Remove("PurchaseSuccess"); // TempData'yi temizle
            }

            if (id!=0)
            {
                var product = _productService.GetByID(id);
                productList.Add(product);
            }

            foreach (var item in productList)
            {
                total += item.Price;
            }
            ViewBag.Total = total;
            return View(productList);
        }

        public IActionResult RemoveFromCart(int Id)
        {
            var product = productList.FirstOrDefault(p=>p.Id== Id);
            productList.Remove(product);
            return RedirectToAction("ShoppingCard");
        }

        public IActionResult ProductBuy()
        {
            int? UserId = _httpContextAccessor.HttpContext.Session.GetInt32("UserId");
            var buyerUser = _userService.GetByID((int)UserId);


           

            string privateKey = buyerUser.PrivateKey;
            var buyerAddress = buyerUser.WalletAdress;
            var sellers = new string[] { };
            // Replace with seller addresses
            var productNames = new string[] {  }; // Replace with product names
            var productTypes = new string[] {  }; // Replace with product types
            var productPrices = new string[] { }; // Replace with product prices
            var productAmounts = new string[] { }; // Replace with product amounts
            var buyerName = buyerUser.UserName;
            var buyerSurname = buyerUser.UserSurname;
            var sellerNames = new string[] {  }; // Replace with seller names
            var sellerSurnames = new string[] { }; // Replace with seller surnames         

            List<string> productName = new List<string>();
            foreach (var item in productList)
            {
                productName.Add(item.ProductName);
            }
            productNames=productName.ToArray();

            List<string> productType = new List<string>();
            foreach (var item in productList)
            {
                productType.Add(item.ProductType);
                   
            }
            productTypes= productType.ToArray();

            List<string> price = new List<string>();
            foreach (var item in productList)
            {
                price.Add(item.Price.ToString());
                
            }
            productPrices=price.ToArray();

            List<string> amount = new List<string>();
            foreach (var item in productList)
            {
                amount.Add("1 Adet");  
            }
            productAmounts = amount.ToArray();

            List<string> userNameList = new List<string>();
            foreach (var item in productList)
            {
                var sellerusername = _userService.GetByID((int)item.UserId);
                userNameList.Add(sellerusername.UserName);
            }
            sellerNames = userNameList.ToArray();

            List<string> userSurnameList = new List<string>();
            foreach (var item in productList)
            {
                var sellerusersurname = _userService.GetByID((int)item.UserId);
                userSurnameList.Add(sellerusersurname.UserSurname);
            }
            sellerSurnames = userSurnameList.ToArray(); 

            List<string> userAdresList = new List<string>();
            foreach (var item in productList)
            {
                var selleradres = _userService.GetByID((int)item.UserId);
                userAdresList.Add(selleradres.WalletAdress);
            }
            sellers = userAdresList.ToArray();

            _contractService.PurchaseProducts(privateKey, buyerAddress, sellers, productNames, productTypes, productPrices, productAmounts, buyerName, buyerSurname, sellerNames, sellerSurnames);

            foreach (var item in productList)
            {
                ProductOperations productopreration = new ProductOperations();
                productopreration.ProductId = item.Id;
                productopreration.OperationType = "satış";
                productopreration.Date = DateTime.Now;
                productopreration.Price = item.Price;
                productopreration.UserId = buyerUser.Id;
                _productOperationsService.Add(productopreration);                
            }            

            productList.Clear();
            TempData["PurchaseSuccess"] = true;
            return RedirectToAction("ShoppingCard");
        }



        //satıcı paneli için olan controller

        public IActionResult SellerProductList()
        {
            int? sellerUserId = _httpContextAccessor.HttpContext.Session.GetInt32("SellerUserId");
            
            var productList = _productService.GetProductsByUserId((int)sellerUserId);
            return View(productList.Where(x=>x.ProductType=="satılık").ToList());
        }

        public IActionResult SellerProductHireList()
        {
            int? sellerUserId = _httpContextAccessor.HttpContext.Session.GetInt32("SellerUserId");

            var productList = _productService.GetProductsByUserId((int)sellerUserId);

            return View(productList.Where(x => x.ProductType == "kiralık").ToList());
        }


        [HttpGet]
        public IActionResult SellerAddProduct() 
        {
            productCategoryModel model = new productCategoryModel();

            model.Categories = _categoryService.GetList().Select(u => new Category
            {
                Id = u.Id,
                CategoryName = u.CategoryName,
            }).ToList();            

            return View(model);
        }

        [HttpPost]
        public IActionResult SellerAddProduct(Product item, IFormFile productImage)
        {
            item.UserId= _httpContextAccessor.HttpContext.Session.GetInt32("SellerUserId");

            Random random = new Random();
            item.AdvertCode = random.Next(10000000, 99999999).ToString();

            if (productImage != null && productImage.Length > 0)
            {
                // Resmi bir yere kaydet, örneğin wwwroot içine
                var imagePath = Path.Combine(_hostingEnvironment.WebRootPath, "ImageProduct", productImage.FileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    productImage.CopyTo(stream);
                }

                // Resmin yolunu veritabanına kaydet
                item.ProductImage = "/imageproduct/" + productImage.FileName;
            }

            _productService.Add(item);

            if (item.ProductType == "satılık")
            {
                return RedirectToAction("SellerProductList");
            }
            else
            {
                return RedirectToAction("SellerProductHireList");
            }            
        }

        [HttpGet]
        public IActionResult SellerUpdateProduct(int id) 
        {
            productCategoryModel model = new productCategoryModel();
            var product = _productService.GetByID(id);           

            ViewBag.Category = _categoryService.GetList().Select(u => new Category
            {
                Id = u.Id,
                CategoryName = u.CategoryName,
            }).ToList();


            

            return View(product);
        }

        [HttpPost]  
        public IActionResult SellerUpdateProduct(Product item)
        {
            _productService.Update(item);
            if (item.ProductType=="satılık")
            {
                return RedirectToAction("SellerProductList");
            }
            else
            {
                return RedirectToAction("SellerProductHireList");
            }
            
        }

        public IActionResult SellerDeleteProduct(int id)
        {
            var product = _productService.GetByID(id);

            _productService.Delete(id);            

            if (product.ProductType == "satılık")
            {
                return RedirectToAction("SellerProductList");
            }
            else
            {
                return RedirectToAction("SellerProductHireList");
            }
        }
    }
}
