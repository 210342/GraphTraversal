using Library.Interfaces;

namespace Library.Logic.Finders
{
    public interface IFinder
    {
        INode FindSolution(INode node);
    }
}
