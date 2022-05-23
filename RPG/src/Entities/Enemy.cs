using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.src.Entities
{
    public abstract class Enemy
    {
        public string Type { get; set; }
        public double Hp { get; set; }
        public double PhysicalAttack { get; set; }
        public double MagicalAttack { get; set; }
        public string Weapon { get; set; }
        public double Critical { get; set; } = 5;
        public double Evasion { get; set; } = 10;
        public double AbilityUsageThreshold { get; set; }
        public struct Skill
        {
            public string Name { get; set; }
            public string Type { get; set; }

            public Skill(string name, string type)
            {
                Name = name;
                Type = type;
            }
        }
        public virtual string Attack(string weapon, Player target)
        {
            Console.WriteLine($"Enemy {this.Type} attacked {target.Name} using the {weapon}, causing {this.PhysicalAttack} damage.");
            return this.PhysicalAttack.ToString("F0");
        }

        public virtual string Special(Skill skill, Player target)
        {
            return $"Enemy {this.Type} used {skill.Name} on {target.Name}";
        }
        public bool SuccessOnAttack(Player target)
        {
            Random random = new Random();
            double chance = random.NextDouble() * 100;
            if (chance >= target.Evasion)
            {
                Console.WriteLine("Enemy Attack Successful!");
                return true;
            }
            return false;
        }
        public bool CriticalHitSuccess()
        {
            Random random = new Random();
            double chance = random.NextDouble() * 100;
            if (chance >= 100 - this.Critical)
            {
                Console.WriteLine("CRITICAL HIT! Damage is doubled for this attack.");
                return true;
            }
            return false;
        }

    }
}
