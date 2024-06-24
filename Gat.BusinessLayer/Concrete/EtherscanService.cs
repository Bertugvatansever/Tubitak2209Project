using Gat.BusinessLayer.Abstract;
using Gat.Core.Model;
using Gat.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gat.BusinessLayer.Concrete
{
    public class EtherscanService : IEtherscanService
    {
        private IEtherscanRepository _etherscanRepository;

        public EtherscanService(IEtherscanRepository etherscanRepository)
        {
            _etherscanRepository = etherscanRepository;
        }

        public async Task<List<EtherscanProductGet>> GetContractLogs(string apiKey, string contractAddress)
        {
            return await _etherscanRepository.GetContractLogs(apiKey, contractAddress); 
        }

        public async Task<List<EtherscanProductGet>> GetTransactionLogs(string apiKey, List<string> transactionHashes)
        {
          return await _etherscanRepository.GetTransactionLogs(apiKey, transactionHashes); 
        }

        public async Task<List<string>> ListTransactions(string apiKey, string walletaddress, string contractadress)
        {
            return await _etherscanRepository.ListTransactions(apiKey, walletaddress, contractadress);
        }
    }
}
