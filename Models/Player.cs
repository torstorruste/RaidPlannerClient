using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RaidPlannerClient.Model
{
    public class Player
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        public List<Character> Characters { get; set; }
    }
}