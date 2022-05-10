using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fideo.Vimeo;
using Fideo.Vimeo.Constants;

namespace Fideo.Controllers
{
    [Route("api/[controller]")]
    public class LiveController : Controller
    {
        // POST : 
        [HttpPost("GetLiveList")]
        public string GetLiveEventList()
        {
            VimeoClient user = new(AppInfo.AccessToken);
            var authCheck = Task.Run(async () => await user.GetAccountInformationAsync()).Result;
            var errorMSG = "Error code 2204: parameter problem. When the API returns error code 2204 with HTTP status 400 Bad Request, you're using at least one unrecognized parameter. The invalid_parameters block of the response gives a separate report and error code for each problematic field, which helps you to pinpoint exactly what's going on.";

            return errorMSG;
        }
        // POST : 
        [HttpPost("GetLive")]
        public string GetLiveEvent()
        {
            VimeoClient user = new(AppInfo.AccessToken);
            var authCheck = Task.Run(async () => await user.GetAccountInformationAsync()).Result;
            var errorMSG = "Error code 2204: parameter problem. When the API returns error code 2204 with HTTP status 400 Bad Request, you're using at least one unrecognized parameter. The invalid_parameters block of the response gives a separate report and error code for each problematic field, which helps you to pinpoint exactly what's going on.";

            return errorMSG;
        }
        // POST : 
        [HttpPost("SetLive")]
        public string SetLive()
        {
            VimeoClient user = new(AppInfo.AccessToken);
            var authCheck = Task.Run(async () => await user.GetAccountInformationAsync()).Result;
            var errorMSG = "Error code 2204: parameter problem. When the API returns error code 2204 with HTTP status 400 Bad Request, you're using at least one unrecognized parameter. The invalid_parameters block of the response gives a separate report and error code for each problematic field, which helps you to pinpoint exactly what's going on.";

            return errorMSG;
        }
        // POST : 
        [HttpPost("SetLiveDomain")]
        public string SetLiveDomain()
        {
            VimeoClient user = new(AppInfo.AccessToken);
            var authCheck = Task.Run(async () => await user.GetAccountInformationAsync()).Result;
            var errorMSG = "Error code 2204: parameter problem. When the API returns error code 2204 with HTTP status 400 Bad Request, you're using at least one unrecognized parameter. The invalid_parameters block of the response gives a separate report and error code for each problematic field, which helps you to pinpoint exactly what's going on.";

            return errorMSG;
        }
        // POST : 
        [HttpPost("SetLiveStart")]
        public string SetLiveStart()
        {
            VimeoClient user = new(AppInfo.AccessToken);
            var authCheck = Task.Run(async () => await user.GetAccountInformationAsync()).Result;
            var errorMSG = "Error code 2204: parameter problem. When the API returns error code 2204 with HTTP status 400 Bad Request, you're using at least one unrecognized parameter. The invalid_parameters block of the response gives a separate report and error code for each problematic field, which helps you to pinpoint exactly what's going on.";

            return errorMSG;
        }
        // POST : 
        [HttpPost("SetLiveEnd")]
        public string SetLiveEnd()
        {
            VimeoClient user = new(AppInfo.AccessToken);
            var authCheck = Task.Run(async () => await user.GetAccountInformationAsync()).Result;
            var errorMSG = "Error code 2204: parameter problem. When the API returns error code 2204 with HTTP status 400 Bad Request, you're using at least one unrecognized parameter. The invalid_parameters block of the response gives a separate report and error code for each problematic field, which helps you to pinpoint exactly what's going on.";

            return errorMSG;
        }

    }
}
