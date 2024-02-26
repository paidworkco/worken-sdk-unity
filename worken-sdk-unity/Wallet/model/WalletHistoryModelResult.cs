namespace worken_sdk_unity.Wallet.model
{
    public class WalletHistoryModelResult
    {
        public string BlockNumber { get; set; }
        public string TimeStamp { get; set; }
        public string Hash { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Value { get; set; }
        public string ContractAddress { get; set; }
        public string Input { get; set; }
        public string Type { get; set; }
        public string Gas { get; set; }
        public string GasUsed { get; set; }
        public string TraceId { get; set; }
        public string IsError { get; set; }
        public string ErrorCode { get; set; }
    }
}
