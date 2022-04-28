using System;
using System.Collections.Generic;

namespace Mars.Vehicle.Core
{
    public class Nasa : ICompany
    {
        private Dictionary<Guid, Rover> rovers = new Dictionary<Guid, Rover>();

        public void Register(Rover rover)
        {
            if (!rovers.ContainsValue(rover))
            {
                rovers[rover.Id] = rover;
            }

            rover.Owner = this;
        }

        public void SendMessage(Guid roverId, string message)
        {
            Rover rover = rovers[roverId];

            if (rover != null)
            {
                rover.ReceiveMessage(message);
            }
        }
    }
}
