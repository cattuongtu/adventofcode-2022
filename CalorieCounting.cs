using System;
using System.Collections.Generic;
 

class MinHeap {
    private List<int> heap = new List<int>();
 
    public void Insert(int value)
    {
        heap.Add(value);
        int index = heap.Count - 1;
        while (index > 0
               && heap[(index - 1) / 2] > heap[index]) {
            Swap(index, (index - 1) / 2);
            index = (index - 1) / 2;
        }
    }
 
    public void Delete(int value)
    {
        int index = heap.IndexOf(value);
        if (index == -1) {
            return;
        }
        heap[index] = heap[heap.Count - 1];
        heap.RemoveAt(heap.Count - 1);
        while (true) {
            int leftChild = 2 * index + 1;
            int rightChild = 2 * index + 2;
            int smallest = index;
            if (leftChild < heap.Count
                && heap[leftChild] < heap[smallest]) {
                smallest = leftChild;
            }
            if (rightChild < heap.Count
                && heap[rightChild] < heap[smallest]) {
                smallest = rightChild;
            }
            if (smallest != index) {
                Swap(index, smallest);
                index = smallest;
            }
            else {
                break;
            }
        }
    }
 
    private void Swap(int i, int j)
    {
        int temp = heap[i];
        heap[i] = heap[j];
        heap[j] = temp;
    }
 
    public int Sum()
    {
        int sum = 0;
        for (int i = 0; i < heap.Count; i++) {
            Console.Write(heap[i] + " ");
            sum += heap[i];
        }
        Console.WriteLine();
        return sum;
    }

    public int Peek()
    {
        return heap[0];
    }
}
public class Program {
    public static void Main()
    {
        MinHeap heap = new MinHeap();
        int[] values = { 10, 7, 11, 5, 4, 13 };

        // Read the text file line by line.
        string textFile = "CalorieCountingInput.txt";
        string[] lines = File.ReadAllLines(textFile);

        int currentElfValue = 0;
        int maxElfValue = 0;
        int count = 0;

        foreach (string line in lines) {
            if (line != "") {
                int x = Int32.Parse(line);
                currentElfValue += x;
            } else {
                maxElfValue = Math.Max(maxElfValue, currentElfValue);
                if (count < 3) {
                    heap.Insert(currentElfValue);
                    count += 1;
                } else if (currentElfValue > heap.Peek()) {
                    heap.Delete(heap.Peek());
                    heap.Insert(currentElfValue);
                }
                currentElfValue = 0;
            }
        }
        Console.WriteLine(heap.Sum());
    }
}