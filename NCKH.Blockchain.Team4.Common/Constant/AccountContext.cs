using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCKH.Blockchain.Team4.Common.Constant
{
    public class AccountContext
    {
        //Current policyID of Account
        public readonly string PolicyID = ""; 
        
        public AccountContext(string policyID)
        {
            PolicyID = policyID;
        }


        //Test policyID
        public const string IssuerPolicyID = "146d28b014f87920fa81c3b91007606d03ce0376c365befb5a3df1f7";

        public const string ReceivedPolicyID = "d9312da562da182b02322fd8acb536f37eb9d29fba7c49dc17255527";

    }
}
