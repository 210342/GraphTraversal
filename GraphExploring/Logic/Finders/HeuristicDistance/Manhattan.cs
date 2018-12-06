using Library.Interfaces;

namespace GraphExploring.Logic.Finders.HeuristicDistance
{
    public class Manhattan : HeuristicProvider
    {
        private readonly byte rowSize = 0;
        public Manhattan(IState state) : base(state.State)
        {
            rowSize = state.Dimensions[0]; // 0 is row index
        }

        public override int Heuristic(INode node)
        {
            int sum = 0;
            for (byte i = 0; i < SolutionToFind.Length; ++i)
            {
                byte number = node.State.State[i];
                if(number != 0)
                {
                    var (currentx, currenty) = TranslateCoordinate(i);
                    var (originx, originy) = TranslateCoordinate(FindIndex(number));
                    sum += System.Math.Abs(originx - currentx) +
                        System.Math.Abs(originy - currenty);
                }
                
            }
            return sum;
        }
        private (byte X, byte Y) TranslateCoordinate(byte number)
        {
            byte X = (byte) (number % rowSize);
            byte Y = (byte) (number / rowSize);
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
