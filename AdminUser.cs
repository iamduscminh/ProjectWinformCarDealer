using ProjectWinformCarDealer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectWinformCarDealer
{
    public partial class AdminUser : Form
    {
        public AdminUser()
        {
            InitializeComponent();
        }

        private void AdminUser_Load(object sender, EventArgs e)
        {
            using (var context = new ProjectWinformContext())
            {
                var GuestList = context.Guests.Select(c => new
                {
                   FullName = c.FullName,
                   Phone = c.Phone,
                   Email = c.Email,
                   Address = c.Address,
                   Title = c.Title,
                   Content = c.Content,
                   TimeRegister = c.CreateDate

                }).OrderByDescending(x=>x.TimeRegister).ToList();
                dataGridView1.DataSource = GuestList;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbAddress.Text = dataGridView1.Rows[e.RowIndex].Cells["Address"].Value.ToString();
            tbName.Text = dataGridView1.Rows[e.RowIndex].Cells["FullName"].Value.ToString();
            tbEmail.Text = dataGridView1.Rows[e.RowIndex].Cells["Email"].Value.ToString();
            tbPhone.Text = dataGridView1.Rows[e.RowIndex].Cells["Phone"].Value.ToString();
            tbTitle.Text = dataGridView1.Rows[e.RowIndex].Cells["Title"].Value.ToString();
            rtbContent.Text = dataGridView1.Rows[e.RowIndex].Cells["Content"].Value.ToString(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tbAddress.Clear();
            tbName.Clear();
            tbEmail.Clear();
            tbPhone.Clear();
            tbTitle.Clear();
            rtbContent.Clear();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            FilterForm filterForm = new FilterForm();
            filterForm.Show();
        }
    }
}
