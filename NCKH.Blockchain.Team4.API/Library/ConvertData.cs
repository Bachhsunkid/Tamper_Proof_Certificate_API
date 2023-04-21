using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCKH.Blockchain.Team4.Common.Library
{
    public class ConvertData
    {
        /// <summary>
        /// Cắt lấy phần code ở trong file name. VD: `Degree_100001.png` -> 100001
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>cert code</returns>
        public static int FileNameToCertificateCode(string fileName)
        {
            string[] parts = fileName.Split('_');
            int number = int.Parse(parts[1].Replace(".png", ""));
            return number;
        }

        /// <summary>
        /// Chuyển từ chữ sang dạng hexa
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string TextToHex(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            string hex = BitConverter.ToString(bytes);
            hex = hex.Replace("-", "");
            return hex;
        }
    }
}
