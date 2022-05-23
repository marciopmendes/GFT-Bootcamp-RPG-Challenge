using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.src.Entities
{
	public class Cleric : Player
	{
		public double Armor { get; set; }
		public double Evasion { get; set; }
		public double Hp { get; set; }
		public double Mp { get; set; }
		public double MagicalAttack { get; set; }
		public Skill HolyLight { get; set; }
		public Skill HealingWave { get; set; }

		public Cleric()
		{
		}

		public Cleric(string name, int level, Skill HolyLight)
		{
			Name = name;
			Weapon = "Orb";
			Level = level;
			Strength = 4;
			Intellect = 7;
			Agility = 3;
			Constitution = 6;
			Armor = BaseArmor + 0.03 * Agility;
			Evasion = BaseEvasion + 0.1 * Agility;
			Hp = BaseHp + 15 * Constitution;
			Mp = BaseMp + 15 * Intellect;
			MagicalAttack = BaseMagicalAttack + 0.1 * Intellect;
			HolyLight = new Skill("Holy Light", "Holy", 25);
			HealingWave = new Skill("Healing Wave", "Support", 25);
		}

		public override string Attack(string weapon, Enemy target)
		{
			return "Clerics can't attack. Try using a special ability";
		}
		public override string Special(Skill skill, Enemy target)
		{
			Console.WriteLine($"{this.Name} used {skill.Name} on {target.Type}, causing {1.4 * this.MagicalAttack + 0.2 * this.Intellect} damage");
			this.Mp -= skill.MpCost;
			return (1.4 * this.MagicalAttack + 0.2 * this.Intellect).ToString("F0");
		}

		public string Heal(Skill skill, Player target)
        {
			Console.WriteLine($"{this.Name} used {skill.Name} on {target.Name}, healing {1.4 * this.MagicalAttack + 0.4 * this.Intellect} hitpoints");
			this.Mp -= skill.MpCost;
			return (1.4 * this.MagicalAttack + 0.4 * this.Intellect).ToString("F0");
		}
	}
}
