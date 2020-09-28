using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using RaidPlannerClient.Model;
using RaidPlannerClient.Pages;
using RaidPlannerClient.Service;

namespace RaidPlannerClient.Components
{
    public partial class RaidForm : ComponentBase
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
        public Raids Raids { get; set; }

        [Inject]
        public IRaidService RaidService { get; set; }

        [Inject]
        public IEncounterService EncounterService { get; set; }

        [Inject]
        private IJSRuntime JSRuntime { get; set; }

        private string Collapse = "collapse";
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

        public void ToggleCollapse()
        {
            if (Collapse == "collapse")
            {
                Collapse = "";
            }
            else
            {
                Collapse = "collapse";
            }
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
            if(!Raid.Finalized) {
                Console.WriteLine($"Signing player {player.Name}");
                Raid.SignedUp.Add((int)player.Id);
                await RaidService.Signup(Raid, player);
            }
        }

        public async Task Unsign(Player player)
        {
            if(!Raid.Finalized) {
                Console.WriteLine($"Unsigning player {player.Name}");
                Raid.SignedUp.Remove((int)player.Id);
                await RaidService.Unsign(Raid, player);
            }
        }

        public async Task DeleteRaid()
        {
            bool confirmed = await JSRuntime.InvokeAsync<bool>("confirm", $"Are you sure you want to raid {Raid.Date.ToString("yyyy-MM-dd")}?");
            if(confirmed) {
                await RaidService.DeleteRaid(Raid);
                Raids.DeleteRaid(Raid);
            }
        }
        internal void AddEncounter(Encounter encounter)
        {
            if(!Raid.Finalized) {
                Raid.Encounters.Add(encounter);
                StateHasChanged();
            }
        }

        internal void DeleteEncounter(Encounter encounter)
        {
            if(!Raid.Finalized) {
                Raid.Encounters.Remove(encounter);
                StateHasChanged();
            }
        }

        internal async void ToggleFinalize() {
            Raid.Finalized = !Raid.Finalized;
            Raid = await RaidService.UpdateRaid(Raid);
            StateHasChanged();
        }
    }
}