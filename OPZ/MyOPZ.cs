using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPZ
{
    public class MyOPZ
    {

        public string ToOPZ(string symbols)
        {
            Stack<char> stack = new Stack<char>(symbols.Length);
            int id = 0;
            string result = "";
            for (id = 0; id < symbols.Length; id++)
            {
                if (symbols[id] == '(')
                {
                    stack.Push(symbols[id]);

                    continue;
                }

                if (symbols[id] == ')')
                {
                    while (stack.Top() != '(')
                    {
                        result += stack.Pop();
                    }
                    stack.Pop();

                    continue;
                }

                if (IsOperand(symbols[id]))
                {
                    result += symbols[id];

                    continue;
                }

                if (Priority(symbols[id]) != 0)
                {
                    if (stack.IsEmpty())
                    {
                        stack.Push(symbols[id]);

                        continue;
                    }
                    else
                    {
                        if (Priority(symbols[id]) <= Priority(stack.Top())) { result += stack.Pop(); id--; }
                        else stack.Push(symbols[id]);
                    }
                }
            }
            while (!stack.IsEmpty())
            {
                result += stack.Pop();
            }
            return result;
        }

        public double ToCalc(string final_string)
        {
            Stack<double> stack = new Stack<double>(final_string.Length);
            stack.Clear(final_string.Length);
            double result;
            for (int i = 0; i < final_string.Length; i++)
            {
                if (IsOperand(final_string[i]))
                {
                    stack.Push(double.Parse(final_string[i].ToString()));
                    continue;
                }
                if (Priority(final_string[i]) != 0)
                {
                    double numb1 = stack.Pop();
                    double numb2 = stack.Pop();

                    if (final_string[i] == '+')
                    {
                        double numb3 = numb1 + numb2;
                        stack.Push(numb3);
                    }
                    if (final_string[i] == '-')
                    {
                        double numb3 = numb2 - numb1;
                        stack.Push(numb3);
                    }
                    if (final_string[i] == '*')
                    {
                        double numb3 = numb2 * numb1;
                        stack.Push(numb3);
                    }
                    if (final_string[i] == '/')
                    {
                        double numb3 = numb2 / numb1;
                        stack.Push(numb3);
                    }
                    if (final_string[i] == '^')
                    {
                        double numb3 = Math.Pow(numb2, numb1);
                        stack.Push(numb3);

                    }
                }
            }
            result = stack.Pop();
            return result;
        }
        private int Priority(char value)
        {
            if (value == '(')
                return 1;
            if (value == '+')
                return 2;
            if (value == '-')
                return 2;
            if (value == '*')
                return 3;
            if (value == '/')
                return 3;
            if (value == '^')
                return 4;
            return 0;
        }
        public bool IsOperand(char value)
        {
            if ((value <= 57) && (value >= 48))
                return true;
            else return false;
        }
    }
}
