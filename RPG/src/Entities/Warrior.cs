using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.src.Entities
{
    public class Warrior : Player
    {
		public double Armor { get; set; }
		public double Evasion { get; set; }
		public double Hp { get; set; }
		public double Mp { get; set; }
		public double PhysicalAttack { get; set; }
		public Skill BodySlam { get; set; }

		public Warrior()
		{
		}

		public Warrior(string name, int level)
		{
			Name = name;
			Weapon = "Axe";
			Level = level;
			Strength = 7;
			Intellect = 3;
			Agility = 4;
			Constitution = 6;
			Armor = BaseArmor + 0.03 * Agility;
			Evasion = BaseEvasion + 0.1 * Agility;
			Hp = BaseHp + 15 * Constitution;
			Mp = BaseMp + 15 * Intellect;
			PhysicalAttack = BasePhysicalAttack + 0.1 * Strength;
			BodySlam = new Skill("Body Slam", "Physical", 25);
		}

		public override string Attack(string weapon, Enemy target)
		{
			Console.WriteLine($"{this.Name} attacked {target.Type} using the {weapon}, causing {this.PhysicalAttack} damage.");
			return this.PhysicalAttack.ToString("F0");
		}

		public override string Special(Skill skill, Enemy target)
		{
			Console.WriteLine($"{this.Name} used {skill.Name} on {target.Type}, causing " +
							$"{1.5 * this.PhysicalAttack + 0.3 * this.Constitution + 0.5 * this.Strength} damage");
			this.Mp -= skill.MpCost;
			return (1.5 * this.PhysicalAttack + 0.3 * this.Constitution + 0.5 * this.Strength).ToString("F0");
		}
	}
}
