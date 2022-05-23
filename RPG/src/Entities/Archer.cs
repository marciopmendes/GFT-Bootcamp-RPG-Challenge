using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.src.Entities
{
	public class Archer : Player
	{
		public double Armor { get; set; }
		public double Evasion { get; set; }
		public double Hp { get; set; }
		public double Mp { get; set; }
		public double PhysicalAttack { get; set; }
		public double RangedAttack { get; set; }
		public Skill AimedShot { get; set; }

		public Archer()
		{
        }

		public Archer(string name, int level, Skill aimedShot)
        {
            Name = name;
            Weapon = "Bow";
            Level = level;
            Strength = 5;
            Intellect = 3;
            Agility = 8;
            Constitution = 4;
            Armor = BaseArmor + 0.03 * Agility;
            Evasion = BaseEvasion + 0.1 * Agility;
            Hp = BaseHp + 15 * Constitution;
            Mp = BaseMp + 15 * Intellect;
            PhysicalAttack = BasePhysicalAttack + 0.1 * Strength;
            RangedAttack = BaseRangedAttack + 0.1 * Agility;
            AimedShot = new Skill("Aimed Shot", "Physical", 20);
        }

        public override string Attack(string weapon, Enemy target)
        {
            Console.WriteLine($"{this.Name} attacked {target.Type} using the {weapon}, causing {this.RangedAttack} damage.");
            return this.RangedAttack.ToString("F0");
        }

        public override string Special(Skill skill, Enemy target)
        {
            Console.WriteLine($"{this.Name} used {skill.Name} on {target.Type}, causing {2 * this.RangedAttack + 0.5 * this.Agility} damage");
            this.Mp -= skill.MpCost;
            return (2 * this.RangedAttack + 0.5 * this.Agility).ToString("F0");
        }
    }
}
