using System.Text.Json.Serialization;

namespace ExamenII_Backend.Dtos
{
    public class ResponseDto
    {
        public bool Status { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }
        public string Message { get; set; }
        //public T Data { get; set; }
    }
}
