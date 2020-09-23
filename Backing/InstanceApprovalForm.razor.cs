using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using RaidPlannerClient.Model;
using RaidPlannerClient.Pages;
using RaidPlannerClient.Service;

namespace RaidPlannerClient.Components
{
    public partial class InstanceApprovalForm
    {

        [Parameter]
        public Instance Instance { get; set; }

        [Parameter]
        public Approvals Approvals { get; set; }

        private string Collapse = "collapse";

        public List<Player> GetPlayers() {
            return Approvals.GetPlayers();
        }

        public void ToggleCollapse() {
            if(Collapse=="collapse") {
                Collapse = "";
            } else {
                Collapse = "collapse";
            }
        }
    }
}