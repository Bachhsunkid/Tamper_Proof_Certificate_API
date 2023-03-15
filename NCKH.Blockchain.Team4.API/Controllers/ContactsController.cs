using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using NCKH.Blockchain.Team4.Common.Constant;
using NCKH.Blockchain.Team4.Common.Entities.DTO;

namespace NCKH.Blockchain.Team4.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        /// <summary>
        /// Lấy danh sách kết nối theo policyID
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetAllContact([FromBody] string UserID)
        {
            try
            {
                var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString);

                string storedProcedureName = DatabaseContext.CONTACT_GETALL;

                var parameters = new DynamicParameters();
                parameters.Add("v_UserID", UserID);

                var certificateIssuedDTOs = mySqlConnection.Query<ContactDTO>(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

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
        /// Chấp nhận kết nối với 1 contact khác
        /// </summary>
        /// <param name="contactID"></param>
        /// <returns></returns>
        [HttpPost("accept")]
        public IActionResult AcceptContact([FromBody] Guid contactID)
        {
            try
            {
                //Khởi tạo kết nối với DB Mysql
                var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString);

                //Chuẩn bị câu lệnh sql 
                string storedProcedureName = DatabaseContext.CONTACT_ACCEPT;

                //Chuẩn bị tham số đầu vào
                var parameters = new DynamicParameters();
                parameters.Add("v_ContactID", contactID);

                //Thực hiện gọi vào DB
                var employee = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                if (employee > 0)
                {
                    return StatusCode(StatusCodes.Status200OK, contactID);
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
        /// Xóa một contact
        /// </summary>
        /// <param name="contactID"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult DeleteContact([FromBody] Guid contactID)
        {
            try
            {
                //Khởi tạo kết nối với DB Mysql
                var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString);

                //Chuẩn bị câu lệnh sql 
                string storedProcedureName = DatabaseContext.CERTIFICATE_DELETE;

                //Chuẩn bị tham số đầu vào
                var parameters = new DynamicParameters();
                parameters.Add("v_ContactID", contactID);

                //Thực hiện gọi vào DB
                var employee = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                if (employee > 0)
                {
                    return StatusCode(StatusCodes.Status200OK, contactID);
                }
                return StatusCode(StatusCodes.Status404NotFound);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
