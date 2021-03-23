using ProfitRobots.TradeScriptConverter.Generators.MQL5.Properties;
using ProfitRobots.TradeScriptConverter.Generators.MQLBase;
using ProfitRobots.TradeScriptConverter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;

namespace ProfitRobots.TradeScriptConverter.Generators.MQL5
{
    public class IndicatorGenerator
    {
        public static string Generate(Script script)
        {
            var rm = new ResourceManager(typeof(Resources));
            var templateLines = rm.GetString("indicator_base.mq5").Split(new string[] { "\r\n" }, StringSplitOptions.None);

            var plots = script.FindUsedPlots().ToList();

            var code = new StringBuilder();
            foreach (var line in templateLines)
            {
                switch (line)
                {
                    case "<<INDICATOR_TYPE>>":
                        code.AppendLine("#property indicator_chart_window");//TODO: Support oscillators
                        break;
                    case "<<INDICATOR_BUFFERS>>":
                        AddBuffersDefinition(script, code, plots);
                        break;
                    case "<<INDICATOR_PLOTS>>":
                        AddPlotsDefinition(script, code, plots);
                        break;
                    case "<<INDICATOR_PREFIX>>":
                        code.AppendLine("   IndicatorObjPrefix = GenerateIndicatorPrefix(\"" + script.ShortTitle + "\");");
                        break;
                    case "<<INDICATOR_SHORT_NAME>>":
                        code.AppendLine("   IndicatorSetString(INDICATOR_SHORTNAME, \"" + script.Title + "\");");
                        break;
                    case "<<INDICATOR_INIT_BUFFERS>>":
                        break;
                    case "<<INPUT_PARAMETERS>>":
                        InputGenerator.AddParameters(script, code);
                        break;
                    case "<<INDICATOR_BUFFERS_DEFINITION>>":
                        break;
                    case "<<BUFFER_INITIALIZE>>":
                        break;
                    default:
                        code.AppendLine(line);
                        break;
                }
            }
            return code.ToString();
        }

        private static void AddBuffersDefinition(Script script, StringBuilder code, List<Value> plots)
        {
            code.AppendLine("#property indicator_buffers " + plots.Count);
        }

        private static void AddPlotsDefinition(Script script, StringBuilder code, List<Value> plots)
        {
            code.AppendLine("#property indicator_plots " + plots.Count);
        }
    }
}
