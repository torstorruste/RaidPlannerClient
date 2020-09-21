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
        private Player player = new Player { Name = "New Player", Characters = new List<Character> { new Character { Name = "New Character" } } };

        public void HandleValidSubmit()
        {
            Console.WriteLine("PlayerForm::HandleValidSubmit");
        }
    }
}