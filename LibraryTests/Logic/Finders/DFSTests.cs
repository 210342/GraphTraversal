using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GraphExploring.Logic;
using GraphExploring.Logic.Finders;
using System.Diagnostics.CodeAnalysis;

namespace GraphExploring.Logic.Finders.Tests
{
    [ExcludeFromCodeCoverage]
    [TestClass()]
    public class DFSTests
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
            byte[] puzzle = new byte[] { 2, 5, 3, 4, 1, 7, 11, 8, 10, 6, 14, 0, 9, 13, 15, 12 };
            GraphExplorer explorer = GraphExplorer.CreateGraphExplorer
                (puzzle,
                new char[] { 'u', 'd', 'l', 'r' }, new DFS());
            string sol = explorer.TraverseForSolution();
            Assert.IsFalse(string.IsNullOrEmpty(sol));
        }
    }
}