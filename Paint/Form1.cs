using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool ciz;
        int baslaX, baslaY;
        int kalinlik = 3;
        ColorDialog renksec = new ColorDialog();

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedText = "Arial";
            comboBox2.SelectedText = "12";
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ciz = true;
            baslaX = e.X;
            baslaY = e.Y;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Pen p = new Pen(renksec.Color, kalinlik);

            Point nokta1 = new Point(baslaX, baslaY);
            Point nokta2 = new Point(e.X, e.Y);

            if (ciz == true)
            {
                g.DrawLine(p, nokta1, nokta2);
                baslaX = e.X;
                baslaY = e.Y;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            ciz = false;
        }

        private void btnYaz_Click(object sender, EventArgs e)
        {

            string yazitipi = comboBox1.Text;
            Graphics g = this.CreateGraphics();
            Font myFont = new Font(yazitipi, Convert.ToInt32(comboBox2.Text));
            Brush myBrush = new SolidBrush(renksec.Color);
            g.DrawString(textBox1.Text, myFont, myBrush, 175, 20);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.Clear(Color.White);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Pen myPen = new Pen(Color.DarkRed);
            SolidBrush mySolidBrush = new SolidBrush(Color.DarkRed);
            g.Clear(Color.White);
            switch (comboBox3.SelectedIndex)
            {
                case 0: // Çizgi 
                        //g. DrawLine(myPen, x, y, width, height); 
                    g.DrawLine(myPen, 220, 20, 200, 210);
                    break;
                case 1: // Daire 
                        //g.DrawEllipse(myPen, x, y, width, height); 
                    g.DrawEllipse(myPen, 250, 50, 150, 150);
                    break;
                case 2: // Kare
                        //DrawRectangle(myPen, x, y, width, height);
                    g.DrawRectangle(myPen, 250, 50, 150, 150);
                    break;
                case 3: // Ellipse
                        //DrawEllipse(myPen, x, y, width, height);
                    g.DrawEllipse(myPen, 250, 85, 150, 115);
                    break;
                case 4: // Pie
                        // DrawPie(Pen, x, y, genişlik, yükseklik, Başlangıç açısı, başlangıçtan bitişe açı);
                    g.DrawPie(myPen, 250, 50, 150, 150, 0, 45);
                    break;
                case 5: // İçi dolu daire
                    g.FillEllipse(mySolidBrush, 250, 50, 150, 150);
                    break;
                case 6: // içi dolu Dikdörtgen
                    g.FillRectangle(mySolidBrush, 250, 50, 150, 150);
                    break;
            }
            g.Dispose(); // Graphics nesnesini serbest bırak

        }

        private void btnrenksec_Click(object sender, EventArgs e)
        {
            renksec.ShowDialog();

        }


    }
}
