using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBRPG
{
    internal class Unit
    {
        private int currentHp;
        private int maxHp;
        private int attackPower;
        private int healPower;
        private string unitName;
        private Random random;

        public int Hp {  get { return currentHp; }}
        public string UnitName { get { return unitName; }}
        public bool IsDead { get { return currentHp <= 0; } }

        public Unit(int maxHp, int attackPower, int healPower, string unitName) // Changed to public
        {
            this.maxHp = maxHp;
            this.currentHp = maxHp;
            this.attackPower = attackPower;
            this.healPower = healPower;
            this.unitName = unitName;
            this.random = new Random(); // Initialize Random instance
        }

        public void Attack(Unit unitToAttack)
        {
            double rng = random.NextDouble();
            rng = rng / 2 + 0.75f;
            int randDamage = (int)(attackPower * rng);
            unitToAttack.TakeDamage(randDamage);
            Console.WriteLine(unitName + " attacks " + unitToAttack.unitName + " and deals " + randDamage + " damage.");
        }

        public void TakeDamage(int damage)
        {
            currentHp -= damage; // Changed to subtract damage from currentHp
            if (IsDead)
            {
                Console.WriteLine(UnitName + " has been defeated");
            }
        }

        public void Heal()
        {
            double rng = random.NextDouble();
            rng = rng / 2 + 0.75f;
            int heal = (int)(rng * healPower);
            currentHp = heal + currentHp > maxHp ? maxHp : currentHp + heal;
            Console.WriteLine(UnitName + " heals " + heal);
        }
    }
}
