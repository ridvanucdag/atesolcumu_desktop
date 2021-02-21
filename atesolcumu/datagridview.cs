using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.Utils.Extensions;

namespace atesolcumu
{
    public partial class datagridview : Form
    {
        public datagridview()
        {
            InitializeComponent();
        }
        //int i;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //label1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            //label2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            
        }

        private void datagridview_Load(object sender, EventArgs e)
        {

            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "Ad Soyad";
            dataGridView1.Columns[1].Name = "Derece";
            

            string[] row = new string[] { "Rıdvan ÜÇDAĞ", "" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "Davut Emre ÖZER", "" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "Abdullah Emre AĞCA", "" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "Mehmet Enis ERTEM", "" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "Fırat BOYAN", "" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "Rıdvan ÜÇDAĞ", "" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "Davut Emre ÖZER", "" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "Abdullah Emre AĞCA", "" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "Mehmet Enis ERTEM", "" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "Fırat BOYAN", "" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "Rıdvan ÜÇDAĞ", "" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "Davut Emre ÖZER", "" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "Abdullah Emre AĞCA", "" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "Mehmet Enis ERTEM", "" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "Fırat BOYAN", "" };
            dataGridView1.Rows.Add(row);
            //i = dataGridView1.Rows.Add();
            //i = 0;
            //dataGridView1.Rows[i].Cells[0].Value = "Rıdvan ÜÇDAĞ";
            //i = 1;
            //dataGridView1.Rows[i].Cells[0].Value = "Davut Emre ÖZER";
            //i = 2;
            //dataGridView1.Rows[i].Cells[0, 3].Value = "Abdullah Emre AĞCA";
            //i = 3;
            //dataGridView1.Rows[i].Cells[0].Value = "Mehmet Enis ERTEM";
            //i = 4;
            //dataGridView1.Rows[i].Cells[0].Value = "Fırat BOYAN";
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            label3.Text = dt.ToLongDateString() + dt.ToLongTimeString();
        }

        //public void verilerigetir (string veriler)
        //{

        //    dataGridView1.ColumnCount = 2;
        //    dataGridView1.Columns[0].Name = "Ad Soyad";
        //    dataGridView1.Columns[1].Name = "Derece";


        //    string[] row = new string[] { "Rıdvan ÜÇDAĞ", "" };
        //    dataGridView1.Rows.Add(row);
        //    row = new string[] { "Davut Emre ÖZER", "" };
        //    dataGridView1.Rows.Add(row);
        //    row = new string[] { "Abdullah Emre AĞCA", "" };
        //    dataGridView1.Rows.Add(row);
        //    row = new string[] { "Mehmet Enis ERTEM", "" };
        //    dataGridView1.Rows.Add(row);
        //    row = new string[] { "Fırat BOYAN", "" };
        //    dataGridView1.Rows.Add(row);
        //    row = new string[] { "Rıdvan ÜÇDAĞ", "" };
        //    dataGridView1.Rows.Add(row);
        //    row = new string[] { "Davut Emre ÖZER", "" };
        //    dataGridView1.Rows.Add(row);
        //    row = new string[] { "Abdullah Emre AĞCA", "" };
        //    dataGridView1.Rows.Add(row);
        //    row = new string[] { "Mehmet Enis ERTEM", "" };
        //    dataGridView1.Rows.Add(row);
        //    row = new string[] { "Fırat BOYAN", "" };
        //    dataGridView1.Rows.Add(row);
        //    row = new string[] { "Rıdvan ÜÇDAĞ", "" };
        //    dataGridView1.Rows.Add(row);
        //    row = new string[] { "Davut Emre ÖZER", "" };
        //    dataGridView1.Rows.Add(row);
        //    row = new string[] { "Abdullah Emre AĞCA", "" };
        //    dataGridView1.Rows.Add(row);
        //    row = new string[] { "Mehmet Enis ERTEM", "" };
        //    dataGridView1.Rows.Add(row);
        //    row = new string[] { "Fırat BOYAN", "" };
        //    dataGridView1.Rows.Add(row);

        //}
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                label1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                label2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                float derece = float.Parse(label2.Text);
                SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-O6T38GN\SQLEXPRESS;Initial Catalog=atesolcer;Integrated Security=True");
                baglanti.Open();

                SqlCommand cmd = new SqlCommand("Insert into derecekayit (adsoyad,derece,saat_tarih) values ('" + label1.Text + "','" + label2.Text + "','" + label3.Text + "')", baglanti);
                cmd.ExecuteReader();
                baglanti.Close();
                //MessageBox.Show("Kaydınız Başarılı bir şekilde oluşturuldu..");
                dataGridView1.CurrentRow.Cells[1].Value = "";

            }
            catch (Exception)
            {

                MessageBox.Show("Kayıt eklenemedi");
            }

            

            //SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-O6T38GN\SQLEXPRESS;Initial Catalog=atesolcer;Integrated Security=True");
            //baglanti.Open();
            //float derece = float.Parse(label2.Text);
            //SqlCommand cmd = new SqlCommand("Insert into derecekayit (adsoyad,derece,saat_tarih) values ('" + label1.Text + "','" + label2.Text + "','" + label3.Text + "')", baglanti);
            //cmd.ExecuteReader();
            //baglanti.Close();
            //MessageBox.Show("Veri başarılı bir şekilde işlenmiştir");

        }


    }
}
