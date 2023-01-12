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
    public partial class devamsizlik : Form
    {
        public devamsizlik()
        {
            InitializeComponent();
        }
       
        SqlCommand cmd;
        SqlDataReader dr;
        SqlConnection conn = new SqlConnection("server=.; Initial Catalog=ogrbs; Integrated Security=SSPI");
        void listeleme()//bu method veri tabanındaki oyunları çeker.
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from dvmsz", conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "dvmsz");
            dataGridView1.DataSource = ds.Tables["dvmsz"];
            conn.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            panel6.Visible = true;
        }

      

        private void button2_Click(object sender, EventArgs e)
        {
          listeleme();
            button3.Visible=true;
            button1.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection("server=.; Initial Catalog=ogrbs; Integrated Security=SSPI");
            cmd = new SqlCommand();
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Lütfen Boşluk Bırakmayınız !");
            }
            else
            {
                
                string sorgu = "Insert into dvmsz(ders_ismi,tarih)" +
              "values (@ders_ismi,@tarih)";
                SqlCommand komut = new SqlCommand(sorgu, conn);
                komut.Parameters.AddWithValue("@ders_ismi", textBox1.Text);
                komut.Parameters.AddWithValue("@tarih", textBox2.Text);
                conn.Open();
                komut.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Eklenmiştir");
                textBox1.Text = "";
                textBox2.Text = "";
               

            }
            listeleme();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "Delete from dvmsz Where ders_ismi=@ders_ismi";
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
