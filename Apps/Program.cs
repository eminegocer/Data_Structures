using DataStructurs.LinkedList.DublyLinkedList;
using DataStructurs.LinkedList.SinglyLinkedList;
using System;
using System.Collections;
using System.Collections.Generic;
using DataStructurs.Stack;
using System.Linq;
using DataStructurs.Tree.BST;
using DataStructurs.Tree.BinaryTree;


namespace Apps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sonuc = DataStructurs.Recursive.Recursive.Fact(3);
            Console.WriteLine( sonuc);
        }
        private static void BinaryTreeApp04()
        {
            var bst = new BST<int>(new int[] { 23, 16, 45, 3, 22, 37, 99 });

            foreach (var node in bst)
            {
                Console.WriteLine(node);
            }
            Console.ReadKey();
        }
        private static void BinaryTreeApp03()
        {
            var bst = new BST<int>(new int[] { 23, 16, 45, 3, 22, 37, 99 });

            Console.WriteLine($"Number of leafs : " + $"{BinaryTree<int>.NumberOfLeafs2(bst.Root)}");

            Console.WriteLine($"Number of full nodes : " +
                $"{BinaryTree<int>.NumberOfFullNodes(bst.Root)}");

            Console.WriteLine($"Number of half nodes : " +
                $"{BinaryTree<int>.NumberOfHalfNodes(bst.Root)}");

            new BinaryTree<int>().PrintPaths(bst.Root);
        }
        private static void BinaryTreeApp02()
        {
            var BST = new BST<int>(new int[] { 60, 40, 70, 20, 45, 65, 85 });


            var bt = new BinaryTree<int>();
            Console.WriteLine("InOrderTraversal");
            bt.InOrder(BST.Root)
                .ForEach(node => Console.Write($"{node,-3}"));

            Console.WriteLine();
            Console.WriteLine("InOrderNonRecursiveTraversal");
            bt.InOrderNonRecursiveTraversal(BST.Root)
                .ForEach(node => Console.Write($"{node,-3}"));

            Console.WriteLine();
            Console.WriteLine("PreOrderNonRecursiveTraversal");

            bt.PreOrderNonRecursiveTraversal(BST.Root)
                .ForEach(node => Console.Write($"{node,-3}"));

            Console.WriteLine();
            Console.WriteLine("PostOrderNonRecursiveTraversal");
            //bt.PostOrderNonRecursiveTraversal(BST.Root)
            //    .ForEach(node => Console.Write($"{node,-3}"));

            Console.WriteLine();
            Console.WriteLine("Level Order Non Recursive Traversal");
            bt.LevelOrderNonRecursiveTravel(BST.Root)
                .ForEach(node => Console.Write($"{node,-3}"));

            Console.WriteLine("\n*****************************************");

            Console.WriteLine($"Minimum Value: {BST.FindMin(BST.Root.Left)}");
            Console.WriteLine($"MAximum Value: {BST.FindMax(BST.Root.Left)}");

            Console.WriteLine("*****************************************");

            var keyNode = BST.Find(BST.Root, 116);
            if (keyNode != null)
            {
                Console.WriteLine("Find");
                Console.WriteLine($"{keyNode.Value} - Left: {keyNode.Left} - Right:{keyNode.Right}");

            }


            bt.InOrderNonRecursiveTraversal(BST.Root)
                .ForEach(node => Console.Write($"{node,-3}"));

            Console.WriteLine();
            Console.WriteLine("RecursiveRemove");

            BST.Remove(BST.Root, 20);
            BST.Remove(BST.Root, 40);
            BST.Remove(BST.Root, 60);

            bt.ClearList();
            bt.InOrderNonRecursiveTraversal(BST.Root)
                .ForEach(node => Console.Write($"{node,-3}"));

            Console.WriteLine("\n*********************MAX_DEPTH********************");
            var bst = new DataStructurs.Tree.BST.BST<byte>(new byte[] { 60, 40, 70, 20, 45, 65, 80, 45 });

            var list = new DataStructurs.Tree.BinaryTree.BinaryTree<byte>().InOrder(bst.Root);

            foreach (var node in list)
            {
                Console.Write($"{node,-3}");
            }
            Console.WriteLine($"\nMin     :{bst.FindMin(bst.Root)}");
            Console.WriteLine($"Max       :{bst.FindMax(bst.Root)}");
            Console.WriteLine($"Depth     :{DataStructurs.Tree.BinaryTree.BinaryTree<byte>.MaxDepth(bst.Root)}");

            Console.WriteLine("\n*********************DEEPEST_NODE********************");
            var bt2 = new BinaryTree<char>();
            bt2.Root = new Node<char>('F');
            bt2.Root.Left = new Node<char>('A');
            bt2.Root.Right = new Node<char>('T');
            bt2.Root.Left.Left = new Node<char>('D');

            var list2 = bt2.LevelOrderNonRecursiveTravel(bt2.Root);

            foreach (var node in list2)
            {
                Console.WriteLine(node);
            }

            Console.WriteLine($"Deepest Node:{bt2.DeepstNode(bt2.Root)}");
            Console.WriteLine($"Deepest Node:{bt2.DeepstNode()}");
            Console.WriteLine($"Max Depth:{BinaryTree<char>.MaxDepth(bt2.Root)}");


        }
        private static void BinaryTreeApp01()
        {
            var BST = new BST<int>(new int[] { 23, 16, 45, 3, 22, 37, 99 });


            var bt = new BinaryTree<int>();

            bt.InOrder(BST.Root)
                .ForEach(node => Console.Write($"{node,-3}"));

            bt.ClearList();

            Console.WriteLine();
            bt.PreOrder(BST.Root)
                .ForEach(node => Console.Write($"{node,-3}"));

            bt.ClearList();
            Console.WriteLine();
            bt.PostOrder(BST.Root)
                .ForEach(node => Console.Write($"{node,-3}"));
            //foreach (var node in list)
            //{
            //    Console.WriteLine(node);
            //}
        }
        private static void DoublyLinkedListApp05()
        {
            var numbers = new int[] { 10, 20, 30 };

            var q1 = new DataStructurs.Queue.Queue<int>();
            var q2 = new DataStructurs.Queue.Queue<int>(DataStructurs.Queue.QueueType.LinkedList);
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
                q2.EnQueue(number);
                q1.EnQueue(number);

            }
            Console.WriteLine($"q1 count : {q1.Count}");
            Console.WriteLine($"q2 count : {q2.Count}");

            Console.WriteLine($"{q2.DeQueue()} has been removed from q2");
            Console.WriteLine($"{q1.DeQueue()} has been removed from q1");

            Console.WriteLine($"q1 count : {q1.Count}");
            Console.WriteLine($"q2 count : {q2.Count}");

            Console.WriteLine($"q1 peek : {q1.Peek()}");
            Console.WriteLine($"q2 peek : {q2.Peek()}");
            Console.ReadKey();
        }
        private static void DoublyLinkedListApp04()
        {
            var charset = new char[] { 'a', 'b', 'c', 'd', 'e' };
            var stack1 = new DataStructurs.Stack.Stack<char>(); // varsayılan olarak dizi şeklinde çalışacak o sekilde tanımlandı
            var stack2 = new DataStructurs.Stack.Stack<char>(StackType.LinkedList);

            foreach (var c in charset)
            {
                Console.WriteLine(c);
                stack1.Push(c);
                stack2.Push(c);
            }

            Console.WriteLine("Peek");
            Console.WriteLine($"Stack1 {stack1.Peek()}");
            Console.WriteLine($"Stack1 {stack2.Peek()}");

            Console.WriteLine("\nCount");
            Console.WriteLine($"Stack1 {stack1.Count}");
            Console.WriteLine($"Stack1 {stack2.Count}");

            Console.WriteLine("\nPop");
            Console.WriteLine($"Stack1 {stack1.Pop()} has been removed");
            Console.WriteLine($"Stack1 {stack2.Pop()} has been removed");
        }
        private static void DoublyLinkedListApp03()
        {
            var list = new DoublyLinkedList<int>(new int[] { 23, 44, 55, 61 });
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();


            list.Remove(55);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        private static void DoublyLinkedListApp02()
        {
            var list = new DoublyLinkedList<char>(new List<char>() { 'a', 'b', 'c' }); //tanımlı constructor lardan birinde parametre olarak IEnumarable (numaralandırılabilen) yapıda ifadealındı
                                                                                       //bu sayede gelecek yapılardan IEnumarable yi kabul eden herhangi bir yapı bu constructoru kullanarak elemaları 
                                                                                       // dongu içinde kullanabilir
            Console.WriteLine($"{list.RemoveFirst()} has been removed from list");
            Console.WriteLine();
            Console.WriteLine($"{list.RemoveLast()} has been removed from list");
            Console.WriteLine($"{list.RemoveLast()} has been removed from list");

        }
        private static void DoublyLinkedListApp01()
        { // DoublyLinkedList

            var list = new DoublyLinkedList<int>();
            list.AddFirst(10);
            list.AddFirst(15);

            list.AddFirst(44);
            list.AddFirst(55);

            //55 44 15 10 
            list.AddAfter(list.Head.Next, new DoublyLinkedListNode<int>(13));
            // 55 44 13 15 10

            list.AddBefore(list.Head.Next.Next, new DoublyLinkedListNode<int>(88));
            // 55 44 88 13 15 10

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        private static void SinglyLinkedListApp02()
        {
            // Bağlı Liste kodları


            var linkedList = new SinglyLinkedList<int>();
            linkedList.AddFirst(1);
            linkedList.AddFirst(2);
            linkedList.AddFirst(3);
            // 3 2 1  O(1s)

            linkedList.AddLast(4);
            linkedList.AddLast(5);
            // 3 2 1 4 5 O(n)

            linkedList.AddAfter(linkedList.Head.Next, 32);
            // 3 2 32 1 4 5 O(n)
            linkedList.AddAfter(linkedList.Head.Next.Next, 33);
            // 3 2 32 33 1 4 5 O(n)

            linkedList.AddAfter(linkedList.Head.Next.Next.Next, new SinglyLinkedListNode<int>(77));
            // 3 2 32 33 77 1 4 5 O(n)

            linkedList.AddBefore(linkedList.Head.Next.Next, 88);
            // 3 2 88 32 33 77 1 4 5 O(n)

            linkedList.AddBefore(linkedList.Head.Next.Next, new SinglyLinkedListNode<int>(99));
            // 3 2 99 88 32 33 77 1 4 5 O(n)


            var list = new LinkedList<int>();
            list.AddFirst(1);
            list.AddFirst(2);
            list.AddFirst(3);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            foreach (var item in linkedList) // oluşturdugum veri yapısında IEnumarable özelliği olmadığından dolayı hata verir. Veri yapısının tanımlandıgı sınıfta IEnumarable ozelliği kazandırılmalı
            {
                Console.WriteLine(item);
            }
        }
        private static void SinglyLinkedListApp01()
        {
            // Array

            //var arrChar = new char[3];
            //var arrChar = new char[] { 'a', 'b', 'c' };
            //char[] arrChar = new char[] {'a', 'b','c'};
            char[] arrChar = new char[3];


            // ArrayList not type-safe  tip guvenli olmadıgı şçin gelen elemanların tıpınebakılmaksızın hepsı kutulanıp aynı anda tutulabilir
            // 10 -> boxing -> object
            // b -> boxing ->object
            // object -> unboxing - int

            var arrObj = new ArrayList();
            arrObj.Add("a");
            arrObj.Add(10);

            var c = ((int)arrObj[1] + 20); // unboxing

            // List<>

            var arrInt = new List<int>();
            arrInt.Add(1);
            arrInt.Add('b'); // ascıı karakter olaraak alır
            arrInt.AddRange(new int[] { 1, 2, 3 }); //çoklu ekleme yapar
            arrInt.RemoveAt(1); // 1. indexteki elemanı siler
            foreach (var i in arrInt)
            {
                Console.WriteLine(i);
            }


            //oluşturulan lısteyi kullanma

            var arr = new DataStructurs
                .Arrays
                .Array<int>();

            arr.Add(77);
            arr.Add(73);
            arr.Add(88);
            arr.Add(93);
            arr.Add(72);

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-------------------");
            //Enumarable  LINQ sorgusu sağlar
            arr.Where(x => x % 2 == 0)
                .ToList()
                .ForEach(x => Console.WriteLine(x));
            arr.Remove();
            // arr.Add(44); dizi boyutu genişletilmeden ekleme yapılamaz
            Console.WriteLine($"{arr.Count} / {arr.Capacity}");



            Console.WriteLine("**************************");

            var arr2 = new DataStructurs
                .Arrays
                .Array<int>(4, 7, 89, 45, 62);

            foreach (var item in arr2)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("**************************");

            var p1 = new DataStructurs.Arrays.Array<int>(1, 2, 3, 4); // IEnumarable yi kabul edebilir. foreach kullanılabilir
            var p2 = new int[] { 8, 9, 10, 11 };// IEnumarable yi kabul edebilir. foreach kullanılabilir
            var p3 = new List<int>() { 5, 15, 0, 25 };// IEnumarable yi kabul edebilir. foreach kullanılabilir
            var p4 = new ArrayList() { 12, 13, 14, 15 };// IEnumarable yi kabul etmez. foreach kullanılamaz. objeye baglı calışır. kutulama işlmi yapılır. tip guvenligi saglanmadıgı ıcın IEnumarable kullanamaz

            var arr3 = new DataStructurs
                .Arrays
                .Array<int>(p1);
            foreach (var item in p1)
                Console.WriteLine(item);


            var arr4 = new DataStructurs
                .Arrays
                .Array<int>();

            for (int i = 0; i < 8; i++)
            {
                arr4.Add(i + 1);
                Console.WriteLine($"{i + 1} has been added to array.");
                Console.WriteLine($"{arr4.Count}/{arr4.Capacity}");
            }

            Console.WriteLine();

            for (int i = arr4.Count; i >= 1; i--)
            {
                Console.WriteLine($"{arr4.Remove()} has been removed the array.");
                Console.WriteLine($"{arr4.Count} /{arr4.Capacity}");
            }
            Console.WriteLine();

            foreach (var item in arr4)
            {
                Console.WriteLine(item);
            }


            // klonlama

            var arr5 = new DataStructurs.Arrays.Array<int>(1, 3, 5, 7);
            var crr = (DataStructurs.Arrays.Array<int>)arr5.Clone(); // objeyi kutudan cıkarma ıslemı
                                                                     // var crr = arr.Clone as DataStructurs.Arrays.Array<int>;  unboxing 2
            foreach (var item in arr5)
            {
                Console.Write($"{item,-3}"); // ker bir elemanı 3 birimlik sola yasladı
            }

            Console.WriteLine();
            foreach (var item in crr)  // IEnunmarable yetenegi yok bundan dolayı dırekt foreach kullanılamaz. yukarıda unboxing işlemi gerceklestirildi
            {
                Console.Write($"{item,-3}"); // ker bir elemanı 3 birimlik sola yasladı
            }

            Console.WriteLine($"{crr.Count} / {crr.Capacity}");


            // AddRange metodu

            var arr6 = new DataStructurs.Arrays.Array<int>(1, 2);

            var ekle = new List<int> { 7, 8, 9, 10 };
            arr6.AddRange(ekle);


            arr6.Remove(1);
            foreach (var item in arr)
            {
                Console.WriteLine(item);
                Console.WriteLine($"{arr6.Count}/{arr6.Capacity}");
            }
        }
        private static void SinglyLinkedListApp03()
        {
            var arr = new char[] { 'a', 'b', 'c' }; // dizi mantıgıyla calısır
            var arrList = new ArrayList(arr); // dizi mantıgıyla calısır
            var list = new List<char>(arr); // dizi mantıgıyla calısır
            var cLinkedList = new LinkedList<char>(arr);  // dinamik bellek yonetimi yapar işsretçiler ile calısır ve parametre aldııgı değer Enumerable ozellikte olmalı


            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
            var linkedList = new SinglyLinkedList<char>(list);
            var charset = new List<char>(linkedList);

            foreach (var item in charset)
            {
                Console.Write(item + " ");
            }
        }
        private static void SinglyLinkedListApp04()
        {
            // Language Integrated Query - LINQ

            var rnd = new Random();
            var initial = Enumerable.Range(1, 10).OrderBy(x => rnd.Next()).ToList();
            var linkedList = new SinglyLinkedList<int>(initial);


            var q = from item in linkedList
                    where item % 2 == 1
                    select item;


            //foreach(var item in q)
            //{
            //    Console.WriteLine(item);
            //}

            linkedList.Where(x => x > 5)
                .ToList()
                .ForEach(x => Console.Write(x + " "));

        }
        private static void SinglyLinkedListRemove()
        {
            var rnd = new Random();
            var initial = Enumerable.Range(1, 5).OrderBy(x => rnd.Next()).ToList();

            var list = new SinglyLinkedList<int>(initial);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"{list.RemoveFirst()} has been removed");
            Console.WriteLine($"{list.RemoveFirst()} has been removed");

            foreach (var item in list)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
            Console.WriteLine($"{list.RemoveLast()} has been removed");
            Console.WriteLine($"{list.RemoveLast()} has been removed");
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
            Console.WriteLine();
            // ara düğüm silme

            var list2 = new SinglyLinkedList<int>(new int[] { 1, 2, 3, 44, 55, 66, 45 });
            list2.Remove(2);
            list2.Remove(55);
            list2.Remove(75);
            foreach (var item in list2)
                Console.Write(item + " ");

        }
    }
   
}
