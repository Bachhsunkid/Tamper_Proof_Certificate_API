using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCKH.Blockchain.Team4.Common.Entities
{
    public class User
    {
        public string PolicyID { get; set; }

        public int UserCode { get; set; }

        public string UserName { get; set; }

        public string Logo { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
