using NBitcoin;
using Nethereum.Hex.HexTypes;
using Nethereum.Web3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet = Nethereum.HdWallet.Wallet;

namespace worken_sdk_unity.WalletMenager
{
    public sealed class WalletManager
    {
        public async Task<Wallet> CreateWallet()
        {
            Mnemonic mnemo = new Mnemonic(Wordlist.English, WordCount.Twelve);

            var wallet = new Nethereum.HdWallet.Wallet(mnemo.WordList, WordCount.Twelve);
            
            return wallet;
        }

        public async Task GetWalletHistory()
        {
            throw new NotImplementedException("GetWalletHistory method is not implemented.");
        }
    }

    public static class WalletMenagerExtensions
    {
        /// <summary>
        /// zwraca Nonce
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public async static Task<HexBigInteger> GetNextAccountNonce(this Nethereum.Web3.Accounts.Account account)
        {
            return await account.NonceService.GetNextNonceAsync();
        }
    }
}
