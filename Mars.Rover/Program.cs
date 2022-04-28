using System;
using Mars.Vehicle.Core;
using Mars.Vehicle.Enums;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            var _plateu = new Plateu(5, 5);
            var nasa = new Nasa();

            var _vehicle = new NasaRover(_plateu, 1, 2, Directions.North);
            var _vehicle2 = new NasaRover(_plateu, 3, 3, Directions.East);

            nasa.Register(_vehicle);
            nasa.Register(_vehicle2);

            nasa.SendMessage(_vehicle.Id, "L");
            nasa.SendMessage(_vehicle.Id, "M");
            nasa.SendMessage(_vehicle.Id, "L");
            nasa.SendMessage(_vehicle.Id, "M");
            nasa.SendMessage(_vehicle.Id, "L");
            nasa.SendMessage(_vehicle.Id, "M");
            nasa.SendMessage(_vehicle.Id, "L");
            nasa.SendMessage(_vehicle.Id, "M");
            nasa.SendMessage(_vehicle.Id, "M");


            nasa.SendMessage(_vehicle2.Id, "M");
            nasa.SendMessage(_vehicle2.Id, "M");
            nasa.SendMessage(_vehicle2.Id, "R");
            nasa.SendMessage(_vehicle2.Id, "M");
            nasa.SendMessage(_vehicle2.Id, "M");
            nasa.SendMessage(_vehicle2.Id, "R");
            nasa.SendMessage(_vehicle2.Id, "M");
            nasa.SendMessage(_vehicle2.Id, "R");
            nasa.SendMessage(_vehicle2.Id, "R");
            nasa.SendMessage(_vehicle2.Id, "M");


            Console.WriteLine($"{_vehicle.X} {_vehicle.Y} {_vehicle.Direction.ToString()[0]}");
            Console.WriteLine($"{_vehicle2.X} {_vehicle2.Y} {_vehicle2.Direction.ToString()[0]}");
            Console.ReadLine();
        }
    }
}
