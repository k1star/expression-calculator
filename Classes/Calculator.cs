using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionCalculatror.Classes
{
    public class Calculator
    {
        public enum Error
        {
            EMPTY_VALUE,
            INVALID_BKD_NUMBER,
            INVALID_SYMBOL,
            OK
        };
        Stack stack = new Stack();

        static int GetPriority(char action)
        {
            switch (action)
            {
                case '%':
                case '^': return 3;
                case '*':
                case '/': return 2;
                case '+':
                case '-': return 1;
                case '(': return 0;
                case ')': return 0;
                default: return -1;
            }
        }

        private Error isCorrectExpression(string _expression)
        {
            if (string.IsNullOrEmpty(_expression))
                return Error.EMPTY_VALUE;

            int CountStart = 0, CountEnd = 0;
            foreach (char c in _expression)
                if (!char.IsDigit(c) && c != '(' && c != ')' && c != '+' && c != '-' && c != '*'
                    && c != '/' && c != '^' && c != '%')
                    return Error.INVALID_SYMBOL;
                else if (c == '(')
                    CountStart++;
                else if (c == ')')
                    CountEnd++;
            if (CountStart != CountEnd)
                return Error.INVALID_BKD_NUMBER;

            return Error.OK;
        }

        public double MakeData(string _expression)
        {
            _expression = _expression.Replace(" ", "");
            {
                Error error = isCorrectExpression(_expression);
                if (error != Error.OK)
                {
                    Display.PrintErrorMessage(error);
                    return 0;
                }
            }


            bool isNumberNow = false;
            bool isNegative = false;
            for (int i = 0; i < _expression.Length; i++)
            {
                char c = _expression[i];
                if (c == '+' || c == '-' || c == '*' || c == '/' || c == '^' || c == '(' || c == ')' || c == '%')
                {
                    if (isNumberNow)
                    {
                        isNumberNow = false;
                        if (isNegative)
                        {
                            stack.Push('?', stack.PopNumber() * -1);
                            isNegative = false;
                        }
                    }


                    if ((stack.GetLengthStackSymbols() == 0 || stack.ReadSymbol() == '(' || stack.ReadSymbol() == ')') && c == '-')
                    {
                        isNegative = true;
                        continue;
                    }

                    if (c == '(')
                        stack.Push(c);
                    else if (c == ')')
                    {
                        while (stack.ReadSymbol() != '(')
                            WorkToNumbers();
                        stack.PopSymbol();
                    }
                    else
                        if (GetPriority(stack.ReadSymbol()) < GetPriority(c))
                        stack.Push(c);
                    else
                    {
                        WorkToNumbers();
                        i--;
                        continue;
                    }
                }
                else
                {
                    if (isNumberNow)
                    {
                        double number = stack.PopNumber();
                        number = number * 10 + double.Parse(c.ToString());
                        stack.Push('?', number);
                    }
                    else
                        stack.Push('?', double.Parse(c.ToString()));
                    isNumberNow = true;
                }
            }

            while (stack.GetLengthStackNumbers() != 1 && stack.GetLengthStackSymbols() != 0)
                WorkToNumbers();

            double k = stack.PopNumber();
            return k;
        }
        private void WorkToNumbers()
        {
            double sNum = stack.PopNumber();
            double fNum = stack.PopNumber();
            stack.Push('?', Calculate(fNum, sNum, stack.PopSymbol()));
        }

        public double Calculate(double first, double end, char action)
        {
            double result = 0;

            switch (action)
            {
                case '+': result = first + end; break;
                case '-': result = first - end; break;
                case '*': result = first * end; break;
                case '/':
                    {
                        try
                        {
                            result = first / end;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Ошибка при попытке деления на ноль: {0}", ex);
                        }
                        break;
                    }
                case '%':
                    {
                        result = first / 100 * end;
                        break;
                    }
                case '^':
                    {
                        result = 1;
                        for (int i = 0; i < end; i++)
                            result *= first;
                        break;
                    }
                default: result = -1; break;
            }
            Display.Test(first, end, result, action);
            return result;
        }
    }
}
