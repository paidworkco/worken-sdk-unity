using System.Numerics;

using Web3 = Nethereum.Web3.Web3;

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

        public async Task<string> GetBalanceInWorkenHex(string address)
        {
            //możliwe do wyniesienia
            var contract = WorkenSDKUnity.Web3Client.Eth.GetContract(WorkenSDKUnity.Abi, WorkenSDKUnity.ContractAddress);
            var function = contract.GetFunction("balanceOf");

            BigInteger balance = await function.CallAsync<BigInteger>(address);

            return balance.ToString("x");
        }
    }
}
