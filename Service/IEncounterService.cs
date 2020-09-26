using System.Threading.Tasks;
using RaidPlannerClient.Model;

namespace RaidPlannerClient.Service {

    public interface IEncounterService {
        Task<Encounter> AddEncounter(Raid raid, Encounter encounter);

        Task DeleteEncounter(Raid raid, Encounter encounter);

        Task AddCharacter(Raid raid, Encounter encounter, EncounterCharacter character);

        Task DeleteCharacter(Raid raid, Encounter encounter, EncounterCharacter character);
    }
}