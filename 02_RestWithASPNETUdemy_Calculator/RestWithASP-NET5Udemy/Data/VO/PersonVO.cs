using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace RestWithASP_NET5Udemy.Data.VO 
{
    public class PersonVO
    {
        // Até a versão 3.1 era assim que se ordenava [DataMember(Order = 1, Name = "ID")]
        //[JsonPropertyName("code")]
        public long Id { get; set; }

        //[JsonPropertyName("name")]
        public string FirstName { get; set; }

        //[JsonPropertyName("Last_Name")]
        public string LastName { get; set; }

        //[JsonPropertyName("Sex")]
        public string Gender { get; set; }

        //[JsonIgnore]
        public string Address { get; set; }


    }
}
