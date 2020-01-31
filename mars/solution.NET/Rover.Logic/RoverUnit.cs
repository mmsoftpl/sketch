using System;

namespace Rover.Logic
{
    public interface IRoverUnit
    {
        RoverStatus Status { get;}
        CommandResult MoveTo(MapCoordinates destination);
        CommandResult Rotate(bool clockwise);
    }

    public class RoverUnit : IRoverUnit
    {
        public RoverStatus Status { get; private set; }
        public Map Map { get; private set; }
        internal RoverCommandModule CommandModule { get; private set; }

        internal RoverUnit(RoverStatus initialStatus, Map map)
        {
            Status = initialStatus;
            Map = map;
            CommandModule = new RoverCommandModule(this);
        }

        CommandResult IRoverUnit.MoveTo(MapCoordinates destination)
        {
            Status = new RoverStatus(Map.GetPosition(destination), Status.Facing);
            return true;
        }

        CommandResult IRoverUnit.Rotate(bool clockwise)
        {
            RoverFacing newFacing;
            if (clockwise)
                newFacing = Status.Facing == RoverFacing.West ? RoverFacing.North : (RoverFacing)((int)Status.Facing + 1);
            else
                newFacing = Status.Facing == RoverFacing.North ? RoverFacing.West : (RoverFacing)((int)Status.Facing - 1);

            Status = new RoverStatus(Status.Position, newFacing);

            return true;
        }

        public CommandResult ExecuteCommand(string command)
        {
            try
            {
                return CommandModule.ExecuteCommand(command);
            }
            catch (Exception exception)
            {
                return exception.Message;
            }

        }


    }
}
