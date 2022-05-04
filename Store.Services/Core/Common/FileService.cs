using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Core
{
    public interface IFileService
    {
        #region Common
        Task WriteFile(byte[] content, string directory, string fileName);

        Task WriteFile(Stream binaryStream, string directory, string fileName);

        Task WriteFileFromUrl(string url, string directory, string fileName);

        Task DeleteFile(string directory, string fileName);

        byte[]? ReadFileAsByte(string directory, string fileName);

        Stream? ReadFileAsStream(string directory, string fileName);

        string GetPathOfFile(string directory, string fileName);
        #endregion

        #region Employee
        Task WriteEmployeeImage(byte[] content, string fileName);

        Task WriteEmployeeImage(Stream binaryStrem, string fileName);

        Task WriteEmployeeImageFromUrl(string url, string fileName);

        Task DeleteEmployeeImage(string fileName);

        byte[]? ReadEmployeeImageAsByte(string fileName);

        Stream? ReadEmployeeImageAsStream(string fileName);

        string GetPathOfEmployeeImage(string fileName);

        string GeneratePathEmployeeImageForUrl(string fileName);

        Task WriteEmployeeImageRecognition(byte[] content, string fileName);

        Task WriteEmployeeImageRecognition(Stream binaryStrem, string fileName);

        Task WriteEmployeeImageRecognitionFromUrl(string url, string fileName);

        Task DeleteEmployeeImageRecognition(string fileName);

        byte[]? ReadEmployeeImageRecognitionAsByte(string fileName);

        Stream? ReadEmployeeImageRecognitionAsStream(string fileName);

        string GetPathOfEmployeeImageRecognition(string fileName);

        string GeneratePathEmployeeImageRecognitionForUrl(string fileName);
        #endregion
    }

    public class FileService : IFileService
    {
        private readonly string _employeeImageFolder;
        private readonly string _employeeImageRecognitionFolder;
        private readonly IHostingEnvironment _environment;

        private const string IMAGE_FOLDER_NAME = "images";
        private const string EMPLOYEE_IMAGE_FOLDER_NAME = "avatars";
        private const string EMPLOYEE_RECOGNITION_FOLDER_NAME = "recognitions";

        public FileService(IHostingEnvironment environment)
        {
            _environment = environment;
            _employeeImageFolder = Path.Combine(_environment.WebRootPath, IMAGE_FOLDER_NAME, EMPLOYEE_IMAGE_FOLDER_NAME);
            _employeeImageRecognitionFolder = Path.Combine(_environment.WebRootPath, IMAGE_FOLDER_NAME, EMPLOYEE_RECOGNITION_FOLDER_NAME);
            
            if (!Directory.Exists(_employeeImageFolder))
                Directory.CreateDirectory(_employeeImageFolder);

            if (!Directory.Exists(_employeeImageRecognitionFolder))
                Directory.CreateDirectory(_employeeImageRecognitionFolder);
        }

        #region Common
        public async Task WriteFile(byte[] content, string directory, string fileName)
        {
            var filePath = Path.Combine(directory, fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                await fileStream.WriteAsync(content, 0, content.Length);
            }
        }

        public async Task WriteFile(Stream binaryStream, string directory, string fileName)
        {
            var filePath = Path.Combine(directory, fileName);
            using var handler = new FileStream(filePath, FileMode.Create);
            await binaryStream.CopyToAsync(handler);
        }

        public async Task WriteFileFromUrl(string url, string directory, string fileName)
        {
            using (WebClient client = new())
            {
                using (Stream stream = client.OpenRead(url))
                {
                    await WriteFile(stream, directory, fileName);
                }
            }
        }

        public async Task DeleteFile(string directory, string fileName)
        {
            var filePath = Path.Combine(directory, fileName);
            if (File.Exists(filePath))
                await Task.Run(() => File.Delete(filePath));
        }

        public byte[]? ReadFileAsByte(string directory, string fileName)
        {
            var filePath = Path.Combine(directory, fileName);
            if (!File.Exists(filePath))
                return null;

            using (var streamReader = new StreamReader(filePath))
            {
                using (var memoryStream = new MemoryStream())
                {
                    streamReader.BaseStream.CopyTo(memoryStream);
                    var fileBytes = memoryStream.ToArray();

                    return fileBytes;
                }
            }
        }

        public Stream? ReadFileAsStream(string directory, string fileName)
        {
            var filePath = Path.Combine(directory, fileName);
            if (!File.Exists(filePath))
                return null;

            var streamReader = new StreamReader(filePath);
            var memoryStream = new MemoryStream();
            streamReader.BaseStream.CopyTo(memoryStream);

            return memoryStream;
        }

        public string GetPathOfFile(string directory, string fileName)
            => Path.Combine(directory, fileName);
        #endregion

        #region --- Employee ---
        public async Task WriteEmployeeImage(byte[] content, string fileName)
            => await WriteFile(content, _employeeImageFolder, fileName);

        public async Task WriteEmployeeImage(Stream binaryStream, string fileName)
             => await WriteFile(binaryStream, _employeeImageFolder, fileName);

        public async Task WriteEmployeeImageFromUrl(string url, string fileName)
           => await WriteFileFromUrl(url, _employeeImageFolder, fileName);

        public async Task DeleteEmployeeImage(string fileName)
            => await DeleteFile(_employeeImageFolder, fileName);

        public byte[]? ReadEmployeeImageAsByte(string fileName)
            => ReadFileAsByte(_employeeImageFolder, fileName);

        public Stream? ReadEmployeeImageAsStream(string fileName)
            => ReadFileAsStream(_employeeImageFolder, fileName);

        public string GetPathOfEmployeeImage(string fileName)
            => GetPathOfFile(_employeeImageFolder, fileName);

        public string GeneratePathEmployeeImageForUrl(string fileName)
            => $"{IMAGE_FOLDER_NAME}/{EMPLOYEE_IMAGE_FOLDER_NAME}/{fileName}";

        public async Task WriteEmployeeImageRecognition(byte[] content, string fileName)
            => await WriteFile(content, _employeeImageRecognitionFolder, fileName);

        public async Task WriteEmployeeImageRecognition(Stream binaryStream, string fileName)
            => await WriteFile(binaryStream, _employeeImageRecognitionFolder, fileName);

        public async Task WriteEmployeeImageRecognitionFromUrl(string url, string fileName)
            => await WriteFileFromUrl(url, _employeeImageRecognitionFolder, fileName);

        public async Task DeleteEmployeeImageRecognition(string fileName)
            => await DeleteFile(_employeeImageRecognitionFolder, fileName);

        public byte[]? ReadEmployeeImageRecognitionAsByte(string fileName)
            => ReadFileAsByte(_employeeImageRecognitionFolder, fileName);

        public Stream? ReadEmployeeImageRecognitionAsStream(string fileName)
            => ReadFileAsStream(_employeeImageRecognitionFolder, fileName);

        public string GetPathOfEmployeeImageRecognition(string fileName)
            => GetPathOfFile(_employeeImageRecognitionFolder, fileName);

        public string GeneratePathEmployeeImageRecognitionForUrl(string fileName)
            => $"{IMAGE_FOLDER_NAME}/{EMPLOYEE_RECOGNITION_FOLDER_NAME}/{fileName}";
        #endregion
    }
}
