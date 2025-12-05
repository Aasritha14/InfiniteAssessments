using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test_Assignment
{
    internal class Setup_TearDown
    {
        [SetUp]
        public void Setup()
        {
            // Runs before each test
            Console.WriteLine("Setup: This runs before each test.");
        }

        [TearDown]
        public void Teardown()
        {
            // Runs after each test
            Console.WriteLine("Teardown: This runs after each test.");
        }

        [Test]
        public void TestOne()
        {
            Console.WriteLine("Executing TestOne...");
            Assert.Pass();
        }

        [Test]
        public void TestTwo()
        {
            Console.WriteLine("Executing TestTwo...");
            Assert.Pass();
        }
    }
}
