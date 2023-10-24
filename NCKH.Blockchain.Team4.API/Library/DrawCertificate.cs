using NCKH.Blockchain.Team4.Common.Entities;
using NCKH.Blockchain.Team4.Common.Entities.DTO;
using System.Drawing;

namespace NCKH.Blockchain.Team4.API.Library
{
    public class DrawCertificate
    {
        CloudinaryService cloudinaryService = new CloudinaryService();
        public string ImageFolderPath { get; set; }

        public string BackgroundImagePath { get; set; }

        public async Task Draw(List<CertificateDTO> certs, string oganizationName)
        {
            var code = DataFromDB.GetMaxCertificateCode() - certs.Count;

            //Create folder contain image cert
            ImageFolderPath = @"NCKH.Blockchain.Team4.BL\DegreeCreated\Degree_" + code;
            if (!Directory.Exists(ImageFolderPath))
                Directory.CreateDirectory(ImageFolderPath);
            BackgroundImagePath = @"NCKH.Blockchain.Team4.BL\DegreeForm\TestForm.png";


            Bitmap image = new Bitmap(928, 648);
            Graphics graphics = Graphics.FromImage(image);

            for (int i = 0; i < certs.Count; i++)
            {
                try
                {
                    // Load the background image and draw it onto the bitmap
                    Image backgroundImage = Image.FromFile(BackgroundImagePath);
                    graphics.DrawImage(backgroundImage, 0, 0, image.Width, image.Height);
                    // Oganization Name dang tam fix cung
                    SizeF stringSize1 = graphics.MeasureString(oganizationName, new Font("Monotype Corsiva", 18));
                    float x1 = (image.Width - stringSize1.Width) / 2;
                    float y1 = 50;
                    graphics.DrawString(oganizationName, new Font("Monotype Corsiva", 18), Brushes.DarkSlateGray, x1, y1);

                    // Received Name
                    SizeF stringSize2 = graphics.MeasureString(certs[i].ReceivedName, new Font("Monotype Corsiva", 48));
                    float x2 = (image.Width - stringSize2.Width) / 2;
                    float y2 = 260;
                    graphics.DrawString(certs[i].ReceivedName, new Font("Monotype Corsiva", 48), Brushes.DarkSlateGray, x2, y2);

                    // Certificate Name
                    graphics.DrawString("Certificate Name: " + certs[i].CertificateName.ToString(), new Font("Monotype Corsiva", 14), Brushes.DarkSlateGray, 180, 370);

                    // Date Of Birth
                    graphics.DrawString("Date Of Birth: " + certs[i].ReceivedDoB.ToString("dd/MM/yyyy"), new Font("Monotype Corsiva", 14), Brushes.DarkSlateGray, 570, 370);

                    //Year Of Graduation
                    graphics.DrawString("Year Of Graduation: " + certs[i].YearOfGraduation.ToString(), new Font("Monotype Corsiva", 14), Brushes.DarkSlateGray, 180, 420);

                    //Classification
                    graphics.DrawString("Classification: " + certs[i].Classification.ToString(), new Font("Monotype Corsiva", 14), Brushes.DarkSlateGray, 180, 470);

                    //Mode Of Study
                    graphics.DrawString("Mode Of Study: " + certs[i].ModeOfStudy.ToString(), new Font("Monotype Corsiva", 14), Brushes.DarkSlateGray, 180, 520);

                    //Certificate Code + Date received dang tam fix cung
                    graphics.DrawString("Certificate number: " + code.ToString(), new Font("Monotype Corsiva", 12), Brushes.DarkSlateGray, 140, 585);

                    string imageFileName = $"Cert_{code}.png";

                    string imagePath = Path.Combine(ImageFolderPath, imageFileName);
                    Directory.CreateDirectory(ImageFolderPath);
                    image.Save(imagePath);

                    string imageLink = await cloudinaryService.UploadImageFromFolder(imagePath);

                    DataFromDB.UpdateImageLinkCertificate(code, imageLink);

                    code++;
                }catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
