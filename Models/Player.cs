using System.Collections.Generic;

namespace org.superhelt.Blazor
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Character> Characters { get; set; }
    }
}