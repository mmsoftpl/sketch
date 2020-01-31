using System;
using System.Diagnostics;

namespace Rover.Logic
{

    [DebuggerDisplay("X = {X}, Y = {Y}}")]
    public class MapCoordinates
    {
        public readonly long X;
        public readonly long Y;
        public MapCoordinates(long x, long y)
        {
            X = x;
            Y = y;
        }

        //I prefer to not overwrite ToString() method
        public string AsText()
        {
            return $"({X},{Y})";
        }
    }

}
