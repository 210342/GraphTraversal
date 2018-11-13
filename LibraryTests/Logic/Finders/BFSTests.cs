using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GraphExploring.Logic;
using GraphExploring.Logic.Finders;

namespace Library.Logic.Finders.Tests
{
    [TestClass()]
    public class BFSTests
    {
        [TestMethod()]
        public void FindSolutionTest()
        {
            GraphExplorer explorer = GraphExplorer.CreateGraphExplorer
                (new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 0, 15 },
                new char[] { 'u', 'd', 'l', 'r' });
            explorer.Finder = new BFS();
            byte[] sol = explorer.TraverseForSolution();
            foreach(byte bt in sol)
            {
                Console.WriteLine(bt);
            }
            Assert.IsNotNull(sol);
        }

        [TestMethod()]
        public void NoSolutionTest()
        {
            GraphExplorer explorer = GraphExplorer.CreateGraphExplorer
                (new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 15, 13, 14, 0, 12 },
                new char[] { 'u', 'd', 'l', 'r' });
            explorer.Finder = new BFS();
            byte[] sol = explorer.TraverseForSolution();
            Assert.IsNull(sol);
        }
    }
}