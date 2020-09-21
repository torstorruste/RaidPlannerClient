using Microsoft.AspNetCore.Components;
using RaidPlannerClient.Model;

namespace RaidPlannerClient.Components
{
    public partial class CharacterForm
    {
        [Parameter]
        public Character Character { get; set; }
    }
}