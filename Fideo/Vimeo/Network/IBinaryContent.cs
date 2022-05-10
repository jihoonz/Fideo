using System.IO;
using System.Threading.Tasks;

namespace Fideo.Vimeo.Network
{
    
    /// IBinaryContent
    
    public interface IBinaryContent
    {
        
        /// Content type
        
        string ContentType { get; set; }

        
        /// Content
        
        Stream Data { get; }

        
        /// Original file name
        
        string OriginalFileName { get; set; }

        
        /// Read all bytes to byte array asynchronously
        
        /// <returns>Byte array</returns>
        Task<byte[]> ReadAllAsync();

        
        /// Read bytes to byte array asynchronously
        
        /// <param name="startIndex">Start index</param>
        /// <param name="endIndex">End index</param>
        /// <returns>Byte array</returns>
        Task<byte[]> ReadAsync(long startIndex, long endIndex);
    }
}