namespace Mars.Vehicle.Core
{
    public interface IPlateu
    {
        bool IsAvailable(int x, int y);
        void AddVehicle(IVehicle vehicle, int x, int y);
        void MoveVehicle(int x, int y, int new_x, int new_y);
    }
}
