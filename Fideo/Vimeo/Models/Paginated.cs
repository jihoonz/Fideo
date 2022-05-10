using System.Collections.Generic;
using Newtonsoft.Json;

namespace Fideo.Vimeo.Models
{
    
    /// Paginated
    
    /// <typeparam name="T"></typeparam>
    public class Paginated<T> where T : class
    {
        
        /// Content
        
        [JsonProperty(PropertyName = "data")]
        public List<T> Data { get; set; }

        
        /// Total
        
        [JsonProperty(PropertyName = "total")]
        public int Total { get; set; }

        
        /// Page
        
        [JsonProperty(PropertyName = "page")]
        public int Page { get; set; }

        
        /// Per page
        
        [JsonProperty(PropertyName = "per_page")]
        public int PerPage { get; set; }

        
        /// Paging
        
        [JsonProperty(PropertyName = "paging")]
        public Paging Paging { get; set; }
    }
}