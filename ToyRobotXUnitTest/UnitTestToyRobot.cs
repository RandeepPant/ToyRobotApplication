using ToyRobot;
using Xunit;

namespace ToyRobotXUnitTest
{
    public class UnitTestToyRobot
    {
        [Fact]
        public void Place_Valid_Position_Direction()
        {
            Robot robot = new Robot();

            robot.Place("1,2,EAST",5);

            Assert.True( robot.IsPlaced);
            Assert.Equal(1, robot.X);
            Assert.Equal(2, robot.Y);
        }

        [Fact]
        public void Move_OneStep_to_Facing_Direction()
        {
            Robot robot = new Robot();

            robot.Place("1,2,EAST", 5);

            robot.Move(5);

            Assert.Equal(2, robot.X);
            Assert.Equal(2, robot.Y);

        }
        
        [Fact]
        public void Turn_Left_Rotate_AntiClockwise_90()
        {
            Robot robot = new Robot();

            robot.Place("1,2,EAST", 5);

            robot.TurnLeft();

            Assert.Equal(1, robot.X);
            Assert.Equal(2, robot.Y); 
            Assert.Equal("NORTH", robot.Direction);
        }

        [Fact]
        public void Turn_Right_Rotate_Clockwise_90()
        {
            Robot robot = new Robot();

            robot.Place("1,2,EAST", 5);

            robot.TurnRight();

            Assert.Equal(1, robot.X);
            Assert.Equal(2, robot.Y);
            Assert.Equal("SOUTH", robot.Direction);
        }
    }
}