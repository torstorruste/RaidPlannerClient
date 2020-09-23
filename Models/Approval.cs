using System.Collections.Generic;
using Newtonsoft.Json;

namespace RaidPlannerClient.Model
{
    public class Approval
    {

        [JsonProperty("character")]
        public Character Character { get; set; }

        [JsonProperty("boss")]
        public Boss Boss { get; set; }

        [JsonProperty("roles")]
        public List<Role> Roles { get; set; }
    }
}