using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FileService
{
    public interface IFileUploader
    {
        Task<bool> SaveFilesAsync(string location,string email,IFormFileCollection files);
    }
}