using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class EquationSolver
{
    public static string Solve(string equation)
    {
        equation = equation.Replace(" ", "");
        if (!IsValidEquation(equation))
        {
            return "Invalid equation";
        }

        try
        {
            // Replace double negations like "10--10" with a single negation
            equation = equation.Replace("--", "+");
            equation = equation.Replace("-+", "-");
            equation = equation.Replace("++", "+");
            equation = equation.Replace("+-", "-");
            double result = EvaluateExpression(equation);
            return result.ToString();
        }
        catch (Exception)
        {
            return "Invalid equation";
        }
    }

    private static bool IsValidEquation(string equation)
    {
        // Allow digits, operators, parentheses, and optionally a leading negative sign
        string pattern = @"^(-?\d+(\.\d+)?[\+\-\*/().\d]*)+$";
        return Regex.IsMatch(equation, pattern);
    }

    private static double EvaluateExpression(string expression)
    {
        Stack<double> values = new Stack<double>();
        Stack<char> operators = new Stack<char>();

        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '(')
            {
                int j = i;
                int count = 1;
                while (count > 0 && j < expression.Length - 1)
                {
                    j++;
                    if (expression[j] == '(')
                        count++;
                    else if (expression[j] == ')')
                        count--;
                }
                if (count != 0)
                {
                    throw new InvalidOperationException("Mismatched parentheses");
                }
                string subExpression = expression.Substring(i + 1, j - i - 1);
                values.Push(EvaluateExpression(subExpression));
                i = j;
            }
            else if (char.IsDigit(expression[i]) || (expression[i] == '-' && (i == 0 || expression[i - 1] == '(' || IsOperator(expression[i - 1]))))
            {
                int j = i;
                while (j < expression.Length && (char.IsDigit(expression[j]) || expression[j] == '.'))
                {
                    j++;
                }
                string number = expression.Substring(i, j - i);
                values.Push(double.Parse(number));
                i = j - 1;
            }
            else if (IsOperator(expression[i]))
            {
                while (operators.Count > 0 && HasPrecedence(expression[i], operators.Peek()))
                {
                    double b = values.Pop();
                    double a = values.Pop();
                    char op = operators.Pop();
                    values.Push(ApplyOperator(a, b, op));
                }
                operators.Push(expression[i]);
            }
        }

        while (operators.Count > 0)
        {
            double b = values.Pop();
            double a = values.Pop();
            char op = operators.Pop();
            values.Push(ApplyOperator(a, b, op));
        }

        if (values.Count == 1)
        {
            return values.Pop();
        }
        else
        {
            throw new InvalidOperationException("Invalid expression");
        }
    }


    private static bool IsOperator(char c)
    {
        return c == '+' || c == '-' || c == '*' || c == '/';
    }

    private static bool HasPrecedence(char op1, char op2)
    {
        if ((op1 == '*' || op1 == '/') && (op2 == '+' || op2 == '-'))
        {
            return true;
        }
        if ((op1 == '/' && (op2 == '+' || op2 == '-')))
        {
            return true;
        }
        return false;
    }

    private static double ApplyOperator(double a, double b, char operatorSymbol)
    {
        switch (operatorSymbol)
        {
            case '+':
                return a + b;
            case '-':
                return a - b;
            case '*':
                return a * b;
            case '/':
                if (b == 0)
                {
                    throw new DivideByZeroException();
                }
                return a / b;
            default:
                throw new InvalidOperationException("Invalid operator");
        }
    }
}
