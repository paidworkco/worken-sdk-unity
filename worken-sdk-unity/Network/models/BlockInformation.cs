namespace worken_sdk_unity.Network.models
{
    public class BlockInformation : IResponse
    {
        public string status { get; set; }

        public string message { get; set; }

        public TransactionResult[] result { get; set; }
    }
}
