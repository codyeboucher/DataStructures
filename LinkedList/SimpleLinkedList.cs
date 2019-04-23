using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLinkedList
{
    class SimpleLinkedList<T>
    {
        public Node<T> Head { get; set; }

        public SimpleLinkedList()
        {
            Head = null;
        }

        
        public void PrintNodes()
        {
            var curr = Head;
            if(curr == null)
            {
                Console.WriteLine("Linked list is empty");
            }
            else
            {
                while(curr != null)
                {
                    Console.Write(curr.Data + " => ");
                    curr = curr.Next;
                }
            }
        }

        public void InsertAtHead(T data)
        {
            var newNode = new Node<T>(data);
            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                newNode.Next = Head;
                Head = newNode;
            }
        }

        public void InsertAtTail(T data)
        {
            var newNode = new Node<T>(data);
            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                var curr = Head;
                while (curr.Next != null)
                {
                    curr = curr.Next;
                }
                curr.Next = newNode;
            }
        }

        public bool InsertAtPosition(T data, int position)
        {
            if(Head == null && position != 1)
            {
                Console.WriteLine("list empty position not valid");
                return false;
            }

            var newNode = new Node<T>(data);

            if (position == 1)
            {              
                newNode.Next = Head;
                Head = newNode;
                Console.WriteLine("node inserted");
                return true;
            }
            var curr = Head;
            var prev = Head;
            var currPos = 1;
            while(curr.Next != null && currPos < position)
            {
                prev = curr;
                curr = curr.Next;
                currPos++;
            }
            if(currPos == position)
            {
                prev.Next = newNode;
                newNode.Next = curr;
                Console.WriteLine("node inserted");
                return true;
            }
            else
            {
                Console.WriteLine("position outside of current node count");
                return false;
            }
        }

        public void DeleteHead()
        {
            if (Head == null || Head.Next == null)
            {
                Head = null;
            }
            else
            {
                var temp = Head.Next;
                Head.Next = null;
                Head = temp;
            }
        }

        public void DeleteTail()
        {
            if (Head == null || Head.Next == null)
            {
                Head = null;
                return;
            }
            else
            {
                var curr = Head;
                while (curr.Next.Next != null)
                {
                    curr = curr.Next;
                }
                curr.Next = null;
            }
        }

        public bool DeleteAtPosition(int position)
        {
            if (Head == null)
            {
                Console.WriteLine("List is empty");
                return false;
            }
            if (position == 1)
            {
                var temp = Head.Next;
                Head.Next = null;
                Head = temp;
                return true;

            }
            var curr = Head;
            var prev = Head;
            var currPos = 1;
            while (currPos != position && curr.Next != null)
            {
                prev = curr;
                curr = curr.Next;
                currPos++;
            }
            if (currPos == position)
            {
                prev.Next = curr.Next;
                curr.Next = null;
                Console.WriteLine("Node deleted");
                return true;
            }
            else
            {
                Console.WriteLine("No element at positiong");
                return false;
            }
        }

        //Caller has to handle if null is returned 
        public Node<T> FindMiddle()
        {
            if(Head == null)
            {
                return null;
            }
            var fast = Head;
            var slow = Head;
            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }
            return slow;
        }           

        public bool IsEven()
        {
            if(Head == null)
            {
                return true;
            }

            var curr = Head;
            while(curr != null && curr.Next != null)
            {
                curr = curr.Next.Next;
            }
            return curr == null ? true : false;
        }

        public bool IsEvenCounter()
        {
            var curr = Head;
            var count = 0;
            while(curr != null)
            {
                curr = curr.Next;
                count++;
            }
            return count % 2 == 0;
        }

        public void Reverse()
        {
            if (Head == null)
            {
                return;
            }
            Node<T> prev = null;
            var curr = Head;
            Node<T> next = null;
            while (curr != null)
            {
                next = curr.Next;
                curr.Next = prev;
                prev = curr;
                curr = next;
 
            }
            Head = prev;
        }
    }
}
