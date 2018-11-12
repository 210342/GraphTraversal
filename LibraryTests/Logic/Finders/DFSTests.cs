﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library.Logic.Finders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Logic.Finders.Tests
{
    [TestClass()]
    public class DFSTests
    {
        [TestMethod()]
        public void FindSolutionTest()
        {
            GraphExplorer explorer = GraphExplorer.CreateGraphExplorer
                (new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 0, 15 },
                new char[] { 'u', 'd', 'l', 'r' });
            explorer.Finder = new DFS();
            byte[] sol = explorer.TraverseForSolution();
            foreach (byte bt in sol)
            {
                Console.WriteLine(bt);
            }
            Assert.IsNotNull(sol);
        }
    }
}