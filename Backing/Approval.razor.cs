using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using RaidPlannerClient.Model;
using RaidPlannerClient.Service;

namespace RaidPlannerClient.Pages
{
    public partial class Approvals : ComponentBase
    {
        private List<Player> players;

        private List<Instance> instances;

        private List<Approval> approvals;

        [Inject]
        private IApprovalService approvalService { get; set; }

        [Inject]
        private IPlayerService playerService { get; set; }

        [Inject]
        private IInstanceService instanceService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Console.WriteLine("Approval::OnInitializedAsync");
            players = await playerService.GetPlayers();
            instances = await instanceService.GetInstances();
            approvals = await approvalService.GetApprovals();

            Console.WriteLine($"Fetched {players.Count} players, {instances.Count} instances and {approvals.Count} approvals");
        }

        public bool IsApproved(Boss boss, Character character)
        {
            return approvals.Exists(a => a.Boss.Id == boss.Id && a.Character.Id == character.Id);
        }

        public List<Instance> GetInstances()
        {
            return instances;
        }
    }
}