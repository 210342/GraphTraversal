using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphExploring.Logic;
using GraphExploring.Logic.Finders;

namespace GraphExploring.Logic.Finders.Tests
{
    [TestClass()]
    public class BFSTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            OperatorsCollection.GetOperator('l');
            OperatorsCollection.GetOperator('r');
            OperatorsCollection.GetOperator('d');
            OperatorsCollection.GetOperator('u');
        }
        [TestMethod()]
        public void FindSolutionTest()
        {
            byte[] puzzle = new byte[] { 1, 2, 3, 4, 5, 11, 0, 7, 9, 6, 10, 8, 13, 14, 15, 12 };
            GraphExplorer explorer = GraphExplorer.CreateGraphExplorer
                (puzzle,
                new char[] { 'u', 'd', 'l', 'r' }, new BFS());
            var sol = explorer.TraverseForSolution();
            System.Console.WriteLine(sol);
            Assert.IsNotNull(sol);
        }
        /*
        [TestMethod()]
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