using RobotSimulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSimulator
{
    class RemoteController
    {
        private Robot robot;
        private PlaceArguments placeArguments;

        public RemoteController(Robot _robot)
        {
            robot = _robot;

        }
        public void RunCommand(string commandLine)
        {
            var command = ParseCommand(commandLine);

            switch (command)
            {
                case Command.Place:
                    robot.Place(placeArguments);
                    break;

                case Command.Move:
                    robot.Move();
                    break;

                case Command.Left:
                    robot.Left();
                    break;

                case Command.Right:
                    robot.Right();
                    break;

                case Command.Invalid:
                    break;

                case Command.Report:
                    robot.Report();
                    break;
                default:
                    break;
            }


        }
        public Command ParseCommand(string commandLine)
        {
            string[] args = commandLine.Split(' ');

            Command result;

            Enum.TryParse<Command>(args.First(), true, out result);

            if (result == Command.Place)
            {
                if (!ParsePlaceArgs(args.Last()))
                {
                    result = Command.Invalid;
                }

            }

            return result;

        }

        private bool ParsePlaceArgs(string arg)
        {
            string[] placeArgs = arg.Split(',');
            int x, y; Direction face;

            if (placeArgs.Length == 3 && int.TryParse(placeArgs[0], out x) &&
                    int.TryParse(placeArgs[1], out y) && Enum.TryParse<Direction>(placeArgs[2], true, out face))
            {
                placeArguments = new PlaceArguments
                {
                    X = x,
                    Y = y,
                    Face = face,
                };
                return true;
            }
            return false;
        }


    }

    //Argument object for Place Command

    public class PlaceArguments
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Face { get; set; }
    }
}
