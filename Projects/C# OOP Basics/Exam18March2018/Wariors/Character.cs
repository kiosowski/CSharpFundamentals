using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards
{
    public abstract class Character
    {
        private string name;
        public Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = this.BaseHealth;
            this.BaseArmor = armor;
            this.Armor = this.BaseArmor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
            this.IsAlive = true;
            this.RestHealMultiplier = 0.2;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                this.name = value;
            }
        }
        public double BaseHealth { get; }
        public double Health { get;  set; }
        public double BaseArmor { get; }
        public double Armor { get;  set; }
        public double AbilityPoints { get; }
        public Bag Bag { get; }
        public Faction Faction { get; }
        public bool IsAlive { get;  set; }
        public virtual double RestHealMultiplier { get; }


        public void TakeDamage(double hitPoints)
        {
            if (this.IsAlive)
            {
                if (this.Armor >= hitPoints)
                {
                    this.Armor -= hitPoints;
                }
                else
                {
                    var leftHitPoint = hitPoints - this.Armor;
                    this.Armor = 0;
                    this.Health -= leftHitPoint;
                }
                if (this.Health <= 0)
                {
                    this.IsAlive = false;
                    this.Health = 0;
                }
            }
            else
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
        public void Rest()
        {
            if (this.IsAlive)
            {
                this.Health += (this.BaseHealth * this.RestHealMultiplier);
            }
            if (this.Health > this.BaseHealth)
            {
                this.Health = this.BaseHealth;
            }
            else
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
        public void UseItem(Item item)
        {
            if (this.IsAlive)
            {
                item.AffectCharacter(this);
            }
            else
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
        public void UseItemOn(Item item, Character character)
        {
            if (IsAlive && character.IsAlive)
            {
                item.AffectCharacter(character);
            }
            else
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
        public void GiveCharacterItem(Item item, Character character)
        {
            if (IsAlive && character.IsAlive)
            {
                character.ReceiveItem(item);
            }
        }
        public void ReceiveItem(Item item)
        {
            if (this.IsAlive)
            {
                this.Bag.AddItem(item);
            }
            else
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
        public override string ToString()
        {
            var status = this.IsAlive ? "Alive" : "Dead";

            return $"{this.Name} - HP: {this.Health}/{this.BaseHealth}, AP: {this.Armor}/{this.BaseArmor}, Status: {status}";
        }

    }
}
