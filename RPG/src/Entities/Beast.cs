using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.src.Entities
{
    public class Beast : Enemy
    {
        public Skill Shred { get; set; }
        public Beast()
        {
            Hp = 80;
            PhysicalAttack = 4;
            Weapon = "Claws";
            Type = "Beast";
            Shred = new Skill("Shred", "Physical");
            AbilityUsageThreshold = 0.3 * Hp;

        }
       
        public override string Special(Skill skill, Player target)
        {
            Console.WriteLine($"{this.Type} used {skill.Name} on {target.Name}, causing {1.4 * this.PhysicalAttack} damage.");
            return (1.4 * this.PhysicalAttack).ToString("F0");
        }
    }
}
