namespace Mars.Vehicle.Core
{
    public interface IRover
    {
        void Accept(IVisitor logger);
    }
}
