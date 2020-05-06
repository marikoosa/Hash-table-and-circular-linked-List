using System;
using System.Collections;

{
    public class DLinkedListNode
    {
        //Varibale declaration
        public object element;
        public DLinkedListNode next;
        public DLinkedListNode previous;

        // A constructor to make the first element of the list
        public DLinkedListNode(object element)
        {
            this.element = element;
            this.next = null;
            this.previous = null;
        }

        //A constructor to make the rest of the nodes
        public DLinkedListNode(object element, DLinkedListNode prevNode)
        {
            this.element = element;
            this.previous = prevNode;
            prevNode.next = this;
        }

        //Getters and Setters
        public void SetElement(object objElement)
        { element = objElement; }

        public object GetElement()
        {
            return element;
        }

        public void SetNext(DLinkedListNode objNext)
        { next = objNext; }

        public object GetNext()
        {
            return next;
        }

        public void SetPrevious(DLinkedListNode objPrevious)
        { next = objPrevious; }

        public object GetPrevious()
        {
            return previous;
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }

    class DLinkedList
    {
        //variable declaration
        public DLinkedListNode head;
        public DLinkedListNode tail;
        public int count;

        //Creating an empty linked list
        public DLinkedList()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        public int GetCount()
        {
            return count;
        }

        //Connecting head to tail 
        private void connectHeadToTail()
        {
            this.head.previous = this.tail;
            this.tail.next = this.head;
        }

        public void enqueue(object item)
        {
            // if list is empty set head and tail to item
            if (this.head == null)
            {
                this.head = new DLinkedListNode(item);
                this.tail = this.head;

                this.head.next = this.tail;
                this.head.previous = this.tail;

                this.tail.next = this.head;
                this.tail.previous = this.head;
            }
            else if (this.head == this.tail)
            {
                this.tail = new DLinkedListNode(item);

                this.head.next = this.tail;
                this.tail.previous = this.head;

                connectHeadToTail();
            }
            else
            {
                DLinkedListNode n = new DLinkedListNode(item);
                // if element is larger than head
                if ((n.element as MobileObject).CompareTo(head.element) >= 0)
                {
                    head.previous = n;
                    n.next = head;
                    head = n;
                    connectHeadToTail();
                }
                // if element is smaller than tail
                else if ((n.element as MobileObject).CompareTo(tail.element) <= 0)

                {
                    tail.next = n;
                    n.previous = tail;
                    tail = n;
                    connectHeadToTail();
                }

                else
                {
                    DLinkedListNode currentNode = head.next;


                    while (currentNode != tail)
                    {
                        if ((n.element as MobileObject).CompareTo(currentNode) >= 0)
                        {
                            currentNode.previous.next = n;
                            n.previous = currentNode.previous;
                            currentNode.previous = n;
                            n.next = currentNode;
                        }

                        else

                        {
                            currentNode = currentNode.next;
                        }

                    }
                }

            }
            count++;
        }


        public void dequeue()
        {
            //if list is not empty
            if (head != null)
            {
                // if there is one item delete all
                if (head == tail)
                {
                    DeleteAll();
                }
                else
                {
                    head = head.next;
                    connectHeadToTail();
                    count--;
                }
            }
        }

        public void PrintAllForward()
        {
            //Printing starting from the head 
            DLinkedListNode currentNode = head;//If the list has one element
            if (head == tail)
            {
                Console.WriteLine(head.element);
            }
            else
            {
                do
                {
                    Console.WriteLine(currentNode.element);
                    currentNode = currentNode.next;
                } while (currentNode != head);
            }
        }

        //Deleting items from the list 
        public void DeleteAll()
        {
            head = null;
            tail = null;
            count = 0;
        }
    }
}
