using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.src.Entities
{
	public class Assassin : Player
	{
		public double Armor { get; set; }
		public double Evasion { get; set; }
		public double Hp { get; set; }
		public double Mp { get; set; }
		public double PhysicalAttack { get; set; }
		public Skill Backstab { get; set; }

		public Assassin()
		{
		}

		public Assassin(string name, int level, Skill Backstab)
		{
			Name = name;
			Weapon = "Twin Daggers";
			Level = level;
			Strength = 4;
			Intellect = 2;
			Agility = 10;
			Constitution = 4;
			Armor = BaseArmor + 0.03 * Agility;
			Evasion = BaseEvasion + 0.1 * Agility;
			Hp = BaseHp + 15 * Constitution;
			Mp = BaseMp + 15 * Intellect;
			PhysicalAttack = BasePhysicalAttack + 0.1 * Strength;
			Backstab = new Skill("Backstab", "Physical", 10);
		}
		public override string Attack(string weapon, Enemy target)
		{
			Console.WriteLine($"{this.Name} attacked {target.Type} using the {weapon}, causing {this.PhysicalAttack} damage.");
			return this.PhysicalAttack.ToString("F0");
		}

		public override string Special(Skill skill, Enemy target)
		{
			Console.WriteLine($"{this.Name} used {skill.Name} on {target.Type}, causing {1.3 * this.PhysicalAttack + 0.8 * this.Strength} damage");
			this.Mp -= skill.MpCost;
			return (1.3 * this.PhysicalAttack + 0.8 * this.Strength).ToString("F0");
		}
	}
}
