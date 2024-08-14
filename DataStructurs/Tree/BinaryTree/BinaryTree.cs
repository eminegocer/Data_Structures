using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructurs.Tree.BinaryTree
{
    public class BinaryTree<T> where T:IComparable
    {
        public Node<T> Root { get; set; }
        public List<Node<T>> list { get; private set; }
        public BinaryTree()
        {

            list = new List<Node<T>>();
        }
        public List<Node<T>> InOrder(Node<T> root)
        {
            if (!(root == null))
            {
                InOrder(root.Left);  // önce sol alt ağaçtaki düğümler yazılır burdaki değerler daha  küçük
                list.Add(root); // sonra kok düğüm yazılır
                InOrder(root.Right); // en son sağ alt ağac değerleri yazılır
            }
            return list;

        }
        public List<Node<T>> InOrderNonRecursiveTraversal(Node<T> root)
        {
            var list = new List<Node<T>>();
            // stack yapısı düğümleri kısa sureliğine tutmak için oluşturuldu. gerekli yerde stack uzerindeki en son eklenen düğümler alınıp listeye eklebnecek
            var S = new DataStructurs.Stack.Stack<Node<T>>();
            Node<T> currentNode = root;
            bool done = false;

            while(!done)
            {   
                // sol taraftan devam eder ve push() islemi yapar
                if(currentNode != null)
                {
                    // elemanı stack üzerinde biriktirir gerekli yerde stack üzerinden alınıp listeye eklenır
                    S.Push(currentNode);
                    currentNode = currentNode.Left;

                }
                else
                {
                    if(S.Count==0)
                    {
                        done = true;
                    }
                    else
                    {
                        // yıgından bir eleman listeye ekler ve stack uxerinden cıkarır
                        currentNode = S.Pop();
                        list.Add(currentNode);
                        currentNode = currentNode.Right;
                    }
                }
            }
            return list;
        }

        public List<Node<T>> PreOrder(Node<T> root)
        {
            if(!(root == null))
            {
                list.Add(root);
                PreOrder(root.Left);
                PreOrder(root.Right);

            }
            return list;
        }
        public List<Node<T>> PreOrderNonRecursiveTraversal(Node<T> root)
        {
            var list = new List<Node<T>>();
            var S = new DataStructurs.Stack.Stack<Node<T>>();

            if (root == null)
                throw new Exception("bu ağaç boş");

            S.Push(root);
            while(S.Count!=0)
            {
                var temp = S.Pop();
                list.Add(temp);

                if(temp.Right != null)
                    S.Push(temp.Right);
                if (temp.Left != null)
                    S.Push(temp.Left); 
            }

            return list;
        }
        public List<Node<T>> PostOrder(Node<T> root)
        {
            if(root != null)
            {
                PostOrder(root.Left);
                PostOrder(root.Right);
                list.Add(root);
            }
            return list;
        }
        public List<Node<T>> PostOrderNonRecursiveTraversal(Node<T> root)
        {
            var list = new List<Node<T>>();
            var S = new DataStructurs.Stack.Stack<Node<T>>();
            var currentNode = root;


            while (currentNode != null || S.Count != 0)
            {

            }
            return list;
           
        }
        public List<Node<T>> LevelOrderNonRecursiveTravel(Node<T> root)
        {
            var list = new List<Node<T>>();
            var Q = new DataStructurs.Queue.Queue<Node<T>>();
            Q.EnQueue(root);

            while(Q.Count>0)
            {
                var temp = Q.DeQueue();
                list.Add(temp);
                if(temp.Left!=null)
                    Q.EnQueue(temp.Left);
                if(temp.Right != null)
                    Q.EnQueue(temp.Right);
                              
            }
            return list;
        }

        public static int MaxDepth(Node<T> root)
        {
            if (root == null)
                return 0;
            int leftDepth = MaxDepth(root.Left);
            int rightDepth = MaxDepth(root.Right);

            return (leftDepth > rightDepth ? leftDepth + 1 : rightDepth + 1);
        }
        public Node<T> DeepstNode(Node<T> root)
        {
            Node<T> temp = null;
            if (root == null)
                throw new Exception("empty tree!");
            var q = new DataStructurs.Queue.Queue<Node<T>>();
            q.EnQueue(root);

            while(q.Count>0)
            {
                temp = q.DeQueue();
                if(temp.Left !=null)
                    q.EnQueue(temp.Left);
                if (temp.Right != null)
                    q.EnQueue(temp.Right);
              
            }
            return temp;


        }
        public Node<T> DeepstNode()
        { 
            var list = LevelOrderNonRecursiveTravel(Root);
            return list[list.Count -1];
        }
        public static int NumberOfLeafs(Node<T> root)
        {
            int count = 0;
            if (root == null)
                return count;
            var q = new DataStructurs.Queue.Queue<Node<T>>();
            q.EnQueue(root);
            while(q.Count>0)
            {
                var temp = q.DeQueue();
                if (temp.Left == null && temp.Right == null)
                    count++;
                if (temp.Left != null)
                    q.EnQueue(temp.Left);
                if (temp.Right != null)
                    q.EnQueue(temp.Right);
            }
            return count;
        }

        public static
            int NumberOfLeafs2(Node<T> root)
        {
            return new BinaryTree<T>().LevelOrderNonRecursiveTravel(root)
                .Where(x => x.Left == null && x.Right == null)
                .ToList()
                .Count();
        }

        public static int NumberOfFullNodes(Node<T> root) =>
            // node ların tamamını alır
            new BinaryTree<T>().LevelOrderNonRecursiveTravel(root)
            .Where(node => node.Left != null && node.Right != null)
            .ToList()
            .Count;

        public static int NumberOfHalfNodes(Node<T> root) =>
            new BinaryTree<T>().LevelOrderNonRecursiveTravel(root)
            .Where(node => (node.Left != null && node.Right == null) || (node.Left == null && node.Right != null))
            .ToList()
            .Count;

        public void PrintPaths(Node<T> root)
        {
            var path = new T[256];
            PrintPaths(root, path, 0);
        }

        private void PrintPaths(Node<T> root, T[] path, int pathLen)
        {
            if (root == null)
                return;
            path[pathLen] = root.Value;
            pathLen++;

            if(root.Left == null && root.Right == null) // yaprak mı
            {
                PrintArray(path, pathLen);
            }
            else
            {
                PrintPaths(root.Left, path, pathLen);
                PrintPaths(root.Right, path, pathLen);
            }

        }

        private void PrintArray(T[] path, int len)
        {
            for (int i = 0 ; i < len ; i++)
            {
                Console.Write($"{path[i]} ");
            }
            Console.WriteLine();
        }
        public void ClearList()
        {
            list.Clear();
        }
    }
}
