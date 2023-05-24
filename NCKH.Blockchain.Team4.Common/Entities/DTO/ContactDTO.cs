using NCKH.Blockchain.Team4.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCKH.Blockchain.Team4.Common.Entities.DTO
{
    public class ContactDTO
    {
        public Guid ContactID { get; set; }

        public int ContactCode { get; set; }

        public string IssuedID { get; set; }

        public string ReceivedID { get; set; }

        public string ContactName { get; set; }

        public DateTime CreatedDate { get; set; }

        public ContactStatus ContactStatus { get; set; }
    }
}
