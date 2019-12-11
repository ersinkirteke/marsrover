using Nasa;
using Nasa.Enums;
using System;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            IPlateu _plateu = new Plateu(5, 5);

            var _vehicle = (Rover)new Rover(_plateu, 1, 2, Directions.North)
                .TurnLeft()
                .MoveForwards()
                .TurnLeft()
                .MoveForwards()
                .TurnLeft()
                .MoveForwards()
                .TurnLeft()
                .MoveForwards()
                .MoveForwards();

            var _vehicle2 = (Rover)new Rover(_plateu, 3, 3, Directions.East)
                .MoveForwards()
                .MoveForwards()
                .TurnRight()
                .MoveForwards()
                .MoveForwards()
                .TurnRight()
                .MoveForwards()
                .TurnRight()
                .TurnRight()
                .MoveForwards();

            Console.WriteLine($"{_vehicle.X} {_vehicle.Y} {_vehicle.Direction.ToString()[0]}");
            Console.WriteLine($"{_vehicle2.X} {_vehicle2.Y} {_vehicle2.Direction.ToString()[0]}");
            Console.ReadLine();
        }
    }
}
