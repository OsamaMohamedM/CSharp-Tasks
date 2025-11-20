using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Employee_Managment_System
{
    internal class Employee
    {
        private string name;
        private int age;
        private JobTitleEnum title;


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public JobTitleEnum Title
        {
            get { return title; }
            set { title = value; }
        }
        public Employee(string name, int age, JobTitleEnum title)
        {
            this.name = name;
            this.age = age;
            this.title = title;
        }

    }
}
