using Gat.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IContractService _contractService;

        public HomeController(ILogger<HomeController> logger, IContractService contractService)
        {
            _logger = logger;
            _contractService = contractService;
        }

        public IActionResult Index()
        {
            //SATIN ALMA

            //string privateKey = "a323fb226863a92fb7be2ae5797c0f21836b3bbcb002b71195d0519a28b6a932";
            //var buyerAddress = "0xE5ed40436Fd514028403D5b310Ec0CFCa732502D";
            //var sellers = new string[] { "0x9A36D7C2AEA774268cb9A41e9c2D68BF258D54eF", "0x9A36D7C2AEA774268cb9A41e9c2D68BF258D54eF" };
            //// Replace with seller addresses
            //var productNames = new string[] { "Domates", "Salata" }; // Replace with product names
            //var productTypes = new string[] { "Sebze", "Sebze" }; // Replace with product types
            //var productPrices = new string[] { "500TL", "750TL" }; // Replace with product prices
            //var productAmounts = new string[] { "20KG", "30KG" }; // Replace with product amounts
            //var buyerName = "Bertug";
            //var buyerSurname = "Vatansever";
            //var sellerNames = new string[] { "Burak", "Umut" }; // Replace with seller names
            //var sellerSurnames = new string[] { "Guler", "Ulke" }; // Replace with seller surnames

            //var hash = _contractService.PurchaseProducts(privateKey,buyerAddress,sellers,productNames,productTypes,productPrices,productAmounts,buyerName,buyerSurname,sellerNames,sellerSurnames);
            //ViewBag.hashAdres = hash.ToString();

            //kiralama
            //string privateKey = "a323fb226863a92fb7be2ae5797c0f21836b3bbcb002b71195d0519a28b6a932";
            //var buyerAddress = "0xE5ed40436Fd514028403D5b310Ec0CFCa732502D";
            //var sellers = new string[] { "0x9A36D7C2AEA774268cb9A41e9c2D68BF258D54eF", "0x9A36D7C2AEA774268cb9A41e9c2D68BF258D54eF" };
            //var aplianceNames = new string[] { "Domates", "Salata" }; // Replace with product names
            //var aplianceTypes = new string[] { "Sebze", "Sebze" }; // Replace with product types
            //var buyerName = "Bertug";
            //var buyerSurname = "Vatansever";
            //var sellerNames = new string[] { "Burak", "Umut" }; // Replace with seller names
            //var sellerSurnames = new string[] { "Guler", "Ulke" }; // Replace with seller surnames
            //var endtime = new string[] { "27.03.2023", "27.03.2023" };
            //var starttime = new string[] { "27.03.2023", "27.03.2023" };

            //_contractService.AppLianceHire(privateKey, buyerAddress, sellers, aplianceNames, aplianceTypes, buyerName, buyerSurname, sellerNames, sellerSurnames, starttime, endtime);


            return View();

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Update()
        {
            return View();
        }
    }
}