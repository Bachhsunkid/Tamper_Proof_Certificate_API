using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCKH.Blockchain.Team4.Common.Entities.DTO
{
    public class UserDTO
    {
        public string UserID { get; set; }

        public string UserName { get; set; }

        public IFormFile Logo { get; set; }
    }
}
