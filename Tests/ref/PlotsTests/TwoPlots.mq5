#property strict

#property indicator_chart_window
#property indicator_buffers 2
#property indicator_plots 2
#property indicator_label1 "CCI Turbo"
#property indicator_type1 DRAW_LINE
#property indicator_color1 Green
#property indicator_style1 STYLE_SOLID
#property indicator_width1 1
#property indicator_label2 "CCI Turbo2"
#property indicator_type2 DRAW_LINE
#property indicator_color2 Green
#property indicator_style2 STYLE_SOLID
#property indicator_width2 1

input int bars_limit = 1000; // Bars limit
double plot1[], plot2[];

string IndicatorObjPrefix;

bool NamesCollision(const string name)
{
   for (int k = ObjectsTotal(0); k >= 0; k--)
   {
      if (StringFind(ObjectName(0, k), name) == 0)
      {
         return true;
      }
   }
   return false;
}

string GenerateIndicatorPrefix(const string target)
{
   for (int i = 0; i < 1000; ++i)
   {
      string prefix = target + "_" + IntegerToString(i);
      if (!NamesCollision(prefix))
      {
         return prefix;
      }
   }
   return target;
}

void OnInit()
{
   IndicatorObjPrefix = GenerateIndicatorPrefix("HGVSAVA");
   IndicatorSetString(INDICATOR_SHORTNAME, "Hidden Gap`s VSA Volume Alert");
   IndicatorSetInteger(INDICATOR_DIGITS, Digits());
   SetIndexBuffer(0, plot1, INDICATOR_DATA);
   SetIndexBuffer(1, plot2, INDICATOR_DATA);
}

void OnDeinit(const int reason)
{
   ObjectsDeleteAll(0, IndicatorObjPrefix);
}

int OnCalculate(const int rates_total,
                const int prev_calculated,
                const datetime &time[],
                const double &open[],
                const double &high[],
                const double &low[],
                const double &close[],
                const long &tick_volume[],
                const long &volume[],
                const int &spread[])
{
   if (prev_calculated <= 0 || prev_calculated > rates_total)
   {
      ArrayInitialize(plot1, EMPTY_VALUE);
      ArrayInitialize(plot2, EMPTY_VALUE);
   }
   int first = 0;
   for (int pos = MathMax(rates_total - 1 - bars_limit, MathMax(first, prev_calculated - 1)); pos < rates_total; ++pos)
   {
      int oldPos = rates_total - pos - 1;
      plot1[pos] = cciTurbo;
      plot2[pos] = cciTurbo2;
   }
   return rates_total;
}
