using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using RaidPlannerClient.Model;
using RaidPlannerClient.Service;

namespace RaidPlannerClient.Pages
{
    public partial class Raids : ComponentBase
    {
        private List<Raid> raids;

        private List<Player> players;

        [Inject]
        private IRaidService raidService { get; set; }

        [Inject]
        private IPlayerService playerService { get; set; }


        protected override async Task OnInitializedAsync()
        {
            Console.WriteLine("Raids::OnInitializedAsync");
            raids = await raidService.GetRaids();
            players = await playerService.GetPlayers();
        }
    }
}