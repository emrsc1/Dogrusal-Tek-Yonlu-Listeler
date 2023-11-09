using System.Collections;

namespace DogrusalTekYonluListeler
{
    internal class TekYonluDogrusalListeEnumerator<T> : IEnumerator<T>
    {
        private TekYonluDogrusalListeNode<T> Head;
        private TekYonluDogrusalListeNode<T> _current;
        public TekYonluDogrusalListeEnumerator(TekYonluDogrusalListeNode<T> head)
        {
            Head = head;
            _current = null;
        }

        public T Current => _current.Value;

        object IEnumerator.Current => Current;

        public void Dispose() //Head ifadesi boş olursa bağlı listeye erişim sağlanmaz.
        {
            Head = null;
        }

        public bool MoveNext()
        {
            if(_current== null)
            {
                _current = Head;
                return true;
            }
            else
            {
                _current = _current.Next;
                return _current!=null?true:false;
            }
        }

        public void Reset()
        {
            _current = null;
        }
    }
}