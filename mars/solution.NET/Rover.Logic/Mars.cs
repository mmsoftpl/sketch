using System;

namespace Rover.Logic
{
    public static class Mars
    {
        public static RoverUnit StartExpedition(Map map, MapCoordinates startLocation, RoverFacing facing)
        {
            if (!map.CheckCoordinates(startLocation))
                throw new RoverCrashLandedException($"Rover crash landed on Mars, start location {startLocation.AsText()} unreachable on {map.AsText()} map");

            return new RoverUnit(new RoverStatus(map.GetPosition(startLocation),facing), map);
        }

        public static RoverUnit StartExpedition(Map map)
        {
            return StartExpedition(map, map.RandomPositionInMap(), Tools.RandomFacing());
        }
    }
}
