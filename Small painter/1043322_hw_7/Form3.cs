using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace _1043322_hw_7
{
    public partial class Form3 : Form
    {
        float r1, g1, b1, a1;
        public Form3()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            r1 = (float)trackBar1.Value / 10;
            g1 = (float)trackBar2.Value / 10;
            b1 = (float)trackBar3.Value / 10;
            a1 = (float)trackBar4.Value / 10;
            this.Close();
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label5.Text = trackBar1.Value.ToString();
            this.Invalidate();
        }
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label6.Text = trackBar2.Value.ToString();
            this.Invalidate();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            label7.Text = trackBar3.Value.ToString();
            this.Invalidate();
        }
        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            label8.Text = trackBar4.Value.ToString();
            this.Invalidate();
        }
        public float getr1()
        {
            return r1;
        }
        public float getg1()
        {
            return g1;
        }
        public float getb1()
        {
            return b1;
        }
        public float geta1()
        {
            return a1;
        }
    }
}
