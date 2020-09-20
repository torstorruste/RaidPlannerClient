using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using RaidPlannerClient.Model;

namespace RaidPlannerClient.Service
{
    public class PlayerService : IPlayerService
    {
        private readonly HttpClient httpClient;

        public PlayerService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public void AddPlayer(Player player)
        {
            // TODO: Implement
        }

        public async Task<List<Player>> GetPlayers()
        {
            Console.WriteLine("PlayerService::GetPlayers");
            return await httpClient.GetFromJsonAsync<List<Player>>("/players");
        }
    }
}