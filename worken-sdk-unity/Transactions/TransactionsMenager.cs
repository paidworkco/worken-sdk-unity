using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.RPC.Reactive.Polling;
using worken_sdk_unity.Network;
using worken_sdk_unity.Transactions.model;
using AccountNethereum = Nethereum.Web3.Accounts.Account;

namespace worken_sdk_unity.Transactions
{
    public static class TransactionsManager
    {
        /// <summary>
        /// Za pomocą tej metody można wysłać transakcję z konta 'account' do odbiorcy 'To' oraz określić wartość 'amount'. 
        /// This method allows sending a transaction from the 'account' to the recipient 'To' specifying the value 'amount'.
        /// </summary>
        /// <param name="account">Konto, z którego ma być wysłana transakcja.</param>
        /// <param name="To">Odbiorca transakcji.</param>
        /// <param name="amount">Wartość transakcji.</param>
        /// <returns>Hash transakcji.</returns>
        public async static Task<string> SendTransaction(this AccountNethereum account, string To, HexBigInteger amount)
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
        /// Method not implemented.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async static Task ReceiveTransaction()
        {
            throw new NotImplementedException("Metoda ReceiveTransaction nie została zaimplementowana.");
        }

        /// <summary>
        /// Zwraca status transakcji o podanym 'TransactionHash'.
        /// Returns the status of the transaction with the specified 'TransactionHash'.
        /// </summary>
        /// <param name="account">Konto, dla którego ma być sprawdzony status transakcji.</param>
        /// <param name="TransactionHash">Hash transakcji.</param>
        /// <returns>Status transakcji.</returns>
        public async static Task<HexBigInteger> GetTransactionStatus(this AccountNethereum account, string transactionHash)
        {
            var Web3Client = NetworkManager.GetAccountWeb3Full(account);

            var receipt = await Web3Client.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(transactionHash);

            return receipt.Status;
        }

        /// <summary>
        /// Zwraca wszystkie transakcje dla określonego numeru bloku.
        /// Returns all transactions for the specified block number.
        /// </summary>
        /// <param name="account">Konto, dla którego mają być zwrócone transakcje.</param>
        /// <param name="blockNumber">Numer bloku.</param>
        /// <returns>Strumień transakcji.</returns>
        public async static Task<IObservable<Transaction>> GetRecentTransactions(this AccountNethereum account, ulong blockNumber)
        {
            var Web3Client = NetworkManager.GetAccountWeb3Full(account);

            var transactions = Web3Client.Eth.GetTransactions(new BlockParameter(blockNumber), new BlockParameter(blockNumber));

            return transactions;
        }
    }


}
