using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ogrbs
{
    public partial class notlar : Form
    {
        public notlar()
        {
            InitializeComponent();
        }
        SqlCommand cmd;
        SqlDataReader dr;
        SqlConnection conn = new SqlConnection("server=.; Initial Catalog=ogrbs; Integrated Security=SSPI");
        void listeleme()//bu method veri tabanındaki oyunları çeker.
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from notlar", conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "notlar");
            dataGridView1.DataSource = ds.Tables["notlar"];
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listeleme();
            button1.Visible = true;
            button3.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel6.Visible = true;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection("server=.; Initial Catalog=ogrbs; Integrated Security=SSPI");
            cmd = new SqlCommand();
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Lütfen Boşluk Bırakmayınız !");
            }
            else
            {

                string sorgu = "Insert into notlar(ders_ismi,vize,final)" +
              "values (@ders_ismi,@vize,@final)";
                SqlCommand komut = new SqlCommand(sorgu, conn);
                komut.Parameters.AddWithValue("@ders_ismi", textBox1.Text);
                komut.Parameters.AddWithValue("@vize", textBox2.Text);
                komut.Parameters.AddWithValue("@final", textBox3.Text);
                conn.Open();
                komut.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Eklenmiştir");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
            listeleme();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "Delete from notlar Where ders_ismi=@ders_ismi";
            SqlCommand komut = new SqlCommand(sorgu, conn);
            komut.Parameters.AddWithValue("@ders_ismi", dataGridView1.CurrentRow.Cells[0].Value.ToString());
            conn.Open();
            komut.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Başarıyla Silinmiştir");
            listeleme();
        }
    }
}
