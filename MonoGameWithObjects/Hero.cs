using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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

        //MonoGame attributes
        private float _myX, _myY; //position of the hero on the screen
        private Texture2D _mySprite; //the hero's image

        //constructor - initializes the state of a hero
        //five arguments, one for each of the attribute variables (above)
        public Hero(string nameIn, int healthIn, float myXIn,
            float myYIn, Texture2D mySpriteIn)
        {
            //the MonoGame attributes are now set
            _mySprite = mySpriteIn;
            _myX = myXIn;
            _myY = myYIn;

            //check the nameIn variable and make sure it makes sense
            if (nameIn == null || nameIn == "")
            {
                nameIn = "Unnamed Hero"; //default name
            }
            _name = nameIn;


            //check the healthIn variable and make sure it makes sense
            if (healthIn < 1 || healthIn > 100)
            {
                healthIn = 100; //default to 100 health
            }
            _health = healthIn;
        }

        //accessors or getter methods - return the state of a hero attribute
        public float GetX() { return _myX; }
        public float GetY() { return _myY; }
        public int GetHealth() { return _health; }
        public string GetName() { return _name; }
        //There's no accessor for the Texture2D because we don't need it for this example


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

        //this is an accessor to see if the hero is dea
        public Boolean IsDead()
        {
            if (_health <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //this is the hero Update() method.
        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.H))
                Heal(1);

            if (Keyboard.GetState().IsKeyDown(Keys.K))
                TakeDamage(1);


            if (Keyboard.GetState().IsKeyDown(Keys.A))
                _myX -= 5;
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                _myX += 5;
            if (Keyboard.GetState().IsKeyDown(Keys.W))
                _myY -= 5;
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                _myY += 5;
        }




        //The hero Draw() method.
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(_mySprite, new Vector2(_myX, _myY), 
                Color.White);
            spriteBatch.End();
        }


        //this is a helper method. It doesn't modify or access
        //the attributes
        public int DealDamage()
        {
            Random rng = new Random();
            return rng.Next(5, 11); //damage between 5 and 15
        }
    }
}
