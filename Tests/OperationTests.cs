using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProfitRobots.TradeScriptConverter.Common;
using ProfitRobots.TradeScriptConverter.Generators.TestsCases;

namespace ProfitRobots.TradeScriptConverter.Generators.MQL5.Tests
{
    [TestClass]
    public class OperationTests
    {
        [TestMethod]
        public void IfWithReturnValue()
        {
            var script = Operations.CreateIfWithReturnValue();
            string code = IndicatorGenerator.Generate(script);
            var reference = System.IO.File.ReadAllText(System.IO.Path.Combine("ref", "OperationTests", "IfWithReturnValue.mq5"));
            Verifier.CompareLineByLine(code, reference);
        }

        [TestMethod]
        public void AssignIntToVar()
        {
            var script = Operations.CreateAssignIntToVar();
            string code = IndicatorGenerator.Generate(script);
            var reference = System.IO.File.ReadAllText(System.IO.Path.Combine("ref", "OperationTests", "AssignIntToVar.mq5"));
            Verifier.CompareLineByLine(code, reference);
        }

        [TestMethod]
        public void AssignIntToVarFloat()
        {
            var script = Operations.CreateAssignIntToVarFloat();
            string code = IndicatorGenerator.Generate(script);
            var reference = System.IO.File.ReadAllText(System.IO.Path.Combine("ref", "OperationTests", "AssignIntToVarFloat.mq5"));
            Verifier.CompareLineByLine(code, reference);
        }

        [TestMethod]
        public void Minus()
        {
            var script = Operations.CreateMinus();
            string code = IndicatorGenerator.Generate(script);
            var reference = System.IO.File.ReadAllText(System.IO.Path.Combine("ref", "OperationTests", "Minus.mq5"));
            Verifier.CompareLineByLine(code, reference);
        }

        [TestMethod]
        public void Equal()
        {
            var script = Operations.CreateEqual();
            string code = IndicatorGenerator.Generate(script);
            var reference = System.IO.File.ReadAllText(System.IO.Path.Combine("ref", "OperationTests", "Equal.mq5"));
            Verifier.CompareLineByLine(code, reference);
        }

        [TestMethod]
        public void NotEqual()
        {
            var script = Operations.CreateNotEqual();
            string code = IndicatorGenerator.Generate(script);
            var reference = System.IO.File.ReadAllText(System.IO.Path.Combine("ref", "OperationTests", "NotEqual.mq5"));
            Verifier.CompareLineByLine(code, reference);
        }

        [TestMethod]
        public void Triary()
        {
            var script = Operations.CreateTriary();
            string code = IndicatorGenerator.Generate(script);
            var reference = System.IO.File.ReadAllText(System.IO.Path.Combine("ref", "OperationTests", "Triary.mq5"));
            Verifier.CompareLineByLine(code, reference);
        }

        [TestMethod]
        public void Greater()
        {
            var script = Operations.CreateGreater();
            string code = IndicatorGenerator.Generate(script);
            var reference = System.IO.File.ReadAllText(System.IO.Path.Combine("ref", "OperationTests", "Greater.mq5"));
            Verifier.CompareLineByLine(code, reference);
        }

        [TestMethod]
        public void Lesser()
        {
            var script = Operations.CreateLesser();
            string code = IndicatorGenerator.Generate(script);
            var reference = System.IO.File.ReadAllText(System.IO.Path.Combine("ref", "OperationTests", "Lesser.mq5"));
            Verifier.CompareLineByLine(code, reference);
        }

        [TestMethod]
        public void And()
        {
            var script = Operations.CreateAnd();
            string code = IndicatorGenerator.Generate(script);
            var reference = System.IO.File.ReadAllText(System.IO.Path.Combine("ref", "OperationTests", "And.mq5"));
            Verifier.CompareLineByLine(code, reference);
        }
    }
}
