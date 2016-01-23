using Microsoft.VisualStudio.TestTools.UnitTesting;

using RobotSimulator;

namespace RobotSimulatorUnitTest
{
    [TestClass]
    public class RobotUnitTest
    {

        [TestMethod]
        public void Test_PlaceCmd()
        {
            Robot robot = new Robot();

            Assert.IsTrue(PlaceAtOrigin(robot));
        }
        

        [TestMethod]
        public void Test_IgnoreInvalidPlaceCmd()
        {
            Robot robot = new Robot();

            Assert.IsFalse(robot.Place(new PlaceArguments()
            {
                Face = Direction.North,
                X = 10,
                Y = 10,
            })
            );
        }


        [TestMethod]
        public void Test_MoveBeforePlaceCmd()
        {
            Robot robot = new Robot();
            Assert.IsFalse(robot.Move());
        }


        [TestMethod]
        public void Test_MoveAfterPlaceCmd()
        {
            Robot robot = new Robot();

            PlaceAtOrigin(robot);
            
            Assert.IsTrue(robot.Move());
        }

        [TestMethod]
        public void Test_RightBeforePlaceCmd()
        {
            Robot robot = new Robot();
            Assert.IsFalse(robot.Right());
        }

        [TestMethod]
        public void Test_RightAfterPlaceCmd()
        {
            Robot robot = new Robot();
            PlaceAtOrigin(robot);
            robot.Right();
            Assert.AreEqual(robot.Face, Direction.East);
        }

        [TestMethod]
        public void Test_LeftBeforePlaceCmd()
        {
            Robot robot = new Robot();
            Assert.IsFalse(robot.Left());
        }
        [TestMethod]
        public void Test_LeftAfterPlaceCmd()
        {
            Robot robot = new Robot();
            PlaceAtOrigin(robot);
            robot.Left();
            Assert.AreEqual(robot.Face, Direction.West);
        }

        [TestMethod]
        public void Test_ReportBeforePlaceCmd()
        {
            Robot robot = new Robot();
            Assert.AreEqual(robot.Report(),"Error");
        }

        [TestMethod]
        public void Test_ReportAfterPlaceCmd()
        {
            Robot robot = new Robot();
            PlaceAtOrigin(robot);
            robot.Move();
            robot.Right();
            Assert.AreEqual(robot.Report(), "Output: 0,1,EAST");
        }



        private bool PlaceAtOrigin(Robot robot)
        {
           return ( robot.Place(new PlaceArguments()
            {

                Face = Direction.North,
                X = 0,
                Y = 0,
            }));
        }

    }
}
