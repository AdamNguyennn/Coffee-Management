using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF2.DTO
{
    public class Drink
    {
        public Drink(int id, int idCategory, string name, float price)
        {
            this.ID = id;
            this.IDCategory = idCategory;
            this.Name = name;
            this.Price = price;
        }

        public Drink(DataRow row)
        {
            this.ID = (int)row["id"];
            this.IDCategory= (int)row["idCategory"];
            this.Name = row["name"].ToString();
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
        }

        private float price;
        private string name;
        private int iDCategory;
        private int iD;

        public int ID { get => iD; set => iD = value; }
        public int IDCategory { get => iDCategory; set => iDCategory = value; }
        public string Name { get => name; set => name = value; }
        public float Price { get => price; set => price = value; }
    }
}
