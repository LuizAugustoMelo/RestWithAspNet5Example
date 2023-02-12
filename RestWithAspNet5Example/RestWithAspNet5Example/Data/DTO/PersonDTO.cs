using System.Text.Json;
using System.Text.Json.Serialization;

namespace RestWithAspNet5Example.Data.DTO
{
    public class PersonDTO
    {
        /*[JsonPropertyOrder(-5)]
        [JsonIgnore] // Used to ignore a field
        [JsonPropertyName("code")]//*/
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Gender { get; set; }
        
    }
}
