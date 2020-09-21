using System.Collections.Generic;
using System.Threading.Tasks;
using RaidPlannerClient.Model;

namespace RaidPlannerClient.Service {
    public interface IPlayerService {
        Task<List<Player>> GetPlayers();
        Task<Player> AddPlayer(Player player);

        void UpdatePlayer(Player player);

        void DeletePlayer(Player player);
    }
}