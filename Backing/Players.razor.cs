using System.Collections.Generic;

namespace org.superhelt.Blazor
{
    public partial class Players {

        List<Player> players  = new List<Player>{
                new Player{Id=1, Name="Zikura", Characters=new List<Character>{
                    new Character{Id=1, Name="Zikura", CharacterClass=CharacterClass.Druid, Roles=new List<Role>{Role.Tank, Role.Ranged}},
                    new Character{Id=2, Name="Ziktator", CharacterClass=CharacterClass.Monk, Roles=new List<Role>{Role.Tank, Role.Ranged}}
                }}, 
                new Player{Id=2, Name="Richard", Characters= new List<Character>{
                    new Character{Id=3, Name="Drahc", CharacterClass=CharacterClass.Druid, Roles=new List<Role>{Role.Tank, Role.Melee}}
                }}
            };

        public List<Player> GetPlayers() {
            return players;
        }

        public void AddPlayer() {
            players.Add(new Player{Id=3, Name="Furo"});
        }
    }
}