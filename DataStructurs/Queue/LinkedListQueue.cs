using DataStructurs.LinkedList.DublyLinkedList;
using System;
using System.Collections.Generic;

namespace DataStructurs.Queue
{
    public class LinkedListQueue<T> : IQueue<T>
    {
        private readonly DoublyLinkedList<T> list = new DoublyLinkedList<T>();
        public int Count { get; private set; }

        public T DeQueue()
        { 
            if(list.İsHeadNull)
            {
                throw new ArgumentNullException("Listde eleman yok");
            }
            var temp = list.RemoveFirst();
            Count--;

            return temp;

        }

        public void EnQueue(T value)
        {
            if(value == null)
            {
                throw new Exception("eklenecek değer girilmdi");
            }
            list.AddLast(value);
           
            //var newNode = new DoublyLinkedListNode<T>(value);
            //list.Tail.Next = newNode;
            //newNode.Prev = list.Tail;
            //list.Tail = newNode;

            Count++;


        }

        public T Peek() => Count == 0 ? throw new ArgumentNullException("listede eleman yok") :  list.Head.Value;
        
            //if (Count == 0)
            //    throw new ArgumentNullException("listede eleman yok");

            //var temp = list.Head.Value;
            //return temp;

        
    }
}