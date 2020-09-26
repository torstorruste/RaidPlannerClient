using Newtonsoft.Json;
using RaidPlannerClient.Model;

namespace RaidPlannerClient.Mode
{
    public class EncounterCharacter
    {
        [JsonProperty("playerId")]
        public int PlayerId { get; set; }

        [JsonProperty("characterId")]
        public int CharacterId { get; set; }

        [JsonProperty("role")]
        public Role Role { get; set; }
    }
}