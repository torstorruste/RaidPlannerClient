using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace RaidPlannerClient.Model
{
    public class Player
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("characters")]
        public List<Character> Characters { get; set; }
    }
}