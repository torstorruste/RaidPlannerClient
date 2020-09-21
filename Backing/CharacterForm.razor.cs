using System;
using Microsoft.AspNetCore.Components;
using RaidPlannerClient.Model;
using RaidPlannerClient.Service;

namespace RaidPlannerClient.Components
{
    public partial class CharacterForm
    {
        [Parameter]
        public Player Player { get; set; }

        [Parameter]
        public Character Character { get; set; }

        [Parameter]
        public PlayerForm PlayerForm { get; set; }

        [Inject]
        public ICharacterService characterService { get; set; }

        public async void HandleValidSubmit()
        {
            Console.WriteLine("CharacterForm::HandleValidSubmit");
            if (Character.Id == null)
            {
                Character = await characterService.AddCharacter(Player, Character);
                PlayerForm.AddCharacter(Character);
            }
            else
            {
                characterService.UpdateCharacter(Player, Character);
                PlayerForm.UpdateCharacters();
            }
        }
    }
}