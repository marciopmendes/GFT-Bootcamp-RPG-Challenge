using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.src.Entities
{
	public class Wizard : Player
	{
		public double Armor { get; set; }
		public double Evasion { get; set; }
		public double Hp { get; set; }
		public double Mp { get; set; }
		public double PhysicalAttack { get; set; }
		public double MagicalAttack { get; set; }
		public Skill LightningSpear { get; set; }

		public Wizard()
		{
		}

		public Wizard(string name, int level, Skill LightningSpear)
		{
			Name = name;
			Weapon = "Staff";
			Level = level;
			Strength = 3;
			Intellect = 9;
			Agility = 4;
			Constitution = 4;
			Armor = BaseArmor + 0.03 * Agility;
			Evasion = BaseEvasion + 0.1 * Agility;
			Hp = BaseHp + 15 * Constitution;
			Mp = BaseMp + 15 * Intellect;
			PhysicalAttack = BasePhysicalAttack + 0.1 * Strength;
			MagicalAttack = BaseMagicalAttack + 0.1 * Intellect;
			LightningSpear = new Skill("Lightning Spear", "Lightning", 30);
        }

		public override string Attack(string weapon, Enemy target)
		{
			Console.WriteLine($"{this.Name} attacked {target.Type} using the {weapon}, causing {this.PhysicalAttack} damage.");
			return this.PhysicalAttack.ToString("F0");
		}

		public override string Special(Skill skill, Enemy target)
		{
			Console.WriteLine($"{this.Name} used {skill.Name} on {target.Type}, causing {2.8 * this.MagicalAttack + 0.5 * this.Intellect} damage");
			this.Mp -= skill.MpCost;
			return (2.8 * this.MagicalAttack + 0.5 * this.Intellect).ToString("F0");
		}
	}
}
