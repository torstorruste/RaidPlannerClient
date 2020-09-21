using System.Collections.Generic;
using Newtonsoft.Json;

namespace RaidPlannerClient.Model
{
    public class Character
    {
        [JsonProperty("id")]
        public int? Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("characterClass")]
        public CharacterClass CharacterClass { get; set; }

        [JsonProperty("roles")]
        public List<Role> Roles { get; set; }

    }
}