using System.Numerics;

using Web3 = Nethereum.Web3.Web3;

namespace worken_sdk_unity.AccountMenager
{
    public sealed class AccountManager
    {
        /// <summary>
        /// Zwraca balans który jest jako ether w postaci WEI
        /// Returns the balance in ether in WEI format
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public async Task<BigInteger> GetBalanceInEtherWei(string address)
        {
            var result = await WorkenSDKUnity.Web3Client.Eth.GetBalance.SendRequestAsync(address);

            return result.Value;
        }

        /// <summary>
        /// Zwraca balans który jest jako ether
        /// Returns the balance in ether
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public async Task<decimal> GetBalanceInEther(string address)
        {
            var result = await WorkenSDKUnity.Web3Client.Eth.GetBalance.SendRequestAsync(address);

            return Web3.Convert.FromWei(result.Value);
        }

        /// <summary>
        /// Zwraca balans w Workenach jako WEI
        /// Returns the balance in Worken in WEI format
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public async Task<BigInteger> GetBalanceInWorkenWei(string address)
        {
            //możliwe do wyniesienia
            var contract = WorkenSDKUnity.Web3Client.Eth.GetContract(WorkenSDKUnity.Abi, WorkenSDKUnity.ContractAddress);
            var function = contract.GetFunction("balanceOf");

            BigInteger balance = await function.CallAsync<BigInteger>(address);

            return balance;
        }

        /// <summary>
        /// Zwraca balans jako Workeny
        /// Returns the balance in Worken
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public async Task<decimal> GetBalanceInWorken(string address)
        {
            //możliwe do wyniesienia
            var contract = WorkenSDKUnity.Web3Client.Eth.GetContract(WorkenSDKUnity.Abi, WorkenSDKUnity.ContractAddress);
            var function = contract.GetFunction("balanceOf");

            BigInteger balance = await function.CallAsync<BigInteger>(address);
            return Web3.Convert.FromWei(balance);
        }

        /// <summary>
        /// Zwraca balans w Workenach lecz w postaci hexa
        /// Returns the balance in Worken in hexadecimal format
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public async Task<string> GetBalanceInWorkenHex(string address)
        {
            //możliwe do wyniesienia
            var contract = WorkenSDKUnity.Web3Client.Eth.GetContract(WorkenSDKUnity.Abi, WorkenSDKUnity.ContractAddress);
            var function = contract.GetFunction("balanceOf");

            BigInteger balance = await function.CallAsync<BigInteger>(address);

            return new Nethereum.Hex.HexTypes.HexBigInteger(balance).HexValue;
        }

        /// <summary>
        /// Tworzy obiekt konta na podstawie klucza prywatnego
        /// Creates an account object based on a private key
        /// </summary>
        /// <param name="privateKey"></param>
        /// <returns></returns>
        public Nethereum.Web3.Accounts.Account CreateAccount(string privateKey)
        {
            return new Nethereum.Web3.Accounts.Account(privateKey);
        }
    }
}
