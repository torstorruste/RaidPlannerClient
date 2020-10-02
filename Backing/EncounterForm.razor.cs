using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
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

        [Parameter]
        public RaidForm RaidForm { get; set; }

        [Inject]
        public IEncounterService EncounterService { get; set; }

        [Inject]
        private IJSRuntime JSRuntime { get; set; }

        private string Collapse = "collapse";

        public Player GetPlayerByid(int id)
        {
            return Players.Where(p => p.Id == id).First();
        }

        public Character GetCharacterById(int? id)
        {
            Console.WriteLine($"Getting character with id {id}");
            if (Players.SelectMany(p => p.Characters).Any(c => c.Id == id))
            {
                return Players.SelectMany(p => p.Characters).Where(c => c.Id == id).FirstOrDefault();
            }
            else
            {
                return new Character { Id = id, Name = "Unknown" };
            };
        }

        public Boss GetBossById(int? id)
        {
            Console.WriteLine($"Getting boss with id {id}");
            if (Instances.SelectMany(i => i.Bosses).Any(b => b.Id == id))
            {
                return Instances.SelectMany(i => i.Bosses).Where(b => b.Id == id).FirstOrDefault();
            }
            else
            {
                Console.WriteLine($"Boss with id {id} does not exist, returning unknown boss");
                return new Boss { Id = id, Name = "Unknown" };
            }
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
            if (!Raid.Finalized && Encounter.Characters.Count < 20)
            {
                Console.WriteLine($"Adding {player.Name} as {role}");
                var encounterCharacter = new EncounterCharacter { PlayerId = (int)player.Id, CharacterId = (int)character.Id, Role = role };
                EncounterService.AddCharacter(Raid, Encounter, encounterCharacter);
                Encounter.Characters.Add(encounterCharacter);
            }
        }

        public void Remove(int playerId)
        {
            if (!Raid.Finalized)
            {
                var player = Players.Where(p => p.Id == playerId).First();
                Console.WriteLine($"Removing {player.Name}");
                EncounterService.DeleteCharacter(Raid, Encounter, Encounter.Characters.First(p => p.PlayerId == playerId));
                Encounter.Characters.RemoveAll(p => p.PlayerId == playerId);
            }
        }

        public List<EncounterCharacter> GetPlayersByRole(Role role)
        {
            return Encounter.Characters
                    .Where(p => p.Role == role)
                    .Where(p => Players.SelectMany(p => p.Characters).Any(c => c.Id == p.CharacterId))
                    .OrderBy(p => GetCharacterById(p.CharacterId).Name)
                    .ToList();
        }

        public List<Character> GetCharactersByClass(CharacterClass characterClass)
        {
            return Encounter.Characters
                    .Select(p=>GetCharacterById(p.CharacterId))
                    .Where(c=>c.CharacterClass==characterClass)
                    .OrderBy(c=>c.Name)
                    .ToList();
        }

        public async void DeleteEncounter()
        {
            if (!Raid.Finalized)
            {
                bool confirmed = await JSRuntime.InvokeAsync<bool>("confirm", $"Are you sure you want to delete encounter {GetBossById(Encounter.BossId).Name}?");
                if (confirmed)
                {
                    await EncounterService.DeleteEncounter(Raid, Encounter);
                    RaidForm.DeleteEncounter(Encounter);
                }
            }
        }
        
        public List<CharacterClass> GetClasses()
        {
            return new List<CharacterClass>{CharacterClass.DeathKnight, CharacterClass.DemonHunter, CharacterClass.Druid,
            CharacterClass.Hunter, CharacterClass.Mage, CharacterClass.Monk, CharacterClass.Paladin, CharacterClass.Priest,
            CharacterClass.Rogue, CharacterClass.Shaman, CharacterClass.Warlock, CharacterClass.Warrior};
        }
    }
}