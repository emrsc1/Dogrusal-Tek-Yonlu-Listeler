using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
namespace DogrusalTekYonluListeler
{
    class Program
    {
        static void Main(string[] args)
        {
            //var linkedList = new TekYonluDogrusalListe<int>();
            //linkedList.addFirst(1);
            //linkedList.addFirst(2);
            //linkedList.addFirst(3);
            //// 3 2 1

            //linkedList.addLast(4);
            //linkedList.addLast(5);
            ////3 2 1 4 5

            //linkedList.addAfter(linkedList.Head.Next,32);
            //linkedList.addAfter(linkedList.Head.Next.Next, 33);
            //linkedList.addBefore(linkedList.Head.Next, 35);
            //linkedList.addBefore(linkedList.Head, 37);

            //var list = new LinkedList<int>();
            //list.AddFirst(1);
            //list.AddFirst(2);
            //list.AddFirst(3);
            //foreach(var item in linkedList)
            //{
            //    Console.WriteLine(item.ToString());
            //}

            //var dizi = new char[] { 'a', 'b', 'c' };
            //var diziListe = new ArrayList(dizi); // dizi ile aynı elemanlara sahip olur
            //var liste = new List<char>(dizi);// dizi ile aynı elemanlara sahip olur
            //var csBagliListe = new LinkedList<char>(dizi);// dizi ile aynı elemanlara sahip olur

            //foreach(var item in dizi) //dizi yerine diziListe,liste,csBagliListe yazsanız da aynı sonucu alırsınız.
            //{
            //    Console.WriteLine(item);
            //}
            //Console.ReadKey();
            //liste.AddRange(new char[] { 'd', 'e', 'f' });
            //var linkedlist = new TekYonluDogrusalListe<char>(liste);
            //foreach(var item in linkedlist)
            //{
            //    Console.WriteLine(item);
            //}

            //var charset = new List<char>(linkedlist);
            //    Console.WriteLine();
            //foreach (var item in charset)
            //{
            //    Console.Write(item + " ");
            //}

            var rnd=new Random();
            var initial = Enumerable.Range(1,10).OrderBy(x=>rnd.Next()).ToList();
            var bagliListe = new TekYonluDogrusalListe<int>(initial);
            var q = from item in bagliListe // listedeki tek sayıları seçer.
                    where item % 2 == 1
                    select item;
            //foreach(var item in q)
            //{
            //    Console.WriteLine(item);
            //}
            /*bagliListe.Where(x => x > 5).ToList().ForEach(x=> Console.Write(x+" "));*/  //ToList() : listeye çevirir. listedeki 5 ten büyük ifadeler yazdırılır.
            bagliListe.removeFirst();
            bagliListe.removeLast();
            foreach(var item in bagliListe)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();

        }
    }
}
