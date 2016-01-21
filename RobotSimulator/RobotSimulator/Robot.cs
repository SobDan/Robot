using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSimulator
{
    class Robot : IRobot
    {
        private const int tableSize = 5;

        private const int origin = 0;

        private bool isPlaced = false;

        public int XPos { get; set; } // Store XPosition

        public int YPos { get; set; }// Store YPosition

        public Direction Face { get; set; }

        public bool Move()
        {
            if (isPlaced)
            {
                int newX = MoveInXDir(XPos);
                int newY = MoveInYDir(YPos);

                if (PosIsValid(newX, newY))
                {
                    XPos = newX;
                    YPos = newY;
                }

            }

            return true;
        }


        private int MoveInXDir(int x)
        {
            if (Face == Direction.East)
                x = x + 1;

            else if (Face == Direction.West)
                x = x - 1;
            return x;

        }

        private int MoveInYDir(int y)
        {
            if (Face == Direction.North)
                y = y + 1;
            else if (Face == Direction.South)
                y = y - 1;
            return y;
        }

        public bool Place(PlaceArguments args)
        {
            if (PosIsValid(args.X, args.Y))
            {
                XPos = args.X;
                YPos = args.Y;
                Face = args.Face;

                return (isPlaced = true);
            }
            else
                return false;
        }

        public void Report()
        {
            if (isPlaced)
                Console.WriteLine(String.Format("Output: {0},{1},{2}", XPos.ToString(), YPos.ToString(), Face.ToString().ToUpper()));

        }

        public bool Left()
        {
            if (isPlaced)
            {
                switch (Face)
                {
                    case Direction.East:
                        Face = Direction.North;
                        break;
                    case Direction.West:
                        Face = Direction.South;
                        break;
                    case Direction.North:
                        Face = Direction.West;
                        break;
                    case Direction.South:
                        Face = Direction.East;
                        break;
                }
                return true;
            }
            return false;
        }

        public bool Right()
        {
            if (isPlaced)
            {
                switch (Face)
                {
                    case Direction.East:
                        Face = Direction.South;
                        break;
                    case Direction.West:
                        Face = Direction.North;
                        break;
                    case Direction.North:
                        Face = Direction.East;
                        break;
                    case Direction.South:
                        Face = Direction.West;
                        break;
                }
                return true;
            }
            return false;
        }

        public bool PosIsValid(int x, int y)
        {
            if (x < origin || x >= tableSize || y < origin || y >= tableSize)
                return false;
            else
                return true;
        }

    }



    public enum Direction
    {
        North = 1,
        South = 2,
        East = 3,
        West = 4,
        
    }

    public enum Command
    {
        Place = 1,
        Move = 2,
        Left = 3,
        Right = 4,
        Report = 5,
        Invalid = 6
    }

}
