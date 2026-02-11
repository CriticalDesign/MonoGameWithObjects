using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameWithObjects
{
    internal class Hero
    {

        //attributes to define the state of a hero
        private int _health;
        private string _name;

        //constructor - initializes the state of a hero
        public Hero(string nameIn, int healthIn)
        {
            if (nameIn == null || nameIn == "")
            {
                nameIn = "Unnamed Hero"; //default name
            }
            _name = nameIn;

            if (healthIn < 1 || healthIn > 100)
            {
                healthIn = 100; //default to 100 health
            }
            _health = healthIn;
        }

        //accessors or getter methods - return the state of a hero attribute
        public int GetHealth() { return _health; }
        public string GetName() { return _name; }


        //mutators or setter methods - change the state of a hero attribute
        public void TakeDamage(int damageAmount)
        {
            if (damageAmount < 0)
            {
                damageAmount = 0; //can't take negative damage
            }
            _health -= damageAmount;
            if (_health < 0)
            {
                _health = 0; //health can't go below 0
            }
        }

        public void Heal(int healAmount)
        {
            if (healAmount < 0)
            {
                healAmount = 0; //can't heal negative amount
            }
            _health += healAmount;
            if (_health > 100)
            {
                _health = 100; //health can't go above 100
            }

        }
    }
}
