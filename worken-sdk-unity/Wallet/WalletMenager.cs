using NBitcoin;
using Nethereum.Hex.HexTypes;
using Newtonsoft.Json;
using worken_sdk_unity.Network;
using worken_sdk_unity.Wallet.model;
using WalletETH = Nethereum.HdWallet.Wallet;

namespace worken_sdk_unity.Wallet
{
    public sealed class WalletManager
    {
        /// <summary>
        /// Metoda jest odpowiedzialna za stworzenie obiektu Portfela potrzebnego do dalszych działań.
        /// This method is responsible for creating a Wallet object required for further operations.
        /// </summary>
        /// <returns>Zwracany jest obiekt portfela.</returns>
        public async Task<WalletETH> CreateWallet()
        {
            Mnemonic mnemo = new Mnemonic(Wordlist.English, WordCount.Twelve);

            var wallet = new WalletETH(mnemo.WordList, WordCount.Twelve);
            
            return wallet;
        }

        /// <summary>
        /// Metoda pozyskuje do 10000 rekordów historii danego portfela pod adresem 'address' używając klucza 'apiKey'
        /// Method retrieves up to 10000 records of wallet history under the address 'address' using the key 'apiKey'
        /// More details: https://docs.polygonscan.com/api-endpoints/accounts#get-a-list-of-internal-transactions-by-address
        /// </summary>
        /// <param name="address">Adres portfela</param>
        /// <param name="apiKey">Klucz uzytkownika</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="HttpRequestException"></exception>
        public async Task<WalletHistoryModel> GetWalletHistory(string address, string apiKey)
        {
            NetworkManager networkManager = new();

            if (string.IsNullOrWhiteSpace(address))
            {
                throw new ArgumentException("Address must be provided.");
            }
            
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentException("API key token must be provided.");
            }
#if DEBUG
            var uriBuilder = new UriBuilder(WorkenSDKUnity.TestPolygonScanBaseUrlApi);
#else
            var uriBuilder = new UriBuilder(WorkenSDKUnity.PolygonScanBaseUrlApi);
#endif
            //Ustawienie wszystkich querry parameters
            var queryParams = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);
            queryParams["module"] = "account";
            queryParams["action"] = "tokentx";
            queryParams["address"] = address;
            queryParams["startblock"] = "0";
            queryParams["endblock"] = (await networkManager.GetLatestBlock()).ToString();
            queryParams["page"] = "asc";
            queryParams["offset"] = "asc";
            queryParams["sort"] = "asc";
            queryParams["apikey"] = apiKey;

            uriBuilder.Query = queryParams.ToString();

            try
            {
                HttpResponseMessage response = await WorkenSDKUnity.httpClient.GetAsync(uriBuilder.Uri);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();

                    WalletHistoryModel info = JsonConvert.DeserializeObject<WalletHistoryModel>(responseData);
                    networkManager = null;
                    return info;
                }
                else
                {
                    string errorMessage = $"Failed to get data. Status code: {response.StatusCode}";
                    if (!string.IsNullOrWhiteSpace(response.ReasonPhrase))
                    {
                        errorMessage += $", Reason: {response.ReasonPhrase}";
                    }
                    networkManager = null;
                    throw new HttpRequestException(errorMessage);
                }
            }
            catch (HttpRequestException ex)
            {
                networkManager = null;
                throw new HttpRequestException("An error occurred while sending the HTTP request.", ex);
            }
        }
    }

    public static class WalletMenagerExtensions
    {
        /// <summary>
        /// zwraca Nonce
        /// Returns the nonce
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public async static Task<HexBigInteger> GetNextAccountNonce(this Nethereum.Web3.Accounts.Account account)
        {
            return await account.NonceService.GetNextNonceAsync();
        }
    }
}
