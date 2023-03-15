using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using NCKH.Blockchain.Team4.API.Library;
using NCKH.Blockchain.Team4.API.PinataAPI;
using NCKH.Blockchain.Team4.Common.Constant;
using NCKH.Blockchain.Team4.Common.Entities.DTO;
using System.Drawing;
using Image = System.Drawing.Image;

namespace NCKH.Blockchain.Team4.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CertificatesController : ControllerBase
    {
        private List<CertificateDTO> certs = new List<CertificateDTO>();

        [HttpPost("Issuer")]
        public IActionResult UploadCertificates([FromForm] UploadCertsFromCSV file)
        {
            try
            {
                ReadCSVandSaveToDB readCSVandSaveToDB = new ReadCSVandSaveToDB();
                DrawCertificate drawCertificate = new DrawCertificate();
                PinataClientAPI pinataClientAPI = new PinataClientAPI();

                //Read csv file
                certs = readCSVandSaveToDB.ReadCSV(file);
                //Insert data from csv file to DB
                readCSVandSaveToDB.InsertToDB(certs);

                //Draw certificate from csv file data
                var oganizationName = DataFromDB.GetOganizationNamebyPolicyID(file.PolicyID);
                drawCertificate.Draw(certs, oganizationName);

                //Upload to IPFS
                pinataClientAPI.UploadImagesToIPFS(drawCertificate.ImageFolderPath);


                return StatusCode(StatusCodes.Status201Created);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
    }
}
