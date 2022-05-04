namespace Mars.Vehicle.Core
{
    public class Nasa : ICompany
    {
        private readonly Dictionary<Guid, Rover> rovers = new();

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
            Console.WriteLine($"Nasa send message:{message} to rover:{roverId}");

            Rover rover = rovers[roverId];

            if (rover != null)
            {
                rover.ReceiveMessage(message);
            }
        }
    }
}
