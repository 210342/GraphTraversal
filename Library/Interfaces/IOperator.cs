namespace Library.Interfaces
{
    public interface IOperator
    {
        char Representation { get; }
        INode Move(INode node);
    }
}
