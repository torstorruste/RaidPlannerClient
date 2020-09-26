using System;
using Microsoft.AspNetCore.Components;
using RaidPlannerClient.Model;
using RaidPlannerClient.Pages;
using RaidPlannerClient.Service;

namespace RaidPlannerClient.Components
{
    public partial class NewRaidForm
    {
        public DateTime RaidDate { get; set; } = DateTime.Now;

        [Parameter]
        public IRaidService RaidService { get; set; }

        [Parameter]
        public Raids Raids { get; set; }

        public async void CreateNewRaid()
        {
            RaidDate = RaidDate.ToLocalTime();
            Console.WriteLine($"NewRaidForm::CreateNewRaid ({RaidDate})");
            Raid raid = await RaidService.AddRaid(new Raid { Date = RaidDate });
            Raids.AddRaid(raid);
            RaidDate = DateTime.Now;
        }
    }
}