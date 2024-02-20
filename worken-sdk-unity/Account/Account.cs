using Nethereum.Web3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace worken_sdk_unity.Account
{
    public sealed class Account
    {

        public async Task<BigInteger> GetBalanceWei(string address)
        {
            //możliwe do wyniesienia
            var contract = WorkenSDKUnity.Web3Client.Eth.GetContract(WorkenSDKUnity.Abi, WorkenSDKUnity.ContractAddress);
            var function = contract.GetFunction("balanceOf");

            BigInteger balance = await function.CallAsync<BigInteger>(address);

            return balance;
        }

        public async Task<decimal> GetBalance(string address)
        {
            //możliwe do wyniesienia
            var contract = WorkenSDKUnity.Web3Client.Eth.GetContract(WorkenSDKUnity.Abi, WorkenSDKUnity.ContractAddress);
            var function = contract.GetFunction("balanceOf");

            BigInteger balance = await function.CallAsync<BigInteger>(address);

            return Web3.Convert.FromWei(balance);
        }
    }
}
