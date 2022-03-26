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
    public partial class DetailForm : Form
    {
        public int CurrentCarId;
        public Car car;
        public DetailForm(int carId)
        {
            CurrentCarId = carId;
            InitializeComponent();
        }

        private void DetailForm_Load(object sender, EventArgs e)
        {
            using (var context = new ProjectWinformContext())
            {
                car = context.Cars.FirstOrDefault(c => c.CarId == CurrentCarId);
                pbBackground.Image = car.CarImage;
                pbDetail.Image = car.CarImage;
                lbCarName.Text = car.Name;
                lbCarPrice.Text = car.Price.ToString();
                lbAcceleration.Text = car.Acceleration;
                lbHeight.Text = "Height: " + car.Tall.ToString() + "mm";
                lbLength.Text = "Length: " + car.Wide.ToString() + "mm";

                tbWattage.Text = car.Wattage.ToString();
                tbPrice.Text = car.Price.ToString();
                tbMaxto.Text = car.MaximumTorque.ToString();
                tbCo2.Text = car.Co2Emissions;
                tbChair.Text = car.Chair.ToString();
                tbMaxSpeed.Text = car.MaxSpeed.ToString() + "km/h";
                tbAcceleration.Text = car.Acceleration.ToString();
                tbFuel.Text = car.Fuel.ToString();
            }

        }

        private void btnModels_Click(object sender, EventArgs e)
        {
            this.Hide();
            FilterForm filterForm = new FilterForm();
            filterForm.Show();
        }

        private void btnCompare_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            CompareForm compareForm = new CompareForm(CurrentCarId);
            compareForm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register registerForm = new Register();
            registerForm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register registerForm = new Register();
            registerForm.Show();
        }
    }
}
