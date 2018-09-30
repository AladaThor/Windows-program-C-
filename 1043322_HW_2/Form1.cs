using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1043322_HW_2
{
    public partial class Form1 : Form
    {
        Rectangle[] rectangle = new Rectangle[9];
        Random num = new Random();
        int[] table = new int[9];

        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < 9; ++i)
            {
                rectangle[i].Height = 60;
                rectangle[i].Width = 60;
                rectangle[i].X = i % 3 * 60;
                rectangle[i].Y = i / 3 * 60 + 30;

                table[i] = 0;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);

            for (int n = 0; n < 9; ++n)
            {
                if (table[n] == 1)
                {
                    e.Graphics.DrawEllipse(new Pen(Color.Blue, 3), rectangle[n].X + 8, rectangle[n].Y + 8, 45, 45);
                }
                else if (table[n] > 1)
                {
                    e.Graphics.DrawLine(new Pen(Color.Blue, 3), rectangle[n].X + 15, rectangle[n].Y + 15, rectangle[n].X + 45, rectangle[n].Y + 45);
                    e.Graphics.DrawLine(new Pen(Color.Blue, 3), rectangle[n].X + 45, rectangle[n].Y + 15, rectangle[n].X + 15, rectangle[n].Y + 45);
                }
            }
            e.Graphics.DrawRectangles(new Pen(Color.Black, 5), rectangle);
        }

        private void Computer_Move()
        {
            for (int i = 0; i < 9; ++i)
                if (table[i] == 0)
                {
                    table[i] = 2;
                    Form1_Paint(new object(), new PaintEventArgs(this.CreateGraphics(), rectangle[i]));
                    break;
                }
        }

        private bool over(Graphics g)
        {
            for (int i = 0; i < 3; ++i)
            {
                // 一行一行判斷
                if (table[i * 3 + 0] > 0 && table[i * 3 + 0] == table[i * 3 + 1] && table[i * 3 + 2] == table[i * 3 + 0])
                {
                    if (table[i * 3 + 0] > 1) label1.Text = "You Lose!";
                    else label1.Text = "You Win!";

                        Form1_Paint(new object(), new PaintEventArgs(this.CreateGraphics(), rectangle[i]));

                    g.DrawLine(new Pen(Color.Red, 4), new Point(rectangle[i * 3].X + 10, rectangle[i * 3].Y + 30), new Point(rectangle[i * 3 + 2].X + 48, rectangle[i * 3 + 2].Y + 30));
                    return true;
                }

                // 一列一列判斷
                if (table[0 + i] > 0 && table[0 + i] == table[3 + i] && table[6 + i] == table[0 + i])
                {
                    if (table[0 + i] > 1) label1.Text = "You Lose!";
                    else label1.Text = "You Win!";

                    Form1_Paint(new object(), new PaintEventArgs(this.CreateGraphics(), rectangle[i]));

                    g.DrawLine(new Pen(Color.Red, 4), new Point(rectangle[0 + i].X + 30, rectangle[0 + i].Y + 10), new Point(rectangle[6 + i].X + 30, rectangle[6 + i].Y + 50));
                    return true;
                }
            }

            // 判斷斜線
            if (table[4] > 0 && (table[0] == table[4] && table[8] == table[4]))
            {
                if (table[4] > 1) label1.Text = "You Lose!";
                else label1.Text = "You Win!";


                Form1_Paint(new object(), new PaintEventArgs(this.CreateGraphics(), rectangle[0]));

                g.DrawLine(new Pen(Color.Red, 4), new Point(rectangle[0].X + 10, rectangle[0].Y + 10), new Point(rectangle[8].X + 50, rectangle[8].Y + 50));
                return true;
            }
            if (table[4] > 0 && (table[2] == table[4] && table[6] == table[4]))
            {
                if (table[4] > 1) label1.Text = "You Lose!";
                else label1.Text = "You Win!";

                    Form1_Paint(new object(), new PaintEventArgs(this.CreateGraphics(), rectangle[0]));

                g.DrawLine(new Pen(Color.Red, 4), new Point(rectangle[2].X + 50, rectangle[2].Y + 10), new Point(rectangle[6].X + 10, rectangle[6].Y + 50));
                return true;
            }

            // 平手
            int steps = 0;
            for (int i = 0; i < 9; ++i)
            {
                if (table[i] > 0)
                    steps++;
            }

            if (steps == 9)
            {
                label1.Text = "Tie";

                Form1_Paint(new object(), new PaintEventArgs(this.CreateGraphics(), rectangle[0]));
                return true;
            }

            return false;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < 9; ++i)
            {
                if (table[i] == 0)
                {
                    if (rectangle[i].Contains(e.Location))
                    {
                        table[i] = 1;
                        Form1_Paint(sender, new PaintEventArgs(this.CreateGraphics(), rectangle[i]));
                            break;
                    }
                }
            }
            if (!over(CreateGraphics()))
            {
                Computer_Move();
            }

        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphics g1 = this.CreateGraphics();
            g1.Clear(this.BackColor);

            label1.Text = "";

            for (int i = 0; i < 9; ++i) 
                table[i] = 0;
    
            g1.DrawRectangles(new Pen(Color.Black, 5), rectangle);
        }
    }
}
