using System.Collections.Generic;
using System.Threading.Tasks;
using RaidPlannerClient.Model;

namespace RaidPlannerClient.Service {
    public interface IApprovalService {
        Task<List<Approval>> GetApprovals();
        Task AddApproval(Player player, Character character, Instance instance, Boss boss);
        Task RemoveApproval(Player player, Character character, Instance instance, Boss boss);
    }
}