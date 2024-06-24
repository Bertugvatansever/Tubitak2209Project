using Gat.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gat.BusinessLayer.Abstract
{
    public interface IEtherscanService
    {
        Task<List<EtherscanProductGet>> GetTransactionLogs(string apiKey, List<string> transactionHashes);

        Task<List<string>> ListTransactions(string apiKey, string walletaddress, string contractadress);

        Task<List<EtherscanProductGet>> GetContractLogs(string apiKey, string contractAddress);
        

    }
}
