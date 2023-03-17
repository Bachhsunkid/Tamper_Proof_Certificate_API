using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCKH.Blockchain.Team4.Common.Entities
{
    public class User
    {
        public Guid UserID { get; set; }

        public string UserName { get; set; }

        public string Logo { get; set; }

        public string AddressWallet { get; set; }

        public string PolicyID { get; set; }
    }
}
