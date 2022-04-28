using System;

namespace Mars.Vehicle.Core
{
    public interface IVehicle
    {
        Guid Id { get; set; }
        ICompany Owner { get; set; }
        IVehicle MoveForwards();
        IVehicle TurnLeft();
        IVehicle TurnRight();
    }
}
