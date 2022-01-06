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

namespace Article04
{
    public partial class CustomerGUI : Form
    {
        CustomerBAL cusBAL = new CustomerBAL();
        public CustomerGUI()
        {
            InitializeComponent();
        }
        private void CustomerGUI_Load(object sender, EventArgs e)
        {
            List<CustomerBEL> lstCus = cusBAL.ReadCustomer();
            foreach (CustomerBEL cus in lstCus)
            {
                dataGridView1.Rows.Add(cus.Id, cus.Name, cus.AreaName);
            }
        }
        private void btAdd_Click(object sender, EventArgs e)
        {
            if (tbId.Text != "" && tbName.Text != "")
            {
                try
                {
                    int ma = Convert.ToInt32(tbId.Text);
                    CustomerBEL cus = new CustomerBEL();
                    cus.Id = int.Parse(tbId.Text);
                    cus.Name = tbName.Text;
                    cusBAL.AddCustomer(cus);
                    dataGridView1.Rows.Add(cus.Id, cus.Name);
                }
                catch (Exception)
                {
                    MessageBox.Show("Nhập số cho (Mã) sinh viên");
                }
            }
            else
                MessageBox.Show("Nhập đầy đủ tt sinh viên");
        }
        private void btDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xoá", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CustomerBEL cus = new CustomerBEL();
                cus.Id = int.Parse(tbId.Text);
                cus.Name = tbName.Text;

                cusBAL.DeleteCustomer(cus);
                int idx = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.Rows.RemoveAt(idx);
            }
        }
        private void btEdit_Click(object sender, EventArgs e)
        {
            CustomerBEL cus = new CustomerBEL();
            cus.Id = int.Parse(tbId.Text);
            cus.Name = tbName.Text;
            cusBAL.EditCustomer(cus);
            DataGridViewRow row = dataGridView1.CurrentRow;
            row.Cells[0].Value = cus.Id;
            row.Cells[1].Value = cus.Name;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            tbId.Text = dataGridView1.Rows[idx].Cells[0].Value.ToString();
            tbName.Text = dataGridView1.Rows[idx].Cells[1].Value.ToString();

        }
        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}