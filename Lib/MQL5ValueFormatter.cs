﻿using ProfitRobots.TradeScriptConverter.Generators.MQLBase;
using ProfitRobots.TradeScriptConverter.Model;

namespace ProfitRobots.TradeScriptConverter.Generators.MQL5
{
    class MQL5ValueFormatter : AValueFormatter
    {
        public MQL5ValueFormatter(DataTypes dataTypes, System.Collections.Generic.List<string> streams, IndicatorsFormatter indicatorFormatter)
            : base(dataTypes, streams, indicatorFormatter)
        {

        }

        protected override string FormatIndex(Value index)
        {
            if (index == null)
            {
                return "[pos]";
            }
            return "[pos - " + Format("", index.Parameters[0], false) + "]";
        }
    }
}
