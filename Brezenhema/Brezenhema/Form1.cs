﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Brezenhema
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static public void Bresenham4Line(Graphics g, Color clr, int x0, int y0, int x1, int y1)
        {
            int dx = x1 - x0;
            int dy = y1 - y0;
            int d = 0;
            int d1 = dy << 1;
            int d2 = -(dx << 1);
            PutPixel(g, clr, x0, y0, 255);
            int x = x0;
            int y = y0;

            for (int i = 1; i <= dx + dy; i++)
            {
                if (d > 0)
                {
                    d += d2;
                    y++;
                }
                else
                {
                    d += d1;
                    x++;
                }
                PutPixel(g, clr, x, y, 255);
            }
        }
        private static void PutPixel(Graphics g, Color clr, int x, int y, int alpha)
        {
            g.FillRectangle(new SolidBrush(Color.FromArgb(alpha, clr)), x, y, 1, 1);
        }

        static public void DdaLine(Graphics g, Color clr, int x0, int y0, int x1, int y1)
        {
            int dx, dy;
            float x, xFark;
            float y, yFark;

            dx = x1 - x0;
            dy = y1 - y0;

            var pikselSayisi = Math.Abs(dx) > Math.Abs(dy) ? Math.Abs(dx) : Math.Abs(dy);

            xFark = (float)dx / (float)pikselSayisi;
            yFark = (float)dy / (float)pikselSayisi;

            x = (float)x0;
            y = (float)y0;

            while (pikselSayisi!=0)
            {
                PutPixel(g, clr, (int)Math.Floor(x + 0.5F), (int)Math.Floor(y + 0.5f), 255);
                x += xFark;
                y += yFark;
                pikselSayisi--;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                var x0 = Int32.Parse(X0.Text);
                var x1 = Int32.Parse(X1.Text);
                var y0 = Int32.Parse(Y0.Text);
                var y1 = Int32.Parse(Y1.Text);

                Graphics g = pictureBox1.CreateGraphics();
                if (Brezenhem.Checked)
                {
                    Bresenham4Line(g, Color.DeepPink, x0, y0, x1, y1);
                }
                else 
                {
                    DdaLine(g, Color.DarkTurquoise, x0, y0, x1, y1);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

    }
}
