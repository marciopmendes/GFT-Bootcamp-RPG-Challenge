using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.src.Entities
{
	public abstract class Player
	{
		public string Name { get; set; }
		public string Weapon { get; set; }
		public int Level { get; set; }
		public double Strength { get; set; }
		public double Intellect { get; set; }
		public double Agility { get; set; }
		public double Constitution { get; set; }
		public double BaseHp { get; set; } = 100;
		public double BaseMp { get; set; } = 100;
		public double BaseArmor { get; set; } = 2;
		public double BaseCritical { get; set; } = 5;
		public double BasePhysicalAttack { get; set; } = 10;
		public double BaseMagicalAttack { get; set; } = 10;
		public double BaseRangedAttack { get; set; } = 10;
		public double BaseEvasion { get; set; } = 5;
        public double Evasion { get; internal set; }
        public int Hp { get; internal set; }

        public struct Skill
		{
			public string Name { get; set; }
			public string Type { get; set; }
			public double MpCost { get; set; }

			public Skill(string name, string type, double mpCost)
			{
				Name = name;
				Type = type;
				MpCost = mpCost;
			}
		}

		public virtual string Attack(string weapon, Enemy target)
		{
			return $"{this.Name} attacked {target.Type} using the {weapon}"; 
		}

		public virtual string Special(Skill skill, Enemy target)
		{
			return $"{this.Name} used {skill.Name} on {target.Type}";
		}

		public bool SuccessOnAttack(Enemy target)
        {
			Random random = new Random();
			double chance = random.NextDouble() * 100;
			if(chance >= target.Evasion)
            {
				Console.WriteLine("Player Attack Successful!");
				return true;
            }
			return false;
        }
		public bool CriticalHitSuccess()
		{
			Random random = new Random();
			double chance = random.NextDouble() * 100;
			if (chance >= 100 - this.BaseCritical)
			{
				Console.WriteLine("CRITICAL HIT! Damage is doubled for this attack.");
				return true;
			}
			return false;
		}
	}
}
