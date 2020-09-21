using System;
using Microsoft.AspNetCore.Components;
using RaidPlannerClient.Model;

namespace RaidPlannerClient.Components
{
    public partial class PlayerForm
    {
        private Player player = new Player();

        public void HandleValidSubmit()
        {
            Console.WriteLine("PlayerForm::HandleValidSubmit");
        }
    }
}