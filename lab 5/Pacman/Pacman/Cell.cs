using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    internal class Cell
    {
        public char value;
        public int X;
        public int Y;

        public Cell(char value, int X, int Y)
        {
            this.value = value;
            this.X = X;
            this.Y = Y;
        }

        public char GetValue()
        {
            return value;
        }

        public void SetValue(char value)
        {
            this.value = value;
        }

        public int GetX()
        {
            return X;
        }

        public int GetY()
        {
            return Y;
        }

        public bool IsPacmanPresent()
        {
            if(value == 'P')
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public bool IsGhostPresent(char ghostCharacter)
        {
            if(value == ghostCharacter)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

    }
}
