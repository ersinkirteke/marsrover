namespace Mars.Vehicle.Core
{
    public interface IPlateu
    {
        bool IsAvailable(int x, int y);
        void AddVehicle(IVehicle thing, int x, int y);
        void MoveVehicle(int x, int y, int new_x, int new_y);
    }
}
