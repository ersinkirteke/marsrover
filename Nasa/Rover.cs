using Nasa.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nasa
{
    public class Rover : IVehicle
    {
        private int _y;
        private int _x;
        private IPlateu _plateu;
        private Directions _direction;

        public Rover(IPlateu plateu, int x, int y, Directions direction)
        {
            _plateu = plateu;
            _x = x;
            _y = y;
            _direction = direction;
            _plateu.AddThing(this, _x, _y);
        }
        public Directions Direction => this._direction;
        public int X => this._x;
        public int Y => this._y;

        public IVehicle MoveForwards()
        {
            var _new_x = _direction.Equals(Directions.North) || _direction.Equals(Directions.South) ? _x
                 : _x + (_direction.Equals(Directions.East) ? +1 : -1);

            var _new_y = _direction.Equals(Directions.East) || _direction.Equals(Directions.West) ? _y
                 : _y + (_direction.Equals(Directions.North) ? +1 : -1);

            if (_plateu.IsAvailable(_new_x, _new_y))
            {
                _plateu.MoveThing(_x, _y, _new_x, _new_y);
                _x = _new_x;
                _y = _new_y;
            }

            return this;
        }

        public IVehicle TurnLeft()
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

        public IVehicle TurnRight()
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
    }
}
