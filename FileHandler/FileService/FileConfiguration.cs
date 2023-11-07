using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileService
{
    public class FileConfiguration
    {
       public string UplaodBasePath {get;set;} = "../UserUploads";

        public string[] AllowedExtensions{get;set;} = {".jpg",".bmp",".gif",".png",".jpeg"};
    }
}