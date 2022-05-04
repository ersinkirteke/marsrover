using System;
using Mars.Vehicle.Core;
using Mars.Vehicle.Enums;

namespace MarsRover
{
    class Program
    {
        static void Main()
        {
            var _plateu = new Plateu(5, 5);
            var nasa = new Nasa();

            var _vehicle = new NasaRover(_plateu, 1, 2, Directions.North);
            var _vehicle2 = new NasaRover(_plateu, 3, 3, Directions.East);
            var _vehicle3 = new NasaRoverWithLogger(_plateu, 4, 4, Directions.East);

            IVisitor logger = new RoverVisitor();

            nasa.Register(_vehicle);
            nasa.Register(_vehicle2);
            nasa.Register(_vehicle3);

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

            _vehicle3.Accept(logger);
            nasa.SendMessage(_vehicle3.Id, "M");
            _vehicle3.Accept(logger);
            nasa.SendMessage(_vehicle3.Id, "M");
            _vehicle3.Accept(logger);
            nasa.SendMessage(_vehicle3.Id, "R");
            _vehicle3.Accept(logger);
            nasa.SendMessage(_vehicle3.Id, "M");
            _vehicle3.Accept(logger);
            nasa.SendMessage(_vehicle3.Id, "M");
            _vehicle3.Accept(logger);
            nasa.SendMessage(_vehicle3.Id, "R");
            _vehicle3.Accept(logger);
            nasa.SendMessage(_vehicle3.Id, "M");
            _vehicle3.Accept(logger);
            nasa.SendMessage(_vehicle3.Id, "R");
            _vehicle3.Accept(logger);
            nasa.SendMessage(_vehicle3.Id, "R");
            _vehicle3.Accept(logger);
            nasa.SendMessage(_vehicle3.Id, "M");
            _vehicle3.Accept(logger);


            Console.WriteLine($"{_vehicle.X} {_vehicle.Y} {_vehicle.Direction.ToString()[0]}");
            Console.WriteLine($"{_vehicle2.X} {_vehicle2.Y} {_vehicle2.Direction.ToString()[0]}");
            Console.WriteLine($"{_vehicle3.X} {_vehicle3.Y} {_vehicle3.Direction.ToString()[0]}");
            Console.ReadLine();
        }
    }
}
