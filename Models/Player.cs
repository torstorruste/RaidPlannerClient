using System.Collections.Generic;

namespace RaidPlannerClient.Model
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Character> Characters { get; set; }
    }
}