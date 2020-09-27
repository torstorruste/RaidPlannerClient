using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RaidPlannerClient.Model;

namespace RaidPlannerClient.Service {
    public class BossService : IBossService {
        private readonly HttpClient httpClient;

        public BossService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<Boss> AddBoss(Instance instance, Boss boss) {
            Console.WriteLine("BossService::AddBoss");

            var json = JsonConvert.SerializeObject(boss);
            Console.WriteLine($"POSTing to rest/instances/{instance.Id}/bosses");
            var result = await httpClient.PostAsync($"rest/instances/{instance.Id}/bosses", new StringContent(json, Encoding.UTF8, "application/json"));
            result.EnsureSuccessStatusCode();

            var resultJson = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Boss>(resultJson);
        }

        public async void UpdateBoss(Instance instance, Boss boss) {
            Console.WriteLine("BossService::UpdateBoss");

            var json = JsonConvert.SerializeObject(boss);
            Console.WriteLine($"PUTing to rest/instances/{instance.Id}/bosses/{boss.Id}");
            var result = await httpClient.PutAsync($"rest/instances/{instance.Id}/bosses/{boss.Id}", new StringContent(json, Encoding.UTF8, "application/json"));
            result.EnsureSuccessStatusCode();
        }
        public async void DeleteBoss(Instance instance, Boss Boss) {
            Console.WriteLine("BossService::DeleteBoss");

            Console.WriteLine($"DELETEing to rest/instances/{instance.Id}/bosses/{Boss.Id}");
            var result = await httpClient.DeleteAsync($"rest/instances/{instance.Id}/bosses/{Boss.Id}");
            result.EnsureSuccessStatusCode();
        }
    }
}