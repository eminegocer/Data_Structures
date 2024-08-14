using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructurs.LinkedList.SinglyLinkedList
{
    public class SinglyLinkedList<T>: IEnumerable<T>
    {

        public SinglyLinkedList()
        {
            
        }

        public SinglyLinkedList(IEnumerable<T> collection)
        {
           foreach (var item in collection)
            {
                AddFirst(item);
            }
        }

        public SinglyLinkedListNode<T> Head { get; set; }

        private bool isHeadNull => Head == null;
        public void AddFirst(T value)
        {
            var newNode = new SinglyLinkedListNode<T>(value);
            newNode.Next = Head;
            Head = newNode;

        }

        public void AddLast (T value)
        {
            var newNode = new SinglyLinkedListNode<T>(value);


            if (Head == null)
            {
                Head = newNode;
                return;
            }
            var current = Head;
            while (current.Next != null)
            {
                current = current.Next;  // baştan başlayarak sona kadar elemanları gezer eleman işaretçisi null olana kadar gezer  O(n)
            }
            current.Next = newNode;
        }

        public void AddAfter(SinglyLinkedListNode<T> node,T value) //Araya ekleme
        {
            if (isHeadNull)
            {
                AddFirst(value);
                return; // eğer metodun geri dönüş tipi void ise return ifadesi tamamen metodu sonlandrırı
            }
            if (node == null)
            {
                throw new ArgumentException("Düğüm parametresi boş olamaz");
            }

            var newNode = new SinglyLinkedListNode<T>(value);

            var current = Head;

            while(current != null)
            {
                if (current.Equals(node))

                {
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    return;
                }

                current = current.Next;
            }
            throw new Exception("Referans düğüm listede mevcut değil");
        }

        public void AddAfter(SinglyLinkedListNode<T> refNode, SinglyLinkedListNode<T> newNode)
        {
            if (isHeadNull)
            {
                AddFirst(newNode.Value);
                return;
            }

            if(newNode == null)
            {
                throw new ArgumentException("eklenecek düğüm değeri verilmedi");
            }

            var current = Head;

            while(current !=null)
            {
                if (current.Equals(refNode))
                {
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    return;

                }
                current = current.Next;
            }
            throw new ArgumentException("bos arguman");
              
        }
        
        public void AddBefore(SinglyLinkedListNode<T> node, T value)
        {
            if ( isHeadNull)
            {
                AddFirst(value);
                    return;
            }
            if(node == null)
            {
                throw new ArgumentNullException("referans düğümü verilmeri");
            }

            var current = Head;

            var newNode = new SinglyLinkedListNode<T>(value);
            while(current.Next != null)
            {
                var Node = current.Next;
                if(Node.Equals(node))
                {
                    current.Next = newNode;
                    newNode.Next = node;
                    return;
                }
                current=current.Next;
            }
            throw new Exception("referans düğüm bulunamadı");
        }

        public void AddBefore(SinglyLinkedListNode<T> refNode, SinglyLinkedListNode<T> newNode)
        {
            if(isHeadNull)
            {
                AddFirst(newNode.Value);
                return;
            }
            if(newNode == null)
            {
                throw new ArgumentNullException("eklenecek düğüm değeri girilmedi");
            }

            var current = Head;

            while(current.Next != null)
            {
                if(current.Next.Equals(refNode))
                {
                    current.Next = newNode;
                    newNode.Next = refNode;
                    return;
                }
                current = current.Next;
            }

            throw new Exception("referans düğüm mevcut değğil");
        }

        public IEnumerator<T> GetEnumerator() // generic için
        {
            return new SinglyLinkedListEnumerator<T>(Head);
        }

        IEnumerator IEnumerable.GetEnumerator() // obje için
        {
            return GetEnumerator();
        }

        // eleman silme

        public T RemoveFirst()
        {
            var current = Head;

            if (isHeadNull)
            {
                throw new ArgumentNullException("Listede eleman yok");
               
            }

            Head = Head.Next;
            return current.Value;
        }

        public T RemoveLast()
        {
            var current = Head;
            SinglyLinkedListNode<T> prev = null;

            while(current.Next != null)
            {
                prev = current;
                current = current.Next;
            }
            var lastValue = current.Value;
            prev.Next = null;
            return lastValue;

        }

        public void Remove( T value)
        {
            if (isHeadNull)
                throw new ArgumentNullException("listede henüz eleman yok");
            
            if (value == null)
                throw new ArgumentNullException("silinecek düğüm değeri verilmedi");

            var current = Head;
            SinglyLinkedListNode<T> prev = null;


            do
            {
                if(current.Value.Equals(value))
                {
                    //son eleman
                    if (current.Next == null)
                    {
                        // head
                        if(prev == null)
                        {
                            Head = null;
                            return;
                        }
                        else
                        {
                            // son eleman
                            prev.Next = null;
                            return;
                        }
                    }
                   
                    else
                    {
                        // head
                        if(prev == null)
                        {
                            Head = Head.Next;
                            return;
                        }
                        // ara düğüm
                        else
                        {
                            prev.Next = current.Next;
                            return;
                        }
                    }
                }else
                {
                    prev = current;
                    current = current.Next;
                }

            } while (current != null);

            throw new Exception("aranan düğüm listede mevcut değil");
        }
    }
}
