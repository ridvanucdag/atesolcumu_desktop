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

namespace atesolcumu
{

    public partial class AnaSayfa : Form
    {

        public AnaSayfa()
        {
            InitializeComponent();
            

        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-O6T38GN\SQLEXPRESS;Initial Catalog=atesolcer;Integrated Security=True");

        public void verilerigoster(string veriler)
        {

            SqlDataAdapter da = new SqlDataAdapter(veriler, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();

        }

        public void verilerigoster2(string veriler)
        {

            SqlDataAdapter da = new SqlDataAdapter(veriler, baglanti);
            DataSet dss = new DataSet();
            da.Fill(dss);

            dataGridView2.DataSource = dss.Tables[0];
            baglanti.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            textBox5.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            textBox6.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            textBox7.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            textBox8.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            comboBox1.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
        }
        
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "")
            {
                MessageBox.Show("Lütfen boş alan bırakmayın");
                
            }
            else
            {
                float derece = float.Parse(textBox3.Text);
                SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-O6T38GN\SQLEXPRESS;Initial Catalog=atesolcer;Integrated Security=True");
                baglanti.Open();
                SqlCommand cmd = new SqlCommand("Insert into derecekayit (adsoyad,derece,saat_tarih) values ('" + textBox2.Text + "', '" + derece + "','" + textBox9.Text + "')", baglanti);
                cmd.ExecuteReader();
                baglanti.Close();
                MessageBox.Show("Veri başarılı bir şekilde işlenmiştir");
                verilerigoster("Select * from atesderece");
            }
            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "" && textBox5.Text == "" && textBox6.Text == "" && textBox7.Text == "" && comboBox1.Text == "")
            {
                MessageBox.Show("Lütfen boş alan bırakmayın");

            }
            else
            {
                try
                {
                    SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-O6T38GN\SQLEXPRESS;Initial Catalog=atesolcer;Integrated Security=True");
                    baglanti.Open();

                    SqlCommand cmd = new SqlCommand("Insert into uyeler (ad,soyad,username,password,birim) values ('" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + comboBox1.Text + "')", baglanti);
                    cmd.ExecuteReader();
                    baglanti.Close();
                    MessageBox.Show("Kaydınız Başarılı bir şekilde oluşturuldu..");
                    verilerigoster2("Select * from uyeler");


                }
                catch (Exception)
                {

                    throw;
                }
            }
            
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-O6T38GN\SQLEXPRESS;Initial Catalog=atesolcer;Integrated Security=True");
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("UPDATE uyeler set ad='" + textBox5.Text + "', soyad='" + textBox6.Text + "',username='" + textBox7.Text + "',password='" + textBox8.Text + "',birim='" + comboBox1.Text + "' where id='" + textBox4.Text + "'", baglanti);
            cmd.ExecuteReader();
            baglanti.Close();
            verilerigoster2("Select * from uyeler");
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-O6T38GN\SQLEXPRESS;Initial Catalog=atesolcer;Integrated Security=True");
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("Delete from uyeler where id='" + textBox4.Text + "'", baglanti);
            cmd.ExecuteReader();
            baglanti.Close();
            verilerigoster2("Select * from uyeler");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" && textBox3.Text == "" && textBox9.Text == "" )
            {
                MessageBox.Show("Lütfen boş alan bırakmayın");

            }
            else
            {
                float derecee = float.Parse(textBox3.Text);
                SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-O6T38GN\SQLEXPRESS;Initial Catalog=atesolcer;Integrated Security=True");
                baglanti.Open();
                SqlCommand cmd = new SqlCommand("UPDATE derecekayit set adsoyad='" + textBox2.Text + "', derece='" + derecee + "', saat_tarih='"+ textBox9.Text + "' where id='" + textBox1.Text + "'", baglanti);
                cmd.ExecuteReader();
                baglanti.Close();
                verilerigoster("Select * from derecekayit ORDER BY id DESC");
            }

        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-O6T38GN\SQLEXPRESS;Initial Catalog=atesolcer;Integrated Security=True");
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("Delete from derecekayit where id='" + textBox1.Text + "'", baglanti);
            cmd.ExecuteReader();
            baglanti.Close();
            verilerigoster("Select * from derecekayit ORDER BY id DESC");
        }

        private void xtraTabPage1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            verilerigoster("Select * from derecekayit ORDER BY id DESC");
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            verilerigoster2("Select * from uyeler");
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))//rakam giriliyor metin girilemiyor
            {
                e.Handled = true;
            }
        }

        private void xtraTabPage3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            GirisEkrani frm = new GirisEkrani();
            frm.Show();
            this.Hide();

        }

        private void labelControl11_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            labelControl11.Text = dt.ToLongDateString()  +  dt.ToLongTimeString();
        }

        private void xtraTabPage3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        //private void datagridview3_Load(object sender, EventArgs e)
        //{



//}

private void simpleButton10_Click(object sender, EventArgs e)
        {
            try
            {
                label1.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
                label2.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
                float derece = float.Parse(label2.Text);
                SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-O6T38GN\SQLEXPRESS;Initial Catalog=atesolcer;Integrated Security=True");
                baglanti.Open();

                SqlCommand cmd = new SqlCommand("Insert into derecekayit (adsoyad,derece,saat_tarih) values ('" + label1.Text + "','" + derece + "','" + labelControl11.Text + "')", baglanti);
                cmd.ExecuteReader();
                baglanti.Close();
                //MessageBox.Show("Kaydınız Başarılı bir şekilde oluşturuldu..");
                dataGridView3.CurrentRow.Cells[1].Value = "";

            }
            catch (Exception)
            {

                MessageBox.Show("Kayıt eklenemedi...");
            }
        }

        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            dataGridView3.ColumnCount = 2;
            dataGridView3.Columns[0].Name = "Ad Soyad";
            dataGridView3.Columns[1].Name = "Derece";


            string[] row = new string[] { "Rıdvan ÜÇDAĞ", "" };
            dataGridView3.Rows.Add(row);
            row = new string[] { "Davut Emre ÖZER", "" };
            dataGridView3.Rows.Add(row);
            row = new string[] { "Abdullah Emre AĞCA", "" };
            dataGridView3.Rows.Add(row);
            row = new string[] { "Mehmet Enis ERTEM", "" };
            dataGridView3.Rows.Add(row);
            row = new string[] { "Fırat BOYAN", "" };
            dataGridView3.Rows.Add(row);
            row = new string[] { "Rıdvan ÜÇDAĞ", "" };
            dataGridView3.Rows.Add(row);
            row = new string[] { "Davut Emre ÖZER", "" };
            dataGridView3.Rows.Add(row);
            row = new string[] { "Abdullah Emre AĞCA", "" };
            dataGridView3.Rows.Add(row);
            row = new string[] { "Mehmet Enis ERTEM", "" };
            dataGridView3.Rows.Add(row);
            row = new string[] { "Fırat BOYAN", "" };
            dataGridView3.Rows.Add(row);
            row = new string[] { "Rıdvan ÜÇDAĞ", "" };
            dataGridView3.Rows.Add(row);
            row = new string[] { "Davut Emre ÖZER", "" };
            dataGridView3.Rows.Add(row);
            row = new string[] { "Abdullah Emre AĞCA", "" };
            dataGridView3.Rows.Add(row);
            row = new string[] { "Mehmet Enis ERTEM", "" };
            dataGridView3.Rows.Add(row);
            row = new string[] { "Fırat BOYAN", "" };
            dataGridView3.Rows.Add(row);
            row = new string[] { "Rıdvan ÜÇDAĞ", "" };
            dataGridView3.Rows.Add(row);
            row = new string[] { "Davut Emre ÖZER", "" };
            dataGridView3.Rows.Add(row);
            row = new string[] { "Abdullah Emre AĞCA", "" };
            dataGridView3.Rows.Add(row);
            row = new string[] { "Mehmet Enis ERTEM", "" };
            dataGridView3.Rows.Add(row);
            row = new string[] { "Fırat BOYAN", "" };
            dataGridView3.Rows.Add(row);
            row = new string[] { "Rıdvan ÜÇDAĞ", "" };
            dataGridView3.Rows.Add(row);
            row = new string[] { "Davut Emre ÖZER", "" };
            dataGridView3.Rows.Add(row);
            row = new string[] { "Abdullah Emre AĞCA", "" };
            dataGridView3.Rows.Add(row);
            row = new string[] { "Mehmet Enis ERTEM", "" };
            dataGridView3.Rows.Add(row);
            row = new string[] { "Fırat BOYAN", "" };
            dataGridView3.Rows.Add(row);

            //this.dataGridView1.Columns[0].Width = 40;

           
            // Datagridviewleri otomatik genişletmeye yarar

            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //datagridview içindeki Ad Soyad sütununa veri girmeyi engeller
            dataGridView3.Columns["Ad Soyad"].ReadOnly = true; 

        }

    }
}
