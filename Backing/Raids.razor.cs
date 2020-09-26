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

        private List<Instance> instances;

        private List<Approval> approvals;

        [Inject]
        private IRaidService raidService { get; set; }

        [Inject]
        private IPlayerService playerService { get; set; }

        [Inject]
        private IInstanceService instanceService { get; set; }

        [Inject]
        private IApprovalService approvalService { get; set; }

        [Inject]
        private IEncounterService encounterService { get; set; }


        protected override async Task OnInitializedAsync()
        {
            Console.WriteLine("Raids::OnInitializedAsync");
            raids = await raidService.GetRaids();
            players = await playerService.GetPlayers();
            instances = await instanceService.GetInstances();
            approvals = await approvalService.GetApprovals();
        }
    }
}