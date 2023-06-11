using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Pacman
{
    internal class Grid
    {
        public int rowsize;
        public int colsize;
        public Cell[,] Maze; 

        public Grid()
        {

        }
        public Grid(int rowsize,int colsize,string path)
        {
            this.rowsize = rowsize;
            this.colsize = colsize;

            if(File.Exists(path))
            {
                StreamWriter file = new StreamWriter(path);
                for (int i = 0; i < rowsize; i++) 
                {
                    for (int j = 0; j < colsize; j++)
                    {
                        file.Write(" ");
                    }
                    Console.WriteLine();
                }
            }
        }

        public Cell GetLeftCell(Cell C)
        {
            C.X = C.X - 1;
            C.SetValue(Maze[C.X, C.Y].value);
            Cell c = new Cell(C.value, C.X, C.Y);
            return c;
        }
        public Cell GetRightCell(Cell C)
        {

            C.X = C.X + 1;
            C.SetValue(Maze[C.X, C.Y].value);
            Cell c = new Cell(C.value, C.X, C.Y);
            return c;
        }

        public Cell GetUpCell(Cell C)
        {
            C.Y = C.Y - 1;
            C.SetValue(Maze[C.X, C.Y].value);
            Cell c = new Cell(C.value, C.X, C.Y);
            return c;
        }

        public Cell GetDownCell(Cell C)
        {
            C.Y = C.Y + 1;
            C.SetValue(Maze[C.X, C.Y].value);
            Cell c = new Cell(C.value, C.X, C.Y);
            return c;
        }
        public Cell FindPacMan()
        {
            for(int i=0;i<rowsize;i++)
            {
                for(int j=0;j<colsize;j++)
                {
                   if(Maze[i, j].value == 'P')
                   {
                        Cell C = new Cell(Maze[i, j].value, i, j);
                        return C;
                        break;
                   }
                }
            }
            return null;
        }

        public Cell FindGhost(char ghostcharacter)
        {
            for (int i = 0; i < rowsize; i++)
            {
                for (int j = 0; j < colsize; j++)
                {
                    if (Maze[i, j].value == ghostcharacter)
                    {
                        Cell C = new Cell(Maze[i, j].value, i, j);
                        return C;
                        break;
                    }
                }
            }
            return null;
        }

        public void StoreMaze(int rowsize,int colsize)
        {
            for (int i = 0; i < rowsize; i++)
            {
                for (int j = 0; j < colsize; j++) 
                {
                    Cell C = new Cell(' ', i, j);
                    Maze[i, j] = C;
                }
            }
        }

        public void ReadMaze(string path)
        {
            int row = 0;
            int col = 0;
            if(File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string record;
                while((record = file.ReadLine())!=null)
                {
                    for (int i = 0; i < record.Length; i++) 
                    {
                        Cell C = new Cell(record[i],col,i);
                        Maze[row,i] = C;
                        row++;
                    }
                    col++;
                }
            }
        }

        public void Draw()
        {
            for(int i=0;i<rowsize;i++)
            {
                for(int j=0;j<colsize;j++)
                {
                    Console.Write(Maze[i,j].value);
                }
                Console.WriteLine();
            }
        }

    }
}
