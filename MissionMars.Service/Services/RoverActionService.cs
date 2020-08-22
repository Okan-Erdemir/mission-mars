using MissionMars.Data.Core.Enums;
using MissionMars.Data.Core.Model;
using MissionMars.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissionMars.Service.Services
{
    public class RoverActionService: IRoverActionService
    {
        public Rover MoveCommands(Rover rover, string movedCommands)
        {
            foreach (var command in movedCommands)
            {
                switch (command)
                {
                    case ('L'):
                        rover.DirectionType = TurnLeft(rover.DirectionType);
                        break;
                    case ('R'):
                        rover.DirectionType = TurnRight(rover.DirectionType);
                        break;
                    case ('M'):
                        rover = Move(rover);
                        break;
                }
            }

            return rover;
        }

        private static DirectionType TurnLeft(DirectionType roverDirection)
        {
            switch (roverDirection)
            {
                case DirectionType.N:
                    roverDirection = DirectionType.W;
                    break;
                case DirectionType.E:
                    roverDirection = DirectionType.N;
                    break;
                case DirectionType.S:
                    roverDirection = DirectionType.E;
                    break;
                case DirectionType.W:
                    roverDirection = DirectionType.S;
                    break;
                default:
                    throw new InvalidOperationException();
            }
            return roverDirection;
        }

        private static DirectionType TurnRight(DirectionType roverDirection)
        {
            switch (roverDirection)
            {
                case DirectionType.N:
                    roverDirection = DirectionType.E;
                    break;
                case DirectionType.E:
                    roverDirection = DirectionType.S;
                    break;
                case DirectionType.S:
                    roverDirection = DirectionType.W;
                    break;
                case DirectionType.W:
                    roverDirection = DirectionType.N;
                    break;
                default:
                    throw new InvalidOperationException();
            }
            return roverDirection;
        }

        private Rover Move(Rover rover)
        {
            switch (rover.DirectionType)
            {
                case DirectionType.N:

                    rover.Coordinates = MoveNorth(rover.Coordinates);
                    break;
                case DirectionType.E:
                    rover.Coordinates = MoveEast(rover.Coordinates);
                    break;
                case DirectionType.S:
                    rover.Coordinates = MoveSouth(rover.Coordinates);
                    break;
                case DirectionType.W:
                    rover.Coordinates = MoveWest(rover.Coordinates);
                    break;
            }
            return rover;
        }

        private static Coordinates MoveEast(Coordinates coordinates)
        {
            return new Coordinates()
            {
                X = coordinates.X + 1,
                Y = coordinates.Y
            };
        }

        private static Coordinates MoveSouth(Coordinates coordinates)
        {
            return new Coordinates()
            {
                X = coordinates.X,
                Y = coordinates.Y - 1
            };
        }

        private static Coordinates MoveWest(Coordinates coordinates)
        {
            return new Coordinates()
            {
                X = coordinates.X - 1,
                Y = coordinates.Y
            };
        }

        private static Coordinates MoveNorth(Coordinates coordinates)
        {
            return new Coordinates()
            {
                X = coordinates.X,
                Y = coordinates.Y + 1
            };
        }
    }
}
