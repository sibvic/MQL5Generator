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
            Verifier.CompareLineByLine(code, @"#property strict

#property indicator_chart_window
#property indicator_buffers 1
#property indicator_plots 1
#property indicator_label1 ""CCI Turbo""
#property indicator_type1 DRAW_LINE
#property indicator_color1 Green
#property indicator_style1 STYLE_SOLID
#property indicator_width1 1

input int bars_limit = 1000; // Bars limit
double plot1[];

" + Constants.NAME_PREFIX + @"
void OnInit()
{
   IndicatorObjPrefix = GenerateIndicatorPrefix(""HGVSAVA"");
   IndicatorSetString(INDICATOR_SHORTNAME, """ + ModelGenerator.DefaultIndicatorTitle + @""");
   IndicatorSetInteger(INDICATOR_DIGITS, Digits());
   SetIndexBuffer(0, plot1, INDICATOR_DATA);
}

" + Constants.EMPTY_DEINIT + @"
" + Constants.ONCALC_HEADER + @"
      ArrayInitialize(plot1, EMPTY_VALUE);
" + Constants.PRE_FOR + @"
   for (int pos = MathMax(rates_total - 1 - bars_limit, MathMax(first, prev_calculated - 1)); pos < rates_total; ++pos)
   {
      int oldPos = rates_total - pos - 1;
   }
" + Constants.POST_FOR + @"}
");
        }

        [TestMethod]
        public void TwoPlots()
        {
            var script = Plots.CreateTwoPlots();
            var code = IndicatorGenerator.Generate(script);
            Verifier.CompareLineByLine(code, @"#property strict

#property indicator_chart_window
#property indicator_buffers 2
#property indicator_plots 2
#property indicator_label1 ""CCI Turbo""
#property indicator_type1 DRAW_LINE
#property indicator_color1 Green
#property indicator_style1 STYLE_SOLID
#property indicator_width1 1
#property indicator_label2 ""CCI Turbo2""
#property indicator_type2 DRAW_LINE
#property indicator_color2 Green
#property indicator_style2 STYLE_SOLID
#property indicator_width2 1

input int bars_limit = 1000; // Bars limit
double plot1[], plot2[];

" + Constants.NAME_PREFIX + @"
void OnInit()
{
   IndicatorObjPrefix = GenerateIndicatorPrefix(""HGVSAVA"");
   IndicatorSetString(INDICATOR_SHORTNAME, """ + ModelGenerator.DefaultIndicatorTitle + @""");
   IndicatorSetInteger(INDICATOR_DIGITS, Digits());
   SetIndexBuffer(0, plot1, INDICATOR_DATA);
   SetIndexBuffer(1, plot2, INDICATOR_DATA);
}

" + Constants.EMPTY_DEINIT + @"
" + Constants.ONCALC_HEADER + @"
      ArrayInitialize(plot1, EMPTY_VALUE);
      ArrayInitialize(plot2, EMPTY_VALUE);
" + Constants.PRE_FOR + @"
   for (int pos = MathMax(rates_total - 1 - bars_limit, MathMax(first, prev_calculated - 1)); pos < rates_total; ++pos)
   {
      int oldPos = rates_total - pos - 1;
   }
" + Constants.POST_FOR + @"}
");
        }
    }
}
