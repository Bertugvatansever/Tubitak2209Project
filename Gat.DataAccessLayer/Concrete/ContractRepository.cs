using Gat.DataAccessLayer.Abstract;
using Nethereum.Hex.HexTypes;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gat.DataAccessLayer.Concrete
{
    public class ContractRepository : IContractRepository
    {
        public async Task AppLianceHire(string _privateKey, string _buyerAddress, string[] _sellersAddress, string[] _applianceNames, string[] _applianceTypes, string[] _productPrices, string _buyerName, string _buyerSurname, string[] _sellerNames, string[] _sellerSurnames, string[] _startTimes, string[] _endTimes)
        {
            string rpcUrl = "https://sepolia.infura.io/v3/3909d04f69e5454fb4ba76d8f3729dd7"; // Replace with your Infura URL
            string privateKey = _privateKey; // Replace with your Ethereum account's private key
            var gasPrice = 900000.ToHexBigInteger();
            var account = new Account(privateKey);
            var web3 = new Web3(account, rpcUrl);

            string contractAddress = "0x66C1B57307ab6cdE3aB87df5b980A29B3375F4A0"; // Replace with your contract's address
            var contractAbi = @"[
	{
		""inputs"": [],
		""stateMutability"": ""nonpayable"",
		""type"": ""constructor""
	},
	{
		""anonymous"": false,
		""inputs"": [
			{
				""indexed"": false,
				""internalType"": ""uint256"",
				""name"": ""hireID"",
				""type"": ""uint256""
			},
			{
				""indexed"": true,
				""internalType"": ""address"",
				""name"": ""buyer"",
				""type"": ""address""
			},
			{
				""indexed"": true,
				""internalType"": ""address"",
				""name"": ""seller"",
				""type"": ""address""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""applianceName"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""applianceType"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""appliancePrice"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""buyerName"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""buyerSurname"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""sellerName"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""sellerSurname"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""startTime"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""endTime"",
				""type"": ""string""
			}
		],
		""name"": ""newHire"",
		""type"": ""event""
	},
	{
		""anonymous"": false,
		""inputs"": [
			{
				""indexed"": false,
				""internalType"": ""uint256"",
				""name"": ""transactionId"",
				""type"": ""uint256""
			},
			{
				""indexed"": true,
				""internalType"": ""address"",
				""name"": ""buyer"",
				""type"": ""address""
			},
			{
				""indexed"": true,
				""internalType"": ""address"",
				""name"": ""seller"",
				""type"": ""address""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""productName"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""productType"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""productPrice"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""productAmount"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""buyerName"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""buyerSurname"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""sellerName"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""sellerSurname"",
				""type"": ""string""
			}
		],
		""name"": ""newTransaction"",
		""type"": ""event""
	},
	{
		""inputs"": [
			{
				""internalType"": ""address"",
				""name"": ""_buyer"",
				""type"": ""address""
			},
			{
				""internalType"": ""address[]"",
				""name"": ""_sellers"",
				""type"": ""address[]""
			},
			{
				""internalType"": ""string[]"",
				""name"": ""_applianceNames"",
				""type"": ""string[]""
			},
			{
				""internalType"": ""string[]"",
				""name"": ""_applianceTypes"",
				""type"": ""string[]""
			},
			{
				""internalType"": ""string[]"",
				""name"": ""_appliancePrices"",
				""type"": ""string[]""
			},
			{
				""internalType"": ""string"",
				""name"": ""_buyerName"",
				""type"": ""string""
			},
			{
				""internalType"": ""string"",
				""name"": ""_buyerSurname"",
				""type"": ""string""
			},
			{
				""internalType"": ""string[]"",
				""name"": ""_sellerNames"",
				""type"": ""string[]""
			},
			{
				""internalType"": ""string[]"",
				""name"": ""_sellerSurnames"",
				""type"": ""string[]""
			},
			{
				""internalType"": ""string[]"",
				""name"": ""_startTimes"",
				""type"": ""string[]""
			},
			{
				""internalType"": ""string[]"",
				""name"": ""_endTimes"",
				""type"": ""string[]""
			}
		],
		""name"": ""ApplianceHire"",
		""outputs"": [],
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""_transactionId"",
				""type"": ""uint256""
			}
		],
		""name"": ""GetTransaction"",
		""outputs"": [
			{
				""internalType"": ""address"",
				""name"": """",
				""type"": ""address""
			},
			{
				""internalType"": ""address"",
				""name"": """",
				""type"": ""address""
			},
			{
				""internalType"": ""string"",
				""name"": """",
				""type"": ""string""
			},
			{
				""internalType"": ""string"",
				""name"": """",
				""type"": ""string""
			},
			{
				""internalType"": ""string"",
				""name"": """",
				""type"": ""string""
			},
			{
				""internalType"": ""uint256"",
				""name"": """",
				""type"": ""uint256""
			},
			{
				""internalType"": ""string"",
				""name"": """",
				""type"": ""string""
			},
			{
				""internalType"": ""string"",
				""name"": """",
				""type"": ""string""
			},
			{
				""internalType"": ""string"",
				""name"": """",
				""type"": ""string""
			},
			{
				""internalType"": ""string"",
				""name"": """",
				""type"": ""string""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""address"",
				""name"": ""_buyer"",
				""type"": ""address""
			},
			{
				""internalType"": ""address[]"",
				""name"": ""_sellers"",
				""type"": ""address[]""
			},
			{
				""internalType"": ""string[]"",
				""name"": ""_productNames"",
				""type"": ""string[]""
			},
			{
				""internalType"": ""string[]"",
				""name"": ""_productTypes"",
				""type"": ""string[]""
			},
			{
				""internalType"": ""string[]"",
				""name"": ""_productPrices"",
				""type"": ""string[]""
			},
			{
				""internalType"": ""string[]"",
				""name"": ""_productAmounts"",
				""type"": ""string[]""
			},
			{
				""internalType"": ""string"",
				""name"": ""_buyerName"",
				""type"": ""string""
			},
			{
				""internalType"": ""string"",
				""name"": ""_buyerSurname"",
				""type"": ""string""
			},
			{
				""internalType"": ""string[]"",
				""name"": ""_sellerNames"",
				""type"": ""string[]""
			},
			{
				""internalType"": ""string[]"",
				""name"": ""_sellerSurnames"",
				""type"": ""string[]""
			}
		],
		""name"": ""PurchaseProducts"",
		""outputs"": [],
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""string"",
				""name"": ""dynamicText"",
				""type"": ""string""
			},
			{
				""internalType"": ""string"",
				""name"": ""staticText"",
				""type"": ""string""
			}
		],
		""name"": ""emitMessage"",
		""outputs"": [
			{
				""internalType"": ""string"",
				""name"": """",
				""type"": ""string""
			}
		],
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""inputs"": [],
		""name"": ""hireCount"",
		""outputs"": [
			{
				""internalType"": ""uint256"",
				""name"": """",
				""type"": ""uint256""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""uint256"",
				""name"": """",
				""type"": ""uint256""
			}
		],
		""name"": ""hires"",
		""outputs"": [
			{
				""internalType"": ""address"",
				""name"": ""buyer"",
				""type"": ""address""
			},
			{
				""internalType"": ""address"",
				""name"": ""seller"",
				""type"": ""address""
			},
			{
				""internalType"": ""string"",
				""name"": ""applianceName"",
				""type"": ""string""
			},
			{
				""internalType"": ""string"",
				""name"": ""applianceType"",
				""type"": ""string""
			},
			{
				""internalType"": ""string"",
				""name"": ""appliancePrice"",
				""type"": ""string""
			},
			{
				""internalType"": ""string"",
				""name"": ""buyerName"",
				""type"": ""string""
			},
			{
				""internalType"": ""string"",
				""name"": ""buyerSurname"",
				""type"": ""string""
			},
			{
				""internalType"": ""string"",
				""name"": ""sellerName"",
				""type"": ""string""
			},
			{
				""internalType"": ""string"",
				""name"": ""sellerSurname"",
				""type"": ""string""
			},
			{
				""internalType"": ""string"",
				""name"": ""startTime"",
				""type"": ""string""
			},
			{
				""internalType"": ""string"",
				""name"": ""endTime"",
				""type"": ""string""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [],
		""name"": ""landCount"",
		""outputs"": [
			{
				""internalType"": ""uint256"",
				""name"": """",
				""type"": ""uint256""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [],
		""name"": ""owner"",
		""outputs"": [
			{
				""internalType"": ""address"",
				""name"": """",
				""type"": ""address""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [],
		""name"": ""transactionCount"",
		""outputs"": [
			{
				""internalType"": ""uint256"",
				""name"": """",
				""type"": ""uint256""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""uint256"",
				""name"": """",
				""type"": ""uint256""
			}
		],
		""name"": ""transactions"",
		""outputs"": [
			{
				""internalType"": ""address"",
				""name"": ""buyer"",
				""type"": ""address""
			},
			{
				""internalType"": ""address"",
				""name"": ""seller"",
				""type"": ""address""
			},
			{
				""internalType"": ""string"",
				""name"": ""productName"",
				""type"": ""string""
			},
			{
				""internalType"": ""string"",
				""name"": ""productType"",
				""type"": ""string""
			},
			{
				""internalType"": ""string"",
				""name"": ""productPrice"",
				""type"": ""string""
			},
			{
				""internalType"": ""string"",
				""name"": ""productAmount"",
				""type"": ""string""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""timeStamp"",
				""type"": ""uint256""
			},
			{
				""internalType"": ""string"",
				""name"": ""buyerName"",
				""type"": ""string""
			},
			{
				""internalType"": ""string"",
				""name"": ""buyerSurname"",
				""type"": ""string""
			},
			{
				""internalType"": ""string"",
				""name"": ""sellerName"",
				""type"": ""string""
			},
			{
				""internalType"": ""string"",
				""name"": ""sellerSurname"",
				""type"": ""string""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	}
]";

            var contract = web3.Eth.GetContract(contractAbi, contractAddress);
            var purchaseFunction = contract.GetFunction("ApplianceHire");
            var buyerAddress = _buyerAddress;
            var sellers = _sellersAddress;
            // Replace with seller addresses
            var applianceNames = _applianceNames; // Replace with product names
            var applianceTypes = _applianceTypes; // Replace with product types
            var buyerName = _buyerName;
            var buyerSurname = _buyerSurname;
            var sellerNames = _sellerNames; // Replace with seller names
            var sellerSurnames = _sellerSurnames; // Replace with seller surnames
            var startTime = _startTimes;
            var endTime = _endTimes;
			var price = _productPrices;
            var transactionHash = await purchaseFunction.SendTransactionAsync(from: buyerAddress, gas: gasPrice, value: 0.ToHexBigInteger(), buyerAddress, sellers, applianceNames, applianceTypes, price, buyerName, buyerSurname, sellerNames, sellerSurnames, startTime, endTime);
            Console.WriteLine(transactionHash.ToString());
        }

        public async Task PurchaseProducts(string _privateKey, string _buyerAddress, string[] _sellersAddress, string[] _productNames, string[] _productTypes, string[] _productPrices, string[] _productAmounts, string _buyerName, string _buyerSurname, string[] _sellerNames, string[] _sellerSurnames)
        {
            string rpcUrl = "https://sepolia.infura.io/v3/3909d04f69e5454fb4ba76d8f3729dd7"; // Replace with your Infura URL
            string privateKey = _privateKey; 
            var gasPrice = 900000.ToHexBigInteger();
            var account = new Account(privateKey);
            var web3 = new Web3(account, rpcUrl);

            string contractAddress = "0x66C1B57307ab6cdE3aB87df5b980A29B3375F4A0"; 
            var contractAbi = @"[
	{
		""inputs"": [],
		""stateMutability"": ""nonpayable"",
		""type"": ""constructor""
	},
	{
		""anonymous"": false,
		""inputs"": [
			{
				""indexed"": false,
				""internalType"": ""uint256"",
				""name"": ""hireID"",
				""type"": ""uint256""
			},
			{
				""indexed"": true,
				""internalType"": ""address"",
				""name"": ""buyer"",
				""type"": ""address""
			},
			{
				""indexed"": true,
				""internalType"": ""address"",
				""name"": ""seller"",
				""type"": ""address""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""applianceName"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""applianceType"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""appliancePrice"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""buyerName"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""buyerSurname"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""sellerName"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""sellerSurname"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""startTime"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""endTime"",
				""type"": ""string""
			}
		],
		""name"": ""newHire"",
		""type"": ""event""
	},
	{
		""anonymous"": false,
		""inputs"": [
			{
				""indexed"": false,
				""internalType"": ""uint256"",
				""name"": ""transactionId"",
				""type"": ""uint256""
			},
			{
				""indexed"": true,
				""internalType"": ""address"",
				""name"": ""buyer"",
				""type"": ""address""
			},
			{
				""indexed"": true,
				""internalType"": ""address"",
				""name"": ""seller"",
				""type"": ""address""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""productName"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""productType"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""productPrice"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""productAmount"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""buyerName"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""buyerSurname"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""sellerName"",
				""type"": ""string""
			},
			{
				""indexed"": false,
				""internalType"": ""string"",
				""name"": ""sellerSurname"",
				""type"": ""string""
			}
		],
		""name"": ""newTransaction"",
		""type"": ""event""
	},
	{
		""inputs"": [
			{
				""internalType"": ""address"",
				""name"": ""_buyer"",
				""type"": ""address""
			},
			{
				""internalType"": ""address[]"",
				""name"": ""_sellers"",
				""type"": ""address[]""
			},
			{
				""internalType"": ""string[]"",
				""name"": ""_applianceNames"",
				""type"": ""string[]""
			},
			{
				""internalType"": ""string[]"",
				""name"": ""_applianceTypes"",
				""type"": ""string[]""
			},
			{
				""internalType"": ""string[]"",
				""name"": ""_appliancePrices"",
				""type"": ""string[]""
			},
			{
				""internalType"": ""string"",
				""name"": ""_buyerName"",
				""type"": ""string""
			},
			{
				""internalType"": ""string"",
				""name"": ""_buyerSurname"",
				""type"": ""string""
			},
			{
				""internalType"": ""string[]"",
				""name"": ""_sellerNames"",
				""type"": ""string[]""
			},
			{
				""internalType"": ""string[]"",
				""name"": ""_sellerSurnames"",
				""type"": ""string[]""
			},
			{
				""internalType"": ""string[]"",
				""name"": ""_startTimes"",
				""type"": ""string[]""
			},
			{
				""internalType"": ""string[]"",
				""name"": ""_endTimes"",
				""type"": ""string[]""
			}
		],
		""name"": ""ApplianceHire"",
		""outputs"": [],
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""uint256"",
				""name"": ""_transactionId"",
				""type"": ""uint256""
			}
		],
		""name"": ""GetTransaction"",
		""outputs"": [
			{
				""internalType"": ""address"",
				""name"": """",
				""type"": ""address""
			},
			{
				""internalType"": ""address"",
				""name"": """",
				""type"": ""address""
			},
			{
				""internalType"": ""string"",
				""name"": """",
				""type"": ""string""
			},
			{
				""internalType"": ""string"",
				""name"": """",
				""type"": ""string""
			},
			{
				""internalType"": ""string"",
				""name"": """",
				""type"": ""string""
			},
			{
				""internalType"": ""uint256"",
				""name"": """",
				""type"": ""uint256""
			},
			{
				""internalType"": ""string"",
				""name"": """",
				""type"": ""string""
			},
			{
				""internalType"": ""string"",
				""name"": """",
				""type"": ""string""
			},
			{
				""internalType"": ""string"",
				""name"": """",
				""type"": ""string""
			},
			{
				""internalType"": ""string"",
				""name"": """",
				""type"": ""string""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""address"",
				""name"": ""_buyer"",
				""type"": ""address""
			},
			{
				""internalType"": ""address[]"",
				""name"": ""_sellers"",
				""type"": ""address[]""
			},
			{
				""internalType"": ""string[]"",
				""name"": ""_productNames"",
				""type"": ""string[]""
			},
			{
				""internalType"": ""string[]"",
				""name"": ""_productTypes"",
				""type"": ""string[]""
			},
			{
				""internalType"": ""string[]"",
				""name"": ""_productPrices"",
				""type"": ""string[]""
			},
			{
				""internalType"": ""string[]"",
				""name"": ""_productAmounts"",
				""type"": ""string[]""
			},
			{
				""internalType"": ""string"",
				""name"": ""_buyerName"",
				""type"": ""string""
			},
			{
				""internalType"": ""string"",
				""name"": ""_buyerSurname"",
				""type"": ""string""
			},
			{
				""internalType"": ""string[]"",
				""name"": ""_sellerNames"",
				""type"": ""string[]""
			},
			{
				""internalType"": ""string[]"",
				""name"": ""_sellerSurnames"",
				""type"": ""string[]""
			}
		],
		""name"": ""PurchaseProducts"",
		""outputs"": [],
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""string"",
				""name"": ""dynamicText"",
				""type"": ""string""
			},
			{
				""internalType"": ""string"",
				""name"": ""staticText"",
				""type"": ""string""
			}
		],
		""name"": ""emitMessage"",
		""outputs"": [
			{
				""internalType"": ""string"",
				""name"": """",
				""type"": ""string""
			}
		],
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""inputs"": [],
		""name"": ""hireCount"",
		""outputs"": [
			{
				""internalType"": ""uint256"",
				""name"": """",
				""type"": ""uint256""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""uint256"",
				""name"": """",
				""type"": ""uint256""
			}
		],
		""name"": ""hires"",
		""outputs"": [
			{
				""internalType"": ""address"",
				""name"": ""buyer"",
				""type"": ""address""
			},
			{
				""internalType"": ""address"",
				""name"": ""seller"",
				""type"": ""address""
			},
			{
				""internalType"": ""string"",
				""name"": ""applianceName"",
				""type"": ""string""
			},
			{
				""internalType"": ""string"",
				""name"": ""applianceType"",
				""type"": ""string""
			},
			{
				""internalType"": ""string"",
				""name"": ""appliancePrice"",
				""type"": ""string""
			},
			{
				""internalType"": ""string"",
				""name"": ""buyerName"",
				""type"": ""string""
			},
			{
				""internalType"": ""string"",
				""name"": ""buyerSurname"",
				""type"": ""string""
			},
			{
				""internalType"": ""string"",
				""name"": ""sellerName"",
				""type"": ""string""
			},
			{
				""internalType"": ""string"",
				""name"": ""sellerSurname"",
				""type"": ""string""
			},
			{
				""internalType"": ""string"",
				""name"": ""startTime"",
				""type"": ""string""
			},
			{
				""internalType"": ""string"",
				""name"": ""endTime"",
				""type"": ""string""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [],
		""name"": ""landCount"",
		""outputs"": [
			{
				""internalType"": ""uint256"",
				""name"": """",
				""type"": ""uint256""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [],
		""name"": ""owner"",
		""outputs"": [
			{
				""internalType"": ""address"",
				""name"": """",
				""type"": ""address""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [],
		""name"": ""transactionCount"",
		""outputs"": [
			{
				""internalType"": ""uint256"",
				""name"": """",
				""type"": ""uint256""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""uint256"",
				""name"": """",
				""type"": ""uint256""
			}
		],
		""name"": ""transactions"",
		""outputs"": [
			{
				""internalType"": ""address"",
				""name"": ""buyer"",
				""type"": ""address""
			},
			{
				""internalType"": ""address"",
				""name"": ""seller"",
				""type"": ""address""
			},
			{
				""internalType"": ""string"",
				""name"": ""productName"",
				""type"": ""string""
			},
			{
				""internalType"": ""string"",
				""name"": ""productType"",
				""type"": ""string""
			},
			{
				""internalType"": ""string"",
				""name"": ""productPrice"",
				""type"": ""string""
			},
			{
				""internalType"": ""string"",
				""name"": ""productAmount"",
				""type"": ""string""
			},
			{
				""internalType"": ""uint256"",
				""name"": ""timeStamp"",
				""type"": ""uint256""
			},
			{
				""internalType"": ""string"",
				""name"": ""buyerName"",
				""type"": ""string""
			},
			{
				""internalType"": ""string"",
				""name"": ""buyerSurname"",
				""type"": ""string""
			},
			{
				""internalType"": ""string"",
				""name"": ""sellerName"",
				""type"": ""string""
			},
			{
				""internalType"": ""string"",
				""name"": ""sellerSurname"",
				""type"": ""string""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	}
]";

            var contract = web3.Eth.GetContract(contractAbi, contractAddress);

            // Example: Calling the PurchaseProducts function
            var purchaseFunction = contract.GetFunction("PurchaseProducts");
            
            var buyerAddress = _buyerAddress;
            var sellers = _sellersAddress;            
            var productNames = _productNames; 
            var productTypes = _productTypes; 
            var productPrices = _productPrices; 
            var productAmounts = _productAmounts; 
            var buyerName = _buyerName;
            var buyerSurname = _buyerSurname;
            var sellerNames = _sellerNames; 
            var sellerSurnames = _sellerSurnames; 

            var transactionHash = await purchaseFunction.SendTransactionAsync(from: buyerAddress, gas: gasPrice, value: 0.ToHexBigInteger(), buyerAddress, sellers, productNames, productTypes, productPrices, productAmounts, buyerName, buyerSurname, sellerNames, sellerSurnames);
             Console.WriteLine(transactionHash.ToString());
        }
    }
}
