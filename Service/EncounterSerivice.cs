using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RaidPlannerClient.Model;

namespace RaidPlannerClient.Service {
    public class EncounterService : IEncounterService {
        private readonly HttpClient httpClient;

        public EncounterService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Task<Encounter> AddEncounter(Raid raid, Encounter encounter)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteEncounter(Raid raid, Encounter encounter)
        {
            throw new System.NotImplementedException();
        }

        public async Task AddCharacter(Raid raid, Encounter encounter, EncounterCharacter character)
        {
            Console.WriteLine("EncounterService::AddCharacter");

            var jsonToPost = JsonConvert.SerializeObject(character);
            var path = $"raids/{raid.Id}/encounters/{encounter.Id}/characters";
            Console.WriteLine($"POSTing to {path}");
            var result = await httpClient.PostAsync(path, new StringContent(jsonToPost, Encoding.UTF8, "application/json"));
            result.EnsureSuccessStatusCode();
        }

        public async Task DeleteCharacter(Raid raid, Encounter encounter, EncounterCharacter character)
        {
            Console.WriteLine("EncounterService::DeleteCharacter");

            var jsonToPost = JsonConvert.SerializeObject(character);
            var path = $"raids/{raid.Id}/encounters/{encounter.Id}/characters/{character.CharacterId}";
            Console.WriteLine($"DELETEing to {path}");
            var result = await httpClient.DeleteAsync(path);
            result.EnsureSuccessStatusCode();
        }
    }
}