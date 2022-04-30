using System;

namespace Mars.Vehicle.Core
{
    public class RoverVisitor : IVisitor
    {
        public void Visit(IRover rover)
        {
            Console.WriteLine($"{nameof(NasaRover)} logged");
        }
    }
}
