using System.Collections.Generic;
using System.Threading.Tasks;
using RaidPlannerClient.Model;

namespace RaidPlannerClient.Service {
    public interface IInstanceService {
        Task<List<Instance>> GetInstances();
        Task<Instance> AddInstance(Instance Instance);

        void UpdateInstance(Instance Instance);

        void DeleteInstance(Instance Instance);
    }
}