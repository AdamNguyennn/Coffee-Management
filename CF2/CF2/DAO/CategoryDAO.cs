using CF2.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF2.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance
        {
            get { if (instance == null) instance = new CategoryDAO(); return CategoryDAO.instance; }
            private set => instance = value;
        }

        private CategoryDAO() { }

        public List<Category> GetListCategory()
        {
            List<Category> list = new List<Category>();

            string query = "select * from DrinkCategory";

            DataTable data = DataProvider.Instace.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Category category = new Category(item);
                list.Add(category);
            }
            return list;

        }

        public Category GetCategoryByID(int id)
        {
            Category category = null;

            string query = "select * from DrinkCategory WHERE id = " + id;

            DataTable data = DataProvider.Instace.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                category = new Category(item);
                {
                    category = new Category(item);
                    {
                        category = new Category(item);
                        return category;
                    }
                    
                }
            }
            return category;
        }

        public bool InsertCategory(string name)
        {
            string query = string.Format("INSERT dbo.DrinkCategory(name) VALUES(N'{0}')", name);
            int result = DataProvider.Instace.ExcuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateCategory(string name, int id)
        {
            string query = string.Format("UPDATE dbo.DrinkCategory SET name = '{0}' WHERE id = {1}", name, id);
            int result = DataProvider.Instace.ExcuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteCategory(int id)
        {
            string query = string.Format("Delete DrinkCategory Where id = {0} ", id);
            int result = DataProvider.Instace.ExcuteNonQuery(query);

            return result > 0;
        }
    }
}
