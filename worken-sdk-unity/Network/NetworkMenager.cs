using Nethereum.Web3;
using Newtonsoft.Json;
using worken_sdk_unity.Network.models;

namespace worken_sdk_unity.Network
{
    public sealed class NetworkManager
    {
        /// <summary>
        /// Returns a Web3 object associated with the account.
        /// </summary>
        internal static Web3 GetAccountWeb3(Nethereum.Web3.Accounts.Account account) => new Web3(account);

        /// <summary>
        /// Returns a full Web3 object associated with the account.
        /// </summary>
        internal static Web3 GetAccountWeb3Full(Nethereum.Web3.Accounts.Account account) => new Web3(account, WorkenSDKUnity.Url);

        /// <summary>
        /// Returns the number of the latest block in the network.
        /// </summary>
        /// <returns></returns>
        public async Task<Nethereum.Hex.HexTypes.HexBigInteger> GetLatestBlock()
        {
            var BlockNumber = await WorkenSDKUnity.Web3Client.Eth.Blocks.GetBlockNumber.SendRequestAsync();

            return BlockNumber;
        }

        /// <summary>
        /// Returns the network hash rate.
        /// </summary>
        /// <returns></returns>
        public async Task<Nethereum.Hex.HexTypes.HexBigInteger> GetHashRate()
        {
            var HashRate = await WorkenSDKUnity.Web3Client.Eth.Mining.Hashrate.SendRequestAsync();

            return HashRate;
        }

        /// <summary>
        /// Returns the Gas price.
        /// </summary>
        /// <returns></returns>
        public async Task<Nethereum.Hex.HexTypes.HexBigInteger> GasPrice()
        {
            var GasPrice = await WorkenSDKUnity.Web3Client.Eth.GasPrice.SendRequestAsync();

            return GasPrice;
        }

        /// <summary>
        /// Method retrieves block information.
        /// </summary>
        /// <param name="blockNumber">Numer bloku.</param>
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
        /// Method retrieves block information.
        /// </summary>
        /// <param name="blockHex">Numer bloku w formacie szesnastkowym.</param>
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
