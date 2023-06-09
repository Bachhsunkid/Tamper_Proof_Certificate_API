﻿using NCKH.Blockchain.Team4.Common.Constant;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System.Data.SqlClient;
using NCKH.Blockchain.Team4.Common.Entities;

namespace NCKH.Blockchain.Team4.API.Library
{
    public class DataFromDB
    {
        /// <summary>
        /// Cập nhật mã IPFS theo mã code
        /// </summary>
        /// <param name="code"></param>
        /// <param name="ipfs"></param>
        public static void UpdateIPFSCertByCode(int code, string ipfs)
        {
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                ipfs = "ipfs://" + ipfs;
                // create an anonymous object with the new IpfsLink and CertificateCode to update
                var parameters = new { CertificateCode = code, IpfsLink = ipfs };

                // execute the update query using Dapper's Execute method
                mySqlConnection.Execute("UPDATE certificate SET IpfsLink = @IpfsLink WHERE CertificateCode = @CertificateCode", parameters);
            }
        }

        public static string GetOganizationNamebyPolicyID(string userID)
        {
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                // create an anonymous object with the new IpfsLink and CertificateCode to update
                var parameters = new { UserID = userID };

                // execute the update query using Dapper's QueryFirstOrDefault method
                return mySqlConnection.QuerySingleOrDefault<string>("SELECT UserName FROM user WHERE UserID = @UserID", parameters);
            }
        }

        public static int GetMaxCertificateCode()
        {
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                // execute the update query using Dapper's QueryFirstOrDefault method
                int code = mySqlConnection.QueryFirstOrDefault<int>("select CertificateCode from certificate order by CertificateCode desc");
                return code > 1 ? code + 1 : 100000;
            }
        }

        public static int GetMaxUserCode()
        {
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                // execute the update query using Dapper's QueryFirstOrDefault method
                int code = mySqlConnection.QueryFirstOrDefault<int>("select UserCode from user order by UserCode desc");

                return code > 1 ? code + 1 : 100000;
            }
        }

        public static void UpdateImageLinkCertificate(int certificateCode, string imageLink)
        {
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                // create an anonymous object with the new IpfsLink and CertificateCode to update
                var parameters = new { CertificateCode = certificateCode, ImageLink = imageLink };

                // execute the update query using Dapper's QueryFirstOrDefault method
                mySqlConnection.Execute("UPDATE certificate SET ImageLink = @ImageLink WHERE CertificateCode = @CertificateCode", parameters);
            }
        }

        public static Guid GetUserIDbyAddressWallet(string addressWallet)
        {
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                // create an anonymous object with the new IpfsLink and CertificateCode to update
                var parameters = new { AddressWallet = addressWallet };

                // execute the update query using Dapper's QueryFirstOrDefault method
                return mySqlConnection.QuerySingleOrDefault<Guid>("SELECT UserID FROM user WHERE AddressWallet = @AddressWallet", parameters);
            }
        }

        public static string GetAssetNameByCertificateID(Guid certificateID)
        {
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                // create an anonymous object with the new IpfsLink and CertificateCode to update
                var parameters = new { certificateID = certificateID };

                // execute the query using Dapper's QueryFirstOrDefault method
                var data = mySqlConnection.QueryFirstOrDefault("SELECT certificateCode, certificateType FROM certificate WHERE certificateID = @certificateID", parameters);

                // check if data is not null
                if (data != null)
                {
                    // concatenate certificateCode and certificateType with a separator of your choice
                    string assetName = $"{data.certificateType}{data.certificateCode}";

                    // return the concatenated string
                    return assetName;
                }

                // return null if no data is found
                return null;
            }
        }
    }
}
