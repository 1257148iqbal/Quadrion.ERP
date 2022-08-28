using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quadrion.ERP.BuildingBlocks.Application.Cryptography;

namespace Quadrion.ERP.BuildingBlocks.Application.Media
{
    public class MediaService : IMediaService
    {
        public async Task<string> Upload(byte[] file, string targetFilePath, string fileExtension)
        {
            var exists = Directory.Exists(targetFilePath);
            if (!exists)
            {
                Directory.CreateDirectory(targetFilePath);
            }

            // For the file name of the uploaded file stored
            // server-side, use Path.GetFileNameWithoutExtension to generate a safe
            // random file name without extension.
            var trustedFileNameForFileStorage = $"{Path.GetFileNameWithoutExtension(Path.GetRandomFileName())}{fileExtension}";
            var filePath = Path.Combine(targetFilePath, trustedFileNameForFileStorage);

            // **WARNING!**
            // In the following example, the file is saved without
            // scanning the file's contents. In most production
            // scenarios, an anti-virus/anti-malware scanner API
            // is used on the file before making the file available
            // for download or for use by other systems.
            // For more information, see the topic that accompanies
            // this sample.
            await using var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            await fileStream.WriteAsync(file);

            return trustedFileNameForFileStorage;
        }

        public bool Remove(string fileLocation)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), fileLocation);
            if (!File.Exists(filePath))
            {
                return false;
            }

            File.Delete(filePath);
            return true;
        }

        public async Task<byte[]> Download(string folderName, string fileLocation)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), folderName, fileLocation);
            if (!System.IO.File.Exists(filePath))
                throw new FileNotFoundException("File Not Found.");

            var memory = new MemoryStream();
            await using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }

            memory.Position = 0;

            var decryptedFile = RijndaelHelper.DecryptBytes(memory.ToArray(), "azim@1232565", "rashed@22222");

            return decryptedFile.ToArray();
        }
    }
}