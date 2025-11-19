using System;
using System.Collections.Generic;

namespace BalancedParentheses
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(IsBalanced("{ int a = new int[ ] ( ( ) ) }")); // true
            Console.WriteLine(IsBalanced("{ () ) ) ( ( }")); // false
            Console.WriteLine(IsBalanced(" ( ( [ < ] > ) ) ")); // false
            Console.WriteLine(IsBalanced(" ( ( [ ")); // false
            Console.WriteLine(IsBalanced(" ] ")); // false
            Console.WriteLine(IsBalanced("({({({({({({({({({({({({({({({{})})})})})})})})})})})})})})})})})})")); // true
        }

        public static bool IsBalanced(string s)
        {
            if (string.IsNullOrEmpty(s))
                return true; // empty string counts as balanced

            Stack<char> stack = new Stack<char>();

            foreach (char c in s)
            {
                // Opening brackets
                if (c == '(' || c == '{' || c == '[' || c == '<')
                {
                    stack.Push(c);
                }
                // Closing brackets
                else if (c == ')' || c == '}' || c == ']' || c == '>')
                {
                    if (stack.Count == 0)
                        return false; // No matching opening bracket

                    char open = stack.Pop();

                    if (!IsMatchingPair(open, c))
                        return false; // Mismatched pair
                }
                // Ignore all other characters
            }

            // Stack should be empty if all brackets were matched
            return stack.Count == 0;
        }

        private static bool IsMatchingPair(char open, char close)
        {
            return (open == '(' && close == ')') ||
                   (open == '[' && close == ']') ||
                   (open == '{' && close == '}') ||
                   (open == '<' && close == '>');
        }
    }
}
