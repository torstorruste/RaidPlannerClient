using System;
using Microsoft.AspNetCore.Components;
using RaidPlannerClient.Model;
using RaidPlannerClient.Service;

namespace RaidPlannerClient.Components
{
    public partial class PlayerForm
    {
        [Parameter]
        public Player Player { get; set; }
        
        [Inject]
        private IPlayerService playerService { get; set; }

        private string Collapse = "collapse";
        private Character newCharacter = new Character();

        public async void HandleValidSubmit()
        {
            Console.WriteLine("PlayerForm::HandleValidSubmit");
            if(Player.Id==null) {
                Player = await playerService.AddPlayer(Player);
            } else {
                playerService.UpdatePlayer(Player);
            }
        }

        public void ToggleCollapse() {
            Console.WriteLine("PlayerForm::ToggleCollapse");
            if(Collapse=="collapse") {
                Collapse = "";
            } else {
                Collapse = "collapse";
            }
        }
    }
}