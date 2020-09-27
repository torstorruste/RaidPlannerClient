using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using RaidPlannerClient.Model;
using RaidPlannerClient.Service;

namespace RaidPlannerClient.Components
{
    public partial class NewEncounterForm
    {
        [Parameter]
        public Raid Raid { get; set; }

        [Parameter]
        public List<Instance> Instances { get; set; }

        [Parameter]
        public RaidForm RaidForm { get; set; }

        [Inject]
        public IEncounterService EncounterService { get; set; }

        public Boss SelectedBoss { get; set; }

        private List<Boss> Bosses = new List<Boss> { new Boss { Name = "TestBoss" } };
        protected override void OnParametersSet()
        {
            Console.WriteLine("NewEncounterForm::OnParametersSet");
            UpdateList();
        }

        protected async override Task OnParametersSetAsync() {
            Console.WriteLine("NewEncounterForm::OnParametersSetAsync");
            UpdateList();
        }

        public async void AddEncounter()
        {
            if(SelectedBoss.Id!=null) {
                Console.WriteLine($"Preparing to add encounter for boss {SelectedBoss.Name}");
                var encounter = await EncounterService.AddEncounter(Raid, SelectedBoss);
                RaidForm.AddEncounter(encounter);
                UpdateList();
            }
        }

        public void UpdateList()
        {
            var addedBosses = Raid.Encounters.Select(e => e.BossId).ToList();
            Bosses = Instances.SelectMany(i => i.Bosses).Where(b => !addedBosses.Contains((int)b.Id)).ToList();
            if(Bosses.Count>0) {
                SelectedBoss = Bosses.FirstOrDefault();
                Console.WriteLine($"NewEncounterForm::OnParametersSet with {Bosses.Count} bosses");
            } else {
                SelectedBoss = new Boss{Name="No boss left to add"};
                Bosses.Add(SelectedBoss);
            }
        }
    }
}