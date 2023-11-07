using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FileService
{
    public class FileUploader : IFileUploader
    {
        private readonly  FileConfiguration _fileConfig;
    public FileUploader(FileConfiguration fileConfig){
        _fileConfig = fileConfig;
    }
        public async Task<bool> SaveFilesAsync(string location, string name, IFormFileCollection files){
            int numFiles;
                        var path = Path.Combine(_fileConfig.UplaodBasePath,location+"/"+name+"/"+DateTime.Today.ToShortDateString());
                        if(!System.IO.Directory.Exists(path)){
                            System.IO.Directory.CreateDirectory(path);
                            Console.WriteLine(path);
                            numFiles = 0;
                        } else{
                     numFiles = System.IO.Directory.GetFiles(path).Count();

                }
                


                for (int i = 1; i < files.Count(); i++)
                {
                    var ext = Path.GetExtension(files[i].FileName);
                          if(_fileConfig.AllowedExtensions.Contains(ext)){
                        var itemNum = numFiles+i;
                     using (var stream = System.IO.File.Create(path+"/00_"+itemNum+ext)){
                            await files[i].CopyToAsync(stream);
                     }
                    }else{
                        return false;
                    }
               
                }
                return true;
               
        }
        
    }
}