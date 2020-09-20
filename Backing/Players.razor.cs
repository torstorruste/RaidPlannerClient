using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using RaidPlannerClient.Model;
using RaidPlannerClient.Service;

namespace RaidPlannerClient.Pages
{
    public partial class Players : ComponentBase
    {
        private List<Player> players;

        [Inject]
        private IPlayerService playerService { get; set; }

        public async Task<List<Player>> GetPlayers()
        {
            Console.WriteLine("Players::GetPlayers");
            return await playerService.GetPlayers();
        }

        public void AddPlayer()
        {
            playerService.AddPlayer(new Player { Id = 3, Name = "Furo" });
        }
        protected override async Task OnInitializedAsync()
        {
            Console.WriteLine("Players::OnInitializedAsync");
            players = await GetPlayers();
        }
    }
}