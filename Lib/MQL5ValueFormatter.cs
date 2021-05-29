using ProfitRobots.TradeScriptConverter.Generators.MQLBase;
using ProfitRobots.TradeScriptConverter.Model;

namespace ProfitRobots.TradeScriptConverter.Generators.MQL5
{
    class MQL5ValueFormatter : IValueFormatter
    {
        public string Format(Value value)
        {
            switch (value.Type)
            {
                case Model.ValueType.Operation:
                    return FormatOperation(value);
                case Model.ValueType.Constant:
                case Model.ValueType.Variable:
                    return value.Content;
                default:
                    break;
            }
            return "";
        }

        #region Operations
        private string FormatOperation(Value variable)
        {
            switch (variable.Id)
            {
                case "=":
                    return Format(variable.Parameters[0]) + " = " + Format(variable.Parameters[1]) + ";";
            }
            return "";
        }
        #endregion
    }
}
