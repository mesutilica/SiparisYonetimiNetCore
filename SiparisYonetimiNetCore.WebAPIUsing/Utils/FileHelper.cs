namespace SiparisYonetimiNetCore.WebUI.Utils
{
    public class FileHelper
    {
        public static async Task<string> FileLoaderAsync(IFormFile formFile, string filePath = "/wwwroot/Img/")
        {
            var fileName = "";

            fileName = formFile.FileName;
            string directory = Directory.GetCurrentDirectory() + filePath + fileName;
            using var stream = new FileStream(directory, FileMode.Create);
            await formFile.CopyToAsync(stream);

            return fileName;
        }
        public static bool FileRemover(string fileName, string filePath = "/wwwroot/Img/")
        {
            string directory = Directory.GetCurrentDirectory() + filePath + fileName;
            if (File.Exists(directory)) // Exists metodu verilen adreste dosya var mı diye kontrol eder
            {
                File.Delete(directory); // dosyayı sunucudan sil
                return true;
            }
            return false;
        }
    }
}
