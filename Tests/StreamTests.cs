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
            Verifier.CompareLineByLine(code, @"#property strict

#property indicator_chart_window
#property indicator_buffers 1
#property indicator_plots 0

input int bars_limit = 1000; // Bars limit
double a[];

" + Constants.NAME_PREFIX + @"
void OnInit()
{
   IndicatorObjPrefix = GenerateIndicatorPrefix(""HGVSAVA"");
   IndicatorSetString(INDICATOR_SHORTNAME, """ + ModelGenerator.DefaultIndicatorTitle + @""");
   IndicatorSetInteger(INDICATOR_DIGITS, Digits());
   SetIndexBuffer(0, a, INDICATOR_CALCULATIONS);
}

" + Constants.EMPTY_DEINIT + @"
" + Constants.ONCALC_HEADER + @"
      ArrayInitialize(a, EMPTY_VALUE);
" + Constants.PRE_FOR + @"
   for (int pos = MathMax(rates_total - 1 - bars_limit, MathMax(first, prev_calculated - 1)); pos < rates_total; ++pos)
   {
      int oldPos = rates_total - pos - 1;
   }
" + Constants.POST_FOR + @"}
");
            //TODO: assign
        }
    }
}
