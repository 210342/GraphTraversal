﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphExploring.Logic.Finders.HeuristicDistance;
using Library.Interfaces;
using System.Diagnostics.CodeAnalysis;
using Library.BasicTypes;

namespace GraphExploring.Logic.Finders.Tests
{
    [ExcludeFromCodeCoverage]
    [TestClass()]
    public class AStarTests
    {

        [TestInitialize]
        public void TestInitialize()
        {
            OperatorsCollection.GetOperator('l');
            OperatorsCollection.GetOperator('r');
            OperatorsCollection.GetOperator('d');
            OperatorsCollection.GetOperator('u');
        }

        private readonly IState solution = new NodeState(new byte[] { 4, 4 },
            new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0 });

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
            //byte[] puzzle = new byte[] { 1, 2, 3, 4, 5, 11, 0, 7, 9, 6, 10, 8, 13, 14, 15, 12 };
            byte[] puzzle = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 0, 13, 14, 15, 12 };
            HeuristicProvider heuristicProvider = new Hamming(solution);
            GraphExplorer explorer = GraphExplorer.CreateGraphExplorer(
                new byte[] {4, 4},
                puzzle,
                new char[] { 'u', 'd', 'l', 'r' }, new AStar(heuristicProvider));
            explorer.TargetState = new NodeState(new byte[] { 4, 4 },
                new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0 });
            string sol = explorer.TraverseForSolution();
            System.Console.WriteLine(sol);
            Assert.IsFalse(string.IsNullOrEmpty(sol));
        }

        [TestMethod()]
        public void AlgorithmManhattanHeuristicTest()
        {
            byte[] puzzle = new byte[] { 1, 2, 3, 4, 5, 11, 0, 7, 9, 6, 10, 8, 13, 14, 15, 12 };
            HeuristicProvider heuristicProvider = new Manhattan(solution);
            GraphExplorer explorer = GraphExplorer.CreateGraphExplorer(
                new byte[] { 4, 4 },
                puzzle,
                new char[] { 'u', 'd', 'l', 'r' }, new AStar(heuristicProvider));
            explorer.TargetState = new NodeState(new byte[] { 4, 4 },
                new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0 });
            string sol = explorer.TraverseForSolution();
            Assert.IsFalse(string.IsNullOrEmpty(sol));
        }
    }
}