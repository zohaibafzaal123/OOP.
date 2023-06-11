using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class Bullets
    {
        public int Bx;
        public int By;
        public bool bulletActive;


        public void Gotoxy(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }
        public void GenerateBullet(char[,] Maze,List<Bullets> bull,Coordinate C)
        {
            char next = Maze[C.Fy, C.Fx + 7];
            if (next == ' ')
            {
                Bullets B = new Bullets();
                B.Bx = C.Fx + 7;
                B.By = C.Fy + 1; 
                B.bulletActive = true;
                bull.Add(B);
                Gotoxy(C.Fx + 7, C.Fy + 1);
                Console.Write(".");
            }
        }

        public void PrintBullet(int x, int y)
        {
            Gotoxy(x, y);
            Console.Write(".");
        }

        public void EraseBullet(int x, int y)
        {
            Gotoxy(x, y);
            Console.Write(" ");
        }

        public void MoveBullet(char[,] Maze, List<Bullets> bull)
        {
            foreach(var  B in bull)
            {
                if (B.bulletActive == true)
                {
                    char next = Maze[B.By + 1, B.Bx + 1];
                    if (next == ' ')
                    {
                        EraseBullet(B.Bx, B.By);
                        B.Bx++;
                        PrintBullet(B.Bx, B.By);
                    }
                    else
                    {
                        EraseBullet(B.Bx, B.By);
                        B.bulletActive = false;
                    }
                }
            }
        }

        public void BulletCollisionWithEnemy(char[,] Maze,List<Bullets> bull, ref int score)
        {
            foreach(var B in bull)
            {
                if (B.bulletActive == true)
                {
                    char next1 = Maze[B.By, B.Bx + 1];
                    if (next1 == '<' || next1 == '(')
                    {
                        score++;
                    }
                }
            }
        }

        public void PrintScore(ref int score)
        {
            Gotoxy(10, 2);
            Console.WriteLine("Score : {0}     ", score);
        }
    }
}
