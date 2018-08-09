using System;
using Newtonsoft.Json;
using System.Net;
namespace ExtAppraisalApp.Models
{
    public class JsonResponseData
    {
        [JsonProperty("data")]
        public object Data { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public class SIMSResponseData{
        [JsonProperty("data")]
        public object Data { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("statuscode")]
        public string StatusCode { get; set; }
        
    }
}
