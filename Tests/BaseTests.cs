using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProfitRobots.TradeScriptConverter.Common;
using ProfitRobots.TradeScriptConverter.Generators.TestsCases;

namespace ProfitRobots.TradeScriptConverter.Generators.MQL5.Tests
{
    [TestClass]
    public class BaseTests
    {
        [TestMethod]
        public void IndicatorHeader()
        {
            var script = Base.CreateIndicatorEmptyScript();
            string code = IndicatorGenerator.Generate(script);
            var reference = System.IO.File.ReadAllText(System.IO.Path.Combine("ref", "BaseTests", "IndicatorHeader.mq5"));
            Verifier.CompareLineByLine(code, reference);
        }
    }
}
