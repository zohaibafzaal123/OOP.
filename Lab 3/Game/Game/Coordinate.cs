using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class Coordinate
    {
        public int Fx = 6;
        public int Fy = 15;
        public int Gx = 120;
        public int Gy = 5;

        public void Gotoxy(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }

        public void PrintFlap(char[,] Flap)
        {
            for (int i = 0; i < 2; i++)
            {
                Gotoxy(Fx, Fy + i);
                for (int j = 0; j < 7; j++)
                {
                    Console.Write(Flap[i, j]);
                }
            }
        }

        public void EraseFlap()
        {
            for (int i = 0; i < 2; i++)
            {
                Gotoxy(Fx, Fy + i);
                for (int j = 0; j < 7; j++)
                {
                    Console.Write(" ");
                }
            }
        }

        public void PrintGrit(char[,] Grit)
        {
            for (int i = 0; i < 4; i++)
            {
                Gotoxy(Gx, Gy + i);
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(Grit[i, j]);
                }
            }
        }

        public void EraseGrit()
        {
            for (int i = 0; i < 4; i++)
            {
                Gotoxy(Gx, Gy + i);
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(" ");
                }
            }
        }
        public void MoveFlapRight(char[,] Maze, char[,] Flap)
        {
            char next = Maze[Fy , Fx + 7];
            if (next == ' ')
            {
                EraseFlap();
                Fx++;
                PrintFlap(Flap);
            }
        }

        public void MoveFlapLeft(char[,] Maze, char[,] Flap)
        {
            char next = Maze[Fy, Fx - 1];
            if (next == ' ')
            {
                EraseFlap();
                Fx--;
                PrintFlap(Flap);
            }
        }

        public void MoveFlapUp(char[,] Maze, char[,] Flap)
        {
            char next = Maze[Fy - 1, Fx];
            if (next == ' ')
            {
                EraseFlap();
                Fy--;
                PrintFlap(Flap);
            }
        }
        public void MoveFlapDown(char[,] Maze, char[,] Flap)
        {
            char next = Maze[Fy + 2, Fx];
            if (next == ' ')
            {
                EraseFlap();
                Fy++;
                PrintFlap(Flap);
            }
        }

        public void MoveGrit(ref string gritDirection,char[,] Maze, char[,] Grit)
        {

            if (gritDirection == "down")
            {
                char next = Maze[Gy + 4, Gx];
                if (next == ' ')
                {
                    EraseGrit();
                    Gy++;
                    PrintGrit(Grit);
                }

                if (next == '=')
                {
                    gritDirection = "up";
                }
            }
            if (gritDirection == "up")
            {
                char next = Maze[Gy - 1, Gx];
                if (next == ' ')
                {
                    EraseGrit();
                    Gy--;
                    PrintGrit(Grit);
                }

                if (next == '=')
                {
                    gritDirection = "down";
                }
            }
        }
    }
}
