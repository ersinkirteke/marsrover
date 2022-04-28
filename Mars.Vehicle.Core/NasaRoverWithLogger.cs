using Mars.Vehicle.Enums;

namespace Mars.Vehicle.Core
{
    public class NasaRoverWithLogger : NasaRover, IRover
    {
        public NasaRoverWithLogger(IPlateu plateu,
                int x,
                int y,
                Directions direction
            ) : base(plateu, x, y, direction)
        {

        }

        public void Accept(ILogger logger) => logger.Log(this);
    }
}
