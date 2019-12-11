
namespace Nasa
{
    public interface IVehicle:IThing
    {
        IVehicle MoveForwards();
        IVehicle TurnLeft();
        IVehicle TurnRight();
    }
}
