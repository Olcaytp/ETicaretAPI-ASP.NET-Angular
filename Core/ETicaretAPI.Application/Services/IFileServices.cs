using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Services
{
    public interface IFileServices
    {
        Task<List<(string fileName, string path)>>  UploadAsync(string path, IFormFileCollection files); //Infrastructurde da service klasörü altına bu interfacein concrete ini oluşturacağız.

        Task<bool> CopyFileAsync(string path, IFormFile file);
    }
}
