﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProfitRobots.TradeScriptConverter.Common;
using ProfitRobots.TradeScriptConverter.Generators.TestsCases;

namespace ProfitRobots.TradeScriptConverter.Generators.MQL5.Tests
{
    [TestClass]
    public class ConstantsTests
    {
        [TestMethod]
        public void AssignColor()
        {
            var script = Constants.CreateAssignColor();
            string code = IndicatorGenerator.Generate(script);
            var reference = System.IO.File.ReadAllText(System.IO.Path.Combine("ref", "ConstantsTests", "AssignColor.mq5"));
            Verifier.CompareLineByLine(code, reference);
        }

        [TestMethod]
        public void AssignFloat()
        {
            var script = Constants.CreateAssignFloat();
            string code = IndicatorGenerator.Generate(script);
            var reference = System.IO.File.ReadAllText(System.IO.Path.Combine("ref", "ConstantsTests", "AssignFloat.mq5"));
            Verifier.CompareLineByLine(code, reference);
        }

        [TestMethod]
        public void AssignBoolean()
        {
            var script = Constants.CreateAssignBoolean();
            string code = IndicatorGenerator.Generate(script);
            var reference = System.IO.File.ReadAllText(System.IO.Path.Combine("ref", "ConstantsTests", "AssignBoolean.mq5"));
            Verifier.CompareLineByLine(code, reference);
        }

        [TestMethod]
        public void AssignNA()
        {
            var script = Constants.CreateAssignNA();
            string code = IndicatorGenerator.Generate(script);
            var reference = System.IO.File.ReadAllText(System.IO.Path.Combine("ref", "ConstantsTests", "AssignNA.mq5"));
            Verifier.CompareLineByLine(code, reference);
        }

        [TestMethod]
        public void AssignString()
        {
            var script = Constants.CreateAssignString();
            string code = IndicatorGenerator.Generate(script);
            var reference = System.IO.File.ReadAllText(System.IO.Path.Combine("ref", "ConstantsTests", "AssignString.mq5"));
            Verifier.CompareLineByLine(code, reference);
        }
    }
}
