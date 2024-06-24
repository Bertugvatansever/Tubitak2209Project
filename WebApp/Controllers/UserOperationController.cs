using Gat.BusinessLayer.Abstract;
using Gat.Core.Entity;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace WebApp.Controllers
{
    public class UserOperationController : Controller
    {
        private IProductService _productService;
        private IUserService _userService;
        private IHttpContextAccessor _httpContextAccessor;
        private ICategoryService _categoryService;
        private IContractService _contractService;
        private IProductOperationsService _productOperationsService;
        private IOrderDetailService _orderDetailService;
        private IOrderService _orderService;
        public UserOperationController(IProductService productService, IHttpContextAccessor httpContextAccessor, ICategoryService categoryService, IUserService userService, IContractService contractService, IProductOperationsService productOperationsService, IOrderDetailService orderDetailService, IOrderService orderService)
        {
            this._productService = productService;
            this._httpContextAccessor = httpContextAccessor;
            this._categoryService = categoryService;
            this._userService = userService;
            this._contractService = contractService;
            this._productOperationsService = productOperationsService;
            this._orderDetailService = orderDetailService;
            this._orderService = orderService;
        }

        public IActionResult Index()
        {
            int? UserId = _httpContextAccessor.HttpContext.Session.GetInt32("UserId");
            var user = _userService.GetByID((int)UserId);

            if (TempData.ContainsKey("UserSuccess"))
            {
                ViewBag.UserSuccess = true;
                TempData.Remove("UserSuccess"); // TempData'yi temizle
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult Index(User p)
        {
            _userService.Update(p);

            TempData["UserSuccess"] = true;
            return RedirectToAction("Index");
        }

        public IActionResult UserProductOperation(int page = 1)
        {
            int? UserId = _httpContextAccessor.HttpContext.Session.GetInt32("UserId");
            var user = _userService.GetByID((int)UserId);

            var operation = _productOperationsService.GetList().Where(x => x.UserId == (int)UserId).ToList();


            return View(operation.ToPagedList(page, 10));
        }
    }
}
