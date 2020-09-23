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
    }
}