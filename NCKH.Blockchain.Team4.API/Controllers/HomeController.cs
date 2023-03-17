using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using NCKH.Blockchain.Team4.Common.Constant;
using NCKH.Blockchain.Team4.Common.Entities.DTO;
using System.Data;
using NCKH.Blockchain.Team4.API.Library;
using NCKH.Blockchain.Team4.Common.Entities;
using System.Runtime.ConstrainedExecution;

namespace NCKH.Blockchain.Team4.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        private readonly CloudinaryService _cloudinaryService;

        public HomeController(CloudinaryService cloudinaryService)
        {
            _cloudinaryService = cloudinaryService;
        }


        /// <summary>
        /// Lấy thông số dashbroad theo PolicyID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetDashbroadInfor([FromBody] string userId)
        {
            try
            {
                var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString);

                string storedProcedureName = DatabaseContext.DASHBROAD_INFOR;

                var parameters = new DynamicParameters();
                parameters.Add("v_UserID", userId, DbType.String, ParameterDirection.Input);
                parameters.Add("v_Pending", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("v_Connected", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("v_Draft", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("v_Signed", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("v_Sent", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("v_Received", dbType: DbType.Int32, direction: ParameterDirection.Output);

                mySqlConnection.Execute("proc_dashbroad_GetInfor", parameters, commandType: CommandType.StoredProcedure);

                int pending = parameters.Get<int>("v_Pending");
                int connected = parameters.Get<int>("v_Connected");
                int draft = parameters.Get<int>("v_Draft");
                int signed = parameters.Get<int>("v_Signed");
                int sent = parameters.Get<int>("v_Sent");
                int receiveed = parameters.Get<int>("v_Received");

                var dashbroadDTO = new DashbroadDTO(pending, connected, draft, signed, sent, receiveed);

                if (dashbroadDTO != null)
                {
                    return StatusCode(StatusCodes.Status200OK, dashbroadDTO);
                }
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("get-userid-by-addresswallet")]
        public IActionResult GetUserIDbyAddressWallet([FromBody] string addressWallet)
        {

            try
            {
                var user = DataFromDB.GetUserIDbyAddressWallet(addressWallet);

                if (user != Guid.Empty)
                {
                    return StatusCode(StatusCodes.Status200OK, user);
                }
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch(Exception e) 
            {
                Console.WriteLine(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }


        }

        /// <summary>
        /// Thêm mới 1 user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("add-user")]
        public async Task<IActionResult> CreateUser([FromForm] UserDTO user)
        {
            try
            {
                var imageUrl = await _cloudinaryService.UploadImageFromIFormFile(user.Logo);

                var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString);

                string storedProcedureName = DatabaseContext.USER_INSERT;

                //var newUser = new User()
                //{
                //    UserName = user.UserName,
                //    Logo = imageUrl,
                //    AddressWallet = user.AddresWallet
                //};

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("v_UserName", user.UserName);
                parameters.Add("v_Logo", imageUrl);
                parameters.Add("v_AddressWallet", user.AddresWallet);

                mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                if (imageUrl != null)
                {
                    return StatusCode(StatusCodes.Status201Created, user.AddresWallet);
                }
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        
    }
}
