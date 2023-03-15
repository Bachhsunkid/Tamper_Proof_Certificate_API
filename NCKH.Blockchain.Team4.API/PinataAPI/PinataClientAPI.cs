using Pinata.Client.Models;
using Pinata.Client;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Flurl.Http.Content;
using System.Drawing;
using NCKH.Blockchain.Team4.Common.Constant;
using NCKH.Blockchain.Team4.Common.Library;
using NCKH.Blockchain.Team4.API.Library;

namespace NCKH.Blockchain.Team4.API.PinataAPI
{
    public class PinataClientAPI
    {
        public async Task UploadImagesToIPFS(string folderPath)
        {
            // Create Pinata client
            var config = new Config
            {
                ApiKey = PinataContext.API_KEY,
                ApiSecret = PinataContext.API_SECRET
            };
            PinataClient client = new PinataClient(config);

            // Get list of image files in folder
            string[] files = Directory.GetFiles(folderPath, "*.png"); // replace *.png with the file extension of your images

            var body = new { hello = "world" };
            var json = JsonConvert.SerializeObject(body);

            var metadata = new PinataMetadata // optional
            {
                KeyValues =
                {
                    {"Author", "Test"}
                }
            };


            int code = DataFromDB.GetMaxCertificateCode() - files.Length;
            // Loop through files and pin to IPFS and save CID to DB
            foreach (string filePath in files)
            {
                 string fileName = Path.GetFileName(filePath);
                 using(var fileStream = new FileStream(filePath, FileMode.Open))
                 {
                    var response = await client.Pinning.PinFileToIpfsAsync(content =>
                    {
                        content.AddPinataFile(new StreamContent(fileStream), fileName);
                    }, metadata);

                    if (response.IsSuccess)
                    {
                        DataFromDB.UpdateIPFSCertByCode(code, response.IpfsHash);
                    }
                    else
                    {
                        Console.WriteLine($"Failed to pin file {filePath} to IPFS: {response.Message}");
                    }
                 }
                code++;
            }
        }
    }
}
