using NCKH.Blockchain.Team4.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCKH.Blockchain.Team4.Common.Entities.DTO
{
    public class CertificateReceivedDTO
    {
        public Guid CertificateID { get; set; }

        public int CertificateCode { get; set; }

        public string CertificateType { get; set; }

        public string OrganizationName { get; set; }

        public int YearOfGraduation { get; set; }

        public string Classification { get; set; }

        public string ModeOfStudy { get; set; }

        public DateTime ReceivedDate { get; set; }
    }
}
