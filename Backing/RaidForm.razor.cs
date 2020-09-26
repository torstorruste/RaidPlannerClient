using Microsoft.AspNetCore.Components;
using RaidPlannerClient.Model;

namespace RaidPlannerClient.Components
{
    public partial class RaidForm
    {

        [Parameter]
        public Raid Raid { get; set; }
    }
}