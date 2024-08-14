using System;
using System.Collections.Generic;

namespace DataStructurs.Stack
{
    public class ArrayStack<T> : IStack<T>
    {
        public int Count  { get; private set; } // sadece sınıf içinde yazilabilir
        private readonly List<T> list = new List<T>();
        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public T Peek()
        {
            if (Count == 0)
            {
                //return default(T);
                throw new Exception("Empty stack");
            }
            return list[list.Count - 1];
        }

        public T Pop()
        {
            if(Count == 0)
            {
                //return default(T);
                throw new Exception("Empty stack");
            }
            var temp = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            Count--;
            return temp;
        }

        public void Push(T value)
        {
            if(value == null)
            {
                throw new ArgumentNullException();
            }
            list.Add(value);
            Count++;

        }
    }
}