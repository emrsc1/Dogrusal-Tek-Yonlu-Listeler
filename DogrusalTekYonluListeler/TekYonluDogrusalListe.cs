using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DogrusalTekYonluListeler
{
    public class TekYonluDogrusalListe<T>:IEnumerable<T>
    {
        public TekYonluDogrusalListe() 
        {
        
        }
        public TekYonluDogrusalListe(IEnumerable<T> collection)
        {
            foreach(var item in collection)
            {
                this.addFirst(item);
            }
        }
        public TekYonluDogrusalListeNode<T>Head { get; set; } //Sınıfın ilk elemanını temsil eder.
        private bool isHeadNull => Head == null; //listenin başındaki eleman mı boş mu? bu şartı değişkene atar.
        public void addFirst(T value)
        {
            var newNode=new TekYonluDogrusalListeNode<T>(value); // yeni düğüm oluşturuyoruz.
            newNode.Next = Head; // Başlangıç ifadesine Head eklenir.
            Head = newNode; //referans düğümünün yerini değiştirir.
                            //yani newNode listenin başı olur ve herhangi bir önceki baş düğümü artık ikinci eleman olur.
                            //Bu, listenin başındaki düğümü değiştirir ve yeni eklenen düğümü başa yerleştirir.
                            //örneğin fonksiyonun içine 10 sayısını gönderdik diyelim. bu sayı newNode değişkenine atanır.
                            //ardından null olan Head değişkeni ikinci eleman olur ve 10 sayısı ilk eleman olur. sonuç 10->null
                            //yeni örnek olarak 23 sayısını gönderelim. bu sayı newNode değişkenine atanır.
                            //ardından 10 sayısı ikinci eleman olur ve 23 sayısı ilk sıraya yerleşir. 23->10->null

                            
        }
        public void addLast(T value)
        {
            var newNode = new TekYonluDogrusalListeNode<T>(value);
            if (isHeadNull)
            {
                Head = newNode;
                return;  // return çalıştıktan sonra direkt fonksiyonu döndürür. return yazılmazsa derleyici
                         // alt satırlardaki kodları çalıştırmayı deneyip hata verecektir.

            }//eğer listenin başında elemanın değeri yoksa fonksiyona girilen değer listenin başına atanır.
            var current = Head; // listenin ilk elemanını current değişkenine atar.
            while (current.Next!=null) // ilk elemandan sonrası boş değilse döngü çalışacaktır.
            {
                current=current.Next; // mevcut elemandan sonraki elemana geçiş yapar.
            } // bu döngü listedeki son elemanı işaret edene kadar dönecektir ve sonunda sonuncu elemanı işaret edecektir.
            current.Next = newNode; // fonksiyona girilen değeri sonuncu elemandan sonraki boş elemana atar.
                                    // kısaca girilen sayı listedeki sonuncu elemanına atanmış olur.
            

        }
        public void addAfter(TekYonluDogrusalListeNode<T> node,T value)
        {
            if (node == null)
            {
                throw new ArgumentNullException(); // birinci parametre boş ise hata döndürür.
            }
            if (isHeadNull)
            {
                addFirst(value);
                return; // listenin başındaki eleman boş ise girilen değeri listenin başına atar.
            }
            var newNode = new TekYonluDogrusalListeNode<T>(value);
            var current = Head;
            while (current!=null)
            {
                if (current.Equals(node)) //fonksiyona girilen ikinci parametre listenin başındaki eleman ile aynı ise
                {
                    newNode.Next = current.Next; //girilen birinci parametredeki değerden sonraki değeri listenin
                                                 //başındaki elemandan sonraki sıraya atar. kısaca listenin ikinci elemanına
                    current.Next = newNode; //listenin ikinci elemanındaki değer, fonksiyonun birinci parametresine girilen
                                            //değer ile değiştirir.
                                           
                    return; //linkedList.addAfter(linkedList.Head.Next,32); listenin ikinci elemanından sonraki elemana 32 yi atar.
                }
                current = current.Next;
            }
            throw new ArgumentException("Burada böyle bir düğüm bulunmamaktadır.");
        }
        public void addAfter(TekYonluDogrusalListeNode<T> refNode,TekYonluDogrusalListeNode<T> newNode)
        {
            if (refNode == null)
            {
                throw new ArgumentNullException("refNode", "Referans düğüm (refNode) null olamaz.");
            }

            if (newNode == null)
            {
                throw new ArgumentNullException("newNode", "Yeni düğüm (newNode) null olamaz.");
            }

            newNode.Next = refNode.Next;
            refNode.Next = newNode;
        }
        public void addBefore(TekYonluDogrusalListeNode<T> node, T value)
        {
            if (node == null)
            {
                throw new ArgumentNullException();
            }
            if (isHeadNull)
            {
                addFirst(value);
                return;
            }
            var newNode = new TekYonluDogrusalListeNode<T>(value);
            var current = Head;
            while (current != null)
            {
                if (current == node)
                {
                    newNode.Next = current;
                    if (current.Previous == null)
                    {
                        Head = newNode;
                    }
                    else
                    {
                        current.Previous.Next = newNode;
                    }
                    current.Previous = newNode;
                    return;
                }
                current = current.Next;
            }
            throw new ArgumentException("Burada böyle bir düğüm bulunmamaktadır.");
        }
        public void addBefore(TekYonluDogrusalListeNode<T> refNode, TekYonluDogrusalListeNode<T> newNode)
        {
            if (refNode == null)
            {
                throw new ArgumentNullException("refNode", "Referans düğüm (refNode) null olamaz.");
            }

            if (newNode == null)
            {
                throw new ArgumentNullException("newNode", "Yeni düğüm (newNode) null olamaz.");
            }

            var previousNode = refNode.Previous;
            if (previousNode == null)
            {
                newNode.Next = refNode;
                Head = newNode;
            }
            else
            {
                newNode.Next = previousNode.Next;
                previousNode.Next = newNode;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new TekYonluDogrusalListeEnumerator<T>(Head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T removeFirst()
        {
            if (isHeadNull)
            {
                throw new Exception("Silinecek bir veri yok");
            }
            var firstValue = Head.Value;
            Head = Head.Next;
            return firstValue;

        }
        public T removeLast()
        {
            var current = Head;
            TekYonluDogrusalListeNode<T> prev = null;
            while (current.Next != null)
            {
                prev = current;
                current = current.Next;
            }
            var lastValue = prev.Next.Value;
            prev.Next = null;
            return lastValue;
        }
        public void Remove(T value)
        {
            if (isHeadNull)
            {
                throw new Exception("Silinecek bir veri yok");
            }
            if (value == null)
            {
                throw new ArgumentException();
            }
            var current = Head;
            TekYonluDogrusalListeNode<T> prev = null;
            do
            {
                if (current.Value.Equals(value))
                {
                    //son eleman mı?
                    if (current.Next == null)
                    {
                        if (prev == null)//head
                        {
                            Head = null;
                            return;
                        }
                        else//son eleman
                        {
                            prev.Next = null;
                            return;
                        }
                    }
                    else
                    {
                        //head
                        if (prev == null) {
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

                }
            } while (current != null);
            throw new ArgumentException("Listede böyle bir değer bulunamadı.");
            

        }
    }

}
