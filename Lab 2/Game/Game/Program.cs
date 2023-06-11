using EZInput;
using System.Net.Http.Headers;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int timer = 0;
            int score = 0;
            List<Bullet> bull = new List<Bullet>();
            int count = 0;
            string gritDirection = "down";
            char[,] Maze = new char[200, 200];
            char[,] Flap ={
            {' ', ' ', ' ', '_', '_', ' ', ' '},
            {' ', '-', '(', ' ', '.', ')', '>'}};
            char[,] Grit = {
            { '<', '.', '.', '>'},
            { ' ', '(', ')', ' '},
            { '<', '|', '|', '>'},
            { ' ', '|', '|', ' '}};
            string path = "F:\\OOP PDs\\Lab 2\\Game\\Maze.txt";
            ReadMaze(path, Maze);
            Coordinates coordinate = new Coordinates();
            Console.ReadKey();
            PrintMaze(Maze);
            PrintFlap(coordinate, Flap);
            PrintGrit(coordinate, Grit);
            while (true)
            {
                PrintScore(ref score);
                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    MoveFlapRight(coordinate, Maze, Flap);
                }

                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    MoveFlapLeft(coordinate, Maze, Flap);
                }

                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    MoveFlapUp(coordinate, Maze, Flap);
                }

                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    MoveFlapDown(coordinate, Maze, Flap);
                }

                if (Keyboard.IsKeyPressed(Key.Space))
                {
                    GenerateBullet(Maze,coordinate,bull);
                }
                MoveBullet(Maze, bull);
                timer++;
                if (timer == 5)
                {
                    MoveGrit(ref gritDirection, coordinate, Maze, Grit);
                    timer = 0;
                }
                BulletCollisionWithEnemy(Maze, coordinate, bull,ref score);
                Thread.Sleep(10);
            }
            Gotoxy(1, 38);
        }

        static void ReadMaze(string path, char[,] Maze)
        {
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string record;
                int row = 0;
                while ((record = file.ReadLine()) != null)
                {
                    for (int i = 0; i < record.Length; i++)
                    {
                        Maze[row, i] = record[i];
                    }
                    row++;
                }
                file.Close();
            }
        }

        static void Gotoxy(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }

        static void PrintMaze(char[,] Maze)
        {
            for (int i = 0; i < 32; i++)
            {
                for (int j = 0; j < 143; j++)
                {
                    Console.Write(Maze[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void PrintFlap(Coordinates C, char[,] Flap)
        {
            for (int i = 0; i < 2; i++)
            {
                Gotoxy(C.Fx, C.Fy + i);
                for (int j = 0; j < 7; j++)
                {
                    Console.Write(Flap[i, j]);
                }
            }
        }

        static void EraseFlap(Coordinates C, char[,] Flap)
        {
            for (int i = 0; i < 2; i++)
            {
                Gotoxy(C.Fx, C.Fy + i);
                for (int j = 0; j < 7; j++)
                {
                    Console.Write(" ");
                }
            }
        }

        static void PrintGrit(Coordinates C, char[,] Grit)
        {
            for (int i = 0; i < 4; i++)
            {
                Gotoxy(C.Gx, C.Gy + i);
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(Grit[i, j]);
                }
            }
        }

        static void EraseGrit(Coordinates C, char[,] Grit)
        {
            for (int i = 0; i < 4; i++)
            {
                Gotoxy(C.Gx, C.Gy + i);
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(" ");
                }
            }
        }

        static void MoveFlapRight(Coordinates C, char[,] Maze, char[,] Flap)
        {
            char next = Maze[C.Fy, C.Fx + 7];
            if (next == ' ')
            {
                EraseFlap(C, Flap);
                C.Fx++;
                PrintFlap(C, Flap);
            }
        }

        static void MoveFlapLeft(Coordinates C, char[,] Maze, char[,] Flap)
        {
            char next = Maze[C.Fy, C.Fx - 1];
            if (next == ' ')
            {
                EraseFlap(C, Flap);
                C.Fx--;
                PrintFlap(C, Flap);
            }
        }

        static void MoveFlapUp(Coordinates C, char[,] Maze, char[,] Flap)
        {
            char next = Maze[C.Fy - 1, C.Fx];
            if (next == ' ')
            {
                EraseFlap(C, Flap);
                C.Fy--;
                PrintFlap(C, Flap);
            }
        }
        static void MoveFlapDown(Coordinates C, char[,] Maze, char[,] Flap)
        {
            char next = Maze[C.Fy + 2, C.Fx];
            if (next == ' ')
            {
                EraseFlap(C, Flap);
                C.Fy++;
                PrintFlap(C, Flap);
            }
        }

        static void MoveGrit(ref string gritDirection, Coordinates C, char[,] Maze, char[,] Grit)
        {

            if (gritDirection == "down")
            {
                char next = Maze[C.Gy + 4, C.Gx];
                if (next == ' ')
                {
                    EraseGrit(C, Grit);
                    C.Gy++;
                    PrintGrit(C, Grit);
                }

                if (next == '=')
                {
                    gritDirection = "up";
                }
            }
            if (gritDirection == "up")
            {
                char next = Maze[C.Gy - 1, C.Gx];
                if (next == ' ')
                {
                    EraseGrit(C, Grit);
                    C.Gy--;
                    PrintGrit(C, Grit);
                }

                if (next == '=')
                {
                    gritDirection = "down";
                }
            }

        }

        static void GenerateBullet(char[,] Maze,Coordinates C,List<Bullet> bull)
        {
            char next = Maze[C.Fy, C.Fx + 7];
            if(next == ' ')
            {
                Bullet B = new Bullet();
                B.Bx = C.Fx + 7;
                B.By = C.Fy + 1;
                B.bulletActive = true;
                bull.Add(B);
                Gotoxy(C.Fx + 7, C.Fy + 1);
                Console.Write(".");
            }
        }

        static void PrintBullet(int x,int y)
        {
            Gotoxy(x, y);
            Console.Write(".");
        }

        static void EraseBullet(int x, int y)
        {
            Gotoxy(x, y);
            Console.Write(" ");
        }

        static void MoveBullet(char[,] Maze,List<Bullet> bull)
        {
            for(int i=0;i< bull.Count;i++)
            {
                if (bull[i].bulletActive == true)
                {
                    char next = Maze[bull[i].By+1, bull[i].Bx + 1];
                    if(next == ' ')
                    {
                        EraseBullet(bull[i].Bx, bull[i].By);
                        bull[i].Bx++;
                        PrintBullet(bull[i].Bx, bull[i].By);
                    }
                    else
                    {
                        EraseBullet(bull[i].Bx, bull[i].By);
                        bull[i].bulletActive = false;
                    }

                }
            }
        }

        static void BulletCollisionWithEnemy(char[,] Maze,Coordinates C,List<Bullet> bull,ref int score)
        {
            for(int i=0;i< bull.Count;i++)
            {
                if (bull[i].bulletActive == true)
                {
                    char next1 = Maze[bull[i].By , bull[i].Bx + 1];
                    if(next1 == '<' || next1 == '(' || next1 == '|')
                    {
                        score++; 
                    }
                }

            }
        }

        static void PrintScore(ref int score)
        {
            Gotoxy(10,2);
            Console.WriteLine("Score : {0}     ",score);

        }
    }
}