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
            Verifier.CompareLineByLine(code, @"#property strict

#property indicator_chart_window
#property indicator_buffers 0
#property indicator_plots 0

input int bars_limit = 1000; // Bars limit

" + Constants.NAME_PREFIX + @"
void OnInit()
{
   IndicatorObjPrefix = GenerateIndicatorPrefix(""HGVSAVA"");
   IndicatorSetString(INDICATOR_SHORTNAME, """ + ModelGenerator.DefaultIndicatorTitle + @""");
   IndicatorSetInteger(INDICATOR_DIGITS, Digits());
}

" + Constants.EMPTY_DEINIT + @"
" + Constants.ONCALC_HEADER + "\r\n" + Constants.PRE_FOR + @"
   for (int pos = MathMax(rates_total - 1 - bars_limit, MathMax(first, prev_calculated - 1)); pos < rates_total; ++pos)
   {
      int oldPos = rates_total - pos - 1;
   }
" + Constants.POST_FOR + @"}
");
        }
    }
}
