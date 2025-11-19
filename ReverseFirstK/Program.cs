using System;
using System.Collections.Generic;

namespace ReverseFirstK
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Queue<int> q = new Queue<int>();
            for (int i = 1; i <= 7; i++)
                q.Enqueue(i);

            Console.WriteLine("Original queue: " + string.Join(", ", q));

            ReverseFirstK(q, 4);

            Console.WriteLine("After reversing first 4 elements: " + string.Join(", ", q));
        }

        /// <summary>
        /// Reverses the first k elements of a given queue.
        /// </summary>
        public static void ReverseFirstK<T>(Queue<T> queue, int k)
        {
            if (queue == null)
                throw new ArgumentNullException(nameof(queue));

            if (k <= 0 || queue.Count == 0)
                return;

            if (k > queue.Count)
                k = queue.Count;

            Stack<T> stack = new Stack<T>();

            // Step 1: Dequeue first k elements and push them onto stack
            for (int i = 0; i < k; i++)
            {
                stack.Push(queue.Dequeue());
            }

            // Step 2: Pop from stack and enqueue back to queue
            while (stack.Count > 0)
            {
                queue.Enqueue(stack.Pop());
            }

            // Step 3: Move the remaining (n - k) elements to the back
            int remaining = queue.Count - k;
            for (int i = 0; i < remaining; i++)
            {
                queue.Enqueue(queue.Dequeue());
            }
        }
    }
}
