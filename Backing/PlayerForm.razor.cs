using System;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using RaidPlannerClient.Model;
using RaidPlannerClient.Pages;
using RaidPlannerClient.Service;

namespace RaidPlannerClient.Components
{
    public partial class PlayerForm
    {
        [Parameter]
        public Player Player { get; set; }

        [Parameter]
        public Players Players { get; set; }

        [Inject]
        private IPlayerService playerService { get; set; }

        [Inject]
        private IJSRuntime JSRuntime { get; set; }

        private string Collapse = "collapse";
        private Character newCharacter = new Character();

        public async void HandleValidSubmit()
        {
            Console.WriteLine("PlayerForm::HandleValidSubmit");
            if (Player.Id == null)
            {
                Player = await playerService.AddPlayer(Player);
                Players.AddPlayer(Player);
            }
            else
            {
                playerService.UpdatePlayer(Player);
            }
        }

        public void AddCharacter(Character character)
        {
            newCharacter = new Character();
            Player.Characters.Add(character);
            UpdateCharacters();
        }

        public void UpdateCharacters()
        {
            Player.Characters.Sort((a, b) => a.Name.CompareTo(b.Name));
            StateHasChanged();
        }

        public void ToggleCollapse()
        {
            Console.WriteLine("PlayerForm::ToggleCollapse");
            if (Collapse == "collapse")
            {
                Collapse = "";
            }
            else
            {
                Collapse = "collapse";
            }
        }

        public async void DeletePlayer()
        {
            bool confirmed = await JSRuntime.InvokeAsync<bool>("confirm", $"Are you sure you want to delete {Player.Name}?");
            if (confirmed)
            {
                playerService.DeletePlayer(Player);
                Players.DeletePlayer(Player);
            }
        }

        internal void DeleteCharacter(Character character)
        {
            Player.Characters.Remove(character);
            UpdateCharacters();
        }
    }
}