using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.src.Entities
{
	public class Warlock : Player
	{
		public double Armor { get; set; }
		public double Evasion { get; set; }
		public double Hp { get; set; }
		public double Mp { get; set; }
		public double MagicalAttack { get; set; }
		public Skill ShadowBolt { get; set; }

		public Warlock()
		{
		}

		public Warlock(string name, int level, Skill ShadowBolt)
		{
			Name = name;
			Weapon = "Wand";
			Level = level;
			Strength = 3;
			Intellect = 8;
			Agility = 3;
			Constitution = 6;
			Armor = BaseArmor + 0.03 * Agility;
			Evasion = BaseEvasion + 0.1 * Agility;
			Hp = BaseHp + 15 * Constitution;
			Mp = BaseMp + 15 * Intellect;
			MagicalAttack = BaseMagicalAttack + 0.1 * Intellect;
			ShadowBolt = new Skill("Shadow Bolt", "Shadow", 30);
		}

		public override string Attack(string weapon, Enemy target)
		{
			return "Warlocks can't attack. Try using a special ability";
		}

		public override string Special(Skill skill, Enemy target)
		{
			Console.WriteLine($"{this.Name} used {skill.Name} on {target.Type}, causing {2.4 * this.MagicalAttack + 0.6 * this.Intellect} damage)");
			this.Mp -= skill.MpCost;
			return (2.4 * this.MagicalAttack + 0.6 * this.Intellect).ToString("F0");
		}
	}

}
