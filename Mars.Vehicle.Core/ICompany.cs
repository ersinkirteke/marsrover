namespace Mars.Vehicle.Core
{
    public interface ICompany
    {
        void Register(Rover rover);
        void SendMessage(Guid roverId, string message);
    }
}
