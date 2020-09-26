using System.Net.Http;
using System.Threading.Tasks;
using RaidPlannerClient.Model;

namespace RaidPlannerClient.Service {
    public class EncounterService : IEncounterService {
        private readonly HttpClient httpClient;

        public EncounterService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Task AddCharacter(Raid raid, Encounter encounter, EncounterCharacter character)
        {
            throw new System.NotImplementedException();
        }

        public Task<Encounter> AddEncounter(Raid raid, Encounter encounter)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteCharacter(Raid raid, Encounter encounter, EncounterCharacter character)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteEncounter(Raid raid, Encounter encounter)
        {
            throw new System.NotImplementedException();
        }
    }
}