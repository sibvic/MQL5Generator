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
            var streams = script.FindInternalStreams().ToList();
            var hlines = script.FindHLines().ToList();

            var code = new StringBuilder();
            foreach (var line in templateLines)
            {
                switch (line)
                {
                    case "<<HLINES>>":
                        PlotGenerator.AddHLines(code, hlines);
                        break;
                    case "<<INDICATOR_TYPE>>":
                        BaseGenerator.AddIndicatorType(script, code);
                        break;
                    case "<<INDICATOR_BUFFERS>>":
                        AddBuffersDefinition(script, code, plots, streams);
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
                        AddPlotsInit(code, plots, streams);
                        break;
                    case "<<INPUT_PARAMETERS>>":
                        InputGenerator.AddParameters(script, code);
                        break;
                    case "<<INDICATOR_BUFFERS_DEFINITION>>":
                        PlotGenerator.AddPlotsDefinition(code, plots, streams);
                        break;
                    case "<<BUFFER_INITIALIZE>>":
                        AddPlotsInitialization(code, plots, streams);
                        break;
                    default:
                        code.AppendLine(line);
                        break;
                }
            }
            return code.ToString();
        }

        private static string GetPlotStyle(Value plot)
        {
            var style = ValueHelper.FindParameterValue(plot, "style");
            if (style == null)
            {
                return "DRAW_LINE";
            }
            switch (style.Content)
            {
                case "plot.style_line":
                    return "DRAW_LINE";
                case "plot.style_stepline":
                case "plot.style_histogram":
                case "plot.style_cross":
                case "plot.style_area":
                case "plot.style_columns":
                case "plot.style_circles":
                case "plot.style_linebr":
                case "plot.style_areabr":
                default:
                    //throw new NotImplementedException();
                    break;
            }
            return "DRAW_LINE";
        }

        private static void AddPlotsInitialization(StringBuilder code, List<Value> plots, List<string> streams)
        {
            for (int index = 0; index < plots.Count; ++index)
            {
                code.AppendLine($"      ArrayInitialize(plot{index + 1}, EMPTY_VALUE);");
            }
            for (int index = 0; index < streams.Count; ++index)
            {
                code.AppendLine($"      ArrayInitialize({streams[index]}, EMPTY_VALUE);");
            }
        }

        private static void AddPlotsInit(StringBuilder code, List<Value> plots, List<string> streams)
        {
            for (int index = 0; index < plots.Count; ++index)
            {
                code.AppendLine($"   SetIndexBuffer({index}, plot{index + 1}, INDICATOR_DATA);");
            }
            for (int index = 0; index < streams.Count; ++index)
            {
                code.AppendLine($"   SetIndexBuffer({index + plots.Count}, {streams[index]}, INDICATOR_CALCULATIONS);");
            }
        }

        private static void AddBuffersDefinition(Script script, StringBuilder code, List<Value> plots, List<string> streams)
        {
            code.AppendLine("#property indicator_buffers " + (plots.Count + streams.Count));
        }

        private static void AddPlotsDefinition(Script script, StringBuilder code, List<Value> plots)
        {
            code.AppendLine("#property indicator_plots " + plots.Count);
            for (int index = 0; index < plots.Count; ++index)
            {
                var plot = plots[index];
                var title = ValueHelper.FindParameterValue(plot, "title");
                if (title != null)
                {
                    code.AppendLine($"#property indicator_label{index + 1} \"{title.Content}\"");
                }
                var style = ValueHelper.FindParameterValue(plot, "style");
                switch (style?.Content)
                {
                    case null:
                        break;
                }

                code.AppendLine($"#property indicator_type{index + 1} " + GetPlotStyle(plot));
                code.AppendLine($"#property indicator_color{index + 1} " + PlotGenerator.GetPlotColor(plot));
                code.AppendLine($"#property indicator_style{index + 1} STYLE_SOLID");//TODO: support style
                code.AppendLine($"#property indicator_width{index + 1} 1");//TODO: support width
            }
        }
    }
}
