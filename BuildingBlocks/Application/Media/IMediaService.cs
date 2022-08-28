using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quadrion.ERP.BuildingBlocks.Application.Media
{
    public interface IMediaService
    {
        Task<string> Upload(byte[] file, string targetFilePath, string fileExtension);

        bool Remove(string fileLocation);

        Task<byte[]> Download(string folderName, string fileLocation);
    }
}