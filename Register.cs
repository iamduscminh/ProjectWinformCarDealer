using ProjectWinformCarDealer.Logics;
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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string GuestName = tbName.Text;
            string Phone = tbPhone.Text;
            string Email = tbEmail.Text;
            string Address = tbAddress.Text;
            string Title = tbTitle.Text;
            string Content = tbContent.Text;

            if (GuestName == "" || Phone == "" || Email == "" || Address == "")
            {
                MessageBox.Show("Fill all need information!");
            }
            else
            {
                Guest guest = new Guest();
                guest.FullName = GuestName;
                guest.Phone = Phone;
                guest.Email = Email;
                guest.Address = Address;
                guest.Title = Title;
                guest.Content = Content;
                guest.CreateDate = DateTime.Now;
                (new GuestLogic()).AddGuest(guest);
                MessageBox.Show("Register successfully, please wait our sale !");
                clearForm();
            }
        }
        private void clearForm()
        {
            foreach (var c in this.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Text = String.Empty;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FilterForm filterForm = new FilterForm();
            filterForm.Show();
        }

        private void btnGuest_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminUser adminUserForm = new AdminUser();
            adminUserForm.Show();
        }
    }
}
