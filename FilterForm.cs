using ProjectWinformCarDealer.Logics;
using ProjectWinformCarDealer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectWinformCarDealer
{
    public partial class FilterForm : Form
    {
        
        public FilterForm()
        {
            InitializeComponent();
        }

        private void FilterForm_Load(object sender, EventArgs e)
        {
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
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("discol"))//bam vao cot edit
            {
                int id = (int) dataGridView1.Rows[e.RowIndex].Cells["CarId"].Value;
                DetailForm detailform = new DetailForm(id);
                
                this.Hide();
                detailform.Show();

            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("comcol"))
            {
                int id = (int)dataGridView1.Rows[e.RowIndex].Cells["CarId"].Value;
                CompareForm compareform = new CompareForm(id);

                this.Hide();
                compareform.Show();

            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            lbPriceValue.Text = trackBar1.Value.ToString()+",000,000,000VND";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string strModel = "", strDesign ="", strChair="";
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
                var CarList = context.Cars.Where(c=>
                (strModel == "" || strModel.Contains(c.Model))
                && (strChair == "" || strChair.Contains(c.Chair))
                && (strDesign == "" || strDesign.Contains(c.Design))
                && ((c.Price/1000000000) >= trackBar1.Value)
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

        private void btnGuest_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminUser adminUserForm = new AdminUser();
            adminUserForm.Show();
        }

        private void btnAdminCar_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminCar adminCarForm = new AdminCar();
            adminCarForm.Show();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register registerForm = new Register();
            registerForm.Show();
        }
    }
}
