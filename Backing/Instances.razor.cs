using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using RaidPlannerClient.Model;
using RaidPlannerClient.Service;

namespace RaidPlannerClient.Pages
{
    public partial class Instances : ComponentBase {
        
        private List<Instance> instances;

        private Instance newInstance = new Instance{Bosses = new List<Boss>()};

        [Inject]
        private IInstanceService instanceService { get; set; }

        public async Task<List<Instance>> GetInstances()
        {
            Console.WriteLine("Instances::GetInstances");
            return await instanceService.GetInstances();
        }

        protected override async Task OnInitializedAsync()
        {
            Console.WriteLine("Instances::OnInitializedAsync");
            instances = await GetInstances();
        }

        public void AddInstance(Instance Instance) {
            newInstance = new Instance{Bosses = new List<Boss>()};
            instances.Add(Instance);
            UpdateInstances();
        }

        internal void DeleteInstance(Instance Instance)
        {
            instances.Remove(Instance);
            UpdateInstances();
        }

        private void UpdateInstances() {
            instances.Sort((a,b)=>a.Name.CompareTo(b.Name));
            StateHasChanged();
        }
    }
}