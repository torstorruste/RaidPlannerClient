using System.Collections.Generic;
using System.Linq;

namespace RaidPlannerClient.Model.Buff
{
    public abstract class Buff {

        private readonly Dictionary<int, Character> characterMap = new Dictionary<int, Character>();

        public Buff(List<Character> characters) {
            foreach(var character in characters) {
                characterMap.Add((int)character.Id, character);
            }
        }

        public abstract bool HasBuff(Encounter encounter);

        public abstract string GetName();

        public abstract string GetImageName();

        protected bool ContainsCharacterOfClass(Encounter encounter, CharacterClass characterClass) {
            if(encounter != null) {
                foreach(var encounterCharacter in encounter.Characters) {
                    var character = GetCharacter(encounterCharacter.CharacterId);
                    if(character != null) {
                        if(character.CharacterClass==characterClass) return true;
                    }
                }
            }
            return false;
        }

        private Character GetCharacter(int characterId)
        {
            if(characterMap.ContainsKey(characterId)) {
                return characterMap[characterId];
            }
            return null;
        }

    }

}