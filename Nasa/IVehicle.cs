using System;
using System.Collections.Generic;
using System.Text;

namespace Nasa
{
    public interface IVehicle:IThing
    {
        IVehicle MoveForwards();
        IVehicle TurnLeft();
        IVehicle TurnRight();
    }
}
