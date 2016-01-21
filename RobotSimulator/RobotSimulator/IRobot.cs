using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSimulator
{
    interface IRobot
    {
        bool Place(PlaceArguments args);

        bool Move();

        bool Left();
        
        bool Right();

        void Report();

        bool PosIsValid(int xCood, int yCood);

    }
}
