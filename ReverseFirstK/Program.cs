namespace ReverseFirstK;

public class Program
{
     public static void Main(string[] args)
     {
     }

     /// <summary>
     /// Write a method void ReverseFirstK(Queue q, int k) that reverses the first k elements of the given queue. 
     /// You may only use stacks and queues (NOT deques) to do this. 
     /// </summary>
     /// <typeparam name="T"></typeparam>
     /// <param name="queue"></param>
     /// <param name="k"></param>
     /// <returns></returns>
     public static void ReverseFirstK<T>(Queue<T> queue, int k)
     {
          // if k > length, then just reverse the entire queue
          // if k < 0, then do nothing


          // 1) dequeue first k elements and push them on a stack

          // 2) pop elements from stack and enqueue on queue 

          // 3)  dequeue and enqueue q.length - k times



     }
}

