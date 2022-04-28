using Mars.Vehicle.Enums;

namespace Mars.Vehicle.Core
{
    public class NasaRover : Rover
    {
        public NasaRover(
                IPlateu plateu,
                int x,
                int y,
                Directions direction
            ) : base(plateu, x, y, direction)
        {

        }
    }
}
