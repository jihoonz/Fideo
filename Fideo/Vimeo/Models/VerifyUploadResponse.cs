using System;
using Fideo.Vimeo.Enums;

namespace Fideo.Vimeo.Models
{
    /// <summary>
    /// Verify upload response
    /// </summary>
    [Serializable]
    public class VerifyUploadResponse
    {
        /// <summary>
        /// Status
        /// </summary>
        public UploadStatusEnum Status { get; set; }

        /// <summary>
        /// Bytes written
        /// </summary>
        public long BytesWritten { get; set; }
    }
}