using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphExploring.Logic.Finders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphExploring.Logic.Finders.HeuristicDistance;
using Library.Interfaces;

namespace GraphExploring.Logic.Finders.Tests
{
    [TestClass()]
    public class AStarTests
    {
        private readonly byte[] solution = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0 };

        [TestMethod()]
        public void AStarTest()
        {
            HeuristicProvider heuristicProvider = new Manhattan(solution);
            IFinder finder = new AStar(heuristicProvider);
            Assert.IsNotNull(finder);
        }

        [TestMethod()]
        public void AlgorithmHammingHeuristicTest()
        {
            GraphExplorer explorer = GraphExplorer.CreateGraphExplorer(
                new byte[] { 0, 2, 3, 4, 1, 6, 7, 8, 5, 10, 11, 12, 9, 13, 14, 15 }, 
                new char[] { 'u', 'd', 'l', 'r' });
            HeuristicProvider heuristicProvider = new Hamming(solution);
            explorer.Finder = new AStar(heuristicProvider);
            string sol = explorer.TraverseForSolution();
            Assert.IsFalse(string.IsNullOrEmpty(sol));
        }

        [TestMethod()]
        public void AlgorithmManhattanHeuristicTest()
        {
            GraphExplorer explorer = GraphExplorer.CreateGraphExplorer(
                new byte[] { 0, 2, 3, 4, 1, 6, 7, 8, 5, 10, 11, 12, 9, 13, 14, 15 },
                new char[] { 'u', 'd', 'l', 'r' });
            HeuristicProvider heuristicProvider = new Manhattan(solution);
            explorer.Finder = new AStar(heuristicProvider);
            string sol = explorer.TraverseForSolution();
            Assert.IsFalse(string.IsNullOrEmpty(sol));
        }
    }
}