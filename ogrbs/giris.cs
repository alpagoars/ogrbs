using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Forms.Application;
using System.Reflection.Emit;

namespace ogrbs
{
    public partial class giris : Form
    {
        public giris()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        private void giris_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            conn = new SqlConnection("server=.; Initial Catalog=ogrbs; Integrated Security=SSPI");
            cmd = new SqlCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = ("Select * From ogr where adi='" + textBox1.Text + "' And parola='" + textBox2.Text + "'");
            dr = cmd.ExecuteReader();


            if (dr.Read())
            {
                MessageBox.Show("giriş başarılı");

                Form1 Form1 = (Form1)Application.OpenForms["Form1"];
                Form1.pictureBox2.ImageLocation = "./profil/" + textBox1.Text + ".jpg";

                Form1.panel3.Show();
                Form1.panel3.BringToFront();

                Form1.button5.Hide();
                this.Close();
                
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı Ya da Şifre Hatalı.");
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection("server=.; Initial Catalog=ogrbs; Integrated Security=SSPI");
            cmd = new SqlCommand();
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Lüfen Boşluk Bırakmayınız !");
            }
            else
            {
                conn.Open();
                string sorgu = "Insert into ogr(adi,parola)" +
              "values (@adi,@parola)";//kullanıcı adı ve şifre girilen verilere göre veri tabanına eklendi.
                SqlCommand komut = new SqlCommand(sorgu, conn);
                komut.Parameters.AddWithValue("@adi", textBox1.Text);
                komut.Parameters.AddWithValue("@parola", textBox2.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("Kayıtınız Oluşturulmuştur.");
                Form1 Form1 = new Form1();
                Form1.ShowDialog();
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
