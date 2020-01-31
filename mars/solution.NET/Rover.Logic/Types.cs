using System;

namespace Rover.Logic
{
    public enum RoverFacing
    {
        North,
        East,
        South,
        West
    }

    public static class RoverCommands
    {
        public const string ROTATE_LEFT_CMD = "L";
        public const string ROTATE_RIGHT_CMD = "R";
        public const string MOVE_FORWARD_CMD = "F";
    }

    public class RoverException : Exception
    {
        public RoverException(string message) : base(message)
        {

        }

    }

    public class RoverCrashLandedException : RoverException
    {
        public RoverCrashLandedException(string message) : base(message)
        {

        }
    }

}
