using Microsoft.AspNetCore.Components;
using RaidPlannerClient.Model;
using RaidPlannerClient.Service;
using System;
using System.Threading.Tasks;

namespace RaidPlannerClient.Components
{
    public class ToastBase : ComponentBase, IDisposable
    {
        protected string Heading { get; set; }
        protected string Message { get; set; }
        protected bool IsVisible { get; set; }
        protected string BackgroundCssClass { get; set; }
        protected string IconCssClass { get; set; }

        [Inject]
        private ToastService ToastService { get; set; }

        protected override void OnInitialized()
        {
            ToastService.StateChanged += async (Source, Property) => await StateChanged(Source, Property);
        }

        private async Task StateChanged(ComponentBase source, string property)
        {
            Console.WriteLine($"Message has changed to {ToastService.Message} with level {ToastService.ToastLevel}");

            ShowToast(ToastService.Message, ToastService.ToastLevel);

            await InvokeAsync(StateHasChanged);
            StateHasChanged();
        }

        public void ShowToast(string message, ToastLevel level)
        {
            Console.WriteLine($"Showing toast {message}");
            BuildToastSettings(level, message);
            IsVisible = true;
        }

        public void HideToast() {
            Console.WriteLine("Hiding toast");
            IsVisible = false;
            StateHasChanged();
        }

        private void BuildToastSettings(ToastLevel level, string message)
        {
            switch (level)
            {
                case ToastLevel.Info:
                    BackgroundCssClass = "bg-info";
                    IconCssClass = "info";
                    Heading = "Info";
                    break;
                case ToastLevel.Success:
                    BackgroundCssClass = "bg-success";
                    IconCssClass = "check";
                    Heading = "Success";
                    break;
                case ToastLevel.Warning:
                    BackgroundCssClass = "bg-warning";
                    IconCssClass = "exclamation";
                    Heading = "Warning";
                    break;
                case ToastLevel.Error:
                    BackgroundCssClass = "bg-danger";
                    IconCssClass = "times";
                    Heading = "Error";
                    break;
            }

            Message = message;
        }

        public void Dispose()
        {
            ToastService.StateChanged -= async (Source, Property) => await StateChanged(Source, Property);
        }
    }
}