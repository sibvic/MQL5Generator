using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProfitRobots.TradeScriptConverter.Common;
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
            var reference = System.IO.File.ReadAllText(System.IO.Path.Combine("ref", "PlotsTests", "LinePlot.mq5"));
            Verifier.CompareLineByLine(code, reference);
        }

        [TestMethod]
        public void LinePlotCustomColor()
        {
            var script = Plots.CreateLinePlotCustomColor();
            var code = IndicatorGenerator.Generate(script);
            var reference = System.IO.File.ReadAllText(System.IO.Path.Combine("ref", "PlotsTests", "LinePlotCustomColor.mq5"));
            Verifier.CompareLineByLine(code, reference);
        }

        [TestMethod]
        public void TwoPlots()
        {
            var script = Plots.CreateTwoPlots();
            var code = IndicatorGenerator.Generate(script);
            var reference = System.IO.File.ReadAllText(System.IO.Path.Combine("ref", "PlotsTests", "TwoPlots.mq5"));
            Verifier.CompareLineByLine(code, reference);
        }

        [TestMethod]
        public void HLine()
        {
            var script = Plots.CreateHLine();
            var code = IndicatorGenerator.Generate(script);
            var reference = System.IO.File.ReadAllText(System.IO.Path.Combine("ref", "PlotsTests", "HLine.mq5"));
            Verifier.CompareLineByLine(code, reference);
        }
    }
}
