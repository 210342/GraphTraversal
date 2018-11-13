using Library.Interfaces;

namespace GraphExploring.Logic.Finders.HeuristicDistance
{
    public class Manhattan : HeuristicProvider
    {
        private byte sideSize = 0;
        public Manhattan(AbstractFinder finder) : base(finder)
        {
            sideSize = (byte)System.Math.Sqrt(SolutionToFind.Length);
        }

        public override int Heuristic(INode node)
        {
            int sum = 0;
            for (byte i = 0; i < SolutionToFind.Length; ++i)
            {
                var (originx, originy) = TranslateCoordinate(SolutionToFind[i]);
                var (currentx, currenty) = TranslateCoordinate(node.State.State[i]);
                sum += System.Math.Abs(originx - currentx) + 
                    System.Math.Abs(originy - currenty);
            }
            return sum;
        }
        private (byte X, byte Y) TranslateCoordinate(byte number)
        {
            byte X = (byte) (number % sideSize);
            byte Y = (byte) (number / sideSize);
            return (X, Y);
        }
    }
}
