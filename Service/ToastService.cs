using Microsoft.AspNetCore.Components;
using RaidPlannerClient.Model;
using System;

namespace RaidPlannerClient.Service
{
    public class ToastService
    {
        public string Message { get; private set; } = "";
        public ToastLevel ToastLevel {get; private set; } = ToastLevel.Info;

        public void UpdateMessage(ComponentBase Source, string Message, ToastLevel toastLevel)
        {
            this.Message = Message;
            this.ToastLevel = toastLevel;
            NotifyStateChanged(Source, "Message");
        }

        public event Action<ComponentBase, string> StateChanged;

        private void NotifyStateChanged(ComponentBase Source, string Property) => StateChanged?.Invoke(Source, Property);
    }
}
