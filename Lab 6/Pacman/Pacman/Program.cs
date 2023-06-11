namespace Pacman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "F:\\OOP PDs\\Lab 6\\Pacman\\Maze.txt";
            Grid G = new Grid(10, 10, path);
            G.Draw();
            Console.ReadKey();
        }
    }
}