using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Product_Manager
{
    internal class Repository<T>
    {
        List<T> products;
        public Repository()
        {
            products = new List<T>();
        }
        public void Add(T item)
        {
            products.Add(item);
        }
        public IEnumerable<T> GetAll()
        {
            return products.AsReadOnly();
        }
    }
}
