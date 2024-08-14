﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructurs.Queue
{
    public class Queue<T>
    {
        private readonly IQueue<T> queue;
        public int Count => queue.Count;
        public Queue(QueueType type = QueueType.Array)
        { // ctor içinde, daha önceden tanımlanmıs ancak baslatılmamıs olan queue ifadesini verilen değerdeki tipt göre başlatır
            if ( type == QueueType.Array)
            {
                queue = new ArrayQueue<T>();
            }
            else
            {
                queue = new LinkedListQueue<T>();
            }
        }
        public void EnQueue(T value)
        {
            queue.EnQueue(value);
        }
        public T DeQueue()
        {
            return queue.DeQueue();
        }
        public T Peek()
        {
            return queue.Peek();
        }

    }

    public interface IQueue<T>
    {
        int Count { get; }
        void EnQueue(T value);  // liste basına eleman ekler
        T DeQueue(); // liste sonundaki elemanı cıkarır
        T Peek();
    }

    public enum QueueType
    {
        Array = 0,          // List<T>
        LinkedList = 1      // DoublyLinkedList<T>
    }

}
