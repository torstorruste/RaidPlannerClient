using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RaidPlannerClient.Service;

namespace RaidPlannerClient.Model
{
    public class Raid
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("encounters")]
        public List<Encounter> Encounters { get; set; }

        [JsonProperty("signedUp")]
        public List<int> SignedUp { get; set; }

        [JsonProperty("finalized")]
        public Boolean Finalized { get; set; }
    }
}