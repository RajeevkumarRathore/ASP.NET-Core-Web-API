using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Implementation.Common
{
    public static class FileUploadHelper
    {
        public static string SaveUploadedFile(IFormFile file, IWebHostEnvironment _environment, string module)
        {
            string fileLocation = Path.Combine(_environment.WebRootPath, @$"UploadedData\{module}");
            if (!Directory.Exists(fileLocation))
            {
                Directory.CreateDirectory(fileLocation);
            }
            fileLocation = Path.Combine(fileLocation, @$"{file.FileName}");

            using (FileStream fs = System.IO.File.Create(fileLocation))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
            return (@$"\UploadedData\{module}\{file.FileName}");
        }
        public static void RemoveFileFromPath(IWebHostEnvironment _environment, string filePath)
        {
            filePath = _environment.WebRootPath + $"{filePath}";
            if (!string.IsNullOrEmpty(filePath))
            {
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }
        }
    }
}
