using Gat.BusinessLayer.Abstract;
using Gat.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gat.BusinessLayer.Concrete
{
    public class ContractService : IContractService
    {
        private IContractRepository _contractRepository;

        public ContractService(IContractRepository contractRepository)
        {
            _contractRepository = contractRepository;
        }

        public async Task AppLianceHire(string _privateKey, string _buyerAddress, string[] _sellersAddress, string[] _applianceNames, string[] _applianceTypes, string[] _productPrices, string _buyerName, string _buyerSurname, string[] _sellerNames, string[] _sellerSurnames, string[] _startTimes, string[] _endTimes)
        {
            await _contractRepository.AppLianceHire( _privateKey, _buyerAddress,  _sellersAddress, _applianceNames, _applianceTypes, _productPrices,  _buyerName, _buyerSurname,  _sellerNames,  _sellerSurnames, _startTimes,  _endTimes);
        }

        public async Task PurchaseProducts(string _privateKey, string _buyerAddress, string[] _sellersAddress, string[] _productNames, string[] _productTypes, string[] _productPrices, string[] _productAmounts, string _buyerName, string _buyerSurname, string[] _sellerNames, string[] _sellerSurnames)
        {
           await _contractRepository.PurchaseProducts( _privateKey,  _buyerAddress,  _sellersAddress,  _productNames,  _productTypes,  _productPrices,  _productAmounts,  _buyerName,  _buyerSurname,  _sellerNames,  _sellerSurnames);
        }
    }
}
