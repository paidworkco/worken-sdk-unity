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
        /// Za pomocą tej metody można wysłać transakcję z konta 'account' do odbiorcy 'To' oraz określić wartość 'amount'. 
        /// </summary>
        /// <param name="account">Konto, z którego ma być wysłana transakcja.</param>
        /// <param name="To">Odbiorca transakcji.</param>
        /// <param name="amount">Wartość transakcji.</param>
        /// <returns>Hash transakcji.</returns>
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
        /// Metoda niezaimplementowana.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async static Task ReceiveTransaction()
        {
            throw new NotImplementedException("Metoda ReceiveTransaction nie została zaimplementowana.");
        }

        /// <summary>
        /// Zwraca status transakcji o podanym 'TransactionHash'.
        /// </summary>
        /// <param name="account">Konto, dla którego ma być sprawdzony status transakcji.</param>
        /// <param name="TransactionHash">Hash transakcji.</param>
        /// <returns>Status transakcji.</returns>
        public async static Task<HexBigInteger> GetTransactionStatus(this Account account, string TransactionHash)
        {
            var Web3Client = NetworkManager.GetAccountWeb3Full(account);

            var receipt = await Web3Client.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(TransactionHash);

            return receipt.Status;
        }

        /// <summary>
        /// Zwraca wszystkie transakcje dla określonego numeru bloku.
        /// </summary>
        /// <param name="account">Konto, dla którego mają być zwrócone transakcje.</param>
        /// <param name="blockNumber">Numer bloku.</param>
        /// <returns>Strumień transakcji.</returns>
        public async static Task<IObservable<Transaction>> GetRecentTransactions(this Account account, ulong blockNumber)
        {
            var Web3Client = NetworkManager.GetAccountWeb3Full(account);

            var transactions = Web3Client.Eth.GetTransactions(new BlockParameter(blockNumber), new BlockParameter(blockNumber));

            return transactions;
        }
    }

}
