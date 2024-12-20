﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HightLightRow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindDataGridView();
            SetAlternateRowColor();
        }

        public void BindDataGridView()
        {
            try
            {
                DataTable dtData = new DataTable();
                using (SqlConnection dbCon = new SqlConnection("Data Source=LITTLE-PARADISE;Initial Catalog=Debugonweb;User ID=radipu; Password=a"))
                {
                    using (SqlCommand cmdGetRecords = new SqlCommand("SELECT [EmployeeID],[EmployeeName],[Gender],[Address],[State],[City],[Status] FROM [dbo].[Employee]", dbCon))
                    {

                        if (dbCon.State == ConnectionState.Closed)
                        {
                            dbCon.Open();
                        }
                        using (SqlDataReader drGetData = cmdGetRecords.ExecuteReader())
                        {
                            dtData.Load(drGetData);
                        }
                        dataGridView1.DataSource = dtData;
                    }
                }
            }
            catch (Exception ex)
            {


            }
        } // database connection

        public void SetAlternateRowColor()
        {
            for (int iCount = 0; iCount < dataGridView1.Rows.Count - 1; iCount++)
            {
                if (Convert.ToString(dataGridView1.Rows[iCount].Cells[6].Value) == "InActive")
                    dataGridView1.Rows[iCount].DefaultCellStyle.BackColor = Color.Red;
                else
                    dataGridView1.Rows[iCount].DefaultCellStyle.BackColor = Color.GreenYellow;

            }
        }
    }
}
