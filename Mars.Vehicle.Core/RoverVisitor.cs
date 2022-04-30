using System;

namespace Mars.Vehicle.Core
{
    public class RoverVisitor : IVisitor
    {
        public void Visit(IRover rover)
        {
            Rover roverLogged = rover as Rover;
            Console.WriteLine($"{nameof(NasaRover)} logged, rover position:{roverLogged.X} - {roverLogged.Y}, rover direction:{roverLogged.Direction}");
        }
    }
}
