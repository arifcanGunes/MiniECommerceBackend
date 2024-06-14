using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MiniETicaretBackend.Application.Abstractions.Storage.Local;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniETicaretBackend.Infrastructure.Concretes.Storage.Local
{
    public class LocalStorage :Storage, ILocalStorage
    {

        readonly IWebHostEnvironment _webHostEnvironment;

        public LocalStorage(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task DeleteAsync(string fileName, string pathOrContainerName)
        {
            File.Delete($"{pathOrContainerName}\\{fileName}");
        }

        public List<string> GetFiles(string pathOrContainerName)
        {
            DirectoryInfo directory = new(pathOrContainerName);
            return directory.GetFiles().Select(f=> f.Name).ToList();
        }

        public bool HasFile(string pathOrContainerName, string fileName)
        {
            var path = Path.Combine(_webHostEnvironment.WebRootPath, pathOrContainerName);
            return File.Exists($@"{path}\{fileName}");
        }

        private async Task<bool> CopyFileAsync(string path, IFormFile file)
        {
            await using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, false);
            await file.CopyToAsync(fileStream);
            await fileStream.FlushAsync();
            return true;
        }

        public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files)
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, pathOrContainerName);
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            List<(string fileName, string path)> datas = new List<(string fileName, string path)>();

            foreach (IFormFile file in files)
            {
                var newFileName = await FileRenameAsync(pathOrContainerName, file.Name, HasFile);
                await CopyFileAsync($"{uploadPath}\\{newFileName}", file);
                datas.Add((newFileName, $"{pathOrContainerName}\\{newFileName}"));
            }

            
            return datas;
        }
    }
}
