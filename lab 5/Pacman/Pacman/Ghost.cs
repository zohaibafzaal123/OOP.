using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    internal class Ghost
    {
        public int X;
        public int Y;
        public string GhostDirection;
        public char GhostCharacter;
        public float GhostSpeed;
        public char PreviousItem;
        public float DeltaChange;
        public Grid MazeGrid;

        public Ghost(int X,int Y,string GhostDirection,char GhostCharacter,float GhostSpeed,char PreviousItem,Grid MazeGrid)
        {
            this.X = X;
            this.Y = Y;
            this.GhostDirection = GhostDirection;
            this.GhostCharacter = GhostCharacter;
            this.GhostSpeed = GhostSpeed;
            this.PreviousItem = PreviousItem;
            this.MazeGrid = MazeGrid;
        }

        public void SetDirection(string GhostDirection)
        {
            this.GhostDirection = GhostDirection;
        }

        public string GetDirection()
        {
            return GhostDirection;
        }

        public void Remove(int x,int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }

        public void Print(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(GhostCharacter);
        }

        public char GetCharacter()
        {
            return GhostCharacter;
        }

        public void ChangeDelta()
        {
            DeltaChange = DeltaChange + GhostSpeed;
        }

        public float GetDelta()
        {
            return DeltaChange;
        }

        public void SetDeltaZero()
        {
            DeltaChange = 0F;
        }

        public void move()
        {
            ChangeDelta();
            if(Math.Floor(GetDelta()) == 1)
            {
                if(GhostCharacter == 'H')
                {
                    MoveHorizontal(MazeGrid);
                }
                SetDeltaZero();
            }
        }

        public void MoveHorizontal(Grid GridMaze)
        {
            if (GetDirection() == "Up" )
            {
                if (GridMaze.Maze[X,Y-1].value == ' ')
                {
                    Y--;
                }
                else
                {
                    SetDirection("Down");
                }
            }
            if (GetDirection() == "Down")
            {
                if (GridMaze.Maze[X, Y + 1].value == ' ')
                {
                    Y++;
                }
                else
                {
                    SetDirection("Up");
                }
            }
        }
    }
}
