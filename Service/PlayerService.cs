using System.Collections.Generic;
using RaidPlannerClient.Model;

namespace RaidPlannerClient.Service {
    public class PlayerService : IPlayerService {
        
        List<Player> players  = new List<Player>{
                new Player{Id=1, Name="Zikura", Characters=new List<Character>{
                    new Character{Id=1, Name="Zikura", CharacterClass=CharacterClass.Druid, Roles=new List<Role>{Role.Tank, Role.Ranged}},
                    new Character{Id=2, Name="Ziktator", CharacterClass=CharacterClass.Monk, Roles=new List<Role>{Role.Tank, Role.Ranged}}
                }}, 
                new Player{Id=2, Name="Richard", Characters= new List<Character>{
                    new Character{Id=3, Name="Drahc", CharacterClass=CharacterClass.Druid, Roles=new List<Role>{Role.Tank, Role.Melee}}
                }}
            };

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public List<Player> GetPlayers() {
            return players;
        }
    }
}