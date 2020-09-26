using System.Collections.Generic;
using System.Threading.Tasks;
using RaidPlannerClient.Model;

namespace RaidPlannerClient.Service {

    public interface IRaidService {
        Task<List<Raid>> GetRaids();

        Task<Raid> AddRaid(Raid raid);

        Task DeleteRaid(Raid raid);

        Task Signup(Raid raid, Player player);

        Task Unsign(Raid raid, Player player);
    }
}