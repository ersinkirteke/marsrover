namespace Mars.Vehicle.Core
{
    public interface IVisitor
    {
        void Visit(IRover rover);
    }
}
