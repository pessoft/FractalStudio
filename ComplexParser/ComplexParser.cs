using System;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Numerics;

namespace ComplexParser
{
    public class ComplexParser
    {
        private string _complexFunciont;
        private string _expression;
        Func<Complex,Complex> _calculate;
        public ComplexParser(string expression)
        {
            _expression = expression;
            
            ParseExpression();
            GetMethod();
        }

        public Complex Calculate(Complex z)
        {
            return _calculate(z);

        }

        private void ParseExpression()
        {
            _complexFunciont = ParseComplexExprsssion.Start(_expression);
        }
        private void GetMethod()
        {
            string function =@"
                               using System;
                               using System.Numerics;
                               namespace DynamicNamespace
                               {
                                   public  class CalculateCreator 
                                   {
                                       public  Func<Complex,Complex> Create()
                                       {
                                           return (z)=>";
                                           string end = @";
                                       }
                                   }
                                }";
             
            function += _complexFunciont + end;

            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateInMemory = true;
            parameters.ReferencedAssemblies.Add("System.dll");
            parameters.ReferencedAssemblies.Add("System.Numerics.dll");
            CompilerResults results = provider.CompileAssemblyFromSource(parameters, function);

            var cls = results.CompiledAssembly.GetType("DynamicNamespace.CalculateCreator");
            dynamic calculateCreator = Activator.CreateInstance(cls);
            Func<Complex, Complex> calculate = (Func<Complex, Complex>)calculateCreator.Create();

            _calculate = calculate;
         }
    }
}
