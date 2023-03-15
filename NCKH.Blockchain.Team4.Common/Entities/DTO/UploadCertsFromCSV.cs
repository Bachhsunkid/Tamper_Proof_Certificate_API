using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCKH.Blockchain.Team4.Common.Entities.DTO
{
    public class UploadCertsFromCSV
    {
        /// <summary>
        /// PolicyID cua nguoi gui
        /// </summary>
        public String PolicyID { get; set; }
        /// <summary>
        /// File csv chua cac thong tin ve bang cap cua sinh vien
        /// </summary>
        public IFormFile fileCSV { get; set; }
    }
}
