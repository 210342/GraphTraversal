using Xunit;
using GraphExploring.Logic;
using GraphExploring.Logic.Finders;
using System.Diagnostics.CodeAnalysis;
using Library.BasicTypes;

namespace GraphExploring.Logic.Finders.Tests
{
    [ExcludeFromCodeCoverage]
    public class BFSTests : IClassFixture<object>
    {
        public BFSTests(object _)
        {
            OperatorsCollection.GetOperator('l');
            OperatorsCollection.GetOperator('r');
            OperatorsCollection.GetOperator('d');
            OperatorsCollection.GetOperator('u');
        }
        [Fact]
        public void FindSolutionTest()
        {
            byte[] puzzle = [1, 2, 3, 4, 5, 11, 0, 7, 9, 6, 10, 8, 13, 14, 15, 12];
            GraphExplorer explorer = GraphExplorer.CreateGraphExplorer
                ([4, 4],
                puzzle,
                ['u', 'd', 'l', 'r'], new BFS());
            explorer.TargetState = new NodeState([4, 4],
                [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0]);
            var sol = explorer.TraverseForSolution();
            Console.WriteLine(sol);
            Assert.NotNull(sol);
        }
        /*
        [Fact]
        public void NoSolutionTest()
        {
            GraphExplorer explorer = GraphExplorer.CreateGraphExplorer
                (new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 15, 13, 14, 0, 12 },
                new char[] { 'u', 'd', 'l', 'r' });
            explorer.Finder = new BFS();
            var (sol, sol_op) = explorer.TraverseForSolution();
            Assert.IsNull(sol);
        }
        */
    }
}