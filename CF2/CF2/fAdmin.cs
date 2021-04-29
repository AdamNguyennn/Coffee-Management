using CF2.DAO;
using CF2.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CF2
{
    public partial class fAdmin : Form
    {
        BindingSource drinkList = new BindingSource();
        public fAdmin()
        {
            InitializeComponent();
            Load();
        }

        void LoadAccountList()
        {
            string query = "SELECT * FROM dbo.Account";
            // "SELECT DisplayName as[Tên Hiển Thị] FROM abo.Account"

            dtgvAccount.DataSource = DataProvider.Instace.ExcuteQuery(query);
            LoadListBillByDate(dtpFromDate.Value, dtpToDate.Value);
        }

        #region
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tcBill_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel18_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tbDrinkCategory_Click(object sender, EventArgs e)
        {

        }

        private void fAdmin_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Methods
        void Load()
        {
            dtgvDrinks.DataSource = drinkList;
            LoadListBillByDate(dtpFromDate.Value, dtpToDate.Value);
            
            LoadListDrink();
            AddDrinkBinding();

            LoadListCategory();
            AddCategoryBinding();
            LoadCategoryIntoCombobox(cbCategory);

            LoadListTable();
            AddTableBinding();
            LoadTypeTableIntoCombobox(cbTable);

            LoadAccountList();
            AddAccountBinding();
            LoadTypeAccountIntoCombobox(cbAccountType);



        }

        // Drink
        void LoadListDrink()
        {
            drinkList.DataSource = DrinkDAO.Instance.GetListDrink();
        }

        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            dtgvBill.DataSource = BillDAO.Instance.GetListByDate(checkIn, checkOut);
        }

        void AddDrinkBinding()
        {
            txtbDrinkName.DataBindings.Add(new Binding("Text", dtgvDrinks.DataSource, "name", true, DataSourceUpdateMode.Never));
            txtbDrinkID.DataBindings.Add(new Binding("Text", dtgvDrinks.DataSource, "id", true, DataSourceUpdateMode.Never));
            numDrinkPrice.DataBindings.Add(new Binding("Value", dtgvDrinks.DataSource, "price", true, DataSourceUpdateMode.Never));
        }

        // Category in Drink
        void LoadCategoryIntoCombobox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "name";
        }

        // CategoryTable
        void LoadListCategory()
        {
            dtgvCategory.DataSource = CategoryDAO.Instance.GetListCategory();
        }

        void AddCategoryBinding()
        {
            txtbCategoryName.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "name"));
            txtbCategoryID.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "id"));
        }

        //Table
        void LoadListTable()
        {
            dtgvTable.DataSource = TableDAO.Instance.LoadTableList();
        }

        void AddTableBinding()
        {
            txtbTableID.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "id"));
            txtbTableName.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "name"));
        }

        void LoadTypeTableIntoCombobox(ComboBox cb)
        {
            cb.DataSource = TableDAO.Instance.LoadTableList();
            cb.DisplayMember = "status";
        }

        //Account
        void AddAccountBinding()
        {
            txtbAccountName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "userName"));
            txtbDisplayName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "displayName"));
        }

        void LoadTypeAccountIntoCombobox(ComboBox cb)
        {
            cb.DataSource = AccountDAO.Instance.LoadAccountList();
            cb.DisplayMember = "type";
        }



        #region Events
        private void btnViewBill_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpFromDate.Value, dtpToDate.Value);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadListDrink();
        }

        

        private void bttnCategoryView_Click(object sender, EventArgs e)
        {
            LoadListCategory();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadListTable();
        }

        // Drink Category combobox
        private void txtbDrinkID_TextChanged(object sender, EventArgs e)
        {
            if(dtgvDrinks.SelectedCells.Count>0)
            { 

            int id = (int)dtgvDrinks.SelectedCells[0].OwningRow.Cells["idCategory"].Value;
            
                Category category = CategoryDAO.Instance.GetCategoryByID(id);

                cbCategory.SelectedItem = category;

                int Index = -1;
                int i = 0;

                foreach  (Category item in cbCategory.Items)
                {
                    if(item.ID == category.ID)
                    {
                        Index = i;
                            break;
                    }
                    i++;
                }
                cbCategory.SelectedIndex = Index;

            }
        }

        // Table Type Combobox
        private void txtbTableID_TextChanged(object sender, EventArgs e)
        {
            if (dtgvTable.SelectedCells.Count > 0)
            {

                int id = (int)dtgvTable.SelectedCells[0].OwningRow.Cells["id"].Value;

                Table table = TableDAO.Instance.GetTypeTableByID(id);

                cbTable.SelectedItem = table;

                int Index = -1;
                int i = 0;

                foreach (Table item in cbTable.Items)
                {
                    if (item.ID == table.ID)
                    {
                        Index = i;
                        break;
                    }
                    i++;
                }
                cbTable.SelectedIndex = Index;

            }
        }


       

        private void txtbAccountName_TextChanged(object sender, EventArgs e)
        {
            //if (dtgvAccount.SelectedCells.Count > 0)
            //{

            //    string name = dtgvAccount.SelectedCells[0].OwningRow.Cells["userName"].Value.ToString();

            //    Account acc = AccountDAO.Instance.GetAccountByType(name);

            //    cbAccountType.SelectedItem = acc;

            //    int Index = -1;
            //    int i = 0;

            //    foreach (Account item in cbAccountType.Items)
            //    {
            //        if (item.Username == acc.Username)
            //        {
            //            Index = i;
            //            break;
            //        }
            //        i++;
            //    }
            //    cbTable.SelectedIndex = Index;

            //}
        }
      

        //Drink Them Xoa Sua
        private void bttnAddDrink_Click(object sender, EventArgs e)
        {
            string name = txtbDrinkName.Text;
            int categoryID = (cbCategory.SelectedItem as Category).ID;
            float price = (float)numDrinkPrice.Value;

            if (DrinkDAO.Instance.InsertDrink(name, categoryID, price))
            {
                MessageBox.Show("Them Mon Thanh Cong");
                LoadListDrink();
                if (insertDrink != null)
                {
                    insertDrink(this, new EventArgs());
                }

                Task sendThread = new Task(() =>
                {
                    TcpClient tcpClient = new TcpClient();

                    tcpClient.Connect(IPAddress.Parse("127.0.0.1"), 8080);

                    NetworkStream Stream = tcpClient.GetStream();

                    byte[] sendBytes = new byte[256];

                    sendBytes = Encoding.UTF8.GetBytes("Da Them Mot Mon");
                    Stream.Write(sendBytes, 0, sendBytes.Length);

                    tcpClient.Close();
                });
                sendThread.Start();

            }
            else
            { 
                MessageBox.Show("Co Loi Khi Them Thuc An");
            }
            
    }
        private void bttnChangeDrink_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtbDrinkID.Text);
            string name = txtbDrinkName.Text;
            int categoryID = (cbCategory.SelectedItem as Category).ID;
            float price = (float)numDrinkPrice.Value;

            if (DrinkDAO.Instance.UpdateDrink(id, name, categoryID, price))
            {
                MessageBox.Show("Sua Mon Thanh Cong");
                LoadListDrink();
                if (updateFood != null)
                {
                    updateFood(this, new EventArgs());
                }

                Task sendThread = new Task(() =>
                {
                    TcpClient tcpClient = new TcpClient();

                    tcpClient.Connect(IPAddress.Parse("127.0.0.1"), 8080);

                    NetworkStream Stream = tcpClient.GetStream();

                    byte[] sendBytes = new byte[256];

                    sendBytes = Encoding.UTF8.GetBytes("Da Sua Mot Mon");
                    Stream.Write(sendBytes, 0, sendBytes.Length);

                    tcpClient.Close();
                });
                sendThread.Start();

            }
            else
            {
                MessageBox.Show("Co Loi Khi Sua Mon");
            }
        }
        private void bttnDelDrink_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtbDrinkID.Text);

            if (DrinkDAO.Instance.DeleteDrink(id))
            {
                MessageBox.Show("Xoa Mon Thanh Cong");
                LoadListDrink();

                if(deleteFood != null)
                {
                    deleteFood(this, new EventArgs());
                }

                Task sendThread = new Task(() =>
                {
                    TcpClient tcpClient = new TcpClient();

                    tcpClient.Connect(IPAddress.Parse("127.0.0.1"), 8080);

                    NetworkStream Stream = tcpClient.GetStream();

                    byte[] sendBytes = new byte[256];

                    sendBytes = Encoding.UTF8.GetBytes("Da Xoa Mot Mon");
                    Stream.Write(sendBytes, 0, sendBytes.Length);

                    tcpClient.Close();
                });
                sendThread.Start();

            }
            else
            {
                MessageBox.Show("Co Loi Khi Xoa Mon");
            }
        }

        private event EventHandler insertDrink;
        public event EventHandler InsertDrink
        {
            add { insertDrink += value; }
            remove { insertDrink += value; }
        }

        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood += value; }
        }

        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood += value; }
        }

        // Category Them Xoa Sua 

        private void bttnAddCategory_Click_1(object sender, EventArgs e)
        {
            string name = txtbCategoryName.Text;


            if (CategoryDAO.Instance.InsertCategory(name))
            {
                MessageBox.Show("Them Danh Muc Thanh Cong");
                LoadListCategory();

                Task sendThread = new Task(() =>
                {
                    TcpClient tcpClient = new TcpClient();

                    tcpClient.Connect(IPAddress.Parse("127.0.0.1"), 8080);

                    NetworkStream Stream = tcpClient.GetStream();

                    byte[] sendBytes = new byte[256];

                    sendBytes = Encoding.UTF8.GetBytes("Da Them Mot Category");
                    Stream.Write(sendBytes, 0, sendBytes.Length);

                    tcpClient.Close();
                });
                sendThread.Start();

            }
            else
            {
                MessageBox.Show("Co Loi Khi Them Danh Muc");
            }
        }

        private void bttnChangeCategory_Click(object sender, EventArgs e)
        {
            string name = txtbCategoryName.Text;
            int id = Convert.ToInt32(txtbCategoryID.Text);

            if (CategoryDAO.Instance.UpdateCategory(name, id))
            {
                MessageBox.Show("Sua Danh Muc Thanh Cong");
                LoadListCategory();

                Task sendThread = new Task(() =>
                {
                    TcpClient tcpClient = new TcpClient();

                    tcpClient.Connect(IPAddress.Parse("127.0.0.1"), 8080);

                    NetworkStream Stream = tcpClient.GetStream();

                    byte[] sendBytes = new byte[256];

                    sendBytes = Encoding.UTF8.GetBytes("Da Sua Mot Category");
                    Stream.Write(sendBytes, 0, sendBytes.Length);

                    tcpClient.Close();
                });
                sendThread.Start();

            }
            else
            {
                MessageBox.Show("Co Loi Khi Sua Danh Muc");
            }
        }

        private void bttnCategoryDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtbCategoryID.Text);

            if (CategoryDAO.Instance.DeleteCategory(id))
            {
                MessageBox.Show("Xoa Danh Muc Thanh Cong");
                LoadListCategory();

                Task sendThread = new Task(() =>
                {
                    TcpClient tcpClient = new TcpClient();

                    tcpClient.Connect(IPAddress.Parse("127.0.0.1"), 8080);

                    NetworkStream Stream = tcpClient.GetStream();

                    byte[] sendBytes = new byte[256];

                    sendBytes = Encoding.UTF8.GetBytes("Da Xoa Mot Category");
                    Stream.Write(sendBytes, 0, sendBytes.Length);

                    tcpClient.Close();
                });
                sendThread.Start();

            }
            else
            {
                MessageBox.Show("Co Loi Khi Xoa Danh Muc");
            }
        }
        #endregion


    }


    #endregion



}

