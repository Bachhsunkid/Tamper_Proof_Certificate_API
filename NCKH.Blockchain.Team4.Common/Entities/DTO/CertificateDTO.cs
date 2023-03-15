using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCKH.Blockchain.Team4.Common.Entities.DTO
{
    public class CertificateDTO
    {
        public string IssuedID { get; set; }
        public string ReceivedID { get; set; }
        public string CertificateType { get; set; }
        public string CertificateName { get; set; }
        public string ReceivedAddressWallet { get; set; }
        public string ReceivedName { get; set; }
        public DateTime ReceivedDoB { get; set; }
        public string YearOfGraduation { get; set; }
        public string Classification { get; set; }
        public string ModeOfStudy { get; set; }
    }
}
