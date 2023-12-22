using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

            var bagliListe = new TekYonluDogrusalListe<int>();

            while (true)
            {
                Console.WriteLine("\n1 Listenin başına eleman ekle");
                Console.WriteLine("2 Listenin sonuna eleman ekle");
                Console.WriteLine("3 Belirli bir konuma eleman ekle");
                Console.WriteLine("4 Belirli bir değere sahip elemanı sil");
                Console.WriteLine("5 Belirli bir değeri ara");
                Console.WriteLine("6 Belirli bir düğümün listenin bir üyesi olup olmadığını kontrol et");
                Console.WriteLine("7 Liste elemanlarını göster");
                Console.WriteLine("0 Çıkış");

                Console.Write("\nSeçiminizi yapın :");
                int secim = int.Parse(Console.ReadLine());
                if (secim == 1)
                {
                    Console.Write("Eklemek istediğiniz değeri girin: ");
                    int deger = int.Parse(Console.ReadLine());
                    bagliListe.addFirst(deger);

                }
                else if (secim == 2)
                {
                    Console.Write("Eklemek istediğiniz değeri girin: ");
                    int deger = int.Parse(Console.ReadLine());
                    bagliListe.addLast(deger);
                }
                else if (secim == 3)
                {
                    Console.Write("Eklemek istediğiniz konumu seçiniz: ");
                    int konum = int.Parse(Console.ReadLine());
                    Console.Write("Eklemek istediğiniz değeri girin: ");
                    int deger = int.Parse(Console.ReadLine());
                    bagliListe.AddNodeAt(deger,konum);
                }
                else if(secim == 4)
                {
                    Console.Write("Silmek istediğiniz değeri girin: ");
                    int deger=int.Parse(Console.ReadLine());
                    bagliListe.RemoveNode(deger);
                }
                else if (secim == 5)
                {
                    Console.Write("Aramak istediğiniz değeri girin: ");
                    int deger = int.Parse(Console.ReadLine());
                    int sonuc = bagliListe.FindIndexByValue(deger);
                    if (sonuc >= 0)
                    {
                        Console.Write($"\nAradığınız {deger} değeri {sonuc} indeksinde bulunmaktadır");
                    }
                    else
                    {
                        Console.Write("\nAradığınız değer bulunmamaktadır.");
                    }
                   

                }
                else if( secim == 6)
                {
                    Console.Write("Sorgulamak istediğiniz değeri girin: ");
                    int deger = int.Parse(Console.ReadLine());
                    bool sonuc=bagliListe.Search(deger);
                    if(sonuc)
                    {
                        Console.Write($"{deger} listede bulunuyor");
                    }
                    else
                    {
                        Console.Write("Listede bulunamadı.");
                    }

                }
                else if(secim==7)
                {
                    Console.Write("LİSTENİN ELEMANLARI: ");
                    bagliListe.ShowAllElements();
                }
                else if (secim == 0)
                {
                    Console.Write("Çıkış yapılıyor..");
                    break;
                }
                else
                {
                    Console.Write("Geçersiz bir seçim yaptınız. Tekrar deneyiniz.");
                }

            }

        }
    }
}
