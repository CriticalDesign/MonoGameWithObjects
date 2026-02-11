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
    internal class Die
    {
        //attributes
        private int _sideUp;
        private int _numSides;
        private List<Texture2D> _diceTextures;
        private float _myX, _myY;

        //constructor
        public Die(int numSidesIn, List<Texture2D> diceTexturesIn, float myXIn, float myYIn)
        {
            if(numSidesIn < 2 || numSidesIn > 6)
            {
                numSidesIn = 6; //default to 6 sides
            }
            _numSides = numSidesIn;
            Roll();
            _diceTextures = diceTexturesIn;
            _myX = myXIn;
            _myY = myYIn;   
        }

        //mutator - changes the value of sideUp
        public void Roll()
        {
            Random rng = new Random();
            _sideUp = rng.Next(1, _numSides + 1);
        }

        //accessor
        public int GetSideUp() { return _sideUp; }


        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                Roll(); 
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(_diceTextures[_sideUp - 1], new Vector2(_myX, _myY), Color.White);
            spriteBatch.End();
        }
    }
}
