using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogrusalTekYonluListeler
{
    public class TekYonluDogrusalListeNode<T> // <T> jenerik bir tipe parametre olarak alındığını belirtir. <int>, <string>
        //gibi tek tek liste oluşturmaktan kurtarır.
    {
        public TekYonluDogrusalListeNode<T> Next { get; set; } // düğüm işaret ettiği elemandan sonrakine karşılık gelir.
        public TekYonluDogrusalListeNode<T> Previous { get; set; }  // düğüm işaret ettiği elemandan öncekine karşılık gelir.
        public T Value { get; set; }
        public TekYonluDogrusalListeNode(T value)
        {
            Value = value;
        }
        public override string ToString() => $"{Value}";
        
    }
}
