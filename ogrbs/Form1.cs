using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ogrbs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        void formgetir(Form frm)//bu method yeni bir panel geldiği zaman ekrandaki paneli temizler ve yeni gelen formu kendisinin şeklinde hizalayıp gösterir.
        {
            panel2.Controls.Clear();
            frm.TopLevel = false;
            panel2.Controls.Add(frm);
            frm.Show();
            frm.Dock = DockStyle.Fill;
            frm.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            solpanel1.Height = button2.Height;
            solpanel1.Top = button2.Top;
            panel1.Visible = true;
            prg prg =new prg();
            formgetir(prg);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            solpanel1.Height = button3.Height;
            solpanel1.Top = button3.Top;
            panel1.Visible = true;
            devamsizlik devamsizlik = new devamsizlik();
            formgetir(devamsizlik);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            solpanel1.Height = button1.Height;
            solpanel1.Top = button1.Top;
            panel1.Visible = true;
            notlar notlar = new notlar();
            formgetir(notlar);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            giris cagir = new giris();
            cagir.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

      
    }
}
