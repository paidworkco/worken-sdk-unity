using Nethereum.RPC.Web3;
using Nethereum.Web3;
using System;

namespace worken_sdk_unity
{
    internal static class WorkenSDKUnity
    {
        /// <summary>
        /// ABI
        /// </summary>
        public readonly static string Abi = @"[
            {
              ""constant"": true,
              ""inputs"": [{""name"": ""_owner"", ""type"": ""address""}],
              ""name"": ""balanceOf"",
              ""outputs"": [{""name"": ""balance"", ""type"": ""uint256""}],
              ""type"": ""function""
            },
            {
              ""inputs"": [
                {
                  ""internalType"": ""address"",
                  ""name"": ""recipient"",
                  ""type"": ""address""
                },
                {
                  ""internalType"": ""uint256"",
                  ""name"": ""amount"",
                  ""type"": ""uint256""
                }
              ],
              ""name"": ""transfer"",
              ""outputs"": [
                {
                  ""internalType"": ""bool"",
                  ""name"": """",
                  ""type"": ""bool""
                }
              ],
              ""stateMutability"": ""nonpayable"",
              ""type"": ""function""
            }
          ]";

        /// <summary>
        /// Worken contract address
        /// </summary>
        public readonly static string ContractAddress = "0x3AE0726b5155fCa70dd79C0839B07508Ce7F0F13";

        #region URL
        public readonly static string Url = "https://rpc-mumbai.maticvigil.com/";

        public readonly static string PolygonScanBaseUrlApi = "https://api.polygonscan.com/api";
        public readonly static string TestPolygonScanBaseUrlApi = "https://api-testnet.polygonscan.com/api";
        #endregion

        #region Objects

        public static readonly Web3 Web3Client = new(Url);

        public static readonly HttpClient httpClient = new(); 
        #endregion
    }
}