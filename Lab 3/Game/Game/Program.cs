using System.IO;
using EZInput;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int timer = 0;
            int score = 0;
            string gritDirection = "down";
            char[,] Flap ={
            {' ', ' ', ' ', '_', '_', ' ', ' '},
            {' ', '-', '(', ' ', '.', ')', '>'}};
            char[,] Grit = {
            { '<', '.', '.', '>'},
            { ' ', '(', ')', ' '},
            { '<', '|', '|', '>'},
            { ' ', '|', '|', ' '}};
            char[,] Maze = new char[200, 200];
            List<Bullets> bull = new List<Bullets>();
            string path = "F:\\OOP PDs\\Lab 3\\Game\\Maze.txt";
            Coordinate C = new Coordinate();
            Bullets B = new Bullets();
            Console.ReadKey();
            ReadMaze(path, Maze);
            PrintMaze(Maze);
            C.PrintFlap(Flap);
            C.PrintGrit(Grit);
            while(true)
            {
                B.PrintScore(ref score);
                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    C.MoveFlapRight(Maze, Flap);
                }

                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    C.MoveFlapLeft(Maze, Flap);
                }

                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    C.MoveFlapUp(Maze, Flap);
                }

                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    C.MoveFlapDown(Maze, Flap);
                }

                if (Keyboard.IsKeyPressed(Key.Space))
                {
                    B.GenerateBullet(Maze,bull,C);
                }
                B.MoveBullet(Maze, bull);

                if (timer == 5)
                {
                    C.MoveGrit(ref gritDirection,Maze, Grit);
                    timer = 0;
                }
                timer++;
                C.Gotoxy(1, 38);
                B.BulletCollisionWithEnemy(Maze, bull, ref score);
                Thread.Sleep(10);
            }
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



    }
}