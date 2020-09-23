using System.Collections.Generic;
using System.Threading.Tasks;
using RaidPlannerClient.Model;

namespace RaidPlannerClient.Service {
    public interface IApprovalService {
        Task<List<Approval>> GetApprovals();
    }
}