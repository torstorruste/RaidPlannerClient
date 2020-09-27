using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
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

        [Inject]
        private IJSRuntime JSRuntime { get; set; }

        [Inject]
        private ToastService ToastService { get; set; }

        public Boolean IsTank { get; set; }
        public Boolean IsHealer { get; set; }
        public Boolean IsMelee { get; set; }
        public Boolean IsRanged { get; set; }

        private String originalName;
        private CharacterClass originalClass;

        public async void HandleValidSubmit()
        {
            Console.WriteLine("CharacterForm::HandleValidSubmit");
            if (IsChanged())
            {
                Character.Roles = GetRolesFromCheckboxes();
                if (Character.Id == null && Character.Name == null && Character.Name != "")
                {
                    Console.WriteLine("Id and name are null, doing nothing");
                }
                else if (Character.Id == null)
                {
                    Character = await characterService.AddCharacter(Player, Character);
                    PlayerForm.AddCharacter(Character);
                    ToastService.UpdateMessage(this, $"Successfully added {Character.Name}", ToastLevel.Success);
                }
                else
                {
                    characterService.UpdateCharacter(Player, Character);
                    PlayerForm.UpdateCharacters();
                    ToastService.UpdateMessage(this, $"Successfully updated {Character.Name}", ToastLevel.Success);
                }
                originalClass = Character.CharacterClass;
                originalName = Character.Name;
            }
        }

        private bool IsChanged()
        {
            if (HasRole(Role.Tank) != IsTank) return true;
            if (HasRole(Role.Healer) != IsHealer) return true;
            if (HasRole(Role.Melee) != IsMelee) return true;
            if (HasRole(Role.Ranged) != IsRanged) return true;
            if (Character.Name != originalName) return true;
            if (Character.CharacterClass != originalClass) return true;
            return false;
        }

        private bool HasRole(Role role)
        {
            return Character.Roles!=null &&  Character.Roles.Contains(role);
        }

        public void UpdateRole(Role role, object checkedValue)
        {
            Console.WriteLine("UpdateRole");
            switch (role)
            {
                case Role.Tank:
                    IsTank = (bool)checkedValue;
                    break;
                case Role.Healer:
                    IsHealer = (bool)checkedValue;
                    break;
                case Role.Melee:
                    IsMelee = (bool)checkedValue;
                    break;
                case Role.Ranged:
                    IsRanged = (bool)checkedValue;
                    break;
            }

            HandleValidSubmit();
        }

        public async void DeleteCharacter()
        {
            bool confirmed = await JSRuntime.InvokeAsync<bool>("confirm", $"Are you sure you want to delete {Character.Name}?");
            if (confirmed)
            {
                characterService.DeleteCharacter(Player, Character);
                PlayerForm.DeleteCharacter(Character);
                ToastService.UpdateMessage(this, $"Successfully deleted {Character.Name}", ToastLevel.Success);
            }
        }

        public List<Role> GetRolesFromCheckboxes()
        {
            List<Role> roles = new List<Role>();

            if (IsTank) roles.Add(Role.Tank);
            if (IsHealer) roles.Add(Role.Healer);
            if (IsMelee) roles.Add(Role.Melee);
            if (IsRanged) roles.Add(Role.Ranged);

            return roles;
        }

        public void SetRolesFromCharacter(List<Role> roles)
        {
            IsTank = roles.Contains(Role.Tank);
            IsHealer = roles.Contains(Role.Healer);
            IsMelee = roles.Contains(Role.Melee);
            IsRanged = roles.Contains(Role.Ranged);
        }

        protected override void OnParametersSet()
        {
            originalClass = Character.CharacterClass;
            originalName = Character.Name;
            if (Character != null && Character.Roles != null)
            {
                SetRolesFromCharacter(Character.Roles);
            }
            else
            {
                IsTank = false;
                IsHealer = false;
                IsMelee = false;
                IsRanged = false;
            }
        }

        public List<CharacterClass> GetClasses()
        {
            return new List<CharacterClass>{CharacterClass.DeathKnight, CharacterClass.DemonHunter, CharacterClass.Druid,
            CharacterClass.Hunter, CharacterClass.Mage, CharacterClass.Monk, CharacterClass.Paladin, CharacterClass.Priest,
            CharacterClass.Rogue, CharacterClass.Shaman, CharacterClass.Warlock, CharacterClass.Warrior};
        }
    }
}