namespace Mars.Vehicle.Core
{
    public interface IVehicle
    {
        IVehicle MoveForwards();
        IVehicle TurnLeft();
        IVehicle TurnRight();
    }
}
