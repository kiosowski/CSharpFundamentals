using DungeonsAndCodeWizards.Bags;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Wariors
{
    class Cleric : Character, IHealable
    {
        public Cleric(string name, Faction faction) : base(name,50d,25d,40,new Backpack(),faction)
        {
        }
        public override double RestHealMultiplier => 0.5d;
        public void Heal(Character character)
        {
            if (character.IsAlive && IsAlive)
            {
                if (this.Faction != character.Faction)
                {
                    throw new InvalidOperationException("Cannot heal enemy character!");
                }
                character.Health += this.AbilityPoints;
            }
        }
    }
}
