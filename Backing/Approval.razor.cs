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

        public async Task AddApproval(Boss boss, Character character)
        {
            Console.WriteLine($"AddApproval {boss.Name}, {character.Name}");
            Player player = GetByCharacter(character);
            Instance instance = GetByBoss(boss);
            await approvalService.AddApproval(player, character, instance, boss);
            approvals.Add(new Approval { Character = character, Boss = boss });
        }

        public async Task RemoveApproval(Boss boss, Character character)
        {
            Console.WriteLine($"RemoveApproval {boss.Name}, {character.Name}");
            Player player = GetByCharacter(character);
            Instance instance = GetByBoss(boss);
            await approvalService.RemoveApproval(player, character, instance, boss);
            approvals.RemoveAll(x=>x.Character.Id==character.Id && x.Boss.Id==boss.Id);
        }

        public List<Instance> GetInstances()
        {
            return instances;
        }

        private Player GetByCharacter(Character character)
        {
            return players.Find(p => p.Characters.Exists(c => c.Id == character.Id));
        }

        private Instance GetByBoss(Boss boss)
        {
            return instances.Find(i => i.Bosses.Exists(b => b.Id == boss.Id));;
        }
    }
}