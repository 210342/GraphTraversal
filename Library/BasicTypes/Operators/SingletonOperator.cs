using Library.Interfaces;

namespace Library.BasicTypes.Operators
{
    public abstract class SingletonOperator : IOperator
    {
        public static IOperator Instance { get; }

        public virtual char Representation { get { return '\0'; } }

        public abstract Node Move(Node node);
    }
}
