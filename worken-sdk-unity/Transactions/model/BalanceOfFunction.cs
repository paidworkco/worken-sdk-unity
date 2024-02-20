using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;

namespace worken_sdk_unity.Transactions.model
{
    [Function("balanceOf", "uint256")]
    public class BalanceOfFunction : FunctionMessage
    {
        [Parameter("address", "_owner", 1)]
        public string Owner { get; set; }
    }
}
