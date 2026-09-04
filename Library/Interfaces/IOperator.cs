using Library.BasicTypes;

namespace Library.Interfaces
{
    public interface IOperator
    {
        char Representation { get; }
        Node Move(Node node);
    }
}
