using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        UseQueue();
        UsePriorityQueue();
        UseStack();
        UseLinkedList();
        UseDictionary();
        UseSortedList();
        UseHashSet();
        UseList();

        Console.ReadLine();
    }

    static void UseQueue()
    {
        Console.WriteLine("Using Queue<T>");
        Queue<string> queue = new Queue<string>();
        queue.Enqueue("Apple");
        queue.Enqueue("Banana");
        queue.Enqueue("Orange");
        queue.Enqueue("Grapes");
        queue.Enqueue("Mango");

        Console.WriteLine("Checking if queue contains 'Banana': " + queue.Contains("Banana"));

        string removedItem = queue.Dequeue();
        Console.WriteLine($"Removed item from queue: {removedItem}");

        Console.WriteLine($"Count of items in queue: {queue.Count}");

        Console.WriteLine("Items in queue:");
        foreach (var item in queue)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
    }

    static void UsePriorityQueue()
    {
        Console.WriteLine("Using PriorityQueue<T>");
        PriorityQueue<int> priorityQueue = new PriorityQueue<int>();
        priorityQueue.Enqueue(10);
        priorityQueue.Enqueue(30);
        priorityQueue.Enqueue(20);
        priorityQueue.Enqueue(50);
        priorityQueue.Enqueue(40);

        Console.WriteLine("Items in priority queue (highest priority first):");
        while (priorityQueue.Count > 0)
        {
            Console.WriteLine(priorityQueue.Dequeue());
        }
        Console.WriteLine();
    }

    static void UseStack()
    {
        Console.WriteLine("Using Stack<T>");
        Stack<string> stack = new Stack<string>();
        stack.Push("C#");
        stack.Push("Python");
        stack.Push("Java");
        stack.Push("JavaScript");
        stack.Push("C++");

        Console.WriteLine("Checking if stack contains 'Python': " + stack.Contains("Python"));

        string removedItem = stack.Pop();
        Console.WriteLine($"Removed item from stack: {removedItem}");

        Console.WriteLine($"Count of items in stack: {stack.Count}");

        Console.WriteLine("Items in stack:");
        foreach (var item in stack)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
    }

    static void UseLinkedList()
    {
        Console.WriteLine("Using LinkedList<T>");
        LinkedList<string> linkedList = new LinkedList<string>();
        linkedList.AddLast("Apple");
        linkedList.AddLast("Banana");
        linkedList.AddLast("Orange");
        linkedList.AddLast("Grapes");
        linkedList.AddLast("Mango");

        Console.WriteLine($"First node in linked list: {linkedList.First.Value}");
        Console.WriteLine($"Last node in linked list: {linkedList.Last.Value}");

        LinkedListNode<string> middleNode = linkedList.Find("Orange");
        if (middleNode != null)
        {
            linkedList.AddAfter(middleNode, "Pineapple");
        }

        linkedList.Remove("Banana");

        Console.WriteLine($"Count of items in linked list: {linkedList.Count}");

        Console.WriteLine("Items in linked list:");
        foreach (var item in linkedList)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
    }

    static void UseDictionary()
    {
        Console.WriteLine("Using Dictionary<TKey, TValue>");
        Dictionary<int, string> dictionary = new Dictionary<int, string>();
        dictionary.Add(1, "Apple");
        dictionary.Add(2, "Banana");
        dictionary.Add(3, "Orange");
        dictionary.Add(4, "Grapes");
        dictionary.Add(5, "Mango");

        Console.WriteLine("Keys in dictionary:");
        foreach (var key in dictionary.Keys)
        {
            Console.WriteLine(key);
        }

        Console.WriteLine("Values in dictionary:");
        foreach (var value in dictionary.Values)
        {
            Console.WriteLine(value);
        }

        Console.WriteLine("Items (key-value pairs) in dictionary:");
        foreach (var kvp in dictionary)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }

        dictionary.Remove(3);

        Console.WriteLine($"Count of items in dictionary: {dictionary.Count}");
        Console.WriteLine();
    }

    static void UseSortedList()
    {
        Console.WriteLine("Using SortedList<TKey, TValue>");
        SortedList<int, string> sortedList = new SortedList<int, string>();
        sortedList.Add(3, "C#");
        sortedList.Add(1, "Python");
        sortedList.Add(5, "Java");
        sortedList.Add(2, "JavaScript");
        sortedList.Add(4, "C++");

        Console.WriteLine("Enter a key:");
        int key = Convert.ToInt32(Console.ReadLine());

        if (sortedList.ContainsKey(key))
        {
            Console.WriteLine($"Value for key {key}: {sortedList[key]}");
            sortedList.Remove(key);
        }
        else
        {
            Console.WriteLine("Key does not exist in the sorted list.");
        }

        Console.WriteLine("Key-value pairs in sorted list:");
        foreach (var kvp in sortedList)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
        Console.WriteLine();
    }

    static void UseHashSet()
    {
        Console.WriteLine("Using HashSet<T>");
        HashSet<string> hashSet1 = new HashSet<string> { "Apple", "Banana", "Orange", "Grapes", "Mango" };
        HashSet<string> hashSet2 = new HashSet<string> { "Apple", "Pineapple", "Kiwi", "Strawberry", "Peach" };
        HashSet<string> hashSet3 = new HashSet<string> { "Pineapple", "Kiwi", "Mango", "Watermelon", "Grapes" };

        hashSet1.UnionWith(hashSet2);
        Console.WriteLine("Combined hash set:");
        foreach (var item in hashSet1)
        {
            Console.WriteLine(item);
        }

        HashSet<string> duplicateHashSet = new HashSet<string>(hashSet1);
        duplicateHashSet.IntersectWith(hashSet3);
        Console.WriteLine("Items that appear in both hash set 1 and hash set 3:");
        foreach (var item in duplicateHashSet)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
    }

    static void UseList()
    {
        Console.WriteLine("Using List<T>");
        List<int> list = new List<int> { 3, 1, 5, 4, 2 };
        list.AddRange(new int[] { 6, 7, 8 });

        list.Sort();
        Console.WriteLine("Items in sorted list:");
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }

        list.Remove(6);

        list.Sort((a, b) => b.CompareTo(a));
        Console.WriteLine("Items in sorted list (reverse order):");
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
    }
}

public class PriorityQueue<T>
{
    private List<T> data;
    private Comparer<T> comparer;

    public PriorityQueue()
    {
        this.data = new List<T>();
        this.comparer = Comparer<T>.Default;
    }

    public void Enqueue(T item)
    {
        data.Add(item);
    }

    public T Dequeue()
    {
        int bestIndex = 0;

        for (int i = 0; i < data.Count; i++)
        {
            if (comparer.Compare(data[i], data[bestIndex]) < 0)
            {
                bestIndex = i;
            }
        }

        T bestItem = data[bestIndex];
        data.RemoveAt(bestIndex);
        return bestItem;
    }

    public int Count => data.Count;
}
