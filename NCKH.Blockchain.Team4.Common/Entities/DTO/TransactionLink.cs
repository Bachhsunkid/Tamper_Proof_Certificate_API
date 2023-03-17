using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCKH.Blockchain.Team4.Common.Entities.DTO
{
    public class TransactionLink
    {
        public List<string> certificateIDs { get; set; }
        public List<string> hashes { get; set; }

    }
}
