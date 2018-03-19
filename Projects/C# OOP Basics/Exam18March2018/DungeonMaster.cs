using DungeonsAndCodeWizards.Wariors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards
{

    public class DungeonMaster
    {
        private List<Character> party;
        private Stack<Item> itemPool;
        private Faction faction;
        private int lastSurvivorRounds;
        public DungeonMaster()
        {
            this.party = new List<Character>();
            this.itemPool = new Stack<Item>();
        }
        public string JoinParty(string[] args)
        {
            string factionToString = args[0];
            this.faction = (Faction)Enum.Parse(typeof(Faction), factionToString);
            string characterType = args[1];
            string name = args[2];
            if (factionToString != "CSharp" || factionToString != "Java")
            {
                throw new ArgumentException($"Invalid faction \"{factionToString}\"!");
            }
            switch (characterType)
            {
                case "Warrior":
                    Warrior warrior = new Warrior(name, faction);
                    party.Add(warrior);
                    break;
                case "Cleric":
                    Cleric cleric = new Cleric(name, faction);
                    party.Add(cleric);
                    break;
                default:
                    throw new ArgumentException($"Invalid character type \"{characterType}\"!");

            }
            return $"{name} joined the party!";

        }
        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];
            switch (itemName)
            {

                case "HealthPotion":
                    HealthPotion healthPotion = new HealthPotion();
                    itemPool.Push(healthPotion);
                    break;
                case "PoisonPotion":
                    PoisonPotion poisonPotion = new PoisonPotion();
                    itemPool.Push(poisonPotion);
                    break;
                case "ArmorRepairKit":
                    ArmorRepairKit armorRepairKit = new ArmorRepairKit();
                    itemPool.Push(armorRepairKit);
                    break;
                default:
                    throw new ArgumentException($"Invalid item \"{itemName}\"!");
            }
            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            if (!party.Any(c => c.Name == characterName))
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }
            if (this.itemPool.Count == 0)
            {
                throw new InvalidOperationException($"No items left in pool!");
            }
            var character = this.party.First(c => c.Name == characterName);
            var item = this.itemPool.Pop();
            character.ReceiveItem(item);
            return $"{characterName} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];
            if (!this.party.Any(c => c.Name == characterName))
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }
            var character = this.party.First(c => c.Name == characterName);
            var item = character.Bag.GetItem(itemName);
            return $"{characterName} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string recieverName = args[1];
            string itemName = args[2];
            if (!this.party.Any(c => c.Name == giverName))
            {
                throw new ArgumentException($"Character {giverName} not found!");
            }
            if (!this.party.Any(c => c.Name == recieverName))
            {
                throw new ArgumentException($"Character {recieverName} not found!");
            }
            var giver = this.party.First(c => c.Name == giverName);
            var reciever = this.party.First(c => c.Name == recieverName);
            var item = giver.Bag.GetItem(itemName);
            giver.UseItemOn(item, reciever);
            return $"{giverName} used {itemName} on {recieverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string recieverName = args[1];
            string itemName = args[2];
            if (!this.party.Any(c => c.Name == giverName))
            {
                throw new ArgumentException($"Character {giverName} not found!");
            }
            if (!this.party.Any(c => c.Name == recieverName))
            {
                throw new ArgumentException($"Character {recieverName} not found!");
            }
            var giver = this.party.First(c => c.Name == giverName);
            var reciever = this.party.First(c => c.Name == recieverName);
            var item = giver.Bag.GetItem(itemName);
            giver.GiveCharacterItem(item, reciever);
            return $"{giverName} gave {recieverName} {itemName}.";
        }

        public string GetStats()
        {
            var sorted = this.party.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health).ToList();
            var sb = new StringBuilder();
            foreach (var character in sorted)
            {
                sb.AppendLine(character.ToString());
                
            }
            var result = sb.ToString().TrimEnd();
            return result;
        }


        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];
            if (!this.party.Any(c => c.Name == attackerName))
            {
                throw new ArgumentException($"Character {attackerName} not found!");
            }
            if (!this.party.Any(c => c.Name == receiverName))
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }
            var attacker = this.party.First(c => c.Name == attackerName);
            var receiver = this.party.First(c => c.Name == receiverName);
            if (!(attacker is IAttackable))
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }
            var attackAsWarrior = (Warrior)attacker;
            attackAsWarrior.Attack(receiver);
            var sb = new StringBuilder();
            sb.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");
            if (!receiver.IsAlive)
            {
                sb.AppendLine($"{receiver.Name} is dead!");
            }
            var result = sb.ToString().TrimEnd();
            return result;
        }

        public string Heal(string[] args)
        {
            var healerName = args[0];
            var healRecieverName = args[1];
            if (!this.party.Any(c => c.Name == healerName))
            {
                throw new ArgumentException($"Character {healerName} not found!");
            }

            if (!this.party.Any(c => c.Name == healRecieverName))
            {
                throw new ArgumentException($"Character {healRecieverName} not found!");
            }
            var healer = this.party.First(c => c.Name == healerName);
            var reciever = this.party.First(c => c.Name == healRecieverName);
            if (!(healer is IHealable))
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }
            var healerAsCleric = (Cleric)healer;
            healerAsCleric.Heal(reciever);
            return $"{healer.Name} heals {reciever.Name} for {healer.AbilityPoints}! {reciever.Name} has {reciever.Health} health now!";

        }

        public string EndTurn(string[] args)
        {
            var aliveCharacters = this.party.Where(c => c.IsAlive == true).ToList();
            var sb = new StringBuilder();
            foreach (var aliveCharacter in aliveCharacters)
            {
                var healthBeforeRest = aliveCharacter.Health;
                aliveCharacter.Rest();
                sb.AppendLine($"{aliveCharacter.Name} rests ({healthBeforeRest} => {aliveCharacter.Health})");
            }
            if (aliveCharacters.Count == 1 || aliveCharacters.Count == 0)
            {
                lastSurvivorRounds++;
            }
            var result = sb.ToString().TrimEnd();
            return result;
        }

        public bool IsGameOver()
        {
            if (lastSurvivorRounds > 1)
            {
                return true;
            }
            return false;
        }

    }
}
