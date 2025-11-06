namespace UnitTests;

using ReverseFirstK;

[TestClass]
public class ReverseFirstKTests 
{
    [TestMethod]
    public void ReverseFirstKTest1() {

        var queue = new Queue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(5);
        queue.Enqueue(6);

        Program.ReverseFirstK(queue, 3);
        int[] expected = {3,2,1,4,5,6};
        int[] actual = queue.ToArray();
        CollectionAssert.AreEqual(expected, actual);
    
        Program.ReverseFirstK(queue, 3);
        int[] expected2 = {1,2,3,4,5,6};
        int[] actual2 = queue.ToArray();
        CollectionAssert.AreEqual(expected2, actual2);

        Program.ReverseFirstK(queue, 6);
        int[] expected3 = {6,5,4,3,2,1};
        int[] actual3 = queue.ToArray();
        CollectionAssert.AreEqual(expected3, actual3);

        Program.ReverseFirstK(queue, 3);
        int[] expected4 = {4,5,6,3,2,1};
        int[] actual4 = queue.ToArray();
        CollectionAssert.AreEqual(expected4, actual4);
    }

    [TestMethod]
    public void ReverseFirstKTest2() {

        var queue = new Queue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(5);
        queue.Enqueue(6);
        queue.Enqueue(7);
        queue.Enqueue(8);
        queue.Enqueue(9);

        Program.ReverseFirstK(queue, 8);
        int[] expected = {8,7,6,5,4,3,2,1,9};
        int[] actual = queue.ToArray();
        CollectionAssert.AreEqual(expected, actual);

        Program.ReverseFirstK(queue, 6);
        int[] expected2 = {3,4,5,6,7,8,2,1,9};
        int[] actual2 = queue.ToArray();
        CollectionAssert.AreEqual(expected2, actual2);

        Program.ReverseFirstK(queue, 4);
        int[] expected3 = {6,5,4,3,7,8,2,1,9};
        int[] actual3 = queue.ToArray();
        CollectionAssert.AreEqual(expected3, actual3);

        Program.ReverseFirstK(queue, 2);
        int[] expected4 = {5,6,4,3,7,8,2,1,9};
        int[] actual4 = queue.ToArray();
        CollectionAssert.AreEqual(expected4, actual4);
    }

    [TestMethod]
    public void ReverseFirstKTest3() {

        var queue = new Queue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(5);
        queue.Enqueue(6);
        queue.Enqueue(7);
        queue.Enqueue(8);
        queue.Enqueue(9);

        Program.ReverseFirstK(queue, 10);
        int[] expected = {9,8,7,6,5,4,3,2,1};
        int[] actual = queue.ToArray();
        CollectionAssert.AreEqual(expected, actual);

        Program.ReverseFirstK(queue, 5);
        int[] expected2 = {5,6,7,8,9,4,3,2,1};
        int[] actual2 = queue.ToArray();
        CollectionAssert.AreEqual(expected2, actual2);

        Program.ReverseFirstK(queue, 0);
        int[] expected3 = {5,6,7,8,9,4,3,2,1};
        int[] actual3 = queue.ToArray();
        CollectionAssert.AreEqual(expected3, actual3);

        Program.ReverseFirstK(queue, 7);
        int[] expected4 = {3,4,9,8,7,6,5,2,1};
        int[] actual4 = queue.ToArray();
        CollectionAssert.AreEqual(expected4, actual4);
    }

    [TestMethod]
    public void ReverseFirstKTest4() {

        var queue = new Queue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(5);
        queue.Enqueue(6);
        queue.Enqueue(7);
        queue.Enqueue(8);
        queue.Enqueue(9);

        Program.ReverseFirstK(queue, 0);
        int[] expected = {1,2,3,4,5,6,7,8,9};
        int[] actual = queue.ToArray();
        CollectionAssert.AreEqual(expected, actual);
    
    }

    [TestMethod]
    public void ReverseFirstKTest5()
    {
        var queue = new Queue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(5);
        queue.Enqueue(6);
        queue.Enqueue(7);
        queue.Enqueue(8);
        queue.Enqueue(9);

        Program.ReverseFirstK(queue, 1);
        int[] expected = {1,2,3,4,5,6,7,8,9};
        int[] actual = queue.ToArray();
        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void ReverseFirstKTest6()
    {
        var queue = new Queue<int>();
        queue.Enqueue(42); // Single-element queue
        Program.ReverseFirstK(queue, 2);
        int[] expected = { 42 };
        int[] actual = queue.ToArray();
        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ReverseFirstKTest_NullQueue()
    {
        Queue<int> queue = null;

        Program.ReverseFirstK(queue, 3);

        // Assert: Handled by ExpectedException attribute
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void ReverseFirstKTest_NegativeK()
    {
        var queue = new Queue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        Program.ReverseFirstK(queue, -1);

        // Assert: Handled by ExpectedException attribute
    }

    [TestMethod]
    public void ReverseFirstK_EmptyQueue()
    {
        var queue = new Queue<int>();

        Program.ReverseFirstK(queue, 3);

        int[] expected = { };
        int[] actual = queue.ToArray();
        CollectionAssert.AreEqual(expected, actual);
    }
}
