using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedC_
{
    internal class Box<T>
    {
        T item;
        public void Add(T newItem)
        {
            item = newItem;
        }
        public T GetItem()
        {
            return item;
        }
    }
}
