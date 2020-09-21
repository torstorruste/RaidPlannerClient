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
        private Player newPlayer = new Player{Name="New Player", Characters=new List<Character>{new Character{Name="New Character"}}};

        [Inject]
        private IPlayerService playerService { get; set; }

        public async Task<List<Player>> GetPlayers()
        {
            Console.WriteLine("Players::GetPlayers");
            return await playerService.GetPlayers();
        }

        public void AddPlayer()
        {
            Console.WriteLine("Add players");
            players = new List<Player>();
        }

        public async void RefreshPlayers() {
            Console.WriteLine("Refresh players");
            players = await GetPlayers();
            StateHasChanged();
        }

        protected override async Task OnInitializedAsync()
        {
            Console.WriteLine("Players::OnInitializedAsync");
            players = await GetPlayers();
        }
    }
}