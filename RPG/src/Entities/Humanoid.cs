using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.src.Entities
{
    public class Humanoid : Enemy
    {
        public Skill ArcaneBolt { get; set; }
        public Humanoid()
        {
            Hp = 150;
            PhysicalAttack = 5;
            MagicalAttack = 5;
            Weapon = "Sword";
            Type = "Humanoid";
            ArcaneBolt = new Skill("Arcane Bolt", "Arcane");
            AbilityUsageThreshold = 0.3 * Hp;
        }
        public override string Special(Skill skill, Player target)
        {
            Console.WriteLine($"{this.Type} used {skill.Name} on {target.Name}, causing {1.7 * this.MagicalAttack} damage.");
            return (1.7 * this.MagicalAttack).ToString("F0");
        }
    }
}
