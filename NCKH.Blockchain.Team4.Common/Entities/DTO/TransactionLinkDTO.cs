using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCKH.Blockchain.Team4.Common.Entities.DTO
{
    public class TransactionLinkDTO
    {
        public List<Guid> certificateIDs { get; set; }
        public string hash { get; set; }

    }
}
