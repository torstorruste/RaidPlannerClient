using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RaidPlannerClient.Model;

namespace RaidPlannerClient.Service {
    public class ApprovalService : IApprovalService
    {
        private readonly HttpClient httpClient;

        public ApprovalService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Approval>> GetApprovals()
        {
            Console.WriteLine("ApprovalService::GetApprovals");

            Console.WriteLine("GETting approvals");
            var result = await httpClient.GetAsync("/approvals");
            result.EnsureSuccessStatusCode();

            var json = await result.Content.ReadAsStringAsync();
            var approvals = JsonConvert.DeserializeObject<List<Approval>>(json);

            return approvals;
        }

        public async Task AddApproval(Player player, Character character, Instance instance, Boss boss)
        {
            Console.WriteLine("ApprovalService::AddApproval");

            var path = $"players/{player.Id}/characters/{character.Id}/approvals/{instance.Id}/{boss.Id}";
            Console.WriteLine($"POSTing to {path}");
            var result = await httpClient.PostAsync(path, null);
            result.EnsureSuccessStatusCode();
        }

        public async Task RemoveApproval(Player player, Character character, Instance instance, Boss boss)
        {
            Console.WriteLine("ApprovalService::RemoveApproval");

            var path = $"players/{player.Id}/characters/{character.Id}/approvals/{instance.Id}/{boss.Id}";
            Console.WriteLine($"DELETEing to {path}");
            var result = await httpClient.DeleteAsync(path);
            result.EnsureSuccessStatusCode();
        }
    }
}