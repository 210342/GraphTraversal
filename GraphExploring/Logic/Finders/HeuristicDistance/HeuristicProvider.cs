using Library.Interfaces;

namespace GraphExploring.Logic.Finders.HeuristicDistance
{
    public abstract class HeuristicProvider
    {
        protected byte[] SolutionToFind { get; private set; }
        protected HeuristicProvider(AbstractFinder finder)
        {
            this.SolutionToFind = finder.ExpectedSolution;
        }
        public abstract int Heuristic(INode node);
    }
}
