using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fideo.Vimeo;
using Fideo.Vimeo.Constants;
using Fideo.Vimeo.Models;
using Fideo.Model;
using Fideo.Vimeo.Network;

namespace Fideo.Controllers
{
    [Route("api/[controller]")]
    public class VideoController : Controller
    {
        // POST : 사용자 비디오 리스트 가져오기
        [HttpPost("GetVideoList")]
        public async Task<Paginated<Video>> GetUserIdAsync()
        {
            VimeoClient user = new(AppInfo.AccessToken);
            var authCheck = Task.Run(async () => await user.GetAccountInformationAsync()).Result;
            var videos = await user.GetVideosAsync(authCheck.Id, 1, 100);

            return videos;
        }

        // POST : 사용자 비디오 1개 정보 가져오기
        [HttpPost("GetVideo")]
        public async Task<Video> GetVideoClip(VideoClipId vid)
        {
            VimeoClient user = new(AppInfo.AccessToken);
            var authCheck = Task.Run(async () => await user.GetAccountInformationAsync()).Result;
            var videoId = Convert.ToInt64(vid);
            var video = await user.GetVideoAsync(videoId);

            return video;
        }

        // POST : 사용자 비디오 1개 정보 변경
        [HttpPost("SetVideo")]
        public async Task<Video> SetVideoClip(VideoClipId vid, VideoUpdateMetadata metadata)
        {
            VimeoClient user = new(AppInfo.AccessToken);
            var authCheck = Task.Run(async () => await user.GetAccountInformationAsync()).Result;
            var videoId = Convert.ToInt64(vid);
            await user.UpdateVideoMetadataAsync(videoId, metadata);
            var video = await user.GetVideoAsync(videoId);

            return video;
        }


        // POST : 사용자 비디오 도메인 정보 변경(도메인 종속여부)
        [HttpPost("SetVideoDomain")]
        public async Task<Video> SetVideoDomain(VideoClipId vid, string domain, bool isAllow)
        {
            VimeoClient user = new(AppInfo.AccessToken);
            var authCheck = Task.Run(async () => await user.GetAccountInformationAsync()).Result;
            var videoId = Convert.ToInt64(vid);
            if( isAllow )
            {
                await user.AllowEmbedVideoOnDomainAsync(videoId, domain);
            }
            else
            {
                await user.DisallowEmbedVideoOnDomainAsync(videoId, domain);
            }
            
            var video = await user.GetVideoAsync(videoId);

            return video;
        }

        // POST : 사용자 비디오 이미지 변경
        [HttpPost("SetVideoThumbnail")]
        public async Task<Picture> SetVideoThumbnail(VideoClipId vid, IBinaryContent fileContent)
        {
            VimeoClient user = new(AppInfo.AccessToken);
            var authCheck = Task.Run(async () => await user.GetAccountInformationAsync()).Result;
            var videoId = Convert.ToInt64(vid);
            var picture = await user.UploadThumbnailAsync(videoId, fileContent);

            return picture;
        }
    }
}
