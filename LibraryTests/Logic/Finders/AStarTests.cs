using GraphExploring.Logic.Finders.HeuristicDistance;
using Library.Interfaces;
using System.Diagnostics.CodeAnalysis;
using Library.BasicTypes;

namespace GraphExploring.Logic.Finders.Tests
{
    [ExcludeFromCodeCoverage]
    public class AStarTests : IClassFixture<object>
    {
        public AStarTests(object _)
        {
            OperatorsCollection.GetOperator('l');
            OperatorsCollection.GetOperator('r');
            OperatorsCollection.GetOperator('d');
            OperatorsCollection.GetOperator('u');
        }

        private readonly NodeState solution = new([4, 4],
            [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0]);

        [Fact]
        public void AStarTest()
        {
            HeuristicProvider heuristicProvider = new Manhattan(solution);
            IFinder finder = new AStar(heuristicProvider);
            Assert.NotNull(finder);
        }

        [Fact]
        public void AlgorithmHammingHeuristicTest()
        {
            byte[] puzzle = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 0, 13, 14, 15, 12];
            HeuristicProvider heuristicProvider = new Hamming(solution);
            GraphExplorer explorer = GraphExplorer.CreateGraphExplorer(
                [4, 4],
                puzzle,
                ['u', 'd', 'l', 'r'], new AStar(heuristicProvider));
            explorer.TargetState = new NodeState([4, 4],
                [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0]);
            string sol = explorer.TraverseForSolution();
            System.Console.WriteLine(sol);
            Assert.False(string.IsNullOrEmpty(sol));
        }

        [Fact]
        public void AlgorithmManhattanHeuristicTest()
        {
            byte[] puzzle = [1, 2, 3, 4, 5, 11, 0, 7, 9, 6, 10, 8, 13, 14, 15, 12];
            HeuristicProvider heuristicProvider = new Manhattan(solution);
            GraphExplorer explorer = GraphExplorer.CreateGraphExplorer(
                [4, 4],
                puzzle,
                ['u', 'd', 'l', 'r'], new AStar(heuristicProvider));
            explorer.TargetState = new NodeState([4, 4],
                [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0]);
            string sol = explorer.TraverseForSolution();
            Assert.False(string.IsNullOrEmpty(sol));
        }
    }
}