using Microsoft.VisualStudio.TestTools.UnitTesting;
using MissionMars.Data.Core.Enums;
using MissionMars.Data.Core.Model;
using MissionMars.Service.Interfaces;
using MissionMars.Service.Services;
using System;
using System.Collections.Generic;
using System.Text;
using MissionMars
namespace MissionMars.Tests
{
    [TestClass]
    public class MarsRoverTest
    {

        [TestMethod]
        public void RoverTest()
        {

            MarsSurface marsSurface = new MarsSurface(5, 5);

            IRoverActionService roverAction = new RoverActionService();

            var firstRoverCommand = roverAction.MoveCommands(new Rover
            {
                Coordinates = new Coordinates() { X = 1, Y = 2 },
                DirectionType = DirectionType.N,
                MarsSurface = marsSurface
            }, "LMLMLMLMM");

            var secondRoverCommand = roverAction.MoveCommands(new Rover
            {
                Coordinates = new Coordinates() { X = 3, Y = 3 },
                DirectionType = DirectionType.E,
                MarsSurface = marsSurface
            }, "MMRMMRMRRM");


            Assert.IsNotNull(firstRoverCommand);
            Assert.IsNotNull(secondRoverCommand);

            Assert.IsNotNull(firstRoverCommand);
            Assert.IsTrue(firstRoverCommand.Coordinates.X == 1);
            Assert.IsTrue(firstRoverCommand.Coordinates.Y == 3);
            Assert.AreEqual(firstRoverCommand.DirectionType, DirectionType.N);


        }
    }
}
