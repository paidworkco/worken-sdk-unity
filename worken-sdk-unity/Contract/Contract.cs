using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace worken_sdk_unity.Contract
{
    public class ContractManager
    {
        /// <summary>
        /// Returnes true if contract is active
        /// </summary>
        /// <returns></returns>
        public async Task<bool> GetContractStatus()
        {
            var response = await WorkenSDKUnity.Web3Client.Eth.GetCode.SendRequestAsync(WorkenSDKUnity.ContractAddress.Replace("3AE0","3333"));

            return response == "0x" ? false : true;
        }
    }
}
