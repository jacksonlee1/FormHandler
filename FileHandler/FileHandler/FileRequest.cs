using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileHandler
{
    public class FileRequest
    {
       public string? Email{get;set;}
        public string? Name{get;set;}
        public string? Service{get;set;}
        public IFormFileCollection? Files{get;set;}
    }
}