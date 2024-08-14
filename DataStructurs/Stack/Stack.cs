using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructurs.Stack
{
    public  class Stack<T>
    {
        private readonly IStack<T> stack; // readonly sadece constructor içinde ya da tanımlandıgı yerde başlatılabilir
                                          // sınıf içindeki işlemler stack uzerinden yapıldıgı ıçın IStack interface i kabul eden yapılar bu sınıfı kullanabilir
                                          // bu interface i kabul eden ArrayStack ve LinkedListStack sınıfları var. bu sınıflar geçerli işlemleri kullanabilir
        public int Count => stack.Count;
        public Stack(StackType type = StackType.Array) // varsayılan olarak Array alınır
        {
            if(type == StackType.Array)
            {
                stack = new ArrayStack<T>();
            }
            else
            {
                stack =  new LinkedListStack<T>();
            }
        }
        public T Pop()
        {
            return stack.Pop();
        }

        public T Peek()
        {
            return stack.Peek();
        }
        public void Push(T value)
        {
            stack.Push(value);
        }
        public void Clear()
        {
            stack.Clear();
        }
    }
    public interface IStack<T>
    {
       
        int Count { get; }
        void Push(T value);
        T Peek();
        void Clear();
        T Pop();
        

    }
    public enum StackType
    {
        Array = 0,              // List<T>
        LinkedList = 1          // SinglyLinkedList<T>
    }
}
