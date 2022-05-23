using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.src.Entities
{
    public class Dragon : Enemy
    {
        public Skill BreatheFire { get; set; }
        public Dragon()
        {
            Hp = 600;
            PhysicalAttack = 10;
            MagicalAttack = 10;
            Weapon = "Fangs";
            Type = "Dragon";
            BreatheFire = new Skill("Breathe Fire", "Fire");
            Evasion = 20;
            AbilityUsageThreshold = 0.3 * Hp;
        }
       
        public override string Special(Skill skill, Player target)
        {
            Console.WriteLine($"{this.Type} used {skill.Name} on {target.Name}, causing {2.0 * this.MagicalAttack} damage.");
            return (2.0 * this.MagicalAttack).ToString("F0");
        }
    }
}
