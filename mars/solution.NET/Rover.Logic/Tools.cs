using System;
using System.Collections.Generic;

namespace Rover.Logic
{
    public static class Tools
    {
        static Random rnd = new Random();

        public static IEnumerable<MapCoordinates> Iterate(this Map map)
        {
            for (var x = 0; x < map.Width; x++)
                for (var y = 0; y < map.Height; y++)
                    yield return new MapCoordinates(x, y);
        }


        public static string StatusString(this RoverUnit rover)
        {
            if (rover != null)
                return $"Rover is now at {rover.Status.Position.AsText()} - facing {rover.Status.Facing}";
            return null;
        }

        public static RoverFacing RandomFacing()
        {
            Array values = Enum.GetValues(typeof(RoverFacing));
            var value = rnd.Next(0, values.Length);
            return (RoverFacing)values.GetValue(value);
        }

        public static MapCoordinates RandomPositionInMap(this Map map)
        {
            return new MapCoordinates(rnd.Next(0,map.Width), rnd.Next(0,map.Height));
        }

        public static MapCoordinates RandomPositionOutsideMap(this Map map)
        {
            long rndX = rnd.Next() + map.Width;
            long rndY = rnd.Next() + map.Height;

            return new MapCoordinates(rndX, rndY);
        }
    }
}
