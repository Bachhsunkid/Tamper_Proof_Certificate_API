using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCKH.Blockchain.Team4.Common.Entities.DTO
{
    public class UpdateAfterSentDTO
    {
        /// <summary>
        /// Danh sách bằng được gửi
        /// </summary>
        public List<Guid> certificateIDs { get; set; }

        /// <summary>
        /// Mã hash của giao dịch gửi
        /// </summary>
        public string hash { get; set; }

        /// <summary>
        /// PolicyID của người gửi
        /// </summary>
        public string policyID { get; set; }

    }
}
