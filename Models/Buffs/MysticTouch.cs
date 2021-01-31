using System.Collections.Generic;
using System.Linq;

namespace RaidPlannerClient.Model.Buff
{
    public class MysticTouch : Buff
    {
        public MysticTouch(List<Character> characters) : base(characters) {
        }

        public override string GetName()
        {
            return "Mystic Touch";
        }

        public override bool HasBuff(Encounter encounter)
        {
            return ContainsCharacterOfClass(encounter, CharacterClass.Monk);
        }

        public override string GetImageName() {
            return "mystictouch.jpg";
        }
    }
}