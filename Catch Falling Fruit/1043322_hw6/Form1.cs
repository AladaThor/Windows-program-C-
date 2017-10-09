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

namespace _1043322_hw6
{
    public partial class Form1 : Form
    {
        Image xx;
        int sec = 121;
        int receveid = 0;
        Random rd = new Random();
        int a = 0, b = 0, c = 0;
        public Form1()
        {
            InitializeComponent();          
            pictureBox1.Image = Properties.Resources.Bowl;
            pictureBox2.Image = Properties.Resources.Banana;
            pictureBox3.Image = Properties.Resources.StawBerry;
            pictureBox4.Image = Properties.Resources.Tomato;
            a = rd.Next(panel3.Width);
            b = rd.Next(panel3.Width);
            c = rd.Next(panel3.Width);
        }
      /*  private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            mousePos = e.Location; // 記錄 滑鼠位置
            this.Invalidate(); // 要求更新表單
        }*/
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            float[][] cmArray2 =
               {
                  new float[] {1, 0, 0, 0, 0},
                  new float[] {0, 1, 0, 0, 0},
                  new float[] {0, 0, 1, 0, 0},
                  new float[] {0, 0, 0, 0.5f, 0},
                  new float[] {0, 0, 0, 0, 1}
               };
            ColorMatrix cm2 = new ColorMatrix(cmArray2);
            ImageAttributes ia2 = new ImageAttributes();
            ia2.SetColorMatrix(cm2, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            Rectangle rectDest = new Rectangle(0, 0, panel3.Width, panel3.Height);
            e.Graphics.DrawImage(xx, rectDest, 0, 0, xx.Width, xx.Height, GraphicsUnit.Pixel, ia2);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X;
            if (x < 0) { x = panel3.Location.X; }
            if (x > (panel3.Width - pictureBox1.Width)) { x = panel3.Width - pictureBox1.Width; }
            pictureBox1.Left = x;
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Left = (panel3.Width - pictureBox1.Width) / 2;
            pictureBox2.Top = -50;
            pictureBox3.Top = -50;
            pictureBox4.Top = -50;
            timer1.Interval = 1200;
            sec = 121;
            label3.Text = "120";
            receveid = 0;
            label4.Text = "0";
            timer1.Start();
            timer2.Start();
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {//-(pictureBox1.Width/2)
            int x = e.X;
            if (x < 0) { x = panel3.Location.X; }
            if (x > (panel3.Width - pictureBox1.Width)) { x = panel3.Width - pictureBox1.Width; }
            pictureBox1.Left = x;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1200;
            if (sec > 0 && timer1.Interval - 1 > 0)
                timer1.Interval--;
            sec--;
            label3.Text = sec.ToString();
            if (sec % 20 == 0)
            {
                xx = Properties.Resources._01;
                panel3.Invalidate();
            }
            else if (sec % 10 == 0)
            {
                xx = Properties.Resources._02;
                panel3.Invalidate();
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
            xx = Properties.Resources._01;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (sec == 0)
            {
                label3.Text = "Time's up!!!";
                pictureBox2.Top = -50;
                pictureBox3.Top = -50;
                pictureBox4.Top = -50;
                timer1.Stop();
                timer2.Stop();
            }
            else 
            {
                pictureBox2.Top += rd.Next(3, 9);
                pictureBox2.Left = a;
                pictureBox3.Top += rd.Next(4, 12);
                pictureBox3.Left = b;
                pictureBox4.Top += rd.Next(5, 15);
                pictureBox4.Left = c;
                if (pictureBox2.Bottom > pictureBox1.Top)
                {
                    if ((pictureBox2.Location.X >= pictureBox1.Location.X) && (pictureBox2.Right <= pictureBox1.Right)) { receveid++; label4.Text = receveid.ToString(); }
                    pictureBox2.Top = -50;
                    a = rd.Next(panel3.Width);
                    while ((a + pictureBox2.Width) > panel3.Width) { a = rd.Next(panel3.Width); }
                }
                if (pictureBox3.Bottom > pictureBox1.Top)
                {
                    if ((pictureBox3.Location.X >= pictureBox1.Location.X) && (pictureBox3.Right <= pictureBox1.Right)) { receveid++; label4.Text = receveid.ToString(); }
                    pictureBox3.Top = -50;
                    b = rd.Next(panel3.Width);
                    while ((b + pictureBox3.Width) > panel3.Width) { b = rd.Next(panel3.Width); }
                }
                if (pictureBox4.Bottom > pictureBox1.Top)
                {
                    if ((pictureBox4.Location.X >= pictureBox1.Location.X) && (pictureBox4.Right <= pictureBox1.Right)) { receveid++; label4.Text = receveid.ToString(); }
                    pictureBox4.Top = -50;
                    c = rd.Next(panel3.Width);
                    while ((c + pictureBox4.Width) > panel3.Width) { c = rd.Next(panel3.Width); }
                }
            }
        }
    }
}
