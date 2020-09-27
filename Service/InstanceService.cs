using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using RaidPlannerClient.Model;
using Newtonsoft.Json;
using System.Text;

namespace RaidPlannerClient.Service
{
    public class InstanceService : IInstanceService
    {
        private readonly HttpClient httpClient;

        public InstanceService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Instance> AddInstance(Instance instance)
        {
            Console.WriteLine("InstanceService::AddInstance");

            var InstanceJson = JsonConvert.SerializeObject(instance);
            Console.WriteLine("POSTing to rest/instances");
            var result = await httpClient.PostAsync("rest/instances", new StringContent(InstanceJson, Encoding.UTF8, "application/json"));
            result.EnsureSuccessStatusCode();

            var json = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Instance>(json);
        }

        public async void UpdateInstance(Instance instance)
        {
            Console.WriteLine("InstanceService::UpdateInstance");

            var InstanceJson = JsonConvert.SerializeObject(instance);
            Console.WriteLine($"PUTing to rest/instances/{instance.Id}");
            var result = await httpClient.PutAsync($"rest/instances/{instance.Id}", new StringContent(InstanceJson, Encoding.UTF8, "application/json"));
            result.EnsureSuccessStatusCode();
        }

        public async Task<List<Instance>> GetInstances()
        {
            Console.WriteLine("InstanceService::GetInstances");

            Console.WriteLine("GETting rest/instances");
            var result = await httpClient.GetAsync("rest/instances");
            result.EnsureSuccessStatusCode();

            var json = await result.Content.ReadAsStringAsync();
            var instances = JsonConvert.DeserializeObject<List<Instance>>(json);

            foreach (var Instance in instances)
            {
                Instance.Bosses.Sort((a, b) => a.Name.CompareTo(b.Name));
            }

            return instances;
        }

        public async void DeleteInstance(Instance instance)
        {
            Console.WriteLine("InstanceService::DeleteInstance");

            Console.WriteLine($"DELETEing to rest/instances/{instance.Id}");
            var result = await httpClient.DeleteAsync($"rest/instances/{instance.Id}");
            result.EnsureSuccessStatusCode();
        }
    }
}