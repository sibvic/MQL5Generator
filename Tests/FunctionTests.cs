﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProfitRobots.TradeScriptConverter.Common;
using ProfitRobots.TradeScriptConverter.Generators.TestsCases;

namespace ProfitRobots.TradeScriptConverter.Generators.MQL5.Tests
{
    [TestClass]
    public class FunctionTests
    {
        [TestMethod]
        public void Min()
        {
            var script = Functions.CreateMin();
            var code = IndicatorGenerator.Generate(script);
            var reference = System.IO.File.ReadAllText(System.IO.Path.Combine("ref", "FunctionTests", "Min.mq5"));
            Verifier.CompareLineByLine(code, reference);
        }

        [TestMethod]
        public void Max()
        {
            var script = Functions.CreateMax();
            var code = IndicatorGenerator.Generate(script);
            var reference = System.IO.File.ReadAllText(System.IO.Path.Combine("ref", "FunctionTests", "Max.mq5"));
            Verifier.CompareLineByLine(code, reference);
        }

        [TestMethod]
        public void Highest()
        {
            var script = Functions.CreateHighest();
            var code = IndicatorGenerator.Generate(script);
            var reference = System.IO.File.ReadAllText(System.IO.Path.Combine("ref", "FunctionTests", "Highest.mq5"));
            Verifier.CompareLineByLine(code, reference);
        }

        [TestMethod]
        public void Lowest()
        {
            var script = Functions.CreateLowest();
            var code = IndicatorGenerator.Generate(script);
            var reference = System.IO.File.ReadAllText(System.IO.Path.Combine("ref", "FunctionTests", "Lowest.mq5"));
            Verifier.CompareLineByLine(code, reference);
        }

        [TestMethod]
        public void Wma()
        {
            var script = Functions.CreateWma();
            var code = IndicatorGenerator.Generate(script);
            var reference = System.IO.File.ReadAllText(System.IO.Path.Combine("ref", "FunctionTests", "Wma.mq5"));
            Verifier.CompareLineByLine(code, reference);
        }

        [TestMethod]
        public void WmaWma()
        {
            var script = Functions.CreateWmaWma();
            var code = IndicatorGenerator.Generate(script);
            var reference = System.IO.File.ReadAllText(System.IO.Path.Combine("ref", "FunctionTests", "WmaWma.mq5"));
            Verifier.CompareLineByLine(code, reference);
        }

        [TestMethod]
        public void Avg()
        {
            var script = Functions.CreateAvg();
            var code = IndicatorGenerator.Generate(script);
            var reference = System.IO.File.ReadAllText(System.IO.Path.Combine("ref", "FunctionTests", "Avg.mq5"));
            Verifier.CompareLineByLine(code, reference);
        }

        [TestMethod]
        public void Atr()
        {
            var script = Functions.CreateAtr();
            var code = IndicatorGenerator.Generate(script);
            var reference = System.IO.File.ReadAllText(System.IO.Path.Combine("ref", "FunctionTests", "Atr.mq5"));
            Verifier.CompareLineByLine(code, reference);
        }
    }
}
