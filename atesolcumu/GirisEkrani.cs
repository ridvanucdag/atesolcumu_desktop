using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace atesolcumu
{
    
    public partial class GirisEkrani : DevExpress.XtraEditors.XtraForm
    {
        public GirisEkrani()
        {
            InitializeComponent();
        }

        

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text=="")
            {
                MessageBox.Show("Lütfen boş alan bırakmayın");
            }
            else
            {
                SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-O6T38GN\SQLEXPRESS;Initial Catalog=atesolcer;Integrated Security=True");
                baglanti.Open();

                SqlCommand cmd = new SqlCommand("Select * from uyeler where username='" + textBox1.Text.Trim() + "' and password='" + textBox2.Text.Trim() + "'", baglanti);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    MessageBox.Show("Başarılı bir şekilde giriş yaptınız.Yönlendirileceksiniz..");
                    AnaSayfa frm = new AnaSayfa();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Hatalı Giriş Yaptınız. Tekrar deneyiniz");
                }
                baglanti.Close();
            }

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
