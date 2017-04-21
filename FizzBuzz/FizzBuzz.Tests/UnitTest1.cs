using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FizzBuzz.Tests
{
    [TestClass]
    public class FizzBuzzTests
    {
        private Dictionary<int, string> rules = new Dictionary<int, string>()
        {
            {3, "Fizz" },
            {5, "Buzz" }
        };

        private FizzBuzzCalculator _service;

        [TestInitialize]
        public void SetUp()
        {
            _service = new FizzBuzzCalculator(rules);
        }
        
        [TestMethod]
        public void Return_Fizz_IfDivisibleBy_Three()
        {
            Assert.AreEqual(_service.check(3), "Fizz");
            
            Assert.AreEqual(_service.check(6), "Fizz");
            
            Assert.AreEqual(_service.check(9), "Fizz");
        }

        [TestMethod]
        public void Return_Buzz_IfDivisibleBy_Five()
        {
            Assert.AreEqual(_service.check(5), "Buzz");
            
            Assert.AreEqual(_service.check(10), "Buzz");
        }

        [TestMethod]
        public void Return_FizzBuzz_IfDivisibleBy_ThreeAndFive()
        {
            Assert.AreEqual(_service.check(15), "Fizz Buzz");
        }

        [TestMethod]
        public void Return_Number_IfNeitherFizzNorBuzz()
        {
            var result = _service.check(1);
            Assert.AreEqual(result, "1");
        }
    }

    public class FizzBuzzCalculator
    {
        private readonly Dictionary<int, string> _rules;

        public FizzBuzzCalculator(Dictionary<int,string> rules)
        {
            _rules = rules;
        }

        public string check(int numberToCheck)
        {
            var result = "";

            foreach (var rule in _rules)
            {
                if (numberToCheck % rule.Key == 0)
                {
                    if (!string.IsNullOrEmpty(result))
                    {
                        result += " ";
                    }
                    result += rule.Value;
                }
            }
            if (string.IsNullOrEmpty(result))
            {
                result = numberToCheck.ToString();
            }

            return result;
        }
    }
}
