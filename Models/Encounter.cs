using System.Collections.Generic;
using Newtonsoft.Json;

namespace RaidPlannerClient.Model
{
    public class Encounter
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("bossId")]
        public int BossId { get; set; }

        [JsonProperty("characters")]
        public List<EncounterCharacter> Characters { get; set; }
    }
}