using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace RaidPlannerClient.Mode
{
    public class Raid
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("encounters")]
        public List<Encounter> Encounters { get; set; }

        [JsonProperty("signedUp")]
        public List<int> SignedUp { get; set; }
    }
}