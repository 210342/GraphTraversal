using Library.Interfaces;

namespace GraphExploring.Logic.Finders.HeuristicDistance
{
    public class Manhattan : HeuristicProvider
    {
        private readonly byte sideSize = 0;
        public Manhattan(byte[] solution) : base(solution)
        {
            sideSize = (byte)System.Math.Sqrt(SolutionToFind.Length);
        }

        public override int Heuristic(INode node)
        {
            int sum = 0;
            for (byte i = 0; i < SolutionToFind.Length; ++i)
            {
                byte number = node.State.State[i];
                if(number != 0)
                {
                    var (currentx, currenty) = TranslateCoordinate(number);
                    var (originx, originy) = TranslateCoordinate(FindIndex(number));
                    sum += System.Math.Abs(originx - currentx) +
                        System.Math.Abs(originy - currenty);
                }
                
            }
            return sum;
        }
        private (byte X, byte Y) TranslateCoordinate(byte number)
        {
            byte X = (byte) (number % sideSize);
            byte Y = (byte) (number / sideSize);
            return (X, Y);
        }

        private byte FindIndex(byte number)
        {
            for(byte i = 0; i < SolutionToFind.Length; ++i)
            {
                if(SolutionToFind[i] == number)
                {
                    return i;
                }
            }
            return (byte)(SolutionToFind.Length + 1);
        }
    }
}
