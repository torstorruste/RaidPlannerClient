using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
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

        [Inject]
        private ToastService ToastService { get; set; }

        private string previousName;

        protected override void OnParametersSet()
        {
            previousName = Boss.Name;
        }

        public async void DeleteBoss()
        {
            bool confirmed = await JSRuntime.InvokeAsync<bool>("confirm", $"Are you sure you want to delete {Boss.Name}?");
            if (confirmed)
            {
                bossService.DeleteBoss(Instance, Boss);
                InstanceForm.DeleteBoss(Boss);
                ToastService.UpdateMessage(this, $"Successfully deleted {Boss.Name}", ToastLevel.Success);
            }
        }

        async void OnFocusOutHandler(FocusEventArgs e)
        {
            if (previousName != Boss.Name)
            {
                Console.WriteLine("Focus handler updating boss");
                if (Boss.Id == null)
                {
                    Boss = await bossService.AddBoss(Instance, Boss);
                    InstanceForm.AddBoss(Boss);
                    ToastService.UpdateMessage(this, $"Successfully added boss {Boss.Name}", ToastLevel.Success);
                }
                else
                {
                    bossService.UpdateBoss(Instance, Boss);
                    InstanceForm.UpdateBosses();
                    ToastService.UpdateMessage(this, $"Successfully updated boss {Boss.Name}", ToastLevel.Success);
                }
            }
            else
            {
                Console.WriteLine("Focus handler doing nothing!");
            }
            previousName = Boss.Name;
        }
    }
}