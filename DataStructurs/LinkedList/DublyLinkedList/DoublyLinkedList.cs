using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructurs.LinkedList.DublyLinkedList
{
    public class DoublyLinkedList<T> : IEnumerable
    {
        public DoublyLinkedListNode<T> Head { get; set; }
        public DoublyLinkedListNode<T> Tail { get; set; }

        public bool İsHeadNull => Head == null ? true : false;
        public DoublyLinkedList()
        {
            
        }
        public DoublyLinkedList(IEnumerable<T> collection)
        {
            foreach(var item in collection)
            {
                AddLast(item);
            }
        }
        public void AddFirst(T value)
        {
            var newNode = new DoublyLinkedListNode<T>(value);

            if(Head != null)
            {
                Head.Prev = newNode;                
            }
            newNode.Next = Head;
            newNode.Prev = null;
            Head = newNode;

            if ( Tail == null)
            {
                Tail = Head;
            }

            
        }
        public void AddLast( T value)
        {

            if( Tail ==null)
            {
                AddFirst(value);
                return;
            }
            var newNode = new DoublyLinkedListNode<T>(value);
            Tail.Next = newNode;
            newNode.Next = null;
            newNode.Prev = Tail;
            Tail = newNode;
        }
        public void AddAfter(DoublyLinkedListNode<T> refNode, DoublyLinkedListNode<T> newNode)
        {
            if (newNode == null)
                throw new ArgumentNullException("Eklenecek düğüm girilmedi");
            if (refNode == null)
                throw new ArgumentNullException("Referans düğüm girilmedi");


            if(refNode== Head && refNode == Tail)
            {
                
                refNode.Prev = null;
                refNode.Next = newNode;

                newNode.Prev = refNode;
                newNode.Next = null;

                Head = refNode;
                Tail = newNode;
                return;
                
            }
            if(refNode != Tail)
            {
                if(refNode == Head)
                {
                    newNode.Next = refNode.Next;
                    refNode.Prev = null;

                    newNode.Prev = refNode;
                    refNode.Next.Prev = newNode;

                    Head = refNode;
                }else
                {
                    newNode.Next = refNode.Next;
                    newNode.Prev = refNode;

                    refNode.Next.Prev = newNode;
                    refNode.Next = newNode;
                }
            }
            else
            {
                refNode.Next = newNode;
                newNode.Prev = refNode;
                newNode.Next = null;

                Tail = newNode;
            }
        }

        public void AddBefore(DoublyLinkedListNode<T> refNode, DoublyLinkedListNode<T> newNode)
        {
            if (refNode == Head)
            {
                AddFirst(newNode.Value);
            }
            else
            {
                newNode.Prev = refNode.Prev;
                newNode.Next = refNode;

                refNode.Prev.Next = newNode;

            }
        }

        public T RemoveFirst()
        {
            if (İsHeadNull)
                throw new Exception("listede henuz eleman yok");


            var temp = Head.Value;


            if (Head.Next == null)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Head = Head.Next;
                Head.Prev = null;
            }
            return temp;
        }

        public T RemoveLast()
        {
            if (İsHeadNull)
                throw new Exception("Listede henuz eleman yok");

            var temp = Tail.Value;

            if(Tail == Head)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Tail.Prev.Next = null;
                Tail = Tail.Prev;
                
                
            }
            return temp;
        }

        public void Remove(T value)
        {

            if (İsHeadNull)
                throw new Exception("listede ehnüz eleman yok");
            if(Head == Tail)
            {
                if (Head.Value.Equals(value))
                {
                    Head = null;
                    Tail = null;
                    return;
                }
            }

            var current = Head;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    // ilk eleman
                    if (current.Prev == null)
                    {
                        current.Next.Prev = null;
                        Head = current.Next;
                        return;
                    }
                    // son eleman
                    else if(current.Next==null)
                    {
                        current.Prev.Next = null;
                        Tail = current.Prev;
                        return;
                    }
                    // arada bir düğüm
                    else 
                    {
                        current.Prev.Next = current.Next;
                        current.Next.Prev = current.Prev;
                    }
                    break;
                }
                current = current.Next;
            }
            
            

        }

        private List<DoublyLinkedListNode<T>> GetAllNodes()
        {
            var list = new List<DoublyLinkedListNode<T>>();
            var current = Head;
            while(current !=null)
            {
                list.Add(current);
                current = current.Next;
            }
            return list;
        }

       

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAllNodes().GetEnumerator();
        }
    }
}
