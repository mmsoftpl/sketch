using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rover.Logic;

namespace Rovert.Test
{
    [TestClass]
    public class MarsMission_Test
    {
        //[TestMethod]
        //[ExpectedException(typeof(RoverCrashLandedException))]
        //public void Rover_Create_Test1()
        //{
        //    var rover = Mars.StartExpedition(new Map(), new Position(), RoverFacing.North);
        //    Assert.IsNull(rover);
        //}

        [TestMethod]
        [ExpectedException(typeof(RoverCrashLandedException))]
        public void Rover_Create_Test2()
        {
            var rover = Mars.StartExpedition(new Map(2,2), new MapCoordinates(2,2), RoverFacing.South);
            Assert.IsNull(rover);
        }

        [TestMethod]
        public void Rover_InvalidCommand_Test()
        {
            var rover = Mars.StartExpedition(new Map(2, 2), new MapCoordinates(1, 1), RoverFacing.East);
            Assert.IsNotNull(rover);

            var actionResult = rover.ExecuteCommand("k");
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(actionResult.Success, false);

            actionResult = rover.ExecuteCommand(null);
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(actionResult.Success, false);

            actionResult = rover.ExecuteCommand(string.Empty);
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(actionResult.Success, false);
        }

        //        As a controller user I want the rover to be able to move forward
        //- Given the Is at position 1.1 and the rover is facing North, when the rover moves forward, the rover is in position 0,1.
        [TestMethod]
        public void Rover_Move_Forward_Test()
        {
            var rover = Mars.StartExpedition(new Map(4, 4), new MapCoordinates(1, 1), RoverFacing.North);
            Assert.IsNotNull(rover);

            var actionResult1 = rover.ExecuteCommand(RoverCommands.MOVE_FORWARD_CMD);
            Assert.IsNotNull(actionResult1);
            Assert.AreEqual(actionResult1.Success, true);
            Assert.AreEqual(rover.Status.Position.X, 0);
            Assert.AreEqual(rover.Status.Position.Y, 1);
        }

        //        As a controller user I want the rover to be able to rotate left
        //- Given the rover is facing North, when  the river rotates Left, Then the rover is facing West.
        //- Given the rover is facing West, when the river rotates Left, Then the rover is facing South.
        //- Given the rover is facing South, when the river rotates Left, Then the rover is facing East.
        //- Given the rover is facing East, when the river rotates Left, Then the rover is facing North.
        [TestMethod]
        public void Rover_Rotate_Left_Check()
        {
            var rover = Mars.StartExpedition(new Map(4, 4), new MapCoordinates(0, 0), RoverFacing.North);
            Assert.IsNotNull(rover);

            var actionResult = rover.ExecuteCommand(RoverCommands.ROTATE_LEFT_CMD);
            Assert.AreEqual(actionResult.Success, true);
            Assert.AreEqual(rover.Status.Facing, RoverFacing.West);

            actionResult = rover.ExecuteCommand(RoverCommands.ROTATE_LEFT_CMD);
            Assert.AreEqual(actionResult.Success, true);
            Assert.AreEqual(rover.Status.Facing, RoverFacing.South);

            actionResult = rover.ExecuteCommand(RoverCommands.ROTATE_LEFT_CMD);
            Assert.AreEqual(actionResult.Success, true);
            Assert.AreEqual(rover.Status.Facing, RoverFacing.East);

            actionResult = rover.ExecuteCommand(RoverCommands.ROTATE_LEFT_CMD);
            Assert.AreEqual(actionResult.Success, true);
            Assert.AreEqual(rover.Status.Facing, RoverFacing.North);

            Assert.AreEqual(rover.Status.Position.AsText(), "(0,0)");

        }

        //        As a controller user I want the rover to be able to rotate right
        //- Given the rover is facing North, when the rover rotates right, Then the rover is facing East.
        //- Given the rover is facing East, when the rover rotates right, Then the rover is facing South.
        //- Given the rover is facing South, when the rover rotates right, Then the rover is facing West.
        //- Given the rover is facing West, when the rover rotates right, Then the rover is facing North.
        [TestMethod]
        public void Rover_Rotate_Right_Check()
        {
            var rover = Mars.StartExpedition(new Map(4, 4), new MapCoordinates(0, 0), RoverFacing.North);
            Assert.IsNotNull(rover);

            var actionResult = rover.ExecuteCommand(RoverCommands.ROTATE_RIGHT_CMD);
            Assert.AreEqual(actionResult.Success, true);
            Assert.AreEqual(rover.Status.Facing, RoverFacing.East);

            actionResult = rover.ExecuteCommand(RoverCommands.ROTATE_RIGHT_CMD);
            Assert.AreEqual(actionResult.Success, true);
            Assert.AreEqual(rover.Status.Facing, RoverFacing.South);

            actionResult = rover.ExecuteCommand(RoverCommands.ROTATE_RIGHT_CMD);
            Assert.AreEqual(actionResult.Success, true);
            Assert.AreEqual(rover.Status.Facing, RoverFacing.West);

            actionResult = rover.ExecuteCommand(RoverCommands.ROTATE_RIGHT_CMD);
            Assert.AreEqual(actionResult.Success, true);
            Assert.AreEqual(rover.Status.Facing, RoverFacing.North);

            Assert.AreEqual(rover.Status.Position.AsText(), "(0,0)");
        }

        //        As a controller I want to be able to see the rover’s position once it has moved
        //- When the user moves the rover to(1,1), the rover’s position is displayed in the format(1,1)
        [TestMethod]
        public void Rover_PositionDisplay_Check()
        {
            var rover = Mars.StartExpedition(new Map(4, 4), new MapCoordinates(1, 1), RoverFacing.North);
            Assert.IsNotNull(rover);
            Assert.AreEqual(rover.Status.Position.X, 1);
            Assert.AreEqual(rover.Status.Position.Y, 1);
            Assert.AreEqual(rover.Status.Position.AsText(), "(1,1)");
        }

        //As a controller I don’t want the rover to be able to move outside the confines of the grid
        //Given the Rover is facing West and is at position(0,0), when the user tries to move forward, the rovers position does not change
        [TestMethod]
        public void Rover_PositionNotChange_Check()
        {
            var rover = Mars.StartExpedition(new Map(4, 4), new MapCoordinates(0, 0), RoverFacing.West);

            var actionResult1 = rover.ExecuteCommand(RoverCommands.MOVE_FORWARD_CMD);
            Assert.IsNotNull(actionResult1);
            Assert.AreEqual(actionResult1.Success, false);
            Assert.AreEqual(rover.Status.Position.X, 0);
            Assert.AreEqual(rover.Status.Position.Y, 0);
            Assert.AreEqual(rover.Status.Position.AsText(), "(0,0)");
        }
    }
}