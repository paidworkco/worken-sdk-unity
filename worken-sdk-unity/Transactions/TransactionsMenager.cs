using Nethereum.Hex.HexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using worken_sdk_unity.Network;
using Account = Nethereum.Web3.Accounts.Account;
using Nethereum.Web3;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts.CQS;
using Nethereum.Util;
using Nethereum.Web3.Accounts;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Contracts;
using Nethereum.Contracts.Extensions;
using System.Numerics;
using worken_sdk_unity.Transactions.model;
using Nethereum.RPC.Eth.DTOs;

namespace worken_sdk_unity.Transactions
{
    public static class TransactionsManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="account"></param>
        /// <param name="To"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public async static Task<string> SendTransaction(this Account account, string To, HexBigInteger amount)
        {
            var Web3Client = NetworkManager.GetAccountWeb3Full(account);

            var transferHandler = Web3Client.Eth.GetContractTransactionHandler<TransferFunction>();

            var transfer = new TransferFunction()
            {
                To = To,
                TokenAmount = amount.Value
            };

            var receipt = await transferHandler.SendRequestAndWaitForReceiptAsync(WorkenSDKUnity.ContractAddress, transfer);

            Web3Client = null;
            return receipt.TransactionHash;
        }

        public async static Task ReceiveTransaction()
        {
            throw new NotImplementedException("ReceiveTransaction method is not implemented.");
        }

        public async static Task GetTransactionStatus()
        {
            
        }

        public async static Task GetRecentTransactions()
        {
            throw new NotImplementedException("GetRecentTransactions method is not implemented.");
        }

        public async static Task GetEstimatedGas()
        {
           
        }
    }
}
