using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ProjetPourTU.Services;


namespace ProjetPourTU.test
{
    class MathsServiceTest
    {
        private MathsService mathsService;

        [SetUp]
        public void Setup()
        {
            this.mathsService = new MathsService();
        }

        [TestCase(2, 3, 6)]
        [TestCase(0, 3, 0)]
        [TestCase(-1, 3, -3)]
        public void MultiplierTest(int nb1, int nb2, int expected)
        {
            int result = mathsService.Multiplier(nb1, nb2);
            Assert.AreEqual(expected, result);
        }
    }
}
