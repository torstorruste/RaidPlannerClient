using Newtonsoft.Json;

namespace RaidPlannerClient.Model
{
    public class Boss
    {
        [JsonProperty("id")]
        public int? Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }

    }
}