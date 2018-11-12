using Library.Interfaces;

namespace Library.Logic.Finders
{
    public interface IFinder
    {
        System.Collections.Generic.IList<IOperator> SavedOperators { get; }
        void AddOperator(IOperator op);
        void ClearOperators();
        INode FindSolution(INode node);
    }
}
