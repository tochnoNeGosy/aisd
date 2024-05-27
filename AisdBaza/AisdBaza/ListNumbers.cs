using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AisdBaza
{
    public class listNode
    {
        public int value;
        public listNode next;
        public listNode prev;

        public listNode(int value)
        {
            this.value = value;
            next = null;
            prev = null;
        }
    }
    internal class ListNumbers
    {
        private listNode head;
        private listNode tail;

        public ListNumbers()
        {
            head = null;
            tail = null;
        }

        public void addFirst(int value)
        {
            listNode newNode = new listNode(value);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
                return;
            }
            head.prev = newNode;
            newNode.next = head;
            head = newNode;
        }

        public void addLast(int value)
        {
            listNode newNode = new listNode(value);
            if (tail == null)
            {
                head = newNode; 
                tail = newNode;
                return;
            }
            tail.next = newNode;
            newNode.prev = tail;
            tail = newNode;
        }

        public void removeFirst()
        {
            if (head == null)
            {
                Console.WriteLine("List is empty");
                return;
            }
            if (head == tail)
            {
                head = null;
                tail = null;
            }
            else
            {
                head = head.next;
                head.prev = null;
            }
        }

        public void RemoveLast()
        {
            if (tail == null)
            {
                Console.WriteLine("List is empty");
            }

            if (head == tail)
            {
                head = null;
                tail = null;
            }
            else
            {
                tail = tail.prev;
                tail.next = null;
            }
        }

        public void PrintForward()
        {
            listNode current = head;
            while (current != null)
            {
                Console.Write(current.value + " ");
                current = current.next;
            }
            Console.WriteLine();
        }

        public void PrintBackward()
        {
            listNode current = tail;
            while (current != null)
            {
                Console.Write(current.value + " ");
                current = current.prev;
            }
            Console.WriteLine();
        }
    }
}
