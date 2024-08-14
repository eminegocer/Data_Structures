using DataStructurs.Tree.BinaryTree;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructurs.Tree.BST
{
    public class BST<T> : IEnumerable<T>
        where T:IComparable   // node leri yerleştirirken karşılaştırma yapılmalı bu yapıyı kabul etmeli generic ifadeler karşılaştırma operatörleri ile kullanılamaz
    {
        public Node<T> Root { get; set; }
        public BST()
        {
            
        }
        public BST(IEnumerable<T> collection)
        {
            foreach(var item in collection)
                Add(item);   
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new BSTEnumerator<T>(Root);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add( T value)
        {
            if (value == null)
                throw new ArgumentNullException();
            var newNode = new Node<T>(value);

            if (Root == null)
                Root = newNode;
            else
            {
                var current = Root;
                Node<T> parent;
                while(true)
                {
                    parent = current;
                    // sol alt ağaç
                    if (value.CompareTo(current.Value) < 0)
                    {
                        // sol düğüm null olana kadar sol düğümleri dolaşır
                        current = current.Left;
                        if (current == null)
                        {
                            parent.Left = newNode;
                            break;
                        }
                    }
                    //sağ alt ağaç
                    else
                    {
                        current = current.Right;
                        if(current == null)
                        {
                            parent.Right = newNode;
                            break;
                        }
                    }
                }
            }
        }

        public Node<T> FindMin(Node<T> root)
        {
            var current = root;
            while(current.Left != null)
                current = current.Left;
            return current;
            
        }

        public Node<T> FindMax(Node<T> root)
        {
            var current = root;

            while (current.Right != null)
                current = current.Right;
            return current;
                
        }

        public Node<T> Find(Node<T> root, T key)
        {
            var current = root;
            // aranan deger düğüm değerine eşit değilken dolaşır
            // üçlü karşılaştırmada(CompareTo)
            // karşılaştrırılan sayı düğüm değerinden küçüksse -1
            // karşılaştırılan sayı düğüm değerinden buyukse +1
            // karşılaştırılan sayıdüğüm değerine eşitse 0 doner
            while (key.CompareTo(current.Value)!=0)
            {
                if (key.CompareTo(current.Value) < 0)
                    current = current.Left;
                else
                    current = current.Right;
                if (current == null)
                    return default(Node<T>);
            }
            return current;
        }

        public Node<T> Remove(Node<T> root, T key)
        {
            if (root == null)
                //throw new Exception("")
                return root;

            // aranan deger kokten kucukse sola  rekürsif ilerleme yapılır
            if(key.CompareTo(root.Value)<0)
            {
                root.Left = Remove(root.Left, key);
            }
            else if(key.CompareTo(root.Value)>0)
            {
                root.Right = Remove(root.Right, key);
            }
            else
            {
                // silme işlemi uygulanır

                //tek cocuk ya da çocuksuz ise
                if(root.Left == null)
                {
                    return root.Right;
                }
                else if(root.Right == null)
                {
                    return root.Left;
                }
                //iki cocuk var ıse
                root.Value = FindMin(root.Right).Value;
                root.Right = Remove(root.Right, root.Value);

                
            }
            return root;
        }

    }
}
