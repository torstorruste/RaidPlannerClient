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
        private Player newPlayer = new Player{Characters= new List<Character>()};

        [Inject]
        private IPlayerService playerService { get; set; }

        public async Task<List<Player>> GetPlayers()
        {
            Console.WriteLine("Players::GetPlayers");
            return await playerService.GetPlayers();
        }

        protected override async Task OnInitializedAsync()
        {
            Console.WriteLine("Players::OnInitializedAsync");
            players = await GetPlayers();
        }

        public void AddPlayer(Player player) {
            newPlayer = new Player{Characters= new List<Character>()};
            players.Add(player);
            UpdatePlayers();
        }

        internal void DeletePlayer(Player player)
        {
            players.Remove(player);
            UpdatePlayers();
        }

        private void UpdatePlayers() {
            players.Sort((a,b)=>a.Name.CompareTo(b.Name));
            StateHasChanged();
        }
    }
}