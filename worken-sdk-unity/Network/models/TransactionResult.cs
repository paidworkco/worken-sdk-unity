namespace worken_sdk_unity.Network.models
{
    public class TransactionResult
    {
        public string BlockNumber { get; set; }
        public string TimeStamp { get; set; }
        public string Hash { get; set; }
        public string Nonce { get; set; }
        public string BlockHash { get; set; }
        public string From { get; set; }
        public string ContractAddress { get; set; }
        public string To { get; set; }
        public string Value { get; set; }
        public string TokenName { get; set; }
        public string TokenSymbol { get; set; }
        public string TokenDecimal { get; set; }
        public string TransactionIndex { get; set; }
        public string Gas { get; set; }
        public string GasPrice { get; set; }
        public string GasUsed { get; set; }
        public string CumulativeGasUsed { get; set; }
        public string Input { get; set; }
        public string Confirmations { get; set; }
    }
}