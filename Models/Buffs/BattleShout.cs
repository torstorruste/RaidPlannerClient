using System.Collections.Generic;
using System.Linq;

namespace RaidPlannerClient.Model.Buff
{
    public class BattleShout : Buff
    {
        private readonly List<Character> characters;

        public BattleShout(List<Character> characters) {
            this.characters = characters;
        }

        public string GetName()
        {
            return "Battle Shout";
        }

        public bool HasBuff(Encounter encounter)
        {
            foreach(EncounterCharacter character in encounter.Characters) {
                if(characters.Any(c=>c.CharacterClass==CharacterClass.Warrior)) {
                    return true;
                }
            }
            return false;
        }

        public string GetImageName() {
            return "battleshout.jpg";
        }
    }
}