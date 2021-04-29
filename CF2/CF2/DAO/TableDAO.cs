﻿using CF2.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF2.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { TableDAO.instance = value; }
        }

        public static int TableHeight = 100;
        public static int TableWidth = 100;
        private TableDAO() { }

        public  List<Table>  LoadTableList()
        {
            List<Table> tableList = new List<Table>();

            DataTable data = DataProvider.Instace.ExcuteQuery(" USP_GetTableList");

            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tableList.Add(table);
            }

            return tableList;
        }

        public Table GetTypeTableByID(int id)
        {
            Table type = null;

            string query = "SELECT * FROM dbo.TableFood WHERE id = " + id;

            DataTable data = DataProvider.Instace.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                type = new Table(item);
                return type;
            }
            return type;
        }

       
    }
}
