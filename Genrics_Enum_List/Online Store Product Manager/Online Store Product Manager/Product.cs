using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Online_Store_Product_Manager
{
    internal class Product
    {
        private string name;
        private decimal price;
        private ProductCategory category;


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public ProductCategory Category
        {
            get { return category; }
            set { category = value; }
        }
        public Product(string name, decimal price, ProductCategory category)
        {
            this.Name = name;
            this.Price = price;
            this.Category = category;
        }

    }
}
