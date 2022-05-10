using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fideo.Vimeo;
using Fideo.Vimeo.Constants;
using Fideo.Vimeo.Models;
using Fideo.Model;

namespace Fideo.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        /// GET : api/auth/finup
        [HttpGet("{id}")]
        public string Get(string id)
        {
            if (id == "finup")
            {
                return AppInfo.AccessToken;
            }
            else
            {
                return "Not Found ID";
            }
        }

        /// POST : AccessToken 을 외부에서 받아서 인증 : Return User Info & AuthToken Check
        [HttpPost]
        public ActionResult<User> CreateAuth(AuthToken aToken)
        {
            VimeoClient user = new(aToken.AccessToken);
            var authCheck = Task.Run(async () => await user.GetAccountInformationAsync()).Result;

            return authCheck;
        }

        // POST : AccessToken 을 Finup 고정으로 인증 : Return User Info & AuthToken Check
        [HttpPost("Finup")]
        public ActionResult<User> Post()
        {
            VimeoClient user = new(AppInfo.AccessToken);
            var authCheck = Task.Run(async () => await user.GetAccountInformationAsync()).Result;

            return authCheck;
        }

        // GET : api/auth/userid
        [HttpGet("GetUserId")]
        public string GetUserId()
        {
            VimeoClient user = new(AppInfo.AccessToken);
            var authCheck = Task.Run(async () => await user.GetAccountInformationAsync()).Result;

            return Convert.ToString(authCheck.Id);
        }
    }
}
