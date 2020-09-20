using System.Collections.Generic;

namespace org.superhelt.Blazor
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CharacterClass CharacterClass { get; set; }
        public List<Role> Roles { get; set; }

    }
}