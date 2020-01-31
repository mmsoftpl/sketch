using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rover.Logic;

namespace Rovert.Test
{
    [TestClass]
    public class MarsMapTest
    {
        [TestMethod]
        public void RoverMap_Create_Test()
        {
            Map map_5_x_15 = new Map(5, 15);
            Assert.AreEqual(map_5_x_15.Width, 5);
            Assert.AreEqual(map_5_x_15.Height, 15);

            Map map_0_x_15 = new Map(0, 15);
            Assert.AreEqual(map_0_x_15.Width, 0);
            Assert.AreEqual(map_0_x_15.Height, 15);

            Map map_5_x_0 = new Map(5, 0);
            Assert.AreEqual(map_5_x_0.Width, 5);
            Assert.AreEqual(map_5_x_0.Height, 0);

            Map map_0_x_0 = new Map(0, 0);
            Assert.AreEqual(map_0_x_0.Width, 0);
            Assert.AreEqual(map_0_x_0.Height, 0);
        }

        [TestMethod]
        public void RoverMap_OverflowCheck_Test1()
        {
            long maxV = int.MaxValue;
            maxV++;

            MapCoordinates positionOutsideMapCoordinates = new MapCoordinates(maxV, maxV);

            Map map = new Map(int.MaxValue, int.MaxValue);

            Assert.IsFalse(map.CheckCoordinates(positionOutsideMapCoordinates));
        }


        [TestMethod]
        [ExpectedException(typeof(RoverException))]
        public void RoverMap_NegativeCreate_Test1()
        {
            Map position = new Map(2, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(RoverException))]
        public void RoverMap_NegativeCreate_Test2()
        {
            Map position = new Map(-1, 3);
        }

        [TestMethod]
        public void RoverMap_ValidatePosition_Test()
        {
            int mapWidth = 3;
            int mapHeight = 2;

            Map map = new Map(mapWidth, mapHeight);
            Assert.AreEqual(map.Width, mapWidth);
            Assert.AreEqual(map.Height, mapHeight);

            //all positions within map borders should be valid
            foreach (var position in map.Iterate())
                Assert.AreEqual(true, map.CheckCoordinates(position));

            //test borders
            for (int x = 0; x <= mapWidth ; x++)
                Assert.AreEqual(false, map.CheckCoordinates(x, mapHeight));

            for (int y = mapHeight; y <= mapHeight; y++)
                Assert.AreEqual(false, map.CheckCoordinates(mapWidth, y));

            //test 5 random locations outside map, should be always not valid
            Random rnd = new Random();
            for (int r = 0; r < 5; r++)
            {
                MapCoordinates randomPosition = map.RandomPositionOutsideMap();

                Assert.AreEqual(false, map.CheckCoordinates(randomPosition), $"Position {randomPosition} should be invalid");

            }
        }
    }
}
