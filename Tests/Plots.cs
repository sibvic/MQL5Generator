using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProfitRobots.TradeScriptConverter.Generators.TestsCases;

namespace ProfitRobots.TradeScriptConverter.Generators.MQL5.Tests
{
    [TestClass]
    public class PlotsTests
    {
        [TestMethod]
        public void LinePlot()
        {
            var script = Plots.CreateLinePlot();
            var code = IndicatorGenerator.Generate(script);
            throw new System.NotImplementedException();
        }
    }
}
