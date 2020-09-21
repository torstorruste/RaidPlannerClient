using System.Threading.Tasks;
using RaidPlannerClient.Model;

namespace RaidPlannerClient.Service {
    public interface ICharacterService {
        Task<Character> AddCharacter(Player player, Character character);

        void UpdateCharacter(Player player, Character character);
    }
}