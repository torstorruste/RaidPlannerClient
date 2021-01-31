using System.Collections.Generic;

namespace RaidPlannerClient.Model.Buff
{
    public class Fortitude : Buff
    {
        public Fortitude(List<Character> characters) : base(characters) {
        }

        public override string GetName()
        {
            return "Fortitude";
        }

        public override bool HasBuff(Encounter encounter)
        {
            return ContainsCharacterOfClass(encounter, CharacterClass.Priest);
        }

        public override string GetImageName() {
            return "fortitude.jpg";
        }
    }
}