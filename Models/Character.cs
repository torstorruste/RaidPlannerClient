using System.Collections.Generic;

namespace RaidPlannerClient.Model
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CharacterClass { get; set; }
        public List<string> Roles { get; set; }

    }
}