using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using RaidPlannerClient.Model;
using RaidPlannerClient.Service;

namespace RaidPlannerClient.Components
{
    public partial class BossForm
    {
        [Parameter]
        public Instance Instance { get; set; }

        [Parameter]
        public Boss Boss { get; set; }

        [Parameter]
        public InstanceForm InstanceForm { get; set; }

        [Inject]
        public IInstanceService instanceService { get; set; }

        [Inject]
        public IBossService bossService { get; set; }

        [Inject]
        private IJSRuntime JSRuntime { get; set; }

        public async void HandleValidSubmit()
        {
            Console.WriteLine("BossForm::HandleValidSubmit");
            if (Boss.Id == null)
            {
                Boss = await bossService.AddBoss(Instance, Boss);
                InstanceForm.AddBoss(Boss);
            }
            else
            {
                bossService.UpdateBoss(Instance, Boss);
                InstanceForm.UpdateBosses();
            }
        }

        public async void DeleteBoss()
        {
            bool confirmed = await JSRuntime.InvokeAsync<bool>("confirm", $"Are you sure you want to delete {Boss.Name}?");
            if (confirmed)
            {
                bossService.DeleteBoss(Instance, Boss);
                InstanceForm.DeleteBoss(Boss);
            }
        }
    }
}