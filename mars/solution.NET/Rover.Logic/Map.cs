namespace Rover.Logic
{

    // !MapCoordinates are using long type
    // !Map dimensions are using int type, so bounds check and operations will always work fine (no overflow risk)
    //
    //One could consider using unsigned types for Width and Height
    //but generally using unsigned types sometimes results in more casting/conversions inside code
    //for example when using Random function or during unit testing 
    //
    public class Map
    {
        public readonly int Width;
        public readonly int Height;

        public Map(int width, int height)
        {
            if (width < 0)
                throw new RoverException($"Map width can't be negative, Width = {width}");

            if (height < 0)
                throw new RoverException($"Map height can't be negative, height = {height}");

            Width = width;
            Height = height;
        }

        public bool CheckCoordinates(long x, long y)
        {
            return x >= 0 && y >= 0 && x < Width && y < Height;
        }

        public bool CheckCoordinates(MapCoordinates position)
        {
           return CheckCoordinates(position.X, position.Y);
        }

        //I prefer to not overwrite ToString() method
        public string AsText()
        {
            return $"({Width} x {Height})";
        }

        internal MapCoordinates GetPosition(MapCoordinates position)
        {
            if (!CheckCoordinates(position))
                throw new RoverException($"unreachable location {position.AsText()}");
            return new MapCoordinates(position.X, position.Y);
        }
    }
}
