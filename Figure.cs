using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CourseWork
{
    public class Figure : Form1
    {
        public Graphics g;
        public Pen p;
        public PointF centrePoint = new PointF();//центр фигуры
        public PointF leftPoint = new PointF(859, 458);//левая верхняя граница
        public PointF righPoint = new PointF();//правая нижняя граница
        public List<Point> listPoint = new List<Point>();//точки фигур
        public double[,] W = { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } }; //матрица преобразований

        public virtual void draw() {
            List<PointF> point = newCoord();
            int y;
            int n = listPoint.Count() - 1;
            //ищем максимальные и минимальные значения по У
            int Ymin = (int)Math.Round(point[0].Y);
            int Ymax = Ymin, Y = 0;
            for (int i = 0; i < n; i++)
            {
                y = (int)Math.Round(point[i].Y);
                if (y < Ymin) Ymin = y;
                if (y > Ymax) Ymax = y;
            }
            if (Ymin < 0) Ymin = 0;
            if (Ymax > 854) Ymax = 854;
            List<double> Xb = new List<double>();
            double x;

            for (Y = Ymin; Y <= Ymax; Y++)
            {
                Xb.Clear();
                for (int i = 0; i < n; i++)
                {
                    if ((point[i].Y < Y) & (point[i + 1].Y >= Y) | (point[i].Y >= Y) & (point[i + 1].Y < Y))
                    {
                        x = (Y - point[i].Y) * (point[i + 1].X - point[i].X) / (point[i + 1].Y - point[i].Y) + point[i].X;
                        Xb.Add(x);
                    }
                }
                Xb.Sort();
                for (int i = 0; i < Xb.Count; i = i + 2)
                {
                    g.DrawLine(p, (int)(Xb[i] + 1), Y, (int)(Xb[i + 1]), Y);
                }
            }
            point.Clear();
        }
        public virtual void getGran()
        {
            List<PointF> l = newCoord();
            leftPoint = l[0]; righPoint = l[0];
            int n = l.Count();

            for (int i = 1; i < n; i++)
            {
                if (l[i].X < leftPoint.X)
                    leftPoint.X = l[i].X;
                if (l[i].Y < leftPoint.Y)
                    leftPoint.Y = l[i].Y;
                if (l[i].X > righPoint.X)
                    righPoint.X = l[i].X;
                if (l[i].Y > righPoint.Y)
                    righPoint.Y = l[i].Y;
            }
            leftPoint.X--; leftPoint.Y--;
            righPoint.X++; righPoint.Y++;
            centrePoint.X = leftPoint.X + (righPoint.X - leftPoint.X) / 2;
            centrePoint.Y = leftPoint.Y + (righPoint.Y - leftPoint.Y) / 2;
        }

        //перемножение матриц
        double[,] multi(double[,] a, double[,] b)
        {
            double[,] rez = new double[a.GetLength(0), b.GetLength(0)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        rez[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return rez;
        }

        //умножение матрицы начальных координат на матрицу преобразования
        public List<PointF> newCoord()
        {
            double[,] temp = new double[1, 3];
            List<PointF> l = new List<PointF>();
            int n = listPoint.Count() - 1;
            for (int i = 0; i <= n; i++)
            {
                double[,] C0 = { { listPoint[i].X, listPoint[i].Y, 1 } };
                temp = multi(C0, W);
                l.Add(new PointF((float)temp[0, 0], (float)temp[0, 1]));
            }
            return l;
        }

        // выделение многоугольника
        public virtual bool choice(int mX, int mY, List<PointF> pointPng)
        {
            int n = pointPng.Count() - 1;
            double x;
            List<double> Xb = new List<double>(); // буфер сегментов
            bool check = false;

            Xb.Clear();
            for (int i = 0; i < n; i++)
            {
                if ((pointPng[i].Y < mY) & (pointPng[i + 1].Y >= mY) | (pointPng[i].Y >= mY) & (pointPng[i + 1].Y < mY))
                {
                    x = (mY - pointPng[i].Y) * (pointPng[i + 1].X - pointPng[i].X) / (pointPng[i + 1].Y - pointPng[i].Y) + pointPng[i].X;
                    Xb.Add(x);
                }
            }
            if (Xb.Count() > 0)
            {
                Xb.Sort();  // по умолчанию по возрастанию
                for (int i = 0; i < Xb.Count; i = i + 2)
                {
                    if (mX >= Xb[i] & mX <= Xb[i + 1]) { check = true; break; }
                }
            }
            pointPng.Clear();
            return check;
        }

        public virtual void Mv(int dx, int dy)
        {
            //матрица движения
            double[,] M = { { 1, 0, 0 },{ 0, 1, 0 },{ dx, dy, 1 } };
            W = multi(W, M);
        }

        //вращение
        public virtual void Rc(Point p1, MouseEventArgs p2, PointF cent)
        {
            //вычисляем вектор от центра преобразований к началу движения
            float aX = p1.X - cent.X;
            float aY = p1.Y - cent.Y;
            //вычисляем вектор от центра преобразований к концу движения
            float bX = p2.X - cent.X;
            float bY = p2.Y - cent.Y;

            double detAB = (bX * aY - aX * bY);
            //вычисляем косинус угла
            double cosf = (aX * bX + aY * bY) / (Math.Sqrt(aX * aX + aY * aY) * Math.Sqrt(bX * bX + bY * bY));
            //синус угла
            double sinf = Math.Sqrt(1 - cosf * cosf);

            if (detAB > 0) sinf = -sinf;

            //матрица движения к началу координат
            double[,] M = { { 1, 0, 0 },{ 0, 1, 0 },{ -cent.X, -cent.Y, 1 } };
            //обратная матрица движения (от начала координат)
            double[,] MObr = { { 1, 0, 0 },{ 0, 1, 0 },{ cent.X, cent.Y, 1 } };
            //матрица вращения
            double[,] R = { { cosf, sinf, 0 },{-sinf, cosf, 0 },{ 0, 0, 1 } };

            W = multi(W, multi(M, multi(R, MObr)));
        }

        //Зеркаливание относительно центра
        public virtual void Spf(PointF cent)
        {
            double[,] M = { { 1, 0, 0 }, { 0, 1, 0 }, { -cent.X, -cent.Y, 1 } };
            double[,] MObr = { { 1, 0, 0 }, { 0, 1, 0 }, { cent.X, cent.Y, 1 } };
            double[,] Otr = { { -1, 0, 0 }, { 0, -1, 0 }, { 0, 0, 1 } };
            W = multi(W, multi(M, multi(Otr, MObr)));
        }

        //Зеркаливание относительно точки
        public virtual void Spс(PointF cent)
        {
            double[,] M = { { 1, 0, 0 }, { 0, 1, 0 }, { -cent.X, -cent.Y, 1 } };
            double[,] MObr = { { 1, 0, 0 }, { 0, 1, 0 }, { cent.X, cent.Y, 1 } };
            double[,] Otr = { { -1, 0, 0 }, { 0, -1, 0 }, { 0, 0, 1 } };
            W = multi(W, multi(M, multi(Otr, MObr)));
        }

        
    }
}
