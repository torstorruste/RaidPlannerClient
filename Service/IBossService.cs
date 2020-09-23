using System.Threading.Tasks;
using RaidPlannerClient.Model;

namespace RaidPlannerClient.Service {
    public interface IBossService {
        Task<Boss> AddBoss(Instance instance, Boss boss);

        void UpdateBoss(Instance instance, Boss boss);

        void DeleteBoss(Instance instance, Boss boss);
    }
}