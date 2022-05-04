namespace Mars.Vehicle.Core
{
    public class Plateu : IPlateu
    {
        private readonly Dictionary<Coordinate, IVehicle> _vehicles = new();
        private readonly int _y;
        private readonly int _x;

        public Plateu(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public void AddVehicle(IVehicle vehicle, int x, int y)
        {
            if (x > _x || y > _y)
            {
                throw new IndexOutOfRangeException("You can't add rover to outer space");
            }

            _vehicles.Add(new(x, y), vehicle);
        }

        public void MoveVehicle(int x, int y, int new_x, int new_y)
        {
            Coordinate _coordinate = new(x, y);
            IVehicle vehicle = _vehicles[_coordinate];
            AddVehicle(vehicle, new_x, new_y);
            _vehicles.Remove(_coordinate);
        }

        public bool IsAvailable(int x, int y)
        {
            if (_vehicles.ContainsKey(new(x, y)))
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
