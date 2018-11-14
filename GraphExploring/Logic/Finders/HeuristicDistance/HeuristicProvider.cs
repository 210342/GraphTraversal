using Library.Interfaces;

namespace GraphExploring.Logic.Finders.HeuristicDistance
{
    public abstract class HeuristicProvider
    {
        protected byte[] SolutionToFind { get; private set; }

        protected HeuristicProvider(byte[] solution)
        {
            SolutionToFind = solution;
        }

        public abstract int Heuristic(INode node);
    }
}
