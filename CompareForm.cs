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
    public partial class CompareForm : Form
    {
        public int CurrentCarId;
        public Car car1, car2, car3;
        public int position;
        public CompareForm(int carId)
        {
            CurrentCarId = carId;
            InitializeComponent();
        }

        private void CompareForm_Load(object sender, EventArgs e)
        {

            car1 = (new CarLogic()).getCarById(CurrentCarId);
            pictureBox1.Image = car1.CarImage;
            lbCarName1.Text = car1.Name;

            tbCarPrice1.Text = car1.Price.ToString();
            tbAccleration1.Text = car1.Acceleration;
            tbHeight1.Text = car1.Tall.ToString() + "mm";
            tbLong1.Text = car1.Long.ToString() + "mm";
            tbWide1.Text = car1.Wide.ToString() + "mm";
            tbWheelbase1.Text = car1.Wheelbase.ToString();
            tbCarWattage1.Text = car1.Wattage.ToString();
            tbMaxto1.Text = car1.MaximumTorque.ToString();
            tbCo21.Text = car1.Co2Emissions;
            tbMaxSpeed1.Text = car1.MaxSpeed.ToString() + "km/h";
            tbFuel1.Text = car1.Fuel.ToString();

            LoadDataForDataGridView();
            FormatDataGridView();


        }
        private void FormatDataGridView()
        {
            dataGridView1.AutoGenerateColumns = true;
            //dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //dataGridView1.co = DataGridViewImageCellLayout.Zoom;
            dataGridView1.Columns["CarName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DataGridViewButtonColumn discol = new DataGridViewButtonColumn();
            discol.Name = "discol";
            discol.HeaderText = "Discovery the Car";
            discol.Text = "Discovery";
            discol.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn comcol = new DataGridViewButtonColumn();
            comcol.Name = "comcol";
            comcol.HeaderText = "Compare the Car";
            comcol.Text = "Compare";
            comcol.UseColumnTextForButtonValue = true;

            dataGridView1.Columns.Add(discol);
            dataGridView1.Columns.Add(comcol);
        }

        private void LoadDataForDataGridView()
        {
            using (var context = new ProjectWinformContext())
            {
                var CarList = context.Cars.Select(c => new
                {
                    CarId = c.CarId,
                    CarName = c.Name,
                    CarPrice = c.Price,
                    CarImages = c.CarImage,
                }).ToList();
                dataGridView1.DataSource = CarList;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string strModel = "", strDesign = "", strChair = "";
            for (int i = 0; i < clbModel.Items.Count; i++)
            {
                if (clbModel.GetItemChecked(i))
                {
                    strModel += (string)clbModel.Items[i];

                }
            }
            for (int i = 0; i < clbDesign.Items.Count; i++)
            {
                if (clbDesign.GetItemChecked(i))
                {
                    strDesign += (string)clbDesign.Items[i];

                }
            }
            for (int i = 0; i < clbChair.Items.Count; i++)
            {
                if (clbChair.GetItemChecked(i))
                {
                    strChair += (string)clbChair.Items[i];

                }
            }
            using (var context = new ProjectWinformContext())
            {
                var CarList = context.Cars.Where(c =>
                (strModel == "" || strModel.Contains(c.Model))
                && (strChair == "" || strChair.Contains(c.Chair))
                && (strDesign == "" || strDesign.Contains(c.Design))
                && ((c.Price / 1000000000) >= trackBar1.Value)
                ).Select(c => new
                {
                    CarId = c.CarId,
                    CarName = c.Name,
                    CarPrice = c.Price,
                    CarImages = c.CarImage,
                }).ToList();
                dataGridView1.DataSource = CarList;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            lbPriceValue.Text = trackBar1.Value.ToString() + ",000,000,000VND";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FilterForm filterForm = new FilterForm();
            filterForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register registerForm = new Register();
            registerForm.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("discol"))//bam vao cot edit
            {
                int id = (int)dataGridView1.Rows[e.RowIndex].Cells["CarId"].Value;
                DetailForm detailform = new DetailForm(id);

                this.Hide();
                detailform.Show();

            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("comcol"))
            {
                int id = (int)dataGridView1.Rows[e.RowIndex].Cells["CarId"].Value;
                AddModeltoCompare(id);
            }
        }
        private void AddModeltoCompare(int carId)
        {
            if (carId == CurrentCarId) return;
            if (position % 2 == 0)
            {
                car2 = (new CarLogic()).getCarById(carId);
                pictureBox2.Image = car2.CarImage;
                lbCarName2.Text = car2.Name;

                tbCarPrice2.Text = car2.Price.ToString();
                tbAccleration2.Text = car2.Acceleration;
                tbHeight2.Text = car2.Tall.ToString() + "mm";
                tbLong2.Text = car2.Long.ToString() + "mm";
                tbWide2.Text = car2.Wide.ToString() + "mm";
                tbWheelbase2.Text = car2.Wheelbase.ToString();
                tbCarWattage2.Text = car2.Wattage.ToString();
                tbMaxto2.Text = car2.MaximumTorque.ToString();
                tbCo22.Text = car2.Co2Emissions;
                tbMaxSpeed2.Text = car2.MaxSpeed.ToString() + "km/h";
                tbFuel2.Text = car2.Fuel.ToString();

                position++;
            }
            else if (position % 2 != 0)
            {
                car3 = (new CarLogic()).getCarById(carId);
                pictureBox3.Image = car3.CarImage;
                lbCarName3.Text = car3.Name;

                tbCarPrice3.Text = car3.Price.ToString();
                tbAccleration3.Text = car3.Acceleration;
                tbHeight3.Text = car3.Tall.ToString() + "mm";
                tbLong3.Text = car3.Long.ToString() + "mm";
                tbWide3.Text = car3.Wide.ToString() + "mm";
                tbWheelbase3.Text = car3.Wheelbase.ToString();
                tbCarWattage3.Text = car3.Wattage.ToString();
                tbMaxto3.Text = car3.MaximumTorque.ToString();
                tbCo23.Text = car3.Co2Emissions;
                tbMaxSpeed3.Text = car3.MaxSpeed.ToString() + "km/h";
                tbFuel3.Text = car3.Fuel.ToString();

                position++;
            }
        }
    }
}
