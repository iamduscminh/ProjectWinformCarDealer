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
    public partial class AddCarForm : Form
    {
        public AddCarForm()
        {
            InitializeComponent();
        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {
            bool allfieldsempty = true;

            foreach (Control c in this.Controls)
            {

                if (this.Controls.OfType<TextBox>().Any(t => string.IsNullOrEmpty(t.Text)))
                {
                    allfieldsempty = false;
                    break;
                }
            }

            if (allfieldsempty == false)
            {
                MessageBox.Show("Please enter all the field");

            }
            else
            {
                try
                {
                    Car cr = new Car();
                    cr.Name = tbCarName.Text;
                    cr.Model = tbModel.Text;
                    cr.Design = tbDesign.Text;
                    int val;
                    if (!int.TryParse(tbChair.Text, out val))
                    {
                        throw new Exception("Chair must be a number!");
                    }
                    cr.Chair = tbChair.Text;
                    cr.Price = Convert.ToInt64(tbCarPrice.Text);
                    cr.Wattage = Convert.ToInt32(tbCarWattage.Text);
                    cr.MaximumTorque = Convert.ToInt32(tbMaxto.Text);
                    cr.Acceleration = tbAcceleration.Text;
                    cr.MaxSpeed = Convert.ToInt32(tbMaxSpeed.Text);
                    cr.Fuel = tbFuel.Text;
                    cr.Co2Emissions = tbCo2.Text;
                    cr.Tall = Convert.ToInt32(tbTall.Text);
                    cr.Wide = Convert.ToInt32(tbWide.Text);
                    cr.Long = Convert.ToInt32(tbLong.Text);
                    cr.Wheelbase = Convert.ToInt32(tbWheelbase.Text);
                    cr.ImageLink = tbCarImage.Text;

                    int add = (new CarLogic()).addCar(cr);
                    if (add > 0)
                    {
                        MessageBox.Show("Add Successfully.");
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("Add Fail.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }



        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clear();
        }
        private void clear()
        {
            foreach (var c in this.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Text = String.Empty;
                }
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
