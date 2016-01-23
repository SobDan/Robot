using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotSimulator;

namespace RobotSimulatorUnitTest
{
    [TestClass]
    public class RemoteControllerUnitTest
    {
        [TestMethod]
        public void Test_RunCommand() {
            Robot robot = new Robot();
            RemoteController controller = new RemoteController(robot);
            controller.RunCommand("Place 1,2,EAST");
            controller.RunCommand("Move");
            controller.RunCommand("Move");
            controller.RunCommand("LEFT");
            controller.RunCommand("Move");
            
            Assert.AreEqual(robot.Report(), "Output: 3,3,NORTH");
        }

        [TestMethod]
        public void Test_ParseInvaludCommand() {

            Robot robot = new Robot();
            RemoteController controller = new RemoteController(robot);
            controller.RunCommand("Place 1,2,EAST");

            Assert.AreEqual(controller.ParseCommand("MOVED"), Command.Invalid);

        }


        [TestMethod]
        public void Test_ParseValidCommand()
        {

            Robot robot = new Robot();
            RemoteController controller = new RemoteController(robot);
            controller.RunCommand("Place 1,2,EAST");
            Assert.AreEqual(controller.ParseCommand("MOVE"), Command.Move);

        }      

    }
}
