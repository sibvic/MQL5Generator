using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProfitRobots.TradeScriptConverter.Common;
using ProfitRobots.TradeScriptConverter.Generators.TestsCases;
using ProfitRobots.TradeScriptConverter.Model;

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
            Verifier.CompareLineByLine(code, @"#property strict

#property indicator_chart_window
#property indicator_buffers 0
#property indicator_plots 0

input int a = 40;
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

        [TestMethod]
        public void FloatInput()
        {
            var script = Input.CreateFloatParameter();
            string code = IndicatorGenerator.Generate(script);
            Verifier.CompareLineByLine(code, @"#property strict

#property indicator_chart_window
#property indicator_buffers 0
#property indicator_plots 0

input double a = 1.5;
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

        [TestMethod]
        public void StringInput()
        {
            var script = Input.CreateStringParameter();
            string code = IndicatorGenerator.Generate(script);
            Verifier.CompareLineByLine(code, @"#property strict

#property indicator_chart_window
#property indicator_buffers 0
#property indicator_plots 0

input string res = """ + (script.Parameters[0] as StringParameter).DefaultValue + "\"; // " + script.Parameters[0].Title + @"
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

        [TestMethod]
        public void BoolInput()
        {
            var script = Input.CreateBoolParameter();
            string code = IndicatorGenerator.Generate(script);
            Verifier.CompareLineByLine(code, @"#property strict

#property indicator_chart_window
#property indicator_buffers 0
#property indicator_plots 0

input bool a = " + ((script.Parameters[0] as BoolParameter).DefaultValue ? "true" : "false") + "; // " + script.Parameters[0].Title + @"
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

        [TestMethod]
        public void SourceInput()
        {
            var script = Input.CreateSourceParameter();
            string code = IndicatorGenerator.Generate(script);
            Verifier.CompareLineByLine(code, @"#property strict

#property indicator_chart_window
#property indicator_buffers 0
#property indicator_plots 0

input ENUM_APPLIED_PRICE a = PRICE_CLOSE; // " + script.Parameters[0].Title + @"
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
