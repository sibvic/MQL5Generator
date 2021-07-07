using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProfitRobots.TradeScriptConverter.Common;
using ProfitRobots.TradeScriptConverter.Generators.TestsCases;

namespace ProfitRobots.TradeScriptConverter.Generators.MQL5.Tests
{
    [TestClass]
    public class StreamTests
    {
        [TestMethod]
        public void InternalStreamReuse()
        {
            var script = Streams.CreateInternalStreamReuse();
            var code = IndicatorGenerator.Generate(script);
            var reference = System.IO.File.ReadAllText(System.IO.Path.Combine("ref", "StreamTests", "InternalStreamReuse.mq5"));
            Verifier.CompareLineByLine(code, reference);
        }

        [TestMethod]
        public void InternalStreamReuseStd()
        {
            var script = Streams.CreateInternalStreamReuseStd();
            var code = IndicatorGenerator.Generate(script);
            var reference = System.IO.File.ReadAllText(System.IO.Path.Combine("ref", "StreamTests", "InternalStreamReuseStd.mq5"));
            Verifier.CompareLineByLine(code, reference);
        }

        [TestMethod]
        public void InternalStreamLaterUse()
        {
            var script = Streams.CreateInternalStreamLaterUse();
            var code = IndicatorGenerator.Generate(script);
            var reference = System.IO.File.ReadAllText(System.IO.Path.Combine("ref", "StreamTests", "InternalStreamLaterUse.mq5"));
            Verifier.CompareLineByLine(code, reference);
        }
    }
}
