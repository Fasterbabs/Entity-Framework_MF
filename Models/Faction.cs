using System.Text.Json.Serialization;

namespace Entity_Framework_MF.Models
{
    public class Faction
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public List<Character> Characters { get; set; }

    }
}
