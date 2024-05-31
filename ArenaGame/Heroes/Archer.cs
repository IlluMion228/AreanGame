using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    namespace ArenaGame.Heroes
    {
        public class Archer : Hero
        {
            private double shotCount;
            private double damageCoef;

            public Archer(string name, double armor, double strength, IWeapon weapon) : base(name, armor, strength, weapon)
            {
                shotCount = 0;
                damageCoef = 0.6; 
            }

            public override double Attack()
            {
                double damage = base.Attack();
                double realDamage = damage * damageCoef;
                if (damageCoef < 1.0) damageCoef += 0.1;  
                return realDamage;
            }

            public override double Defend(double damage)
            {
                shotCount++;
                if (shotCount == 3)  
                {
                    shotCount = 0;
                    return 0;
                }
                return base.Defend(damage);
            }
        }
    }
