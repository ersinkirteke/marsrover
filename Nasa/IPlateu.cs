
namespace Nasa
{
    public interface IPlateu
    {
        bool IsAvailable(int x, int y);
        void AddThing(IThing thing, int x, int y);
        void MoveThing(int x, int y, int new_x, int new_y);
    }
}
