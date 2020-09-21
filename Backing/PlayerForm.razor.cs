using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using RaidPlannerClient.Model;

namespace RaidPlannerClient.Components
{
    public partial class PlayerForm
    {
        [Parameter]
        public Player Player { get; set; }

        private bool Collapsed = true;

        public void HandleValidSubmit()
        {
            Console.WriteLine("PlayerForm::HandleValidSubmit");
        }

        public void ToggleCollapse() {
            Console.WriteLine("PlayerForm::ToggleCollapse");
            Collapsed = !Collapsed;
        }
    }
}