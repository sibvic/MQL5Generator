using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            throw new System.NotImplementedException();
        }
    }
}
