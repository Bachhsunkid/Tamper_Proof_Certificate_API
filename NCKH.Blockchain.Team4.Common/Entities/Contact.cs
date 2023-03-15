using NCKH.Blockchain.Team4.Common.Enum;

namespace NCKH.Blockchain.Team4.Common.Entities
{
    public class Contact
    {
        public Guid ContactID { get; set; }

        public int ContactCode { get; set; }

        public string IssuedID { get; set; }

        public string ReceivedID { get; set; }

        public ContactStatus ContactStatus { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}