using Gat.BusinessLayer.Abstract;
using Gat.Core.Entity;
using Microsoft.AspNetCore.Mvc;


namespace WebApp.Controllers
{
    public class LoginController : Controller
    {
        private IUserService _userService;
		private IHttpContextAccessor _httpContextAccessor;


		public LoginController(IUserService userService, IHttpContextAccessor httpContextAccessor)
		{
			this._userService = userService;
            this._httpContextAccessor = httpContextAccessor;
		}


        //alici için giriş ve kayıt olma

        [HttpGet]
		public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
		public IActionResult Login(User p)
		{
            var userList = _userService.GetList();

           
            foreach (var item in userList)
            {
                if (item.Mail== p.Mail && item.Password== p.Password && item.UserType== "alici")
                {
					_httpContextAccessor.HttpContext.Session.SetInt32("UserId", item.Id);
					return RedirectToAction("Index", "Main");
                }               
            }
			return View();
		}

		[HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User p)
        {
            p.UserType = "alici";
            _userService.Add(p);
            return RedirectToAction("Login");
        }

        //satıcı paneli için giriş ve kayıt olma

        [HttpGet]
        public IActionResult SellerLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SellerLogin(User p)
        {
			var userList = _userService.GetList();            

			foreach (var item in userList)
			{
				if (item.Mail == p.Mail && item.Password == p.Password && item.UserType== "satici")
				{
                    _httpContextAccessor.HttpContext.Session.SetInt32("SellerUserId", item.Id);
					return RedirectToAction("SellerProductList", "Shop");
				}
			}
			return View();
			
        }


		[HttpGet]
		public IActionResult SellerRegister()
		{
			return View();
		}
		[HttpPost]
		public IActionResult SellerRegister(User p)
		{
			p.UserType = "satici";
			_userService.Add(p);
			return RedirectToAction("SellerLogin");
		}



	}
}
