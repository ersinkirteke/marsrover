using System;

namespace Mars.Vehicle.Core
{
    public class Logger : ILogger
    {
        public void Log(IRover nasaRover)
        {
            Console.WriteLine($"{nameof(NasaRover)} logged");
        }
    }
}
