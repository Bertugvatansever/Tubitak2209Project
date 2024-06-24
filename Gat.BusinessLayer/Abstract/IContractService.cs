using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gat.BusinessLayer.Abstract
{
    public interface IContractService
    {
         Task PurchaseProducts(string _privateKey, string _buyerAddress, string[] _sellersAddress, string[] _productNames, string[] _productTypes, string[] _productPrices, string[] _productAmounts, string _buyerName, string _buyerSurname, string[] _sellerNames, string[] _sellerSurnames);
        Task AppLianceHire(string _privateKey, string _buyerAddress, string[] _sellersAddress, string[] _applianceNames, string[] _applianceTypes, string[] _productPrices, string _buyerName, string _buyerSurname, string[] _sellerNames, string[] _sellerSurnames, string[] _startTimes, string[] _endTimes);
    }
}
