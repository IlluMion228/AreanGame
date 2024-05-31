using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.Heroes
{
    public class Tank : Hero
    {
        private double hitCount;
        private double damageCoef;

        public Tank(string name, double armor, double strength, IWeapon weapon) : base(name, armor, strength, weapon)
        {
            hitCount = 0;
            damageCoef = 0.5;  
        }

        public override double Attack()
        {
            double damage = base.Attack();
            double realDamage = damage * damageCoef;
            if (damageCoef < 0.8) damageCoef += 0.05;  
            return realDamage;
        }

        public override double Defend(double damage)
        {
            hitCount++;
            if (hitCount == 4)  
            {
                hitCount = 0;
                return 0;
            }
            return base.Defend(damage);
        }
    }
}
