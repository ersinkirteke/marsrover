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

        public void Accept(IVisitor visitor) => visitor.Visit(this);
    }
}
