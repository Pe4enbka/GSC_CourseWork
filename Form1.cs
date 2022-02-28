using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class Form1 : Form
    {
        Bitmap myBitmap;
        Graphics g;
        Pen pen = new Pen(Color.Black);
        int type = 1;
        List<Figure> ltFig = new List<Figure>();
        Figure f1, f2;
        bool check = false;
        Point centre = new Point();
        Point lastMousePos = new Point(); //последнее положение точки

        List<Point> list = new List<Point>();

        public Form1()
        {
            InitializeComponent();
            myBitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            g = Graphics.FromImage(myBitmap);
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            type = 1;            
        }

        private void btnBezier_Click(object sender, EventArgs e)
        {
            type = 2;
        }

        private void btnCross_Click(object sender, EventArgs e)
        {
            type = 3;
        }

        private void btnPgn_Click(object sender, EventArgs e)
        {
            type = 4;
        }

        private void btnMv_Click(object sender, EventArgs e)
        {
            type = 5;
        }

        private void btnRc_Click(object sender, EventArgs e)
        {
            type = 6;
        }

        private void btnSpf_Click(object sender, EventArgs e)
        {
            type = 7;
        }

        private void btnSpс_Click(object sender, EventArgs e)
        {
            type = 8;
        }

        private void btnIntersection_Click(object sender, EventArgs e)
        {
            type = 9;
            f1 = f2 = null;
        }

        private void btnSymDifference_Click(object sender, EventArgs e)
        {
            type = 10;
            f1 = f2 = null;
        }

        private void nDeleteFig_Click(object sender, EventArgs e)
        {
            type = 11;
            if (f1 != null)
            {
                ltFig.Remove(f1);
                g.Clear(pictureBox.BackColor);
                filAllFig();
                pictureBox.Image = myBitmap;
                f1 = null;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ltFig.Clear();
            g.Clear(pictureBox.BackColor);
            pictureBox.Image = myBitmap;
        }

        private void draw()
        {
            g.Clear(pictureBox.BackColor);
            filAllFig();
            gran(f1);
        }

        private Figure choice(int x, int y)
        {
            for (int k = 0; k < ltFig.Count; k++)
            {
                List<PointF> p = new List<PointF>();
                if (ltFig[k].choice(x, y, p))
                    return ltFig[k];
            }
            return null;
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            Point pnt;
            switch (type)
            {
                case 1://линия
                    pnt = new Point() { X = e.X, Y = e.Y };
                    list.Add(pnt);
                    g.DrawEllipse(pen, e.X, e.Y, 3, 3);

                    if (list.Count == 2)
                    {
                        f1 = new Line(g, pen, list);
                        ltFig.Add(f1);
                        draw();
                        list.Clear();
                    }
                    break;
                case 2://кривая Безье
                    pnt = new Point() { X = e.X, Y = e.Y };
                    list.Add(pnt);
                    g.DrawEllipse(pen, e.X, e.Y, 3, 3);
                    if (list.Count > 1)
                        g.DrawLine(new Pen(Color.Gray), list[list.Count - 2], pnt);

                    if (e.Button == MouseButtons.Right) // Конец ввода
                    {
                        f1 = new Bezier(g, pen, list);
                        ltFig.Add(f1);
                        draw();
                        list.Clear();
                    }
                    break;
                case 3://крест
                    pnt = new Point() { X = e.X, Y = e.Y };
                    f1 = new Cross(g, pen, pnt);
                    ltFig.Add(f1);
                    draw();
                    break;
                case 4://многоугольник
                    pnt = new Point() { X = e.X, Y = e.Y };
                    int n = 20 - domainUpDown1.SelectedIndex;
                    f1 = new Pgn(g, pen, pnt, n);
                    ltFig.Add(f1);
                    draw();
                    break;
                case 8:
                    if (type == 8 && e.Button == MouseButtons.Right)//задаем центр отражения
                    {
                        centre.X = e.X;
                        centre.Y = e.Y;
                        g.DrawLine(new Pen(Color.Red), centre.X - 3, centre.Y, centre.X + 3, centre.Y);
                        g.DrawLine(new Pen(Color.Red), centre.X, centre.Y - 3, centre.X, centre.Y + 3);
                        break;
                    }
                    f1 = choice(e.X, e.Y);
                    if (f1 != null)
                    {
                        draw();
                        lastMousePos = e.Location;
                        check = true;
                    }
                    else
                    {
                        g.Clear(pictureBox.BackColor);
                        filAllFig();
                        check = false;
                    }
                    break;
                case 5:
                case 6:
                    if (type == 6 && e.Button == MouseButtons.Right)//задаем центр вражения
                    {
                            centre.X = e.X;
                            centre.Y = e.Y;
                            g.DrawLine(new Pen(Color.Red), centre.X - 3, centre.Y, centre.X + 3, centre.Y);
                            g.DrawLine(new Pen(Color.Red), centre.X, centre.Y - 3, centre.X, centre.Y + 3);
                            break;
                    }
                    f1 = choice(e.X, e.Y);
                    if (f1 != null)
                    {
                        draw();
                        lastMousePos = e.Location;
                        check = true;
                    }
                    else
                    {
                        g.Clear(pictureBox.BackColor);
                        filAllFig();
                        check = false;
                    }
                    break;
                case 7:
                    f1 = choice(e.X, e.Y);
                    if (f1 != null)
                    {
                        
                        f1.Spf(f1.centrePoint);
                        draw();
                    }
                    else
                    {
                        g.Clear(pictureBox.BackColor);
                        filAllFig();
                    }
                    break;
                case 9:
                case 10:
                    Figure f = choice(e.X, e.Y);
                    g.Clear(pictureBox.BackColor);
                    filAllFig();
                    if (f != null && f != f1 && f != f2)
                        if (!f.GetType().FullName.Equals("CourseWork.Line") && !f.GetType().FullName.Equals("CourseWork.Bezier")
                            && !f.GetType().FullName.Equals("CourseWork.TMO "))
                        {
                            if (e.Button == MouseButtons.Right)
                            {
                                f2 = f;
                            }
                            else
                            {
                                f1 = f;
                            }
                            
                        }
                    if (f2 != null)
                        gran(f2);
                    if (f1 != null)
                        gran(f1);
                    if (f1 != null && f2 != null)
                    {
                        if (type == 9)
                            f = new TMO(g, pen, f1, f2, 2);
                        else
                            f = new TMO(g, pen, f1, f2, 4);
                        ltFig.Remove(f1);
                        ltFig.Remove(f2);
                        ltFig.Add(f);

                        f1 = f;
                        f2 = null;
                        draw();
                    }
                    break;
                case 11:
                    f1 = choice(e.X, e.Y);
                    if (f1 != null)
                    {
                        ltFig.Remove(f1);
                        g.Clear(pictureBox.BackColor);
                        filAllFig();
                        f1 = null;
                    }
                    break;
            }
            pictureBox.Image = myBitmap;
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //если операция перемещения и фигура выбрана
                if (type == 5 & check)
                {
                    //двигаем фигуру
                    f1.Mv(e.X - lastMousePos.X, e.Y - lastMousePos.Y);
                } //если операция масштабировния и фигура выбрана
                else if (type == 6 & check)
                {
                    //поворачиваем фигуру
                    f1.Rc(lastMousePos, e, centre);

                } //если операция масштаба и фигура выбрана
                else if (type == 8 & check)
                {
                    //зеркаливание фигуры
                    f1.Spс(centre);
                }
                //если фигура не рисуется
                if ((type == 5 || type == 6 || type ==8) && f1 != null)
                {
                    //чистим экран
                    g.Clear(pictureBox.BackColor);
                    //рисуем все фигуры из списка
                    filAllFig();
                    //рисуем границы
                    gran(f1);
                    //устанавливаем буфер
                    pictureBox.Image = myBitmap;
                    //меняем последнее положение мыши
                    lastMousePos = e.Location;
                }
            }
        }

        private void gran(Figure f)
        {
            f.getGran();

            g.DrawLine(new Pen(Color.LightGreen), f.centrePoint.X - 3, f.centrePoint.Y, f.centrePoint.X + 3, f.centrePoint.Y);
            g.DrawLine(new Pen(Color.LightGreen), f.centrePoint.X, f.centrePoint.Y - 3, f.centrePoint.X, f.centrePoint.Y + 3);

            g.DrawRectangle(new Pen(Color.LightGreen), f.leftPoint.X, f.leftPoint.Y, f.righPoint.X - f.leftPoint.X, f.righPoint.Y - f.leftPoint.Y);
        }

        private void filAllFig()
        {
            for (int k = 0; k < ltFig.Count; k++)
                ltFig[k].draw();
            
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void cbColorFig_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbColorFig.SelectedIndex)
            {
                case 0:
                    pen.Color = Color.Black;
                    break;
                case 1:
                    pen.Color = Color.Red;
                    break;
                case 2:
                    pen.Color = Color.Yellow;
                    break;
                case 3:
                    pen.Color = Color.Green;
                    break;
                case 4:
                    pen.Color = Color.Blue;
                    break;
                case 5:
                    pen.Color = Color.Purple;
                    break;
            }
        }
    }
}
