using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using RaidPlannerClient.Model;
using RaidPlannerClient.Service;

namespace RaidPlannerClient.Pages
{
    public partial class Players
    {

        [Inject]
        private IPlayerService playerService { get; set; }

        public List<Player> GetPlayers()
        {
            return playerService.GetPlayers();
        }

        public void AddPlayer()
        {
            playerService.AddPlayer(new Player { Id = 3, Name = "Furo" });
        }
    }
}