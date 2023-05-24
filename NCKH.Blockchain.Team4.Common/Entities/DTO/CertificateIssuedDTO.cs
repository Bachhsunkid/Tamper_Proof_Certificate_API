using NCKH.Blockchain.Team4.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCKH.Blockchain.Team4.Common.Entities.DTO
{
    public class CertificateIssuedDTO
    {
        public Guid CertificateID { get; set; }

        public string ImageLink { get; set; }

        public string TransactionLink { get; set; }

        public string OrganizationName { get; set; }

        public string ReceivedIdentityNumber { get; set; }

        public DateTime ReceivedDoB { get; set; }

        public int YearOfGraduation { get; set; }

        public string Classification { get; set; }

        public string ModeOfStudy { get; set; }

        public string IpfsLink { get; set; }

        public DateTime SentDate { get; set; }

        public string ReceivedAddressWallet { get; set; }

        public int CertificateCode { get; set; }

        public string CertificateType { get; set; }

        public string CertificateName { get; set; }

        public string ReceivedName { get; set; }

        public DateTime SignedDate { get; set; }

        public ContactStatus ContactStatus { get; set; }

        public CertificateStatus CertificateStatus { get; set; }

    }
}
