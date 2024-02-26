namespace worken_sdk_unity.Wallet.model
{
    public class WalletHistoryModel : IResponse
    {
        public string status { get; set ; }
        public string message { get; set; }

        public WalletHistoryModelResult[] result { get; set; }
    }
}
