using AisdBaza;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography;

class Program
{
    public static void BFS(int[, ] graph)
    {
        int size = graph.GetLength(0);
        bool[] used = new bool[graph.GetLength(0)];
        List<int> nodes = new List<int>();
        for (int i = 0; i < size; ++i)
        {
            if (!used[i])
            {
                nodes.Add(i);
            }
            while(nodes.Count > 0)
            {
                int curNode = nodes.First();
                nodes.RemoveAt(0);
                if (used[curNode])
                {
                    continue;
                }
                for (int j = 0; j < size; ++j)
                {
                    if (graph[curNode, j] > 0)
                    {
                        nodes.Add(j);
                    }
                }
                used[curNode] = true;
                Console.Write(curNode + ", ");
            }
        }
        Console.WriteLine();
    }

    public static void DFS(int[, ] graph)
    {
        int size = graph.GetLength(0);
        bool[] used = new bool[size];
        for (int i =0; i < size; ++i)
        {
            if (!used[i])
            {
                DFSNode(graph, used, i);
            }
        }
        Console.WriteLine();
    }

    private static void DFSNode(int[,] graph, bool[] used, int curNode)
    {
        if (used[curNode])
        {
            return;
        }
        used[curNode] = true;
        Console.Write(curNode + ", ");
        for (int i = 0; i < graph.GetLength(0); ++i)
        {
            if (graph[curNode, i] > 0)
            {
                if (!used[i])
                {
                    DFSNode(graph, used, i);
                }
            }
        }
    }

    public static void FastSort(int[] ints)
    {
        FastSortIter(0, ints.Length - 1, ints);
    }

    private static void FastSortIter(int l, int r, int[] ints)
    {
        if (l >= r)
        {
            return;
        }
        int pivot = FastSortPivot(l, r, ints);
        FastSortIter(l, pivot, ints);
        FastSortIter(pivot + 1, r, ints);
    }

    private static int FastSortPivot(int l, int r, int[] ints)
    {
        int pivot = ints[r];
        int ll = l - 1;
        for (int i = l; i <= r; ++i)
        {
            if (ints[i] <= pivot)
            {
                ll += 1;
                int swap = ints[i];
                ints[i] = ints[ll];
                ints[ll] = swap;
            }
        }
        return ll - 1;
    }

    public static void MergeSort(int[] ints)
    {
        MergeSortRec(0, ints.Length - 1, ints);
    }

    private static void MergeSortRec(int l, int r, int[] ints)
    {
        if (l >= r)
        {
            return;
        }
        int pivot = (l + r) / 2;
        MergeSortRec(l, pivot, ints);
        MergeSortRec(pivot + 1, r, ints);
        int[] swap = new int[r - l + 1];
        int ll = l;
        int rr = pivot + 1;
        for (int i = 0; i < (r - l + 1); ++i)
        {
            if (rr > r || ints[ll] < ints[rr] && ll <= pivot)
            {
                swap[i] = ints[ll];
                ll += 1;
            }
            else{
                swap[i] = ints[rr];
                rr += 1;
            }
        }
        swap.CopyTo(ints, l);
    }

    static void Main()
    {
        {
            ListNumbers list = new ListNumbers();
            list.addFirst(10);
            list.addFirst(20);
            list.addLast(30);
            list.addLast(40);

            list.PrintForward();
            list.PrintBackward();

            list.removeFirst();
            list.RemoveLast();

            list.PrintForward();
            list.PrintBackward();
        }
        {
            CircularList list = new CircularList();
            list.AddNode(10);
            list.AddNode(20);
            list.AddNode(30);
            list.AddNode(40);
            list.AddNode(50);

            list.WriteForward();
            list.WriteBackword();

            list.DeleteNode();
            list.DeleteNode();

            list.WriteForward();
            list.WriteBackword();
        }
        {
            BinaryTree bst = new BinaryTree();

            int[] valuesToInsert = { 50, 30, 20, 40, 70, 60, 80, 65, 85, 75, 10, 35, 45, 55, 90 };
            foreach (int value in valuesToInsert)
            {
                bst.AddElement(value);
            }

            Console.WriteLine("In-order traversal:");
            bst.WriteElements();
            Console.WriteLine();

            Console.WriteLine("Delete 20:");
            bst.RemoveElement(20);
            bst.WriteElements();
            Console.WriteLine();

            Console.WriteLine("Delete 20 (leaf node):");
            bst.RemoveElement(20);
            bst.WriteElements();

            Console.WriteLine("Delete 30 (node with one child):");
            bst.RemoveElement(30);
            bst.WriteElements();

            Console.WriteLine("Delete 70 (node with two children):");
            bst.RemoveElement(70);
            bst.WriteElements();

            Console.WriteLine("Delete 50 (root node):");
            bst.RemoveElement(50);
            bst.WriteElements();

            Console.WriteLine("Delete 75 (node with no children):");
            bst.RemoveElement(75);
            bst.WriteElements();

            Console.WriteLine("Delete 65 (node with one child):");
            bst.RemoveElement(65);
            bst.WriteElements();

            Console.WriteLine("Delete 80 (node with two children):");
            bst.RemoveElement(80);
            bst.WriteElements();
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        {
            int size = 10;
            int[, ] graph = new int[size, size];
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < i; ++j)
                {
                    Random rand = new Random();
                    graph[i, j] = rand.Next(2);
                    graph[j, i] = graph[i, j];
                }
            }
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    Console.Write(graph[i, j] + " ");
                }
                Console.WriteLine();
            }
            BFS(graph);
            DFS(graph);
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        {
            int size = 10;
            int[] ints = new int[size];
            for (int i = 0; i < size; ++i)
            {
                Random rand = new Random();
                ints[i] = rand.Next(11);
                Console.Write(ints[i] + " ");
            }
            Console.WriteLine();

            FastSort(ints);
            for (int i = 0; i < size; ++i)
            {
                Console.Write(ints[i] + " ");
            }
            Console.WriteLine();
            FastSort(ints);
            for (int i = 0; i < size; ++i)
            {
                Console.Write(ints[i] + " ");
            }
            Console.WriteLine();
            Array.Reverse(ints);
            for (int i = 0; i < size; ++i)
            {
                Console.Write(ints[i] + " ");
            }
            Console.WriteLine();
            FastSort(ints);
            for (int i = 0; i < size; ++i)
            {
                Console.Write(ints[i] + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        {
            int size = 100;
            int[] ints = new int[size];
            for (int i = 0; i < size; ++i)
            {
                Random rand = new Random();
                ints[i] = rand.Next(11);
                Console.Write(ints[i] + " ");
            }
            Console.WriteLine();

            MergeSort(ints);
            for (int i = 0; i < size; ++i)
            {
                Console.Write(ints[i] + " ");
            }
            Console.WriteLine();
            MergeSort(ints);
            for (int i = 0; i < size; ++i)
            {
                Console.Write(ints[i] + " ");
            }
            Console.WriteLine();
            Array.Reverse(ints);
            for (int i = 0; i < size; ++i)
            {
                Console.Write(ints[i] + " ");
            }
            Console.WriteLine();
            MergeSort(ints);
            for (int i = 0; i < size; ++i)
            {
                Console.Write(ints[i] + " ");
            }
            Console.WriteLine();
        }


        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        {
            DoubleHashTable hashTable = new DoubleHashTable();

            hashTable.Add(1, 100);
            hashTable.Add(11, 200);
            hashTable.Add(21, 300);
            hashTable.Add(21, 3000);

            Console.WriteLine("Value for key 1: " + hashTable.GetValue(1));
            Console.WriteLine("Value for key 11: " + hashTable.GetValue(11));
            Console.WriteLine("Value for key 21: " + hashTable.GetValue(21));
            Console.WriteLine("Value for key 21: " + hashTable.GetValue(21));
            Console.WriteLine("Value for key 22: " + hashTable.GetValue(22));

            hashTable.Delete(11);

            Console.WriteLine("Value for key 11 after deletion: " + hashTable.GetValue(11));
            hashTable.Delete(11);
            hashTable.Add(11, 2000);
            Console.WriteLine("Value for key 11: " + hashTable.GetValue(11));

            DoubleHashTable hashTablee = new DoubleHashTable();
            for(int i = 1; i < 12; ++i)
            {
                hashTablee.Add(i, i);
            }
            Console.WriteLine("Value for key 11: " + hashTablee.GetValue(11));
        }
    }
}
