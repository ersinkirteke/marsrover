using System;
using System.Collections.Generic;

namespace Mars.Vehicle.Core
{
    public class Plateu : IPlateu
    {
        IDictionary<Tuple<int, int>, IVehicle> _vehicles;
        private int _y;
        private int _x;

        public Plateu(int x, int y)
        {
            _x = x;
            _y = y;
            _vehicles = new Dictionary<Tuple<int, int>, IVehicle>();
        }

        public void AddVehicle(IVehicle vehicle, int x, int y)
        {
            if (x > _x || y > _y)
            {
                throw new IndexOutOfRangeException("You can't add rover to outer space");
            }

            _vehicles.Add(Tuple.Create(x, y), vehicle);
        }

        public void MoveVehicle(int x, int y, int new_x, int new_y)
        {
            var _coordinates = Tuple.Create(x, y);
            IVehicle vehicle = _vehicles[_coordinates];
            AddVehicle(vehicle, new_x, new_y);
            _vehicles.Remove(_coordinates);
        }

        public bool IsAvailable(int x, int y)
        {
            if (_vehicles.Keys.Contains(Tuple.Create(x, y)))
            {
                return false;
            }

            if (x > _x || y > _y)
            {
                return false;
            }

            return true;
        }
    }
}
