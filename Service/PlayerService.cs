using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using RaidPlannerClient.Model;
using Newtonsoft.Json;
using System.Text;

namespace RaidPlannerClient.Service
{
    public class PlayerService : IPlayerService
    {
        private readonly HttpClient httpClient;

        public PlayerService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Player> AddPlayer(Player player)
        {
            Console.WriteLine("PlayerService::AddPlayer");
            
            var playerJson = JsonConvert.SerializeObject(player);
            Console.WriteLine("POSTing to players");
            var result = await httpClient.PostAsync("players", new StringContent(playerJson, Encoding.UTF8, "application/json"));
            result.EnsureSuccessStatusCode();

            var json = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Player>(json);
        }

        public async void UpdatePlayer(Player player)
        {
            Console.WriteLine("PlayerService::UpdatePlayer");
            
            var playerJson = JsonConvert.SerializeObject(player);
            Console.WriteLine($"PUTing to players/{player.Id}");
            var result = await httpClient.PutAsync($"players/{player.Id}", new StringContent(playerJson, Encoding.UTF8, "application/json"));
            result.EnsureSuccessStatusCode();
        }

        public async Task<List<Player>> GetPlayers()
        {
            Console.WriteLine("PlayerService::GetPlayers");

            Console.WriteLine("GETting players");
            var result = await httpClient.GetAsync("/players");
            result.EnsureSuccessStatusCode();

            var json = await result.Content.ReadAsStringAsync();
            var players = JsonConvert.DeserializeObject<List<Player>>(json);

            foreach(var player in players) {
                player.Characters.Sort((a,b)=>a.Name.CompareTo(b.Name));
            }

            return players;
        }
    }
}