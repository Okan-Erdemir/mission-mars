using MissionMars.Data.Core.Enums;
using MissionMars.Data.Core.Model;
using MissionMars.Service.Interfaces;
using MissionMars.Service.Services;
using System;
using Xunit;

namespace MissionMars.Test.Unit
{
    public class MarsRoverTest
    {
        [Fact]
        public void FirstRoverTest()
        {

            MarsSurface marsSurface = new MarsSurface(5, 5);

            IRoverActionService roverAction = new RoverActionService();

            var firstRoverCommand = roverAction.MoveCommands(new Rover
            {
                Coordinates = new Coordinates() { X = 1, Y = 2 },
                DirectionType = DirectionType.N,
                MarsSurface = marsSurface
            }, "LMLMLMLMM");


            Assert.NotNull(firstRoverCommand);

            Assert.NotNull(firstRoverCommand);
            Assert.True(firstRoverCommand.Coordinates.X == 1);
            Assert.True(firstRoverCommand.Coordinates.Y == 3);
            Assert.Equal(DirectionType.N, firstRoverCommand.DirectionType);

        }

        [Fact]
        public void SecondRoverTest()
        {

            MarsSurface marsSurface = new MarsSurface(5, 5);

            IRoverActionService roverAction = new RoverActionService();

           
            var secondRoverCommand = roverAction.MoveCommands(new Rover
            {
                Coordinates = new Coordinates() { X = 3, Y = 3 },
                DirectionType = DirectionType.E,
                MarsSurface = marsSurface
            }, "MMRMMRMRRM");


            Assert.NotNull(secondRoverCommand);

            Assert.NotNull(secondRoverCommand);
            Assert.True(secondRoverCommand.Coordinates.X == 5);
            Assert.True(secondRoverCommand.Coordinates.Y == 1);
            Assert.Equal(DirectionType.E, secondRoverCommand.DirectionType);

        }
    }
}
