using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSimulator
{
    interface IRemoteController
    {
        void RunCommand();

        Command ParseCommand();

    }
}
