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

        private readonly CloudinaryService _cloudinaryService;

        public CertificatesController(CloudinaryService cloudinaryService)
        {
            _cloudinaryService = cloudinaryService;
        }

        /// <summary>
        /// Lấy danh sách bằng xuất ra
        /// </summary>
        /// <param name="IssuedID"></param>
        /// <returns></returns>
        [HttpPost("certificate-issued")]
        public IActionResult GetAllCertIsssued([FromBody] string IssuedID)
        {
            try
            {
                var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString);

                string storedProcedureName = DatabaseContext.CERTIFICATE_GETALL_ISSUED;

                var parameters = new DynamicParameters();
                parameters.Add("v_IssuerID", IssuedID);

                var certificateIssuedDTOs = mySqlConnection.Query<CertificateIssuedDTO>(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                if (certificateIssuedDTOs != null)
                {
                    return StatusCode(StatusCodes.Status200OK, certificateIssuedDTOs);
                }
                return StatusCode(StatusCodes.Status200OK, new List<CertificateIssuedDTO>());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Lấy danh sách bằng nhận được
        /// </summary>
        /// <param name="ReceivedID"></param>
        /// <returns></returns>
        [HttpPost("certificate-received")]
        public IActionResult GetAllCertsReceived([FromBody] string ReceivedID)
        {
            try
            {
                var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString);

                string storedProcedureName = DatabaseContext.CERTIFICATE_GETALL_RECEIVED;

                var parameters = new DynamicParameters();
                parameters.Add("v_ReceivedID", ReceivedID);

                var certificateIssuedDTOs = mySqlConnection.Query<CertificateReceivedDTO>(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                if (certificateIssuedDTOs != null)
                {
                    return StatusCode(StatusCodes.Status200OK, certificateIssuedDTOs);
                }
                return StatusCode(StatusCodes.Status200OK, new List<CertificateReceivedDTO>());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Thêm mới 1 lô bằng
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("issuer")]
        public async Task<IActionResult> UploadCertificates([FromForm] UploadCertsFromCSV file)
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
                var oganizationName = DataFromDB.GetOganizationNamebyPolicyID(file.UserID);
                await drawCertificate.Draw(certs, oganizationName);

                //Upload to IPFS
                await pinataClientAPI.UploadImagesToIPFS(drawCertificate.ImageFolderPath);

                return StatusCode(StatusCodes.Status201Created);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        /// <summary>
        /// Kí 1 bằng
        /// </summary>
        /// <param name="certificateID"></param>
        /// <returns></returns>
        [HttpPost("issued/sign/")]
        public IActionResult SignCertificate([FromBody] Guid certificateID)
        {
            try
            {
                //Khởi tạo kết nối với DB Mysql
                var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString);

                //Chuẩn bị câu lệnh sql 
                string storedProcedureName = DatabaseContext.CERTIFICATE_SIGN;

                //Chuẩn bị tham số đầu vào
                var parameters = new DynamicParameters();
                parameters.Add("v_CertificateID", certificateID);

                //Thực hiện gọi vào DB
                var employee = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                if (employee > 0)
                {
                    return StatusCode(StatusCodes.Status200OK, certificateID);
                }
                return StatusCode(StatusCodes.Status404NotFound);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Ki nhieu bang
        /// </summary>
        /// <param name="certificateIDs"></param>
        /// <returns></returns>
        [HttpPost("issued/sign-multiple/")]
        public IActionResult SignMutipleCertificate([FromBody] List<string> certificateIDs)
        {
            try
            {
                var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString);

                //Chuẩn bị câu lệnh sql 
                string storedProcedureName = DatabaseContext.CERTIFICATE_SIGN_MULTIPLE;

                //Xử lý string đầu vào proc về dạng "A,B,C"
                string inputProc = String.Join(",", certificateIDs);

                //Chuẩn bị tham số đầu vào
                var parameters = new DynamicParameters();
                parameters.Add("v_CertificateIDs", inputProc);

                //Thực hiện gọi vào DB
                var certEffected = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                if (certificateIDs.Count > 0)
                {
                    return StatusCode(StatusCodes.Status200OK, certificateIDs);
                }

                return StatusCode(StatusCodes.Status404NotFound);
            }
            //Try catch Exception
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Gửi 1 bằng
        /// </summary>
        /// <param name="certificateID"></param>
        /// <returns></returns>
        [HttpPost("issued/send/")]
        public IActionResult SendCertificate([FromBody] Guid certificateID)
        {
            try
            {
                //Khởi tạo kết nối với DB Mysql
                var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString);

                //Chuẩn bị câu lệnh sql 
                string storedProcedureName = DatabaseContext.CERTIFICATE_SEND;

                //Chuẩn bị tham số đầu vào
                var parameters = new DynamicParameters();
                parameters.Add("v_CertificateID", certificateID);

                //Thực hiện gọi vào DB
                var employee = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                if (employee > 0)
                {
                    return StatusCode(StatusCodes.Status200OK, certificateID);
                }
                return StatusCode(StatusCodes.Status404NotFound);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Gửi nhiều bằng
        /// </summary>
        /// <param name="certificateIDs"></param>
        /// <returns></returns>
        [HttpPost("issued/send-multiple/")]
        public IActionResult SendMultipleCertificate([FromBody] List<string> certificateIDs)
        {
            try
            {
                var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString);

                //Chuẩn bị câu lệnh sql 
                string storedProcedureName = DatabaseContext.CERTIFICATE_SEND_MULTIPLE;

                //Xử lý string đầu vào proc về dạng "A,B,C"
                string inputProc = String.Join(",", certificateIDs);

                //Chuẩn bị tham số đầu vào
                var parameters = new DynamicParameters();
                parameters.Add("v_CertificateIDs", inputProc);

                //Thực hiện gọi vào DB
                var certEffected = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                if (certificateIDs.Count > 0)
                {
                    return StatusCode(StatusCodes.Status200OK, certificateIDs);
                }

                return StatusCode(StatusCodes.Status404NotFound);
            }
            //Try catch Exception
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Xóa 1 bằng cấp
        /// </summary>
        /// <param name="certificateID"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult DeleteCertificate([FromBody] Guid certificateID)
        {
            try
            {
                //Khởi tạo kết nối với DB Mysql
                var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString);

                //Chuẩn bị câu lệnh sql 
                string storedProcedureName = DatabaseContext.CERTIFICATE_DELETE;

                //Chuẩn bị tham số đầu vào
                var parameters = new DynamicParameters();
                parameters.Add("v_CertificateID", certificateID);

                //Thực hiện gọi vào DB
                var cert = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                if (cert > 0)
                {
                    return StatusCode(StatusCodes.Status200OK, certificateID);
                }
                return StatusCode(StatusCodes.Status404NotFound);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Xóa nhiều bằng cấp theo danh sách ID bằng được chọn
        /// </summary>
        /// <param name="certificateIDs"></param>
        /// <returns></returns>
        [HttpDelete("issued/delete-multiple")]
        public IActionResult DeleteMultipleCertificates([FromBody] List<string> certificateIDs)
        {
            try
            {
                var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString);

                //Chuẩn bị câu lệnh sql 
                string storedProcedureName = DatabaseContext.CERTIFICATE_DELETE_MULTIPLE;

                //Xử lý string đầu vào proc về dạng "A,B,C"
                string inputProc = String.Join(",", certificateIDs);

                //Chuẩn bị tham số đầu vào
                var parameters = new DynamicParameters();
                parameters.Add("v_CertificateIDs", inputProc);

                //Thực hiện gọi vào DB
                var certEffected = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                if (certificateIDs.Count > 0)
                {
                    return StatusCode(StatusCodes.Status200OK, certificateIDs);
                }

                return StatusCode(StatusCodes.Status404NotFound);
            }
            //Try catch Exception
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Xóa 1 bằng cấp
        /// </summary>
        /// <param name="certificateID"></param>
        /// <returns></returns>
        [HttpPost("issued/ban")]
        public IActionResult BanCertificate([FromBody] Guid certificateID)
        {
            try
            {
                //Khởi tạo kết nối với DB Mysql
                var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString);

                //Chuẩn bị câu lệnh sql 
                string storedProcedureName = DatabaseContext.CERTIFICATE_BAN;

                //Chuẩn bị tham số đầu vào
                var parameters = new DynamicParameters();
                parameters.Add("v_CertificateID", certificateID);

                //Thực hiện gọi vào DB
                var cert = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                if (cert > 0)
                {
                    return StatusCode(StatusCodes.Status200OK, certificateID);
                }
                return StatusCode(StatusCodes.Status404NotFound);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Xóa nhiều bằng cấp theo danh sách ID bằng được chọn
        /// </summary>
        /// <param name="certificateIDs"></param>
        /// <returns></returns>
        [HttpPost("issued/ban-multiple")]
        public IActionResult BanMultipleCertificates([FromBody] List<string> certificateIDs)
        {
            try
            {
                var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString);

                //Chuẩn bị câu lệnh sql 
                string storedProcedureName = DatabaseContext.CERTIFICATE_BAN_MULTIPLE;

                //Xử lý string đầu vào proc về dạng "A,B,C"
                string inputProc = String.Join(",", certificateIDs);

                //Chuẩn bị tham số đầu vào
                var parameters = new DynamicParameters();
                parameters.Add("v_CertificateIDs", inputProc);

                //Thực hiện gọi vào DB
                var certEffected = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                if (certificateIDs.Count > 0)
                {
                    return StatusCode(StatusCodes.Status200OK, certificateIDs);
                }

                return StatusCode(StatusCodes.Status404NotFound);
            }
            //Try catch Exception
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("add-transaction-link")]
        public IActionResult AddTransactionLinkCertificates([FromBody] TransactionLink transactionLink)
        {
            try
            {
                int countCertEffected = 0;
                for (int i = 0; i < transactionLink.certificateIDs.Count; i++)
                {
                    var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString);

                    string storedProcedureName = DatabaseContext.CERTIFICATE_ADD_TRANSACTIONLINK;

                    var parameters = new DynamicParameters();
                    parameters.Add("v_CertificateID", transactionLink.certificateIDs[i]);
                    parameters.Add("v_TransactionLink", transactionLink.hashes[i]);

                    mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                    countCertEffected++;
                }
                if (countCertEffected == transactionLink.certificateIDs.Count && countCertEffected == transactionLink.hashes.Count)
                {
                    return StatusCode(StatusCodes.Status200OK, transactionLink.certificateIDs);
                }

                return StatusCode(StatusCodes.Status404NotFound);

            }
            catch(Exception e)
            {
                Console.Write(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
