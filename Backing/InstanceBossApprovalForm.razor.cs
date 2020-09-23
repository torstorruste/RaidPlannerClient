using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using RaidPlannerClient.Model;
using RaidPlannerClient.Pages;
using RaidPlannerClient.Service;
using System.Linq;

namespace RaidPlannerClient.Components
{
    public partial class InstanceBossApprovalForm
    {
        [Parameter]
        public Boss Boss { get; set; }

        [Parameter]
        public Instance Instance { get; set; }

        [Parameter]
        public Approvals Approvals { get; set; }

        private string Collapse = "collapse";

        public async void CheckboxClicked(Boss boss, Character character, object value)
        {
            Console.WriteLine($"CheckboxClicked: {boss.Name}, {character.Name}, {value}");
            if ((bool)value == true)
            {
                await Approvals.AddApproval(boss, character);
            }
            else
            {
                await Approvals.RemoveApproval(boss, character);
            }
            StateHasChanged();
        }

        public bool IsApproved(Boss boss, Character character)
        {
            var isApproved = Approvals.IsApproved(boss, character);
            Console.WriteLine($"IsApproved({boss.Name}, {character.Name}): {isApproved}");
            return isApproved;
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

        public List<Character> GetCharacters()
        {
            return Approvals.GetPlayers().SelectMany(x=>x.Characters).ToList();
        }
    }
}