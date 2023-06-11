using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZInput;
namespace Pacman
{
    internal class Pacman
    {
        public int X;
        public int Y;
        public int Score;
        public Grid MazeGrid = new Grid();

        public Pacman(int X, int Y, Grid MazeGrid)
        {
            this.X = X;
            this.Y = Y;
            this.MazeGrid = MazeGrid;
        }

        public void Print(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("P");
        }

        public void Remove(int x,int y)
        {
            Console.SetCursorPosition(x,y);
            Console.Write(" ");
        }

        public void MoveLeft(Cell current,Cell next)
        {
            if(next.value==' ')
            {
                Remove(current.X,current.Y);
                current.X--;
                Print(next.X, next.Y);
            }
        }

        public void MoveRight(Cell current, Cell next)
        {
            if (next.value == ' ')
            {
                Remove(current.X, current.Y);
                current.X++;
                Print(next.X, next.Y);
            } 
        }

        public void MoveUp(Cell current, Cell next)
        {
            Remove(current.X, current.Y);
            current.Y--;
            Print(next.X, next.Y);
        }

        public void MoveDown(Cell current, Cell next)
        {
            Remove(current.X, current.Y);
            current.Y++;
            Print(next.X, next.Y);
        }

        public void Move()
        {
            Grid G = new Grid();
            Cell C = new Cell('P', X, Y);
            Cell CR = G.GetRightCell(C);
            Cell CL = G.GetLeftCell(C);
            Cell CU = G.GetUpCell(C);
            Cell CD = G.GetDownCell(C);

            if(Keyboard.IsKeyPressed(Key.RightArrow))
            {
                MoveRight(C, CR);
            }

            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                MoveLeft(C, CL);
            }

            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                MoveUp(C, CU);
            }

            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                MoveDown(C, CD);
            }
        }

        public void PrintScore()
        {
            Console.SetCursorPosition(80,10);
            Score++;
        }
    }
}
