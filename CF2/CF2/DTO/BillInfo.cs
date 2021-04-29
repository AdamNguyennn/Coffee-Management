using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF2.DTO
{
    public class BillInfo
    {
        public BillInfo(int id, int drinkID,int billID,int count)
        {
            this.ID = id;
            this.BillID = billID;
            this.Count = count;
            this.DrinkID = drinkID;
        }

        public BillInfo(DataRow row)
        {
            this.ID = (int)row["id"];
            this.BillID = (int)row["idBill"];
            this.Count = (int)row["count"];
            this.DrinkID = (int)row["idDrink"];
        }

        private int count;
        private int drinkID;
        private int billID;
        private int iD;

        public int ID { get => iD; set => iD = value; }
        public int BillID { get => billID; set => billID = value; }
        public int DrinkID { get => drinkID; set => drinkID = value; }
        public int Count { get => count; set => count = value; }
    }
}
