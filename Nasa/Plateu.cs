using System;
using System.Collections.Generic;
using System.Text;

namespace Nasa
{
    public class Plateu : IPlateu
    {
        IDictionary<Tuple<int, int>, IThing> _things;
        private int _y;
        private int _x;

        public Plateu(int x, int y)
        {
            _x = x;
            _y = y;
            _things = new Dictionary<Tuple<int, int>, IThing>();
        }

        public void AddThing(IThing thing, int x, int y)
        {
            if (x > _x || y > _y)
            {
                throw new IndexOutOfRangeException("You can't add anything to outer space");
            }

            _things.Add(Tuple.Create(x, y), thing);
        }

        public void MoveThing(int x, int y, int new_x, int new_y)
        {
            var _coordinates = Tuple.Create(x, y);
            IThing _thing = _things[_coordinates];
            AddThing(_thing, new_x, new_y);
            _things.Remove(_coordinates);
        }

        public bool IsAvailable(int x, int y)
        {
            if (_things.Keys.Contains(Tuple.Create(x, y)))
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
