using FileService;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FileService;
using Microsoft.AspNetCore.Mvc;

namespace FileHandler.Controllers
{
    // todo: implement ->
    // https://stackoverflow.com/questions/72561109/how-to-set-cookie-in-the-browser-using-aspnet-core-6-web-api
    [ApiController]
    [Route("api/[controller]")]
    public class UploadController : ControllerBase
    {
         private readonly IEmailSender _emailSender;
         private readonly IFileUploader _fileUploader;
             public UploadController(IEmailSender emailSender, IFileUploader fileUploader)
        {
            _emailSender = emailSender;
            _fileUploader = fileUploader;
        }

        [HttpPost]
        public async Task<IActionResult> UploadAsync([FromForm]FileRequest req){
            if(req.Files == null){
                return NotFound();
            }
            var message = new Message(new string[] { "jacksonlee050802@gmail.com" }, "New File Upload!", req.Name+" Has uploaded a new files! It is saved to UserUploads/"+req.Service+"/"+req.Name+"/"+DateTime.Now.ToShortDateString() +" Email them back at "+req.Email+"!", req.Files);
            await _emailSender.SendEmailAsync(message);
            return   await _fileUploader.SaveFilesAsync(req.Service, req.Name,req.Files)?Ok():NoContent();
            
        }

        
    }

}