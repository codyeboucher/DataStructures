using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLinkedList
{
    class SimpleLinkedList<T> where T : struct
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

        public void InsertAtPosition(T data, int position)
        {
            if(Head == null && position != 1)
            {
                Console.WriteLine("list empty position not valid");
            }

            var newNode = new Node<T>(data);

            if (position == 1)
            {              
                newNode.Next = Head;
                Head = newNode;
                Console.WriteLine("node inserted");
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
            }
            else
            {
                Console.WriteLine("position outside of current node count");
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

        public void DeleteAtPosition(int position)
        {
            if (Head == null)
            {
                Console.WriteLine("List is empty");
            }
            if (position == 1)
            {
                var temp = Head.Next;
                Head.Next = null;
                Head = temp;

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
            }
            else
            {
                Console.WriteLine("No element at positiong");
            }
        }

        public void DeleteNthFromEnd(int position)
        {
            if(Head == null)
            {
                Console.WriteLine("List is empty");
                //return null;
            }

            var fast = Head;
            var slow = Head;

            for(int i = 0; i < position; i++)
            {
                if(fast == null)
                {
                    Console.WriteLine("position greater than list length");
                    return;
                }
                fast = fast.Next;
            }

            if(fast == null)
            {
                var temp = Head.Next;
                Head.Next = null;
                Head = temp;
                return;
            }

            while(fast.Next != null)
            {
                fast = fast.Next;
                slow = slow.Next;

            }
            slow.Next = slow.Next.Next;
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

        public bool IsPalindrome()
        {
            if(Head == null || Head.Next == null)
            {
                return true;
            }

            var prev = new Node<T>(Head.Data);
            var curr = Head;

            while(curr.Next != null)
            {
                var temp = new Node<T>(curr.Next.Data);
                temp.Next = prev;
                prev = temp;
                curr = curr.Next;
            }

            var reverse = prev;
            var orig = Head;

            while(orig != null)
            {
                Console.WriteLine("reverse" + reverse.Data);
                if(!EqualityComparer<T>.Default.Equals(orig.Data, reverse.Data))
                {
                    return false;
                }
                reverse = reverse.Next;
                orig = orig.Next;
            }
            return true;
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
