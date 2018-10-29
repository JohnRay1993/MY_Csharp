using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snake
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        Graphics g, g2;
        Brush brush;
        Pen pen;



        int dir_x = 0, dir_y = 0;   //direction
        int player_x = 0, player_y = 0;
        int speed = 10;
        int lenght = 4;
        int[,] body;
        int[] apple = { 0, 0 };


        private void timer1_Tick(object sender, EventArgs e)
        {
            g.Clear(Color.Black);
            
            player_x = speed * dir_x;
            player_y = speed * dir_y;
            /*if (player_x >= this.Width)
                player_x = 0;
            if (player_y >= this.Height)
                player_y = 0;*/
            draw(player_x, player_y);
            //g.FillRectangle(brush, player_x, player_y, 30, 30);

            //this.Text = player_x.ToString() + " " + player_y.ToString();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'w' && dir_y != 1) { dir_x = 0; dir_y = -1; }
            if (e.KeyChar == 's' && dir_y != -1) { dir_x = 0; dir_y = 1; }
            if (e.KeyChar == 'a' && dir_x != 1) { dir_x = -1; dir_y = 0; }
            if (e.KeyChar == 'd' && dir_x != -1) { dir_x = 1; dir_y = 0; }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void draw()
        {
            brush = new SolidBrush(Color.Yellow);
            for (int i = 0; i < body.Length / 2; i++)
            {
                if (body[0, i] != 0 && body[1, i] != 0)
                    g.FillRectangle(brush, body[0, i], body[1, i], speed, speed);
            }
        }
        private void draw(int x, int y)
        {
            Random r = new Random();
            //brush = new SolidBrush(Color.Yellow);
            brush = new SolidBrush(Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)));
            for (int i = (body.Length / 2); i > 0; i--)
            {
                if (body[0, i - 1] != 0 && body[1, i - 1] != 0 && body[0, i] == 0 && body[1, i] == 0)
                {
                    body[0, i] = body[0, i - 1];
                    body[1, i] = body[1, i - 1];
                    body[0, i - 1] = 0;
                    body[1, i - 1] = 0;

                    if (i >= lenght)
                        body[0, i] = body[1, i] = 0;
                }
            }

            body[0, 0] = body[0, 1] + x;
            body[1, 0] = body[1, 1] + y;



            for (int i = 0; i < (body.Length / 2); i++)
            {
                if (body[0, 0] == body[0, i] && body[1, 0] == body[1, i] && i > 0)
                {
                    //game over
                    timer1.Enabled = false;
                    label1.Visible = true;
                }

                if (body[0, 0] == apple[0] && body[1, 0] == apple[1])
                {
                    //apple
                    apple[0] = 0;
                    apple[1] = 0;

                    lenght++;
                }

                if (body[0, i] != 0 && body[1, i] != 0)
                {
                    g.FillRectangle(brush, body[0, i] + 1, body[1, i] + 1, speed - 2, speed - 2);
                }
            }



            //apple

            if (apple[0] == 0 && apple[1] == 0)
            {
                apple[0] = r.Next(speed, this.Width);
                apple[1] = r.Next(speed, this.Height);

                if (apple[0] / speed != 0)
                {
                    apple[0] -= apple[0] % speed;
                }
                if (apple[1] / speed != 0)
                {
                    apple[1] -= apple[1] % speed;
                }
            }
            brush = new SolidBrush(Color.Pink);
            g.FillRectangle(brush, apple[0] + 1, apple[1] + 1, speed - 2, speed - 2);

            this.Text = apple[0] + " " + apple[1];

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(Color.Black);

            //pen = new Pen(Color.Red);
            //for (int y = 0; y < this.Height - 1; y = y + 30)
            //{
            //    g.DrawLine(pen, 0, y, this.Height, y);
            //    g.DrawLine(pen, y, 0, y, this.Width);
            //}
            label1.Visible = false;

            player_x = 50;
            player_y = 50;

            dir_x = 1;
            dir_y = 0;
            

            body = new int[2, 500];
            for (int i = 0; i < body.Length / 2; i++)
            {
                body[0, i] = 0;
                body[1, i] = 0;
            }
            body[0, 3] = 50;
            body[1, 3] = 50;
            body[0, 2] = 60;
            body[1, 2] = 50;
            body[0, 1] = 70;
            body[1, 1] = 50;
            body[0, 0] = 80;
            body[1, 0] = 50;

            //draw();

            

            timer1.Enabled = true;
            //timer2.Enabled = true;


        }
    }
}
