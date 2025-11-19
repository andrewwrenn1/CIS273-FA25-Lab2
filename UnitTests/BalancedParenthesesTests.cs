namespace UnitTests;

[TestClass]
public class BalancedParenthesesTests
{
    [TestMethod]
    public void Parentheses1()
    {
        Assert.IsTrue(BalancedParentheses.Program.IsBalanced("{()}{}"));
    }

    [TestMethod]
    public void Parentheses2()
    {
        Assert.IsTrue(BalancedParentheses.Program.IsBalanced("{ int a = new int[ ] ( ( ) ) }"));
    }

    [TestMethod]
    public void Parentheses3()
    {
        Assert.IsFalse(BalancedParentheses.Program.IsBalanced("{ [ ] ) ) ( ( "));
    }

    //this one has the right number of corresponding braces but in the wrong order
    [TestMethod]
    public void Parentheses4()
    {
        Assert.IsFalse(BalancedParentheses.Program.IsBalanced("{[}]"));
    }

    [TestMethod]
    public void Parentheses5()
    {
        Assert.IsFalse(BalancedParentheses.Program.IsBalanced("{"));
    }

    [TestMethod]
    public void Parentheses6()
    {
        Assert.IsFalse(BalancedParentheses.Program.IsBalanced("("));
    }

    [TestMethod]
    public void Parentheses7()
    {
        Assert.IsFalse(BalancedParentheses.Program.IsBalanced("["));
    }

    [TestMethod]
    public void Parentheses8()
    {
        Assert.IsFalse(BalancedParentheses.Program.IsBalanced("}"));
    }

    [TestMethod]
    public void Parentheses9()
    {
        Assert.IsFalse(BalancedParentheses.Program.IsBalanced(")"));
    }

    [TestMethod]
    public void Parentheses10()
    {
        Assert.IsFalse(BalancedParentheses.Program.IsBalanced("]"));
    }

    [TestMethod]
    public void Parentheses11()
    {
        string testString = @"
using System;
using System.Collections.Generic;

namespace DataStructures.Stack
{
    public class ListBasedStack<T>
    {
        private readonly LinkedList<T> stack;


        public ListBasedStack() {
            stack = new LinkedList<T>();
        }


        public ListBasedStack(T item) : this() {
            Push(item);
        }


        public ListBasedStack(IEnumerable<T> items)
            : this()
        {
            foreach (var item in items)
            {
                Push(item);
            }
        }


        public int Count
        {
            get
            {
                return
                    stack.Count;
            }
        }



        public void Clear() {
            stack.Clear();
        }


        public bool Contains(T item) {
            stack.Contains(item);
        }


        public T Peek()
        {
            if (stack.First is null)
            {
                throw new InvalidOperationException(""Stack is empty"");
            }

            return stack.First.Value;
        }


        public T Pop()
        {
            if (stack.First is null)
            {
                throw new InvalidOperationException(""Stack is empty"");
            }

            var item = stack.First.Value;
            stack.RemoveFirst();
            return item;
        }


        public void Push(T item) {
            stack.AddFirst(item);
        }
    }
}
";

        Assert.IsTrue(BalancedParentheses.Program.IsBalanced(testString));
    }

    [TestMethod]
    public void Parentheses12()
    {
        string testString = "List<int> list = new List<int>();";
        Assert.IsTrue(BalancedParentheses.Program.IsBalanced(testString));
    }

    [TestMethod]
    public void Parentheses13()
    {
        string testString = "List<int> list = new List<int();";
        Assert.IsFalse(BalancedParentheses.Program.IsBalanced(testString));
    }

    [TestMethod]
    public void Parentheses14()
    {
        string testString = "List<int> list = new List int>();";
        Assert.IsFalse(BalancedParentheses.Program.IsBalanced(testString));
    }

    [TestMethod]
    public void Parentheses1withNoBrace()
    {
        Assert.IsTrue(BalancedParentheses.Program.IsBalanced("1"));
    }

    [TestMethod]
    public void ParenthesesWithNoBraces()
    {
        Assert.IsTrue(BalancedParentheses.Program.IsBalanced("When in the course of Human Events..."));
    }
}