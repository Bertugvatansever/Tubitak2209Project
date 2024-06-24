<<<<<<< HEAD
﻿using Gat.BusinessLayer.Abstract;
using Gat.Core.Model;
=======
﻿using Gat.Core.Entity;
>>>>>>> 0697b16a2ae9fad810f7f4667bb0e632747aa704
using Gat.DataAccessLayer.Concrete.GatContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class MainController : Controller
    {
        private IProductService _productService;
        private IHttpContextAccessor _httpContextAccessor;
        private ICategoryService _categoryService;
        public MainController(IProductService productService, IHttpContextAccessor httpContextAccessor, ICategoryService categoryService)
        {
            this._productService = productService;
            this._httpContextAccessor = httpContextAccessor;
            this._categoryService = categoryService;
        }
        public IActionResult Index()
        {
            productCategoryModel model = new productCategoryModel();
            model.Categories= _categoryService.GetList();

            model.Products= _productService.GetList()
                    .Where(x=>x.ProductType=="satılık")
                    .OrderByDescending(x => x.Id)
                    .Take(8)
                    .ToList();

            model.ProductsHire = _productService.GetList()
                    .Where(x => x.ProductType == "kiralık")
                    .OrderByDescending(x => x.Id) 
                    .Take(8)
                    .ToList();

            return View(model);
        }
    }
}
