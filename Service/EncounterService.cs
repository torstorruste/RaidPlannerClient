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

        public async Task<Encounter> AddEncounter(Raid raid, Boss boss)
        {
            Console.WriteLine("EncounterService::AddEncounter");

            var jsonToPost = JsonConvert.SerializeObject(boss);
            var path = $"raids/{raid.Id}/encounters";
            Console.WriteLine($"POSTing to {path}");
            var result = await httpClient.PostAsync(path, new StringContent(jsonToPost, Encoding.UTF8, "application/json"));
            
            result.EnsureSuccessStatusCode();
            var json = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Encounter>(json);
        }

        public async Task DeleteEncounter(Raid raid, Encounter encounter)
        {
            Console.WriteLine("EncounterService::AddEncounter");

            var jsonToPost = JsonConvert.SerializeObject(encounter);
            var path = $"raids/{raid.Id}/encounters/{encounter.Id}";
            Console.WriteLine($"DELETEing to {path}");
            var result = await httpClient.DeleteAsync(path);
            result.EnsureSuccessStatusCode();
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