using CF2.DAO;
using CF2.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace CF2
{
    public partial class fTablbeManager : Form
    {

        private Account loginAccount;
        public Account LoginAccount
        {
            get => loginAccount;
            set { loginAccount = value; ChangeAccount(loginAccount.Type); }
        }

        public fTablbeManager(Account acc)
        {   
            InitializeComponent();

            this.LoginAccount = acc;

            LoadTable();
            LoadCategory();
        }
       

        #region Method
        void ChangeAccount(int type)
        {
            adminToolStripMenuItem.Enabled = type == 0;
            thôngTinCáNhânToolStripMenuItem.Text += "(" +loginAccount.Displayname+ ")";
        }

        void UpdateAccount()
        {

        }

        void LoadCategory()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
            cbCategory.DataSource = listCategory;
            cbCategory.DisplayMember = "Name";
        }

        void LoadDrinkListByCategory(int id)
        {
            List<Drink> listDrink = DrinkDAO.Instance.GetDrinkByCategoryID(id);
            cbDrinks.DataSource = listDrink;
            cbDrinks.DisplayMember = "Name";
        }
        void LoadTable()
        {
           flpTable.Controls.Clear();
           List<Table> tableList = TableDAO.Instance.LoadTableList();

            foreach (var item in tableList)
            {
                Button bttn = new Button() { Width = TableDAO.TableWidth , Height = TableDAO.TableHeight };

                bttn.Text = item.Name + Environment.NewLine + item.Status;
                bttn.Click += bttn_Click;
                bttn.Tag = item;

                switch(item.Status)
                {
                    case "Empty":
                        bttn.BackColor = Color.Khaki;
                        break;               
                    default: 
                        bttn.BackColor = Color.Chocolate;
                        break;
                }
                flpTable.Controls.Add(bttn);
            }
        }
        void ShowBill(int id)
        {
            lsvBill.Items.Clear();

            List<CF2.DTO.Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);
            float totalPrice = 0;
            foreach (CF2.DTO.Menu item in listBillInfo)
            {
             
                ListViewItem lsvItem = new ListViewItem(item.DrinkName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice; // tổng giá tiền
                lsvBill.Items.Add(lsvItem);
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            
            /*
            Thread.CurrentThread.CurrentCulture = culture ;
            // Thay doi luong 
            */

            txbTotalPrice.Text = totalPrice.ToString("c",culture);

            
        
        }

        #endregion

        #region Event
        void bttn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            lsvBill.Tag = (sender as Button).Tag;
            ShowBill(tableID);
        }
    
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile(LoginAccount);
           
            f.ShowDialog();
        }

        

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.InsertDrink += F_InsertDrink;
            f.UpdateFood += F_UpdateFood;
            f.DeleteFood += F_DeleteFood;
            f.ShowDialog();
        }

        private void F_DeleteFood(object sender, EventArgs e)
        {
            LoadDrinkListByCategory((cbCategory.SelectedItem as Category).ID);
            if (lsvBill.Tag != null)
            {
                ShowBill((lsvBill.Tag as Table).ID);
            }
            LoadTable();
        }

        private void F_UpdateFood(object sender, EventArgs e)
        {
            LoadDrinkListByCategory((cbCategory.SelectedItem as Category).ID);
            if (lsvBill.Tag != null)
            {
                ShowBill((lsvBill.Tag as Table).ID);
            }
        }

        private void F_InsertDrink(object sender, EventArgs e)
        {
            LoadDrinkListByCategory((cbCategory.SelectedItem as Category).ID);
            if (lsvBill.Tag != null)
            {
                ShowBill((lsvBill.Tag as Table).ID);
            }
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;

            Category selected = cb.SelectedItem as Category;
            id = selected.ID;

            LoadDrinkListByCategory(id);
        }

        private void bttnAdd_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;

            if(table == null)
            {
                MessageBox.Show("Hay chon ban");
                return ;
            }

            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
            int drinkId = (cbDrinks.SelectedItem as Drink).ID;
            int count = (int)numDrink.Value;

            if(idBill == -1)
            {
                BillDAO.Instance.InsertBill(table.ID);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), drinkId, count);
            }
            else
            {
                BillInfoDAO.Instance.InsertBillInfo(idBill, drinkId, count);
            }
            ShowBill(table.ID);

            LoadTable();
        }

        private void bttnCheckOut_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;

            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
            int discount =(int) numDiscount.Value;

            double totalPrice = Convert.ToDouble(txbTotalPrice.Text.Split(',')[0]);
            double finalTotalPrice = totalPrice - (totalPrice / 100) * discount;

            if (idBill != -1)
            {
                if (MessageBox.Show(string.Format("Ban muon thanh toan {0}\n Tong Tien = {1} \n Sau Giam Gia {2}%: {3}  ", table.Name, totalPrice, discount, finalTotalPrice), "Thong bao", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(idBill, discount, (float)finalTotalPrice);
                    ShowBill(table.ID);

                    LoadTable();
                }
            }

            
            Task sendThread = new Task(() =>
            {
                TcpClient tcpClient = new TcpClient();

                tcpClient.Connect(IPAddress.Parse("127.0.0.1"), 8080);

                NetworkStream Stream = tcpClient.GetStream();

                byte[] sendBytes = new byte[256];

                sendBytes = Encoding.UTF8.GetBytes(" Bill: " + idBill + " Ban: "+ table.Name + " Tong Gia:  " + totalPrice * 1000);
                Stream.Write(sendBytes, 0, sendBytes.Length);

                tcpClient.Close();
            });
            sendThread.Start();
        }
    }
    #endregion
}
