using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.src.Entities
{
    public class Troll : Enemy
    {
        public Troll()
        {
            Hp = 120;
            PhysicalAttack = 6;
            Weapon = "Mace";
            Type = "Troll";
        }
    }
}
