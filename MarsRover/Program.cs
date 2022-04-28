using System;
using Mars.Vehicle.Core;
using Mars.Vehicle.Enums;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            IPlateu _plateu = new Plateu(5, 5);

            var _vehicle = new NasaRover(_plateu, 1, 2, Directions.North)
                .TurnLeft()
                .MoveForwards()
                .TurnLeft()
                .MoveForwards()
                .TurnLeft()
                .MoveForwards()
                .TurnLeft()
                .MoveForwards()
                .MoveForwards() as NasaRover;

            var _vehicle2 = new NasaRover(_plateu, 3, 3, Directions.East)
                .MoveForwards()
                .MoveForwards()
                .TurnRight()
                .MoveForwards()
                .MoveForwards()
                .TurnRight()
                .MoveForwards()
                .TurnRight()
                .TurnRight()
                .MoveForwards() as NasaRover;

            Console.WriteLine($"{_vehicle.X} {_vehicle.Y} {_vehicle.Direction.ToString()[0]}");
            Console.WriteLine($"{_vehicle2.X} {_vehicle2.Y} {_vehicle2.Direction.ToString()[0]}");
            Console.ReadLine();
        }
    }
}
