using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructurs.Arrays
{
    public class Array<T> :IEnumerable<T>, ICloneable
    {
        private T[] InnerList; // veri organızasyonunu sağlayan dızı burada tanımlandı
        public int Count { get; private set; } // eleman sayısını veren ozellik
        public int Capacity => InnerList.Length; 

        public Array() // conctructor
        {
            InnerList = new T[2]; // diziyi başlatır, başlangıçta dizi boyutu 2 olarak ayarlanmıs
            Count = 0; // başlangıçta eleman sayısı 0
        }

        public Array(params T[] initial)
        {
            InnerList = new T[initial.Length];
            Count = 0;
            foreach (var item in initial) 
            {
                Add(item);
            }
        }

        public Array(IEnumerable<T> collection) // gonderilen koleksiyondakı elemanlar dızıye eklenebilir
        {
             InnerList = new T[collection.ToArray().Length]; // koleksiyon dızıye cevrilip uzunlugu alınır
             Count = 0;

            foreach (var item in collection)
            {
                Add(item);
            }
        }
        public object Clone()
        {
            // return this.MemberwiseClone(); // mevcut ornegin sığ kopyasını olusturur
            // sığ kopyalama ilgili nesnenın tum ozellıklerının klonlnaan ogeye geçmesini sağlar ıstenılen yerler manuel olarak değıstırılır 
            // kopyalanmıs nesne asıl nesneden farkllıdır herhangı bırınde yapılan degısıklık dıgerını etkılemez. referans tipli degildir



            // derin kopyalama --> bu da referans tipli değildir bundan dolayı birinde yapılandegişiklik diğerini etkielemz
            // olusturulan kopya sıfırdan olusur
            var arr = new Array<T>();
            foreach (var item in this)
            {
                arr.Add(item);
               
            }
            return arr;


        }

        public void AddRange(IEnumerable<T> collection)
        {
            int eleman = collection.Count();
            if (InnerList.Length == Count || (Count + eleman) >= InnerList.Length)
            {
                DoubleArray();
            }

            var sayi=Capacity;
            foreach (var item in collection)
            {
                InnerList[Count] = item;
                Count++;
            }

        }

        public void Remove(T item)
        {
            foreach (var eleman in InnerList)
            {
                if (item.Equals(eleman))
                {
                    Remove(eleman);
                }
            }

        }
        public void Add(T item) // dizinin ilk başta belirtilen tipte parametre alınıp ekleme yapılması gerek
        {
            if( InnerList.Length == Count)
            {
                DoubleArray(); // eğer dizinin uzunluğu eleman sayısında eşitse daha fazla eleman ekleyebilmek içindizi boyutu 2 katına cıkarıldı
            }
            InnerList[Count] = item;  // dizinin başlangıcta eleman sayısı 0 oldugu içinelemanlar 0. indexten eklenmeye başlar
                                      //eleman indise eklandikten sonra count sayısı 1 artırılarak yeni gelecek eleman için indis değeri değiştirilmiş olur
            Count++;
        }

        public T Remove() // silinen elemanı geriye dondurecek bundan dolayı geri donus tıpı T dir
        {
            if (Count == 0) // silinecek eleman yoksa 
                throw new Exception("there is no more item to be removed from the array.");

            if( InnerList.Length/4 == Count)// eklenmesi gerekirse 2 katına cıklamı ondan dolayı 4te 1 karsılastırılır
            {
                HalfArray(); // dızı boyutu dusurulur
            }
            var temp = InnerList[Count - 1]; // count en sondaki boş yeri ifade eder bundan dolayı son eleman count-1. indextedir  
            if(Count >0)
                Count--;
            return temp;
        }

        private void HalfArray()
        {
            if (InnerList.Length >2)
            {
                var temp =new T[InnerList.Length/2];
                System.Array.Copy(InnerList, temp, InnerList.Length/4);
                InnerList = temp;
            }
        }

        private void DoubleArray()
        {
            var temp = new T[InnerList.Length*2]; // dizi boyutunu 2 katına çıkarır ancak mevcut dizi için kapasıte artırılamaz bundan dolayı yenı bir dizide boyut arttı ve mevcut dizinin elemanları bu diziye kopyalandı
            //for (int i=0; i<InnerList.Length; i++)
            //{
            //    temp[i] = InnerList[i];
            //}
            System.Array.Copy(InnerList, temp, InnerList.Length);
            InnerList = temp;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return InnerList.Take(Count).GetEnumerator();  // count a bağlı olarak kaç tane eleman varsa o kadarını getiri
            // eğer bu şekilde yapılmazsa dizinin tüm boyutlarını getirir boş yerleri de 0 olarak getirrir
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();  //IEnumarable interface obje olarak değil generic olarak tanımlandığı için yı-ukarıdaki metoda yonlendirildi 
        }
    }
}
