using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Math;

namespace PodUglom
{
    public partial class Form1 : Form
    {
        double angle, vel, Hmax, t, L;
        const double g = 9.81;
        public Form1()
        { 
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            { 
                angle = double.Parse(textBox1.Text)*PI/180;
            }
            catch
            { 
                textBox1.Text = "Ошибка";
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                vel = double.Parse(textBox2.Text);
            } 
            catch
            {
                textBox2.Text = "Ошибка"; 
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Calc();
            Graph(); 
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Graphics c = pictureBox1.CreateGraphics();
            c.Clear(BackColor);
        }
        
        public void Calc()
        { 
            double velOY = vel * Math.Sin(angle);
            double velOX = vel * Math.Cos(angle);
            Hmax = Math.Pow(velOY, 2) / (2 * g);
            textBox4.Text = Convert.ToString(Hmax);
            t = 2 * velOY / g;
            textBox5.Text = Convert.ToString(t);
            L = velOX * t;
            textBox3.Text = Convert.ToString(L);
        }

        public void Graph()
        { 
            Graphics G = pictureBox1.CreateGraphics();
            int H = pictureBox1.Height;
            int W = pictureBox1.Width;
            G.DrawLine(new Pen(Brushes.Black, 3),0, 0, 0, W); 
            G.DrawLine(new Pen(Brushes.Black, 3), 0, W-1, H, W-1); 
            double velOY = (float)vel * Math.Sin(angle); 
            double velOX = (float)vel * Math.Cos(angle);
            Graphics f = pictureBox1.CreateGraphics();
            float t = 0;
            while ( t < 2 * velOY / g)
            {
                float x = (float)velOX*t*30;
                float y = (float)(velOY * t - (g * Pow(t, 2) / 2))*30;
                f.DrawEllipse(new Pen(Color.Blue, 2), x, W-y, 1, 1);
                t =(float)(t + 0.001);
            }           
        }
    }
}
