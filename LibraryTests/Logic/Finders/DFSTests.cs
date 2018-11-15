using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GraphExploring.Logic;
using GraphExploring.Logic.Finders;

namespace GraphExploring.Logic.Finders.Tests
{
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
            byte[] puzzle = new byte[] { 1, 2, 3, 4, 5, 11, 0, 7, 9, 6, 10, 8, 13, 14, 15, 12 };
            GraphExplorer explorer = GraphExplorer.CreateGraphExplorer
                (puzzle,
                new char[] { 'u', 'd', 'l', 'r' }, new DFS());
            string sol = explorer.TraverseForSolution();
            Assert.IsFalse(string.IsNullOrEmpty(sol));
        }
    }
}