using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace Savvy.Services.API.Contracts.V1.Responses
{
    public class ErrorDetailsResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public Guid ExceptionId { get; set; }
        public bool Success { get; set; }
        public override string ToString()
        {
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            return JsonConvert.SerializeObject(this, serializerSettings);
        }
    }
}
