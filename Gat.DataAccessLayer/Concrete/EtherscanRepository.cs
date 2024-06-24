using Gat.Core.Entity;
using Gat.Core.Model;
using Gat.DataAccessLayer.Abstract;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Gat.DataAccessLayer.Concrete
{
    public class EtherscanRepository : IEtherscanRepository
    {
        public async  Task<List<EtherscanProductGet>> GetTransactionLogs(string apiKey, List<string> transactionHashes)
        {
            List<string> logDetails = new List<string>();

            foreach (var transactionHash in transactionHashes)
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"https://api-sepolia.etherscan.io/api?module=proxy&action=eth_getTransactionReceipt&txhash={transactionHash}&apikey={apiKey}";

                    try
                    {
                        HttpResponseMessage response = await client.GetAsync(apiUrl);

                        if (response.IsSuccessStatusCode)
                        {
                            string jsonResult = await response.Content.ReadAsStringAsync();
                            var parsedResult = JToken.Parse(jsonResult);

                            var receipt = parsedResult["result"];

                            if (receipt != null)
                            {
                                var logs = receipt["logs"];

                                if (logs != null)
                                {
                                    foreach (var log in logs)
                                    {
                                        var data = log["data"].ToString();
                                        var cleanedData = CleanUnwantedCharacters(HexToAscii(data));
                                        logDetails.Add($"İşlem Bilgisi: {AddSpaceAfterEachWord(cleanedData)}");
                                    }
                                }
                                else
                                {
                                    logDetails.Add("Logs not found in receipt.");
                                }
                            }
                            else
                            {
                                logDetails.Add($"Receipt not found for transaction hash: {transactionHash}");
                            }
                        }
                        else
                        {
                            logDetails.Add($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                        }
                    }
                    catch (Exception ex)
                    {
                        logDetails.Add($"Error: {ex.Message}");
                    }
                }
            }

            List<EtherscanProductGet> productList = new List<EtherscanProductGet>();

            foreach (var item in logDetails)
            {
                EtherscanProductGet product = new EtherscanProductGet();
                product.productName = GetFieldValue(item, "Urun adi");
                product.productType = GetFieldValue(item, "Urun kategorisi");
                product.productPrice = GetFieldValue(item, "Urun fiyati");
                product.productAmount = GetFieldValue(item, "Urun miktari");
                product.buyerName = GetFieldValue(item, "Alici adi");
                product.buyersurName = GetFieldValue(item, "Alici soyadi");
                product.sellerName = GetFieldValue(item, "Satici adi");
                product.sellerSurname = GetFieldValue(item, "Satici soyadi");
                product.startTime = GetFieldValue(item, "Baslangic zamani");
                product.endTime = GetFieldValue(item, "Bitis zamani");
                productList.Add(product);
            }

            return productList;
        }

        public async Task<List<EtherscanProductGet>> GetContractLogs(string apiKey, string contractAddress)
        {
            List<string> logcontractDetails = new List<string>();
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = $"https://api-sepolia.etherscan.io/api?module=logs&action=getLogs&fromBlock=0&toBlock=latest&address={contractAddress}&apikey={apiKey}";

                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResult = await response.Content.ReadAsStringAsync();
                        var parsedResult = JToken.Parse(jsonResult);

                        var logs = parsedResult["result"];

                        if (logs != null && logs.HasValues)
                        {


                            foreach (var log in logs)
                            {
                                var data = log["data"].ToString();
                                var cleanedData = CleanUnwantedCharacters(HexToAscii(data));
                                logcontractDetails.Add($" {AddSpaceAfterEachWord(cleanedData)}");
                            }

                            
                        }
                        else
                        {                            
                            Console.Write("No logs found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine( $"Error: {response.StatusCode} - {response.ReasonPhrase}" );
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            List<EtherscanProductGet> productList2 = new List<EtherscanProductGet>();
            foreach (var item in logcontractDetails)
            {
                EtherscanProductGet product = new EtherscanProductGet();
                product.productName = GetFieldValue(item, "Urun adi");
                product.productType = GetFieldValue(item, "Urun kategorisi");
                product.productPrice = GetFieldValue(item, "Urun fiyati");
                product.productAmount = GetFieldValue(item, "Urun miktari");
                product.buyerName = GetFieldValue(item, "Alici adi");
                product.buyersurName = GetFieldValue(item, "Alici soyadi");
                product.sellerName = GetFieldValue(item, "Satici adi");
                product.sellerSurname = GetFieldValue(item, "Satici soyadi");
                product.startTime = GetFieldValue(item, "Baslangic zamani");
                product.endTime = GetFieldValue(item, "Bitis zamani");
                productList2.Add(product);
            }
            return productList2;
        }


        public async Task<List<string>> ListTransactions(string apiKey, string walletaddress, string contractadress)
        {
             List<string> hashList = new List<string>();

            using (HttpClient client = new HttpClient())
            {
                string apiUrl = $"https://api-sepolia.etherscan.io/api?module=account&action=txlist&address={walletaddress}&apikey={apiKey}";

                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResult = await response.Content.ReadAsStringAsync();
                        var parsedResult = JToken.Parse(jsonResult);

                        var transactions = parsedResult["result"];

                        if (transactions != null && transactions.HasValues)
                        {
                            foreach (var transaction in transactions)
                            {
                                var tempAddress = transaction["to"];

                                if (tempAddress != null && tempAddress.ToString() == contractadress.ToLower())
                                {
                                    var transactionHash = transaction["hash"];
                                    hashList.Add(transactionHash.ToString());                                    
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.Write($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                return hashList;
            }
        }


        //çekmek için kullanılan 

        static string GetFieldValue(string text, string fieldName)
        {
            // Alan değerlerini çıkarmak için düzenli ifade kullanma
            string pattern = $@"{fieldName}\s*:\s*([^:]+)";
            Match match = Regex.Match(text, pattern);

            // Eğer eşleşme bulunursa, değeri döndür; aksi halde boş bir dize döndür
            return match.Success ? match.Groups[1].Value.Trim() : string.Empty;
        }


        /// Veri Düzeltme fonksiyonları
        static void CleanAndPrintLogs(JToken logs)
        {
            foreach (var log in logs)
            {
                var data = log["data"].ToString();

                // Hex stringi ASCII karakterlere çevir, kontrolsüz karakterleri temizle ve ekrana yazdır
                var cleanedData = CleanUnwantedCharacters(HexToAscii(data));
                Console.WriteLine($"İşlem Bilgisi: {AddSpaceAfterEachWord(cleanedData)}");
            }
        }

        static string HexToAscii(string hex)
        {
            StringBuilder ascii = new StringBuilder();

            for (int i = 0; i < hex.Length; i += 2)
            {
                string hexByte = hex.Substring(i, 2);
                try
                {
                    // Hex'i ASCII karaktere çevir
                    byte asciiByte = Convert.ToByte(hexByte, 16);
                    char asciiChar = Convert.ToChar(asciiByte);
                    ascii.Append(asciiChar);
                }
                catch (Exception)
                {
                    // Geçersiz hex karakteri, boşluk ekleyerek devam et
                    ascii.Append(" ");
                }
            }

            return ascii.ToString();
        }

        static string CleanUnwantedCharacters(string input)
        {
            // ASCII dışındaki tüm karakterleri temizle
            var cleaned = new string(input.Where(c => c >= 32 && c < 127).ToArray());

            return cleaned.Trim(); // Başındaki ve sonundaki boşlukları kaldır
        }

        static string AddSpaceAfterEachWord(string input)
        {
            StringBuilder result = new StringBuilder();

            foreach (char c in input)
            {
                // Her büyük harfin önüne bir boşluk ekle
                if (char.IsUpper(c) && result.Length > 0)
                {
                    result.Append(' ');
                }

                result.Append(c);
            }

            return result.ToString();
        }

       
    }
}
