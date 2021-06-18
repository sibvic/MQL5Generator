using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}
