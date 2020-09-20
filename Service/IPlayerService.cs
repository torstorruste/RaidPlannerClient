using System.Collections.Generic;
using System.Threading.Tasks;
using RaidPlannerClient.Model;

namespace RaidPlannerClient.Service {
    public interface IPlayerService {
        public Task<List<Player>> GetPlayers();
        void AddPlayer(Player player);
    }
}