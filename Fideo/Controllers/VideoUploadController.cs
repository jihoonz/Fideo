using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fideo.Vimeo;
using Fideo.Vimeo.Constants;
using Fideo.Vimeo.Models;
using Fideo.Vimeo.Network;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fideo.Controllers
{
    [Route("api/[controller]")]
    public class VideoUploadController : Controller
    {
        internal const int DefaultUploadChunkSize = 1048576; // 1MB

        // POST : 
        [HttpPost("GetUploadTicket")]
        public async Task<UploadTicket> GetUploadTicketAsync()
        {
            VimeoClient user = new(AppInfo.AccessToken);
            var authCheck = Task.Run(async () => await user.GetAccountInformationAsync()).Result;
            var ticket = await user.GetUploadTicketAsync();

            return ticket;
        }
        // POST : 
        [HttpPost("FileUpload")]
        public async Task<IUploadRequest> FileUpload(IBinaryContent fileContent)
        {
            VimeoClient user = new(AppInfo.AccessToken);
            var authCheck = Task.Run(async () => await user.GetAccountInformationAsync()).Result;
            var ticket = await user.UploadEntireFileAsync(fileContent);

            return ticket;
        }
        // POST : 
        [HttpPost("FileUploadReplace")]
        public async Task<IUploadRequest> FileUploadReplace(IBinaryContent fileContent, string replaceVideoId)
        {
            VimeoClient user = new(AppInfo.AccessToken);
            var authCheck = Task.Run(async () => await user.GetAccountInformationAsync()).Result;
            var videoId = Convert.ToInt64(replaceVideoId);
            var ticket = await user.UploadEntireFileAsync(fileContent, DefaultUploadChunkSize, videoId);

            return ticket;
        }
    }
}
