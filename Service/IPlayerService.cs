using System.Collections.Generic;
using RaidPlannerClient.Model;

namespace RaidPlannerClient.Service {
    public interface IPlayerService {
        public List<Player> GetPlayers();
        void AddPlayer(Player player);
    }
}