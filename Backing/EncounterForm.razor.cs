using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using RaidPlannerClient.Model;
using RaidPlannerClient.Service;

namespace RaidPlannerClient.Components
{
    public partial class EncounterForm
    {
        [Parameter]
        public Raid Raid { get; set; }

        [Parameter]
        public Encounter Encounter { get; set; }

        [Parameter]
        public List<Player> Players { get; set; }

        [Parameter]
        public List<Instance> Instances { get; set; }

        [Parameter]
        public List<Approval> Approvals { get; set; }

        [Inject]
        public IEncounterService EncounterService { get; set; }

        private string Collapse = "collapse";

        public Player GetPlayerByid(int id)
        {
            return Players.Where(p => p.Id == id).First();
        }

        public Character GetCharacterById(int id)
        {
            return Players.SelectMany(p => p.Characters).Where(c => c.Id == id).First();
        }

        public Boss GetBossById(int id)
        {
            return Instances.SelectMany(i => i.Bosses).Where(b => b.Id == id).First();
        }

        public List<Player> GetBenchedPlayers()
        {
            var playersInTeam = Encounter.Characters.Select(p => p.PlayerId).ToList();
            return Players
                    .Where(p => Raid.SignedUp.Contains((int)p.Id))
                    .Where(p => !playersInTeam.Contains((int)p.Id))
                    .ToList();
        }

        public void ToggleCollapse()
        {
            if (Collapse == "collapse")
            {
                Collapse = "";
            }
            else
            {
                Collapse = "collapse";
            }
        }

        public List<Role> GetRoles()
        {
            return new List<Role> { Role.Tank, Role.Healer, Role.Melee, Role.Ranged };
        }

        public bool IsApproved(Character character)
        {
            var Boss = GetBossById(Encounter.BossId);
            return Approvals.Exists(a => a.Boss.Id == Boss.Id && a.Character.Id == character.Id);
        }

        public void Add(Player player, Character character, Role role)
        {
            Console.WriteLine($"Adding {player.Name} as {role}");
            var encounterCharacter = new EncounterCharacter { PlayerId = (int)player.Id, CharacterId = (int)character.Id, Role = role };
            EncounterService.AddCharacter(Raid, Encounter, encounterCharacter);
            Encounter.Characters.Add(encounterCharacter);
        }

        public void Remove(int playerId)
        {
            var player = Players.Where(p => p.Id == playerId).First();
            Console.WriteLine($"Removing {player.Name}");
            EncounterService.DeleteCharacter(Raid, Encounter, Encounter.Characters.First(p=>p.PlayerId==playerId));
            Encounter.Characters.RemoveAll(p => p.PlayerId == playerId);
        }

        public List<EncounterCharacter> GetPlayersByRole(Role role) {
            return Encounter.Characters
                    .Where(p=>p.Role==role)
                    .OrderBy(p=>GetCharacterById(p.CharacterId).Name)
                    .ToList();
        }
    }
}