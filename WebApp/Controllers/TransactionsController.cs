using Gat.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Text;

namespace WebApp.Controllers
{
    public class TransactionsController : Controller
    {
        private IProductService _productService;
        private IHttpContextAccessor _httpContextAccessor;
        private ICategoryService _categoryService;
        private IUserService _userService;
        private IEtherscanService _etherscanService;
        public TransactionsController(IProductService productService, IHttpContextAccessor httpContextAccessor, ICategoryService categoryService, IUserService userService, IEtherscanService etherscanService)
        {
            this._productService = productService;
            this._httpContextAccessor = httpContextAccessor;
            this._categoryService = categoryService;
            this._userService = userService;    
            this._etherscanService = etherscanService;
        }

        //private static List<string> hashList = new List<string>();
        private static string contractAddress = "0x66C1B57307ab6cdE3aB87df5b980A29B3375F4A0";

        public async Task<IActionResult> Index()
        {
            int? sellerUserId = _httpContextAccessor.HttpContext.Session.GetInt32("UserId");

            var user = _userService.GetByID((int)sellerUserId);
            string walletAdress = user.WalletAdress; 

            string apiKey = "UCDWJK542CSXBRGZF8SXSDS5RD4EYG6KCM";
            // cüzdan adresi veritabanından çekilecek buraya.
            string address = walletAdress.ToString();

            //await ListTransactions(apiKey, address);

            var hashList = await _etherscanService.ListTransactions(apiKey, walletAdress, contractAddress);

            var model = await _etherscanService.GetTransactionLogs(apiKey, hashList);

            return View(model);
        }

        public async Task<IActionResult> ContractLogs()
        { 
                      
           string apiKey = "UCDWJK542CSXBRGZF8SXSDS5RD4EYG6KCM";            

            var model = await _etherscanService.GetContractLogs(apiKey, contractAddress);

            return View(model);
        }




    }
}
