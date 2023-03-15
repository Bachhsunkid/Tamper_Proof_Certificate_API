using NCKH.Blockchain.Team4.Common.Constant;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System.Data.SqlClient;

namespace NCKH.Blockchain.Team4.API.Library
{
    public class DataFromDB
    {
        public static void UpdateIPFSCertByCode(int code, string ipfs)
        {
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                ipfs = "https://gateway.pinata.cloud/ipfs/" + ipfs;
                // create an anonymous object with the new IpfsLink and CertificateCode to update
                var parameters = new { CertificateCode = code, IpfsLink = ipfs };

                // execute the update query using Dapper's Execute method
                mySqlConnection.Execute("UPDATE certificate SET IpfsLink = @IpfsLink WHERE CertificateCode = @CertificateCode", parameters);
            }
        }

        public static string GetOganizationNamebyPolicyID(string policyID)
        {
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                // create an anonymous object with the new IpfsLink and CertificateCode to update
                var parameters = new { PolicyID = policyID};

                // execute the update query using Dapper's QueryFirstOrDefault method
                return mySqlConnection.QuerySingleOrDefault<string>("SELECT UserName FROM user WHERE PolicyID = @PolicyID", parameters);
            }
        }

        public static int GetMaxCertificateCode()
        {
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                // execute the update query using Dapper's QueryFirstOrDefault method
                int code = mySqlConnection.QueryFirstOrDefault<int>("select CertificateCode from certificate order by CertificateCode desc");
                return code + 1;
            }
        }
    }
}
