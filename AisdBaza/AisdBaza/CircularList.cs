using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AisdBaza
{
    public class ListNode
    {
        public int value;
        public ListNode next;
        public ListNode prev;

        public ListNode(int value) { this.value = value;
            next = null;
            prev = null;
        }
    }

    public class CircularList
    {
        private ListNode head;

        public CircularList()
        {
            head = null;
        }

        public void AddNode(int value)
        {
            ListNode newNode = new ListNode(value);
            if (head == null)
            {
                newNode.next = newNode;
                newNode.prev = newNode;
                head = newNode;
                return;
            }
            newNode.prev = head.prev;
            head.prev.next = newNode;
            newNode.next = head;
            head.prev = newNode;
            head = newNode;
        }

        public void DeleteNode()
        {
            if (head == null)
            {
                Console.WriteLine("List is empty");
                return;
            }
            if (head.next == head)
            {
                head = null;
            }
            head.prev.next = head.next;
            head.next.prev = head.prev;
            head = head.next;
        }

        public void WriteForward()
        {
            ListNode cur = head;
            Console.Write(cur.value + ", ");
            while(cur.next != head)
            {
                cur = cur.next;
                Console.Write(cur.value + ", ");
            }
            Console.WriteLine("");
        }

        public void WriteBackword()
        {
            ListNode cur = head;
            Console.Write(cur.value + ", ");
            while (cur.prev != head)
            {
                cur = cur.prev;
                Console.Write(cur.value + ", ");
            }
            Console.WriteLine("");
        }
    }
}
