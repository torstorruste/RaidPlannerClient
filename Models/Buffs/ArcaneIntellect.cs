using System.Collections.Generic;
using System.Linq;

namespace RaidPlannerClient.Model.Buff
{
    public class ArcaneIntellect : Buff
    {
        public ArcaneIntellect(List<Character> characters) : base(characters) {
        }

        public override string GetName()
        {
            return "Intellect";
        }

        public override bool HasBuff(Encounter encounter)
        {
            return ContainsCharacterOfClass(encounter, CharacterClass.Mage);
        }

        public override string GetImageName() {
            return "intellect.jpg";
        }
    }
}