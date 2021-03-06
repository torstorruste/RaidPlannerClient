using System;
using System.Collections.Generic;
using System.Linq;

namespace RaidPlannerClient.Model.Buff
{
    public class BattleShout : Buff
    {
        public BattleShout(List<Character> characters) : base (characters) {
        }

        public override string GetName()
        {
            return "Battle Shout";
        }

        public override bool HasBuff(Encounter encounter)
        {
            return ContainsCharacterOfClass(encounter, CharacterClass.Warrior);
        }

        public override string GetImageName() {
            return "battleshout.jpg";
        }
    }
}