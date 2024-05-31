using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    namespace ArenaGame.Heroes
    {
        public class Wizard : Hero
        {
            private double spellCount;
            private double damageCoef;

            public Wizard(string name, double armor, double strength, IWeapon weapon) : base(name, armor, strength, weapon)
            {
                spellCount = 0;
                damageCoef = 0.7;  
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
                spellCount++;
                if (spellCount == 3)  
                {
                    spellCount = 0;
                    return 0;
                }
                return base.Defend(damage);
            }
        }
    }
