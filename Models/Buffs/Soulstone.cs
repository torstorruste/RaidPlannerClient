using System.Collections.Generic;
using System.Linq;

namespace RaidPlannerClient.Model.Buff
{
    public class Soulstone : Buff
    {
        public Soulstone(List<Character> characters) : base(characters) {
        }

        public override string GetName()
        {
            return "Soulstone";
        }

        public override bool HasBuff(Encounter encounter)
        {
            return ContainsCharacterOfClass(encounter, CharacterClass.Warlock);
        }

        public override string GetImageName() {
            return "soulstone.jpg";
        }
    }
}