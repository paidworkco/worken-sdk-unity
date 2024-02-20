using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.RPC.Reactive.Polling;
using worken_sdk_unity.Network;
using worken_sdk_unity.Transactions.model;
using Account = Nethereum.Web3.Accounts.Account;

namespace worken_sdk_unity.Transactions
{
    public static class TransactionsManager
    {
        /// <summary>
        /// za pomocą tej metody można wysłać transakcje z konta 'account' do kogo 'to' oraz określając wartość 'amount' 
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

        /// <summary>
        /// not implemented
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async static Task ReceiveTransaction()
        {
            throw new NotImplementedException("ReceiveTransaction method is not implemented.");
        }

        /// <summary>
        /// Zwraca status zamówienia wyszukując po 'TransactionHash'
        /// </summary>
        /// <param name="account"></param>
        /// <param name="TransactionHash"></param>
        /// <returns></returns>
        public async static Task<HexBigInteger> GetTransactionStatus(this Account account, string TransactionHash)
        {
            var Web3Client = NetworkManager.GetAccountWeb3Full(account);

            var receipt = await Web3Client.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(TransactionHash);

            return receipt.Status;
        }

        /// <summary>
        /// Zwraca wszystkie transakcje dla konkretnego numeru bloku
        /// </summary>
        /// <param name="account"></param>
        /// <param name="blockNumber"></param>
        /// <returns></returns>
        public async static Task<IObservable<Transaction>> GetRecentTransactions(this Account account, ulong blockNumber)
        {
            var Web3Client = NetworkManager.GetAccountWeb3Full(account);

            var transactions = Web3Client.Eth.GetTransactions(new BlockParameter(blockNumber), new BlockParameter(blockNumber));

            return transactions;
        }
    }
}
