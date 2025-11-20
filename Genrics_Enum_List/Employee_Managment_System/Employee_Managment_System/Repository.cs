using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Managment_System
{
    internal class Repository<T>
    {
        List<T> employee;
        public Repository()
        {
            employee = new List<T>();
        }
        public void Add(T item)
        {
            employee.Add(item);
        }
        public IEnumerable<T> GetAll()
        {
            return employee.AsReadOnly();
        }
    }
}
