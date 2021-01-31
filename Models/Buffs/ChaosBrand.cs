using System.Collections.Generic;
using System.Linq;

namespace RaidPlannerClient.Model.Buff
{
    public class ChaosBrand : Buff
    {
        public ChaosBrand(List<Character> characters) : base(characters) {
        }

        public override string GetName()
        {
            return "Chaos Brand";
        }

        public override bool HasBuff(Encounter encounter)
        {
            return ContainsCharacterOfClass(encounter, CharacterClass.DemonHunter);
        }

        public override string GetImageName() {
            return "chaosbrand.jpg";
        }
    }
}