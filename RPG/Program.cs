using RPG.src.Entities;

namespace RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Warrior juntsu = new Warrior("Juntsu", 1);
            Beast wolf = new Beast();
            bool combatFlag = true;

            while (combatFlag)
            {
                if (juntsu.SuccessOnAttack(wolf))
                {
                    if (juntsu.CriticalHitSuccess())
                        if (juntsu.Mp >= juntsu.BodySlam.MpCost)
                        {
                            double inflictedDamage = Convert.ToDouble(juntsu.Special(juntsu.BodySlam, wolf));
                            wolf.Hp -= inflictedDamage * 2;
                        }
                        else
                        {
                            double inflictedDamage = Convert.ToDouble(juntsu.Attack(juntsu.Weapon, wolf));
                            wolf.Hp -= inflictedDamage * 2;
                        }
                    else
                    {
                        if (juntsu.Mp >= juntsu.BodySlam.MpCost)
                        {
                            double inflictedDamage = Convert.ToDouble(juntsu.Special(juntsu.BodySlam, wolf));
                            wolf.Hp -= inflictedDamage;
                        }
                        else
                        {
                            double inflictedDamage = Convert.ToDouble(juntsu.Attack(juntsu.Weapon, wolf));
                            wolf.Hp -= inflictedDamage;
                        }
                    }
                    if(wolf.Hp <= 0)
                    {
                        combatFlag = false;
                        Console.WriteLine("Player won the combat");
                        break;
                    }
                }
                else 
                {
                    Console.WriteLine("Player missed the attack");
                }
                if (combatFlag)
                {
                    if (wolf.SuccessOnAttack(juntsu))
                    {
                        if (wolf.CriticalHitSuccess())
                            if (wolf.Hp <= wolf.AbilityUsageThreshold)
                            {
                                double inflictedDamage = Convert.ToDouble(wolf.Special(wolf.Shred, juntsu));
                                juntsu.Hp -= inflictedDamage * 2;
                            }
                            else
                            {
                                double inflictedDamage = Convert.ToDouble(wolf.Attack(wolf.Weapon, juntsu));
                                juntsu.Hp -= inflictedDamage * 2;
                            }
                        else
                        {
                            if (wolf.Hp <= wolf.AbilityUsageThreshold)
                            {
                                double inflictedDamage = Convert.ToDouble(wolf.Special(wolf.Shred, juntsu));
                                juntsu.Hp -= inflictedDamage;
                            }
                            else
                            {
                                double inflictedDamage = Convert.ToDouble(wolf.Attack(wolf.Weapon, juntsu));
                                juntsu.Hp -= inflictedDamage;
                            }
                        }
                        if (juntsu.Hp <= 0)
                        {
                            combatFlag = false;
                            Console.WriteLine("Player lost the combat");
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enemy missed the attack");
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
}