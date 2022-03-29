using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionCalculatror.Classes
{
    public class Stack
    {
        List<double> numbers = new List<double>();
        List<char> symbols = new List<char>();

        public void Push(char _symbol = '?', double _number = 0)
        {
            if(_symbol == '?')
                numbers.Add(_number);
            else
                symbols.Add(_symbol);
        }

        public double PopNumber()
        {
            if(numbers.Count == 0)
                return 0;

            var result = numbers[numbers.Count - 1];
            numbers.RemoveAt(numbers.Count -1);
            return result;
        }

        public char PopSymbol()
        {
            if (symbols.Count == 0)
                return '?';

            char result = symbols[symbols.Count - 1];
            symbols.RemoveAt(symbols.Count - 1);
            return result;
        }

        public double ReadNumber()
        {
            if (numbers.Count == 0)
                return 0;
            return numbers[numbers.Count - 1];
        }

        public char ReadSymbol()
        {
            if (symbols.Count == 0)
                return '?';
            return symbols[symbols.Count - 1];
        }

        public int GetLengthStackNumbers()
        {
            return numbers.Count;
        }

        public int GetLengthStackSymbols()
        {
            return numbers.Count;
        }
    }
}
