using Mars.Vehicle.Enums;
using System;

namespace Mars.Vehicle.Core
{
    public abstract class Rover : IVehicle
    {
        private Guid _id;
        private int _y;
        private int _x;
        private IPlateu _plateu;
        private Directions _direction;
        public ICompany Owner { get; set; }

        public Rover(IPlateu plateu, int x, int y, Directions direction)
        {
            _id = Guid.NewGuid();
            _plateu = plateu;
            _x = x;
            _y = y;
            _direction = direction;
            _plateu.AddVehicle(this, _x, _y);
        }

        public Directions Direction => _direction;
        public Guid Id => _id;
        public int X => this._x;
        public int Y => this._y;

        public virtual IVehicle MoveForwards()
        {
            var _new_x = _direction.Equals(Directions.North) || _direction.Equals(Directions.South) ? _x
                 : _x + (_direction.Equals(Directions.East) ? +1 : -1);

            var _new_y = _direction.Equals(Directions.East) || _direction.Equals(Directions.West) ? _y
                 : _y + (_direction.Equals(Directions.North) ? +1 : -1);

            if (_plateu.IsAvailable(_new_x, _new_y))
            {
                _plateu.MoveVehicle(_x, _y, _new_x, _new_y);
                _x = _new_x;
                _y = _new_y;
            }

            return this;
        }

        public virtual IVehicle TurnLeft()
        {
            switch (_direction)
            {
                case Directions.North:
                    _direction = Directions.West;
                    break;
                case Directions.South:
                    _direction = Directions.East;
                    break;
                case Directions.East:
                    _direction = Directions.North;
                    break;
                case Directions.West:
                    _direction = Directions.South;
                    break;
                default:
                    break;
            }

            return this;
        }

        public virtual IVehicle TurnRight()
        {
            switch (_direction)
            {
                case Directions.North:
                    _direction = Directions.East;
                    break;
                case Directions.South:
                    _direction = Directions.West;
                    break;
                case Directions.East:
                    _direction = Directions.South;
                    break;
                case Directions.West:
                    _direction = Directions.North;
                    break;
                default:
                    break;
            }

            return this;
        }

        public virtual void ReceiveMessage(string message)
        {
            if (Owner != null)
            {
                switch (message)
                {
                    case "R":
                        TurnRight();
                        break;
                    case "L":
                        TurnLeft();
                        break;
                    case "M":
                        MoveForwards();
                        break;
                    default:
                        break;
                }
            }
            else
                Console.WriteLine($"Not permitted rover, rover id { Id}");
        }
    }
}
