using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using RaidPlannerClient.Model;
using RaidPlannerClient.Service;

namespace RaidPlannerClient.Components
{
    public partial class RaidForm
    {

        [Parameter]
        public Raid Raid { get; set; }

        [Parameter]
        public List<Player> Players { get; set; }

        [Parameter]
        public List<Instance> Instances { get; set; }

        [Parameter]
        public List<Approval> Approvals { get; set; }

        [Parameter]
        public IRaidService RaidService { get; set; }

        [Parameter]
        public IEncounterService EncounterService { get; set; }

        public List<Player> PlayersToSignup { get; set; }

        private string SignupCollapse = "collapse";
        private string EncountersCollapse = "collapse";

        public List<Player> GetUnsignedPlayers()
        {
            return Players.Where(p => !Raid.SignedUp.Contains((int)p.Id)).ToList();
        }

        public List<Player> GetSignedPlayers()
        {
            return Players.Where(p => Raid.SignedUp.Contains((int)p.Id)).ToList();
        }

        public void CollapseSignups()
        {
            if (SignupCollapse == "collapse")
            {
                SignupCollapse = "";
            }
            else
            {
                SignupCollapse = "collapse";
            }
        }

        public void CollapseEncounters()
        {
            if (EncountersCollapse == "collapse")
            {
                EncountersCollapse = "";
            }
            else
            {
                EncountersCollapse = "collapse";
            }
        }

        public async Task Signup(Player player)
        {
            Console.WriteLine($"Signing player {player.Name}");
            Raid.SignedUp.Add((int)player.Id);
            await RaidService.Signup(Raid, player);
        }

        public async Task Unsign(Player player)
        {
            Console.WriteLine($"Unsigning player {player.Name}");
            Raid.SignedUp.Remove((int)player.Id);
            await RaidService.Unsign(Raid, player);
        }
    }
}