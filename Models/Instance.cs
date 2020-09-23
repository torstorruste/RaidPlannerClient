using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace RaidPlannerClient.Model
{
    public class Instance
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("bosses")]
        public List<Boss> Bosses { get; set; }
    }
}