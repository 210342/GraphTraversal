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
            byte[] puzzle = new byte[] { 1, 2, 3, 4, 5, 13, 6, 7, 10, 0, 11, 8, 9, 14, 15, 12 };
            HeuristicProvider heuristicProvider = new Hamming(solution);
            GraphExplorer explorer = GraphExplorer.CreateGraphExplorer(
                puzzle,
                new char[] { 'u', 'd', 'l', 'r' }, new AStar(heuristicProvider));
            string sol = explorer.TraverseForSolution();
            Assert.IsFalse(string.IsNullOrEmpty(sol));
        }

        [TestMethod()]
        public void AlgorithmManhattanHeuristicTest()
        {
            byte[] puzzle = new byte[] { 1, 2, 3, 4, 5, 13, 6, 7, 10, 0, 11, 8, 9, 14, 15, 12 };
            HeuristicProvider heuristicProvider = new Manhattan(solution);
            GraphExplorer explorer = GraphExplorer.CreateGraphExplorer(
                puzzle,
                new char[] { 'u', 'd', 'l', 'r' }, new AStar(heuristicProvider));
            string sol = explorer.TraverseForSolution();
            Assert.IsFalse(string.IsNullOrEmpty(sol));
        }
    }
}