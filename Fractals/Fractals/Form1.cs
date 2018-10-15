using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Controls;


namespace Fractals
{
    public partial class Form1 : Form
    {
        Graphics g;
        Brush brush;
        Pen pen;
        v2 a, b, c, d, t, start, last;
        int multiplicator = 100;
        int i = 0;

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            timer1.Interval = trackBar1.Value * 10;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                g = this.CreateGraphics();
                brush = new SolidBrush(Color.Black);

                pen = new Pen(Color.Black);

                g.FillRectangle(brush, 0, 0, this.Width, this.Height);


                Random r = new Random();
                a = new v2(); b = new v2(); c = new v2();

                a.x = r.Next(this.Width / 4, this.Width - this.Width / 4);
                a.y = r.Next(this.Height / 4, this.Height - this.Height / 2);

                b.x = r.Next(this.Width / 4, this.Width - this.Width / 2);
                b.y = r.Next(this.Height / 2, this.Height - this.Height / 4);

                c.x = r.Next(this.Width / 2, this.Width - this.Width / 4);
                c.y = r.Next(this.Height / 2, this.Height - this.Height / 4);

                //a.x = this.Width / 2;
                //a.y = this.Height / 4;

                //b.x = this.Width / 4;
                //b.y = this.Height - this.Height / 4;

                //c.x = this.Width - this.Width / 4;
                //c.y = this.Height - this.Height / 4;

                a = new v2(0, 100);
                b = new v2(this.Width, 100);
                c = new v2(0, this.Height);
                d = new v2(this.Width, this.Height);



                pen.Color = Color.White;

                g.DrawRectangle(pen, a.x, a.y, 1, 1);
                g.DrawRectangle(pen, b.x, b.y, 1, 1);
                g.DrawRectangle(pen, c.x, c.y, 1, 1);


                int left, right, top, bottom;
                left = a.x;
                left = left > b.x ? b.x : left;
                left = left > c.x ? c.x : left;
                right = a.x;
                right = right < b.x ? b.x : right;
                right = right < c.x ? c.x : right;
                top = a.y;
                top = top > b.y ? b.y : top;
                top = top > c.y ? c.y : top;
                bottom = a.y;
                bottom = bottom > b.y ? b.y : bottom;
                bottom = bottom > c.y ? c.y : bottom;


                last = new v2();
                start = new v2(r.Next(left, right), r.Next(top, bottom));
                start = new v2(r.Next(100, 300), r.Next(100, 400));

                t = start;

                timer1.Enabled = true;
            }
            else
            {
                timer1.Enabled = false;
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random r = new Random();

            

            for (int j = 0; j < 1000; j++)
            {
                i = r.Next(1, 5);
                //multiplicator = 100;// r.Next(1, 11);
                if (multiplicator < 51)
                    multiplicator += 1;
                else
                    multiplicator = 2;

                if (i == 1)
                {
                    t.x += (a.x - t.x) / multiplicator;
                    t.y += (a.y - t.y) / multiplicator;
                }
                if (i == 2)
                {
                    t.x += (b.x - t.x) / multiplicator;
                    t.y += (b.y - t.y) / multiplicator;
                }
                if (i == 3)
                {
                    t.x += (c.x - t.x) / multiplicator;
                    t.y += (c.y - t.y) / multiplicator;
                }
                if (i == 4)
                {
                    t.x += (d.x - t.x) / multiplicator;
                    t.y += (d.y - t.y) / multiplicator;
                }
                //if (t.x < 0) t.x *= -1;
                //if (t.y < 0) t.y *= -1;


                pen.Color = Color.FromArgb(r.Next(100, 255), r.Next(100, 255), r.Next(100, 255));

                g.DrawRectangle(pen, t.x, t.y, 1, 1);
            }

        }
    }
}
