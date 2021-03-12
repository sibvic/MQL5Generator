using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            throw new System.NotImplementedException();
        }

        [TestMethod]
        public void FloatInput()
        {
            var script = Input.CreateFloatParameter();
            string code = IndicatorGenerator.Generate(script);
            throw new System.NotImplementedException();
        }

        [TestMethod]
        public void String()
        {
            var script = Input.CreateStringParameter();
            string code = IndicatorGenerator.Generate(script);
            throw new System.NotImplementedException();
        }

        [TestMethod]
        public void BoolInput()
        {
            var script = Input.CreateBoolParameter();
            string code = IndicatorGenerator.Generate(script);
            throw new System.NotImplementedException();
        }
    }
}
