using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProfitRobots.TradeScriptConverter.Common;
using ProfitRobots.TradeScriptConverter.Generators.TestsCases;

namespace ProfitRobots.TradeScriptConverter.Generators.MQL5.Tests
{
    [TestClass]
    public class InputTests
    {
        [TestMethod]
        public void Integer()
        {
            var script = Input.CreateIntParameter();
            string code = IndicatorGenerator.Generate(script);
            var reference = System.IO.File.ReadAllText(System.IO.Path.Combine("ref", "InputTests", "Integer.mq5"));
            Verifier.CompareLineByLine(code, reference);
        }

        [TestMethod]
        public void FloatInput()
        {
            var script = Input.CreateFloatParameter();
            string code = IndicatorGenerator.Generate(script);
            var reference = System.IO.File.ReadAllText(System.IO.Path.Combine("ref", "InputTests", "FloatInput.mq5"));
            Verifier.CompareLineByLine(code, reference);
        }

        [TestMethod]
        public void StringInput()
        {
            var script = Input.CreateStringParameter();
            string code = IndicatorGenerator.Generate(script);
            var reference = System.IO.File.ReadAllText(System.IO.Path.Combine("ref", "InputTests", "StringInput.mq5"));
            Verifier.CompareLineByLine(code, reference);
        }

        [TestMethod]
        public void BoolInput()
        {
            var script = Input.CreateBoolParameter();
            string code = IndicatorGenerator.Generate(script);
            var reference = System.IO.File.ReadAllText(System.IO.Path.Combine("ref", "InputTests", "BoolInput.mq5"));
            Verifier.CompareLineByLine(code, reference);
        }

        [TestMethod]
        public void SourceInput()
        {
            var script = Input.CreateSourceParameter();
            string code = IndicatorGenerator.Generate(script);
            var reference = System.IO.File.ReadAllText(System.IO.Path.Combine("ref", "InputTests", "SourceInput.mq5"));
            Verifier.CompareLineByLine(code, reference);
        }

        [TestMethod]
        public void TimeframeInput()
        {
            var script = Input.CreateTimeframeParameter();
            string code = IndicatorGenerator.Generate(script);
            var reference = System.IO.File.ReadAllText(System.IO.Path.Combine("ref", "InputTests", "TimeframeInput.mq5"));
            Verifier.CompareLineByLine(code, reference);
        }
    }
}
