using CF2.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF2.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;

        public static MenuDAO Instance
        {
            get { if (instance == null) instance = new MenuDAO(); return MenuDAO.instance; }
            private set => instance = value;
        }

        private MenuDAO() { }

        public List<Menu> GetListMenuByTable(int id)
        {
            List<Menu> listMenu = new List<Menu>();

            string query = @"SELECT d.name, b.count,d.price, d.price*b.count AS totalprice FROM dbo.BillInfo AS b,  dbo.Bill AS bi, dbo.Drink AS d  
WHERE b.idBill = bi.id AND b.idDrink = d.id AND bi.status = 0 AND bi.idTable = "+ id ;

            DataTable data = DataProvider.Instace.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);
                listMenu.Add(menu);
            }
            return listMenu;
        }
    }
}
