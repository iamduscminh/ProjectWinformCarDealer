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
    public partial class UpdateCarForm : Form
    {
        Car curCar;
        public UpdateCarForm(Car car)
        {
            curCar = car;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnUpdateCar_Click(object sender, EventArgs e)
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
                    cr.CarId = curCar.CarId;
                    cr.Name = tbCarName.Text;
                    cr.Model = tbModel.Text;
                    cr.Design = tbDesign.Text;
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

                    int upadte = (new CarLogic()).updateCar(cr);
                    if (upadte > 0)
                    {
                        MessageBox.Show("Update Successfully.");
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("Update Fail.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void UpdateCarForm_Load(object sender, EventArgs e)
        {
            tbCarName.Text = curCar.Name;
            tbModel.Text = curCar.Model;
            tbDesign.Text = curCar.Design;
            tbChair.Text = curCar.Chair;
            tbCarPrice.Text = curCar.Price.ToString();
            tbCarWattage.Text = curCar.Wattage.ToString();
            tbMaxto.Text =curCar.MaximumTorque.ToString();
            tbAcceleration.Text = curCar.Acceleration.ToString();
            tbMaxSpeed.Text = curCar.MaxSpeed.ToString();
            tbFuel.Text = curCar.Fuel.ToString();
            tbCo2.Text = curCar.Co2Emissions.ToString();
            tbTall.Text = curCar.Tall.ToString();
            tbWide.Text = curCar.Wide.ToString();
            tbLong.Text = curCar.Long.ToString();
            tbWheelbase.Text = curCar.Wheelbase.ToString();
            tbCarImage.Text = curCar.ImageLink.ToString();
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
        
    }
}
