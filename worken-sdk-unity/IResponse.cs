using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace worken_sdk_unity
{
    public interface IResponse
    {
        string status { get; set; }

        string message { get; set; }
    }
}
