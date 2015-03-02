using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
namespace ComplexParser
{
    public static class ParseComplexExprsssion
    {
        enum Types
        {
            RE, IM,DELIMETER, NON, COMPLEX
        }

        enum Errors 
        {
            SYNTAX, UNBALPARENS, NOEXP, DIVBYZERO
        }
        static string _exp;
        static string _token;
        static int _expId;
        static Types _typeToken;
        static Complex _complex;
        static StringBuilder _result;
        private static void Init(string exp)
        {
            _exp = exp.Replace("pow","Complex.Pow").Replace("i", "new Complex");
            
            _token ="";
            _typeToken = Types.NON;
            _expId = 0;
        }

        public static string Start(string exp)
        {
            Init(exp);

            _result = new StringBuilder(_exp);


                return _result.ToString();
        }

        static void  GetToken()
        {
            _token = "";
            
            if (_expId == _exp.Length)
                return;
            
            char chr = _exp[_expId];

            if (!isLexem(chr))
                SyntaxErr(Errors.SYNTAX);

            _token+=Convert.ToString(chr);
            ++_expId;

            if (!isDelimeter(chr))
            {
                if (chr == 'i')
                {
                    _token = _token.Replace("i", "");
                    _typeToken = Types.IM;
                }
                else
                 if (chr == 'z')
                    _typeToken = Types.COMPLEX;
                else
                    _typeToken = Types.RE;


                double tmpD;
                bool im = false, comp = false;

                while (_expId != _exp.Length &&
                    (char.IsDigit(chr = _exp[_expId]) || chr == ',' || chr == 'i' || chr == 'z'))
                {
                    ++_expId;
                    if (im)
                        SyntaxErr(Errors.SYNTAX);

                    if (comp)
                        SyntaxErr(Errors.SYNTAX);

                    switch (_typeToken)
                    {
                        case Types.IM: im = true; break;
                        case Types.COMPLEX: comp = true; break;
                    }

                    if (double.TryParse(_token + chr, out tmpD))
                    { 
                        _token+=Convert.ToString(chr);
                         im = false;
                    }
                    else
                        SyntaxErr(Errors.SYNTAX);
                }
                if (!isLexem(chr))
                    SyntaxErr(Errors.SYNTAX);

            }
            else
                _typeToken = Types.DELIMETER;

            switch (_typeToken)
            {
                case Types.RE: _token = string.Format("new Complex({0},0)",_token);break;
                case Types.IM: _token = string.Format("new Complex(0,{0})", _token); break;
                case Types.NON:SyntaxErr(Errors.SYNTAX);break;
            }
        }

        static bool  isDelimeter(char chr)
        {
            bool result = false;

            if ("+-*/%^()".IndexOf(chr) != -1)
                result = true;

            return result;
        }

        static void PlusMinus(out Complex result)
        {
            result = new Complex(0, 0);
            Complex tmpResult = 0.0;
            string operation = "";
            MultiDivis(out result);

            while ((operation = _token.ToString()) == "+" || operation == "-")
            {
                GetToken();

                MultiDivis(out tmpResult);

                switch (operation)
                {
                    case "+":_result.Append(string.Format("new Complex({0},{1}) + new Complex({2},{3})", result.Real, result.Imaginary, tmpResult.Real, tmpResult.Imaginary)); result += tmpResult; break;
                    case "-": result -= tmpResult; break;
                }
            }
        }

        static void MultiDivis(out Complex result)
        {
            result = new Complex(0, 0);
            Complex tmpResult = 0.0;
            string operation = "";
            Pow(out result);

            while ((operation = _token.ToString()) == "*" || operation == "/")
            {
                GetToken();

                Pow(out tmpResult);

                switch (operation)
                {
                    case "*": result *= tmpResult; break;
                    case "/": if (tmpResult == 0)
                                SyntaxErr(Errors.DIVBYZERO);
                            result /= tmpResult; break;
                }
            }
        }

        static void Pow(out Complex result)
        {
            result = new Complex(0, 0);
            Complex tmpResult = 0.0;
            string operation = "";

            Unary(out result);

            if((operation = _token.ToString()) == "^")
            {
                GetToken();

                Pow(out tmpResult);

                result = Complex.Pow(result, tmpResult);
            }
            
        }

        static void Unary(out Complex result)
        {
            result = new Complex(0, 0);
            string operation = "";

            if ( _typeToken == Types.DELIMETER &&
                (_token.Equals("+") || _token.Equals("-")))
            {
                operation = _token.ToString();
                GetToken();
            }

            Parentheses(out result);
            if (operation == "-")
                result = -result;
        }

        static void Parentheses(out Complex result)
        {
            result = new Complex(0, 0);

            if (_token.Equals("("))
            {
                GetToken();

                PlusMinus(out result);

                if (!_token.Equals(")"))
                    SyntaxErr(Errors.UNBALPARENS);

                    GetToken();
            }
            else
                Atom(out result);
        }

        static void Atom(out Complex result)
        {
            result = new Complex(0,0);

            switch (_typeToken)
            {
                case Types.RE: result = new Complex(double.Parse(_token.ToString()), 0); GetToken(); break;
                case Types.IM: result = new Complex(0, double.Parse(_token.ToString())); GetToken(); break;
                case Types.COMPLEX: result = _complex; GetToken(); break;
                default: result = new Complex(0, 0);SyntaxErr(Errors.SYNTAX); break;
            }

           
        }

        static bool isLexem(char chr)
        {
            bool result = false;

            if (isDelimeter(chr) || char.IsDigit(chr) || chr == 'z' || chr == 'i' || chr == ',')
                result = true;

            return result;
        }
        static void SyntaxErr(Errors error)
        {
            string[] err = {
                "Синтаксическая ошибка",
                "Дисбаланс скобок",
                "Выраение отсутствует",
                "Деление на ноль"
            };

            throw new Exception(err[(int)error]);
        }
    }
}
