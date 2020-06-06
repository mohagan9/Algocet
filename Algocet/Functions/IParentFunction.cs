namespace Algocet.Functions
{
    public interface IParentFunction
    {
        void ConfigureWith(Function child);
        Function Function { get; }
    }
}
