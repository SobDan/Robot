using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            
            RemoteController controller = new RemoteController(new Robot());
            controller.RunCommand("Place 0,0,NORTH");
            controller.RunCommand("MOVE");
            controller.RunCommand("Report");

            controller.RunCommand("Place 0,0,NORTH");
            controller.RunCommand("LEFT");
            controller.RunCommand("Report");

            controller.RunCommand("Place 1,2,EAST");
            controller.RunCommand("Move");
            controller.RunCommand("Move");
            controller.RunCommand("LEFT");
            controller.RunCommand("Move");
            controller.RunCommand("Report");

            Console.Read();

        }
    }
}
