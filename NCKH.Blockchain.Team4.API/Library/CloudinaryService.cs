using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using NCKH.Blockchain.Team4.Common.Constant;
using NCKH.Blockchain.Team4.API.Library;

public class CloudinaryService
{
    private readonly Account _account;
    private readonly Cloudinary _cloudinary;

    public CloudinaryService()
    {
        // replace with your Cloudinary credentials
        _account = new Account(
            CloudinaryContext.CLOUD_NAME, 
            CloudinaryContext.API_KEY, 
            CloudinaryContext.API_SECRET);
        _cloudinary = new Cloudinary(_account);
    }

    public async Task<string> UploadImageFromIFormFile(IFormFile file)
    {
        try
        {
            using var stream = file.OpenReadStream();

            int code = DataFromDB.GetMaxUserCode();

            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(code.ToString() + file.FileName, stream),
                PublicId = Guid.NewGuid().ToString(), // generate a unique ID for the image
                Folder = "Logo" // optional: specify a folder in Cloudinary to store the image
            };

            var result = await _cloudinary.UploadAsync(uploadParams);

            return result.SecureUrl.AbsoluteUri; // return the URL of the uploaded image
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }

    public async Task<string> UploadImageFromFolder(string filePath)
    {
        try
        {
            using var stream = new FileStream(filePath, FileMode.Open);

            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(Path.GetFileName(filePath), stream),
                PublicId = Guid.NewGuid().ToString(), // generate a unique ID for the image
                Folder = "Degree" // optional: specify a folder in Cloudinary to store the image
            };

            var result = await _cloudinary.UploadAsync(uploadParams);

            return result.SecureUrl.AbsoluteUri; // return the URL of the uploaded image
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }
}