using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.src.Entities
{
    public class Mech : Enemy
    {
        public Mech()
        {
            Hp = 400;
            PhysicalAttack = 4;
            Weapon = "Cannon";
            Type = "Mech";
        }
    }
}
