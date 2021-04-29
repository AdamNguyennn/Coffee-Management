using CF2.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF2.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance
        {
            get { if (instance == null) instance = new BillInfoDAO(); return BillInfoDAO.instance;}
            private set => instance = value;
        }

        private BillInfoDAO() { }

        public void DeleteBillInfoDrinkID(int id)
        {
            DataProvider.Instace.ExcuteQuery("Delete dbo.BillInfo Where idDrink =" + id);
        }
        public List<BillInfo> GetListBillInfo(int id)
        {
            List<BillInfo> listBillInfo = new List<BillInfo>();

            DataTable data = DataProvider.Instace.ExcuteQuery("SELECT * FROM dbo.BillInfo WHERE idBill = " + id);

            foreach (DataRow item in data.Rows)
            {
                BillInfo info = new BillInfo(item);
                listBillInfo.Add(info);
                
            }
            
            return listBillInfo;
        }
        public void InsertBillInfo(int idBill, int idDrink, int count)
        {
            DataProvider.Instace.ExcuteNonQuery("exec USP_InsertBillInfo @idBill , @idDrink , @count", new object[] { idBill, idDrink, count });
        }
    }
}
