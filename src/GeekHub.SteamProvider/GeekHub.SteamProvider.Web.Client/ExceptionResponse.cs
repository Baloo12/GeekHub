using System.Collections;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GeekHub.SteamProvider.Web.Client
{
    public class ExceptionResponse
    {
        public string Type { get; set; }
 
        public string Message { get; set; }
 
        public IDictionary Data { get; set; }
 
        public int StatusCode { get; set; }
 
        [JsonConverter(typeof(StringEnumConverter))]
        public LogLevel LogLevel { get; set; } = LogLevel.Error;
    }
}