using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GraphExploring.Logic;
using GraphExploring.Logic.Finders;

namespace Library.Logic.Finders.Tests
{
    [TestClass()]
    public class DFSTests
    {
        [TestMethod()]
        public void FindSolutionTest()
        {
            byte[] puzzle = new byte[] { 1, 2, 3, 4, 5, 13, 6, 7, 10, 0, 11, 8, 9, 14, 15, 12 };
            GraphExplorer explorer = GraphExplorer.CreateGraphExplorer
                (puzzle,
                new char[] { 'u', 'd', 'l', 'r' });
            explorer.Finder = new DFS();
            var sol = explorer.TraverseForSolution();
            Assert.IsNotNull(sol);
        }
    }
}