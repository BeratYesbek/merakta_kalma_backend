using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.FileHelper;
using Core.Utilities.Result;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Storage
{
    internal class StorageHelper : IFileHelper
    {
        private readonly string _currentDirectory = Environment.CurrentDirectory + "\\wwwroot";
        private readonly string _folderName = "Files";

        public StorageHelper(string folderName)
        {
            _folderName = $"\\{folderName}\\"; ;

        }

        public IResult Upload(IFormFile file)
        {
            if (file == null && file.Length <= 0)
            {
                return new ErrorResult("File doesn't exist");
            }

            var randomName = Guid.NewGuid().ToString();
            var type = Path.GetExtension(file.FileName);
            CheckDirectoryExists(_currentDirectory + _folderName);
            CreateFile(_currentDirectory + _folderName + randomName + type, file);

            return new SuccessResult((_folderName + randomName + type).Replace("\\", "/"));
        }

        public IResult Update(IFormFile file, string filePath, string publicId = default)
        {
            if (file == null && file.Length <= 0)
            {
                return new ErrorResult("File doesn't exist");
            }

            var type = Path.GetExtension(file.FileName);
            var randomName = Guid.NewGuid().ToString();

            DeleteOldFile((_currentDirectory + filePath).Replace("/", "\\"));
            CheckDirectoryExists(_currentDirectory + _folderName);
            CreateFile(_currentDirectory + _folderName + randomName + type, file);
            return new SuccessResult((_folderName + randomName + type).Replace("\\", "/"));
        }

        public IResult Delete(string filePath, string publicId = default)
        {
            DeleteOldFile((_currentDirectory + filePath).Replace("/", "\\"));
            return new SuccessResult();
        }


        public async Task<IResult> UploadAsync(IFormFile file)
        {
            if (file == null && file.Length <= 0)
            {
                return new ErrorResult("File doesn't exist");
            }

            var randomName = Guid.NewGuid().ToString();
            var type = Path.GetExtension(file.FileName);
            CheckDirectoryExists(_currentDirectory + _folderName);
            await CreateFileAsync(_currentDirectory + _folderName + randomName + type, file);

            return new SuccessResult((_folderName + randomName + type).Replace("\\", "/"));
        }


        public async Task<IResult> UpdateAsync(IFormFile file, string filePath, string publicId = default)
        {
            if (file == null && file.Length <= 0)
            {
                return new ErrorResult("File doesn't exist");
            }

            var type = Path.GetExtension(file.FileName);
            var randomName = Guid.NewGuid().ToString();

            DeleteOldFile((_currentDirectory + filePath).Replace("/", "\\"));
            CheckDirectoryExists(_currentDirectory + _folderName);
            await CreateFileAsync(_currentDirectory + _folderName + randomName + type, file);
            return new SuccessResult((_folderName + randomName + type).Replace("\\", "/"));
        }

        public async Task<IResult> DeleteAsync(string filePath, string publicId = default)
        {
            DeleteOldFile((_currentDirectory + filePath).Replace("/", "\\"));
            return new SuccessResult();
        }

        private void DeleteOldFile(string directory)
        {
            if (File.Exists(directory.Replace("/", "\\")))
            {
                File.Delete(directory.Replace("/", "\\"));
            }
        }

        private void CreateFile(string directory, IFormFile file)
        {

            using (FileStream fileStream = File.Create(directory))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }

        }

        private async Task CreateFileAsync(string directory, IFormFile file)
        {

            using (FileStream fileStream = File.Create(directory))
            {
                file.CopyTo(fileStream);
                await fileStream.FlushAsync();
            }

        }

        private void CheckDirectoryExists(string directory)
        {
            if (!Directory.Exists((directory)))
            {
                Directory.CreateDirectory(directory);
            }
        }
    }
}
