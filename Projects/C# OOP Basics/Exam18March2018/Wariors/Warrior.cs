using DungeonsAndCodeWizards.Bags;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Wariors
{
    public class Warrior : Character, IAttackable
    {
        public Warrior(string name, Faction faction) : base(name,100d,50d,40d,new Satchel(), faction)
        {
        }

        public void Attack(Character character)
        {
            if (character.IsAlive && IsAlive)
            {
                if (this.Name == character.Name)
                {
                    throw new InvalidOperationException("Cannot attack self!");
                }
                if (this.Faction == character.Faction)
                {
                    throw new ArgumentException($"Friendly fire! Both characters are from {character.Faction} faction!");
                }
                character.TakeDamage(this.AbilityPoints);
            }
        }
    }
}
