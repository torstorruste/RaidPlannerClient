using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RaidPlannerClient.Model;

namespace RaidPlannerClient.Service
{
    public class RaidService : IRaidService
    {
        private readonly HttpClient httpClient;

        public RaidService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Task<Raid> AddRaid(Raid raid)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteRaid(Raid raid)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Raid>> GetRaids()
        {
            Console.WriteLine("RaidService::GetRaids");

            Console.WriteLine("GETting raids");
            var result = await httpClient.GetAsync("/raids");
            result.EnsureSuccessStatusCode();

            var json = await result.Content.ReadAsStringAsync();
            var raids = JsonConvert.DeserializeObject<List<Raid>>(json);

            raids.Sort((a,b)=>b.Date.CompareTo(a.Date));

            return raids;
        }

        public async Task Signup(Raid raid, Player player)
        {
            Console.WriteLine("RaidService::Signup");

            var jsonToPost = JsonConvert.SerializeObject(player);
            var path = $"raids/{raid.Id}/signups";
            Console.WriteLine($"POSTing to {path}");
            var result = await httpClient.PostAsync(path, new StringContent(jsonToPost, Encoding.UTF8, "application/json"));
            result.EnsureSuccessStatusCode();
        }

        public async Task Unsign(Raid raid, Player player)
        {
            Console.WriteLine("RaidService::Unsign");

            var path = $"raids/{raid.Id}/signups/{player.Id}";
            Console.WriteLine($"DELETEing to {path}");
            var result = await httpClient.DeleteAsync(path);
            result.EnsureSuccessStatusCode();
        }
    }
}