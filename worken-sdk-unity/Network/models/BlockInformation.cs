using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace worken_sdk_unity.Network.models
{
    public class BlockInformation
    {
        public string status { get; set; }

        public string message { get; set; }

        public TransactionResult[] result { get; set; }
    }
}
