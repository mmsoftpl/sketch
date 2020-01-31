namespace Rover.Logic
{

    public class RoverStatus
    {
        public readonly RoverFacing Facing;

        public readonly MapCoordinates Position;

        internal RoverStatus(MapCoordinates position, RoverFacing facing)
        {
            Position = position;
            Facing = facing;
        }

    }
}
