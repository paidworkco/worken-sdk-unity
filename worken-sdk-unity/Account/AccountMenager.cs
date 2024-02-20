using Nethereum.Web3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace worken_sdk_unity.Account
{
    public sealed class AccountMenager
    {

        public async Task<BigInteger> GetBalanceInEtherWei(string address)
        {
            var result = await WorkenSDKUnity.Web3Client.Eth.GetBalance.SendRequestAsync(address);

            return result.Value;
        }

        public async Task<decimal> GetBalanceInEther(string address)
        {
            var result = await WorkenSDKUnity.Web3Client.Eth.GetBalance.SendRequestAsync(address);

            return Web3.Convert.FromWei(result.Value);
        }

        public async Task<BigInteger> GetBalanceInWorkenWei(string address)
        {
            //możliwe do wyniesienia
            var contract = WorkenSDKUnity.Web3Client.Eth.GetContract(WorkenSDKUnity.Abi, WorkenSDKUnity.ContractAddress);
            var function = contract.GetFunction("balanceOf");

            BigInteger balance = await function.CallAsync<BigInteger>(address);

            return balance;
        }

        public async Task<decimal> GetBalanceInWorken(string address)
        {
            //możliwe do wyniesienia
            var contract = WorkenSDKUnity.Web3Client.Eth.GetContract(WorkenSDKUnity.Abi, WorkenSDKUnity.ContractAddress);
            var function = contract.GetFunction("balanceOf");

            BigInteger balance = await function.CallAsync<BigInteger>(address);

            return Web3.Convert.FromWei(balance);
        }
    }
}
