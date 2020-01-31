using System;

namespace Rover.Logic
{
    public class RoverCommandModule
    {
        private IRoverUnit _explorerUnit;

        public RoverCommandModule(IRoverUnit explorerUnit)
        {
            _explorerUnit = explorerUnit;
        }

        // MapCoordinates are using long type
        // Map dimensions are using int type, so bounds check and operations will always work fine (no overflow risk)
        private MapCoordinates CalculateNewPositon(int step)
        {
            long newX = _explorerUnit.Status.Position.X;
            long newY = _explorerUnit.Status.Position.Y;

            switch (_explorerUnit.Status.Facing)
            {
                case RoverFacing.North:
                    newX -= step; break;
                case RoverFacing.East:
                    newY += step; break;
                case RoverFacing.South:
                    newX += step; break;
                case RoverFacing.West:
                    newY -= step; break;
            }

            if (newX > int.MaxValue)
                throw new RoverException($"x coordinate outside bounds");

            if (newY > int.MaxValue)
                throw new RoverException($"y coordinate outside bounds");

            return new MapCoordinates(newX, newY);
        }

        internal CommandResult ExecuteCommand(string command)
        {
            switch (command)
            {
                case RoverCommands.ROTATE_LEFT_CMD: return _explorerUnit.Rotate(false);
                case RoverCommands.ROTATE_RIGHT_CMD: return _explorerUnit.Rotate(true);
                case RoverCommands.MOVE_FORWARD_CMD: return _explorerUnit.MoveTo(CalculateNewPositon(1));
                default: return "invalid command";
            }
        }
    }
}
