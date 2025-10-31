using System.Collections;

namespace AdvancedC_
{
    public class CustomClass<T> : IEnumerable<T>, IEnumerator<T>
    {
        List<T> lst = new List<T>();
        int position = -1;
        public void Add(T newItem)
        {
            lst.Add(newItem);
        }
        public int Count()
        {
            return lst.Count();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool MoveNext()
        {
            position++;
            return (position < lst.Count);
        }

        public void Reset()
        {
            position = -1;
        }
        public void Dispose()
        {

        }

        public T Current
        {
            get
            {
                if (position < 0 || position >= lst.Count)
                    throw new InvalidOperationException();
                return lst[position];
            }
        }

        object IEnumerator.Current => Current;
        public T this[int index]   // this[int index] defines the indexer
    {
        get
        {
            if (index < 0 || index >= lst.Count)
                throw new IndexOutOfRangeException();
            return lst[index];
        }
        set
        {
            if (index < 0 || index >= lst.Count)
                throw new IndexOutOfRangeException();
            lst[index] = value;
        }
    }
    }

}