using System.Globalization;

namespace PostfixCalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Evaluate("5 3 +"));                // 8
            Console.WriteLine(Evaluate("7 5 -"));                // 2
            Console.WriteLine(Evaluate("5 3 1 + -"));            // 1
            Console.WriteLine(Evaluate("15 7 1 1 + - / 3 * 2 1 1 + + -")); // 5
            Console.WriteLine(Evaluate("1 + + -"));              // null
            Console.WriteLine(Evaluate("1 -"));                  // null
            Console.WriteLine(Evaluate("-"));                    // null
            Console.WriteLine(Evaluate(""));                     // null
            Console.WriteLine(Evaluate("   "));                  // null
            Console.WriteLine(Evaluate("3"));                    // 3
            Console.WriteLine(Evaluate("3 4 5 6 7 8 "));         // null
        }

        public static double? Evaluate(string s)
        {
            // Handle null or empty input
            if (string.IsNullOrWhiteSpace(s))
                return null;

            Stack<double> stack = new Stack<double>();
            string[] tokens = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (string token in tokens)
            {
                double num;
                // ✅ Case 1: Operand
                if (double.TryParse(token, NumberStyles.Float, CultureInfo.InvariantCulture, out num))
                {
                    stack.Push(num);
                }
                // ✅ Case 2: Operator
                else if (token == "+" || token == "-" || token == "*" || token == "/")
                {
                    // Need at least two operands
                    if (stack.Count < 2)
                        return null;

                    double b = stack.Pop(); // second operand
                    double a = stack.Pop(); // first operand

                    double result = 0;

                    switch (token)
                    {
                        case "+": result = a + b; break;
                        case "-": result = a - b; break;
                        case "*": result = a * b; break;
                        case "/":
                            if (b == 0) return null; // avoid division by zero
                            result = a / b;
                            break;
                    }

                    stack.Push(result);
                }
                // ❌ Invalid token
                else
                {
                    return null;
                }
            }

            // After processing all tokens, stack must have exactly one result
            if (stack.Count == 1)
                return stack.Pop();

            // Otherwise, invalid postfix expression
            return null;
        }
    }
}

