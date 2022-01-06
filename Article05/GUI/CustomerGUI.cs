using Article05.BAL;
using Article05.BEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Article05
{
    public partial class CustomerGUI : Form
    {
        CustomerBAL cusBAL = new CustomerBAL();
        AreaBAL areBAL = new AreaBAL();
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
            List<AreaBEL> lstArea = areBAL.ReadAreaList();
            foreach (AreaBEL area in lstArea)
            {
                cbArea.Items.Add(area);
            }
            cbArea.DisplayMember = "name";
        }
        private void btAdd_Click(object sender, EventArgs e)
        {
            if (tbId.Text != "" && tbName.Text != "" && cbArea.Text != "")
            {
                try
                {
                    int ma = Convert.ToInt32(tbId.Text);
                    CustomerBEL cus = new CustomerBEL();
                    cus.Id = int.Parse(tbId.Text);
                    cus.Name = tbName.Text;
                    cus.Area = (AreaBEL)cbArea.SelectedItem;
                    cusBAL.AddCustomer(cus);
                    dataGridView1.Rows.Add(cus.Id, cus.Name, cus.Area.Name);
                }
                catch (Exception)
                {
                    MessageBox.Show("Nhập số cho (Mã) nhân viên");
                }
            }
            else
                MessageBox.Show("Nhập đầy đủ thông tin nhân viên");
        }
        private void btEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            if (row != null)
            {
                CustomerBEL cus = new CustomerBEL();
                cus.Id = int.Parse(tbId.Text);
                cus.Name = tbName.Text;
                cus.Area = (AreaBEL)cbArea.SelectedItem;
                cusBAL.EditCustomer(cus);

                row.Cells[0].Value = cus.Id;
                row.Cells[1].Value = cus.Name;
                row.Cells[2].Value = cus.AreaName;
            }
            else
                MessageBox.Show("Chọn nhân viên cần sửa");
        }
        private void btDelete_Click(object sender, EventArgs e)
        {

            if (tbId.Text == "" && tbName.Text == "" && cbArea.Text == "")
            {
                MessageBox.Show("Chọn nhân viên cần xoá");
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn xoá", "Thông báo",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CustomerBEL cus = new CustomerBEL();
                    cus.Id = int.Parse(tbId.Text);
                    cus.Name = tbName.Text;
                    cus.Area = (AreaBEL)cbArea.SelectedItem;

                    cusBAL.DeleteCustomer(cus);
                    int idx = dataGridView1.CurrentCell.RowIndex;
                    dataGridView1.Rows.RemoveAt(idx);
                }
            }
        }
        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[idx];
            if (row.Cells[0].Value != null)
            {
                tbId.Text = row.Cells[0].Value.ToString();
                tbName.Text = row.Cells[1].Value.ToString();
                cbArea.Text = row.Cells[2].Value.ToString();
            }
        }
    }
}