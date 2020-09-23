using System;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using RaidPlannerClient.Model;
using RaidPlannerClient.Pages;
using RaidPlannerClient.Service;

namespace RaidPlannerClient.Components
{
    public partial class InstanceForm
    {
        [Parameter]
        public Instance Instance { get; set; }

        [Parameter]
        public Instances Instances { get; set; }
        
        [Inject]
        private IInstanceService instanceService { get; set; }

        [Inject]
        private IJSRuntime JSRuntime { get; set; }

        private string Collapse = "collapse";

        private Boss newBoss = new Boss();

        public async void HandleValidSubmit()
        {
            Console.WriteLine("InstanceForm::HandleValidSubmit");
            if (Instance.Id == null)
            {
                Instance = await instanceService.AddInstance(Instance);
                Instances.AddInstance(Instance);
            }
            else
            {
                instanceService.UpdateInstance(Instance);
            }
        }

        public void AddBoss(Boss boss)
        {
            newBoss = new Boss();
            Instance.Bosses.Add(boss);
            UpdateBosses();
        }

        public void UpdateBosses()
        {
            Instance.Bosses.Sort((a, b) => a.Name.CompareTo(b.Name));
            StateHasChanged();
        }

        public void DeleteBoss(Boss boss)
        {
            Instance.Bosses.Remove(boss);
            UpdateBosses();
        }

        public async void DeleteInstance()
        {
            bool confirmed = await JSRuntime.InvokeAsync<bool>("confirm", $"Are you sure you want to delete {Instance.Name}?");
            if (confirmed)
            {
                instanceService.DeleteInstance(Instance);
                Instances.DeleteInstance(Instance);
            }
        }

        public void ToggleCollapse()
        {
            Console.WriteLine("InstanceForm::ToggleCollapse");
            if (Collapse == "collapse")
            {
                Collapse = "";
            }
            else
            {
                Collapse = "collapse";
            }
        }
    }
}