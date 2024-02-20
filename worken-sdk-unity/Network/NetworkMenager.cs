using Nethereum.Web3;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using worken_sdk_unity.Network.models;

namespace worken_sdk_unity.Network
{
    public sealed class NetworkManager
    {
        internal static Web3 GetAccountWeb3(Nethereum.Web3.Accounts.Account account) => new Web3(account);
        internal static Web3 GetAccountWeb3Full(Nethereum.Web3.Accounts.Account account) => new Web3(account, WorkenSDKUnity.Url);

        public async Task GetNetworkStatus()
        {
            throw new NotImplementedException("GetNetworkStatus method is not implemented.");
        }

        public async Task GetMonitorNetworkCongestion()
        {
            throw new NotImplementedException("GetMonitorNetworkCongestion method is not implemented.");
        }

        /// <summary>
        /// https://docs.polygonscan.com/api-endpoints/accounts#get-a-list-of-erc-20-token-transfer-events-by-address
        /// metode musze jeszcze przetestować bo narazie zwraca status 0 czyli brak znalezionych transakcji 
        /// </summary>
        /// <param name="blockNumber">podawana wartość bloku jest jako liczba</param>
        /// <param name="apiKeyToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="HttpRequestException"></exception>
        public async Task<BlockInformation> getBlockInformation(int blockNumber, string apiKeyToken)
        {
            if (blockNumber <= 0)
            {
                throw new ArgumentException("Block number must be a positive integer.");
            }

            if (string.IsNullOrWhiteSpace(apiKeyToken))
            {
                throw new ArgumentException("API key token must be provided.");
            }
#if DEBUG
            var uriBuilder = new UriBuilder(WorkenSDKUnity.TestPolygonScanBaseUrlApi);
#else
            var uriBuilder = new UriBuilder(WorkenSDKUnity.PolygonScanBaseUrlApi);
#endif
            var queryParams = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);
            queryParams["module"] = "account";
            queryParams["action"] = "tokentx";
            queryParams["contractaddress"] = WorkenSDKUnity.ContractAddress;
            queryParams["startblock"] = blockNumber.ToString();
            queryParams["endblock"] = blockNumber.ToString();
            queryParams["sort"] = "asc";
            queryParams["apikey"] = apiKeyToken;
            
            uriBuilder.Query = queryParams.ToString();

            try
            {
                HttpResponseMessage response = await WorkenSDKUnity.httpClient.GetAsync(uriBuilder.Uri);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    
                    BlockInformation info = JsonConvert.DeserializeObject<BlockInformation>(responseData);
                    return info;
                }
                else
                {
                    string errorMessage = $"Failed to get data. Status code: {response.StatusCode}";
                    if (!string.IsNullOrWhiteSpace(response.ReasonPhrase))
                    {
                        errorMessage += $", Reason: {response.ReasonPhrase}";
                    }
                    throw new HttpRequestException(errorMessage);
                }
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException("An error occurred while sending the HTTP request.", ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="blockHex">Podawana wartość bloku musi być jako hex</param>
        /// <param name="apiKeyToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="HttpRequestException"></exception>
        public async Task<BlockInformation> getBlockInformation(string blockHex, string apiKeyToken)
        {
            if (blockHex == string.Empty)
            {
                throw new ArgumentException("Block number must be filled");
            }

            if (string.IsNullOrWhiteSpace(apiKeyToken))
            {
                throw new ArgumentException("API key token must be provided.");
            }
#if DEBUG
            var uriBuilder = new UriBuilder(WorkenSDKUnity.TestPolygonScanBaseUrlApi);
#else
            var uriBuilder = new UriBuilder(WorkenSDKUnity.PolygonScanBaseUrlApi);
#endif
            var queryParams = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);
            queryParams["module"] = "account";
            queryParams["action"] = "tokentx";
            queryParams["contractaddress"] = WorkenSDKUnity.ContractAddress;
            queryParams["startblock"] = blockHex;
            queryParams["endblock"] = blockHex;
            queryParams["sort"] = "asc";
            queryParams["apikey"] = apiKeyToken;

            uriBuilder.Query = queryParams.ToString();

            try
            {
                HttpResponseMessage response = await WorkenSDKUnity.httpClient.GetAsync(uriBuilder.Uri);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();

                    BlockInformation info = JsonConvert.DeserializeObject<BlockInformation>(responseData);
                    return info;
                }
                else
                {
                    string errorMessage = $"Failed to get data. Status code: {response.StatusCode}";
                    if (!string.IsNullOrWhiteSpace(response.ReasonPhrase))
                    {
                        errorMessage += $", Reason: {response.ReasonPhrase}";
                    }
                    throw new HttpRequestException(errorMessage);
                }
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException("An error occurred while sending the HTTP request.", ex);
            }
        }
    }
}
