using System;
using System.Collections.Generic;
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

        public Boolean IsTank { get; set; }
        public Boolean IsHealer { get; set; }
        public Boolean IsMelee { get; set; }
        public Boolean IsRanged { get; set; }

        public async void HandleValidSubmit()
        {
            Console.WriteLine("CharacterForm::HandleValidSubmit");
            Console.WriteLine($"Is Tank: {IsTank}");
            Console.WriteLine($"Is Healer: {IsHealer}");
            Console.WriteLine($"Is Melee: {IsMelee}");
            Console.WriteLine($"Is Ranged: {IsRanged}");
            Character.Roles = GetRolesFromCheckboxes();
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

        public async void DeleteCharacter() {
            characterService.DeleteCharacter(Player, Character);
            PlayerForm.DeleteCharacter(Character);
        }

        public List<Role> GetRolesFromCheckboxes() {
            List<Role> roles = new List<Role>();

            if(IsTank) roles.Add(Role.Tank);
            if(IsHealer) roles.Add(Role.Healer);
            if(IsMelee) roles.Add(Role.Melee);
            if(IsRanged) roles.Add(Role.Ranged);

            return roles;
        }

        public void SetRolesFromCharacter(List<Role> roles) {
            IsTank = roles.Contains(Role.Tank);
            IsHealer = roles.Contains(Role.Healer);
            IsMelee = roles.Contains(Role.Melee);
            IsRanged = roles.Contains(Role.Ranged);
        }

        protected override void OnParametersSet() {
            if(Character != null && Character.Roles != null) {
                Console.WriteLine("Character is set, updating checkboxes");
                SetRolesFromCharacter(Character.Roles);
            } else {
                Console.WriteLine("Character is not set");
            }
        }
    }
}