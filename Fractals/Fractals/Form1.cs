using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Controls;
using System.IO;


namespace Fractals
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        Graphics g, g2;
        Brush brush;
        Pen pen;
        v2 a, b, c, d, e2, t, start, last;
        int multiplicator = 100;
        int i = 0;
        int count = 0;

        string PNG_dir = "";

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
            //Bitmap bitmap = new Bitmap(Convert.ToInt32(this.Width), Convert.ToInt32(this.Height), System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            //Graphics g = Graphics.FromImage(bitmap);

            // Add drawing commands here
            //g.Clear(Color.Black);

            bitmap.Save(PNG_dir + "\test_" + count.ToString() + ".png", System.Drawing.Imaging.ImageFormat.Png);    //@"C:\Users\johndoe\
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (!timer1.Enabled)
            {
                bitmap = new Bitmap(Convert.ToInt32(this.Width), Convert.ToInt32(this.Height), System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                PNG_dir = "session at " + DateTime.Now.Year.ToString() + "." + DateTime.Now.Month.ToString() + "." + DateTime.Now.Day.ToString() + "  " + DateTime.Now.Hour.ToString() + "." + DateTime.Now.Minute.ToString();
                Directory.CreateDirectory(PNG_dir);

                g = this.CreateGraphics();
                g2 = Graphics.FromImage(bitmap);
                brush = new SolidBrush(Color.Red);

                pen = new Pen(Color.Black);

                //g.FillRectangle(brush, 0, 0, this.Width, this.Height);
                g.Clear(Color.Black);
                g2.Clear(Color.Black);

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

                a = new v2(0, 0);
                b = new v2(this.Width, 0);
                c = new v2(0, this.Height);
                d = new v2(this.Width, this.Height);
                

                pen.Color = Color.White;

                g.DrawRectangle(pen, a.x, a.y, 1, 1);
                g.DrawRectangle(pen, b.x, b.y, 1, 1);
                g.DrawRectangle(pen, c.x, c.y, 1, 1);
                g2.DrawRectangle(pen, a.x, a.y, 1, 1);
                g2.DrawRectangle(pen, b.x, b.y, 1, 1);
                g2.DrawRectangle(pen, c.x, c.y, 1, 1);


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
            


            //g = this.CreateGraphics();
            //brush = new SolidBrush(Color.Black);

            //pen = new Pen(Color.Black);

            //g.FillRectangle(brush, 0, 0, this.Width, this.Height);

            //pen = new Pen(Color.White);
            ////y=100*[x/50]
            ////y=50*[x/(100/[x/100])]
            ////X' = -0.5*X -0.5*Y + 490 
            ////Y' = 0.5*X -0.5*Y + 120 
            //int h = this.Height, w = this.Width;
            ////a = new v2(h, 0);
            ////b = new v2(w / 2, 100);
            ////c = new v2(w, h);
            ////d = new v2(w / 2, h);
            ////e2 = new v2(w, 100);

            //a = new v2(h, 0);
            //b = new v2(w / 2, 100);
            //c = new v2(w, h);
            //d = new v2(w / 2, h);
            //e2 = new v2(w, 100);

            //double y = 0;
            //for (double x = 0; x < 1000; x++)
            //{
                




            //    g.DrawRectangle(pen, (int)x, (int)y, 1, 1);
            //}




        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random r = new Random();


            //if (count < 10000)
                for (int j = 0; j < 1000; j++)
                {
                    this.Text = count++.ToString();
                    i = r.Next(1, 5);
                //multiplicator = 100;// r.Next(1, 11);
                /*if (multiplicator < 11)
                    multiplicator = 50;
                else
                    multiplicator -= 10;*/
                //int q = 1;
                //multiplicator = r.Next(q, r.Next(q, r.Next(q, r.Next(q, 51))));
                if (multiplicator < 11)
                    multiplicator = 1;
                else
                    multiplicator = 1;

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


                    pen.Color = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));

                    g.DrawRectangle(pen, t.x, t.y, 1, 1);
                    g2.DrawRectangle(pen, t.x, t.y, 1, 1);
                }
            //else
            //{
            //    bitmap.Save("test.png", System.Drawing.Imaging.ImageFormat.Png);    //@"C:\Users\johndoe\
            //}
        }
    }
}
/*
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
*/