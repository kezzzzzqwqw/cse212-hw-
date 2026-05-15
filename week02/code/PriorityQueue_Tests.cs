using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Dequeue from empty queue
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Summary: The PriorityQueue.Dequeue() method correctly handles the empty queue condition by throwing the expected exception with the correct message.
    public void TestPriorityQueue_Empty_ThrowsException()
    {
        var pq = new PriorityQueue();

        var ex = Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue());
        Assert.AreEqual("The queue is empty.", ex.Message);
    }

    [TestMethod]
    // Scenario: Single item enqueue/dequeue
    // Expected Result: returns that item
    // Summary: The PriorityQueue correctly handles a single-item scenario, returning the enqueued element when dequeued.
    public void TestPriorityQueue_SingleItem()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);

        var result = pq.Dequeue();

        Assert.AreEqual("A", result);
    }

    [TestMethod]
    // Scenario: Highest priority is selected
    // Expected Result: item with highest priority is dequeued
    // Summary: The PriorityQueue correctly selects and dequeues the item with the highest priority value.
    public void TestPriorityQueue_HighestPrioritySelected()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 3);

        var result = pq.Dequeue();

        Assert.AreEqual("B", result);
    }

    [TestMethod]
    // Scenario: Tie on highest priority
    // Expected Result: front-most (earliest enqueued) is dequeued
    // Summary: The PriorityQueue does not currently enforce FIFO ordering for items with equal priority. When priorities are tied, the dequeue operation selects "B" instead of the earliest enqueued item "A", indicating a tie-breaking defect in the implementation.
    public void TestPriorityQueue_TieBreak_FrontMostWins()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 5);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 3);

        var result = pq.Dequeue();

        Assert.AreEqual("A", result);
    }

    [TestMethod]
    // Scenario: Ensure removal after dequeue
    // Expected Result: next highest is returned after first removal
    // Summary: The PriorityQueue does not correctly update internal ordering after a dequeue operation. The highest-priority element "B" is repeatedly returned, indicating that removal logic is not properly updating the queue state or re-evaluating remaining elements.
    public void TestPriorityQueue_RemovalAfterDequeue()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 2);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 4);

        pq.Dequeue(); 
        var second = pq.Dequeue();

        Assert.AreEqual("C", second);
    }
}