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
    public partial class AdminCar : Form
    {
        List<Car> cars;
        Car CurrentCar = null;
        public AdminCar()
        {
            InitializeComponent();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            FilterForm filterForm = new FilterForm();
            filterForm.Show();
        }

        private void AdminCar_Load(object sender, EventArgs e)
        {
            cars = (new CarLogic()).getAllCar();
            dataGridView1.DataSource = cars;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CurrentCar = cars[e.RowIndex];
            tbCarName.Text = CurrentCar.Name;
            tbCarPrice.Text = CurrentCar.Price.ToString();
            tbCarWattage.Text = CurrentCar.Wattage.ToString();
            tbCo2.Text = CurrentCar.Co2Emissions.ToString();
            tbMaxSpeed.Text = CurrentCar.MaxSpeed.ToString() + "km/h";
            tbFuel.Text = CurrentCar.Fuel.ToString() + "mm";   
            tbLong.Text = CurrentCar.Long.ToString() + "mm";
            tbWide.Text = CurrentCar.Wide.ToString() + "mm";
            tbWheelbase.Text = CurrentCar.Wheelbase.ToString() + "mm";
            tbTall.Text = CurrentCar.Tall.ToString();   
            tbAcceleration.Text = CurrentCar.Acceleration.ToString();
            tbMaxto.Text = CurrentCar.MaximumTorque.ToString() + "Nm";
            pbCarImage.Image = CurrentCar.CarImage;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddCarForm addform = new AddCarForm();
            addform.FormClosed += AddCarForm_FormClosed;
            addform.Show();
        }
        private void AddCarForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            cars = (new CarLogic()).getAllCar();
            dataGridView1.DataSource = cars;
        }
        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CurrentCar == null) MessageBox.Show("Please choose a car!");
            else {
                UpdateCarForm updateForm = new UpdateCarForm(CurrentCar);
                updateForm.FormClosed += UpdateCarForm_FormClosed;
                updateForm.Show(); 
            }
        }
        private void UpdateCarForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            cars = (new CarLogic()).getAllCar();
            dataGridView1.DataSource = cars;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (CurrentCar == null) MessageBox.Show("Please choose a car!");
            else
            {
                int delete = (new CarLogic()).deleteCar(CurrentCar.CarId);
                if(delete > 0)
                {
                    MessageBox.Show("Delete car sucessfully!");
                }else
                {
                    MessageBox.Show("Delete car faild!");
                }
            }
            cars = (new CarLogic()).getAllCar();
            dataGridView1.DataSource = cars;
        }
    }
}
