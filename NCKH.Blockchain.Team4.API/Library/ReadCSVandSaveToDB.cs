using Dapper;
using Microsoft.SqlServer.Server;
using MySqlConnector;
using NCKH.Blockchain.Team4.Common.Constant;
using NCKH.Blockchain.Team4.Common.Entities.DTO;

namespace NCKH.Blockchain.Team4.API.Library
{
    public class ReadCSVandSaveToDB
    {
        public List<CertificateDTO> lstCerts = new List<CertificateDTO>();

        public List<CertificateDTO> ReadCSV(UploadCertsFromCSV file)
        {
            //Check file NULL
            if (file == null || file.fileCSV.Length == 0)
            {
                Console.WriteLine("No file found!");
                return null;
            }

            // Check file extension
            if (Path.GetExtension(file.fileCSV.FileName).ToLower() != ".csv")
            {
                Console.WriteLine("Incorrect file format!");
                return null;
            }

            // Save file to disk
            var uploadsFolder = @"..\NCKH.Blockchain.Team4.BL\DegreeData";
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var filePath = Path.Combine(uploadsFolder, file.fileCSV.FileName);

            using (FileStream fs = System.IO.File.Create(filePath))
            {
                file.fileCSV.CopyTo(fs);
                fs.Flush();
            }

            //Read data form file csv and save to List<CertificateDTO> certs
            using (StreamReader reader = new StreamReader(filePath))
            {
                // Read the header line and discard it
                string headerLine = reader.ReadLine();

                // Loop through the remaining lines in the file
                while (!reader.EndOfStream)
                {
                    // Read a line from the file
                    string line = reader.ReadLine();

                    // Split the line into an array of values
                    string[] values = line.Split(',');


                    string formatString = "M/d/yyyy h:mm:ss tt";
                    // Extract the values and do something with them
                    var cert = new CertificateDTO
                    {
                        IssuedID = file.PolicyID,
                        ReceivedID = values[0],
                        CertificateType = values[1],
                        CertificateName = values[2],
                        ReceivedAddressWallet = values[3],
                        ReceivedName = values[4],
                        ReceivedDoB = DateTime.ParseExact(values[5], formatString, null),
                        YearOfGraduation = values[6],
                        Classification = values[7],
                        ModeOfStudy = values[8]
                    };
                    lstCerts.Add(cert);
                }
            }
            return lstCerts;
        }


        public void InsertToDB(List<CertificateDTO> certs)
        {
            var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString);
            string storedProcedureName = DatabaseContext.CERTIFICATE_INSERT;

            foreach (var cert in certs)
            {
                var parameters = new DynamicParameters();
                var props = cert.GetType().GetProperties();

                for (int i = 0; i < props.Length; i++)
                {
                    var value = props[i].GetValue(cert);
                    parameters.Add($"@v_{props[i].Name}", value);
                }

                mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
