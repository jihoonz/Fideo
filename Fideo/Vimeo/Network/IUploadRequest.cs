using Fideo.Vimeo.Models;

namespace Fideo.Vimeo.Network
{
    
    /// IUploadRequest
    
    public interface IUploadRequest
    {
        
        /// Bytes written
        
        long BytesWritten { get; set; }

        
        /// Chunk size
        
        int ChunkSize { get; set; }

        
        /// Clip id
        
        long? ClipId { get; }

        
        /// Clip URI
        
        string ClipUri { get; set; }

        
        /// File
        
        IBinaryContent File { get; set; }

        
        /// File length
        
        long FileLength { get; }

        
        /// Is verified complete
        
        bool IsVerifiedComplete { get; set; }

        
        /// Ticket
        
        UploadTicket Ticket { get; set; }
    }
}