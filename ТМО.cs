using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CourseWork
{
    class TMO : Figure
    {
        Figure f1;
        Figure f2;
        int num;

        public TMO(Graphics gr, Pen pn, Figure fig1, Figure fig2, int m)
        {
            g = gr;
            p = new Pen(pn.Color);
            f1 = fig1;
            f2 = fig2;
            num = m;
        }

        private int minmax(List<PointF> l, int m, int var)
        {
            int n = l.Count() - 1, y;
            for (int i = 0; i < n; i++)
            {
                y = (int)Math.Round(l[i].Y);
                if (y < m && var == 1) m = y;
                if (y > m && var == 2) m = y;
            }
            if (m < 0)
                m = 0;
            if (m > 854)
                m = 854;
            return m;
        }

        public override void draw()
        {
            List<PointF> l1 = f1.newCoord();
            List<PointF> l2 = f2.newCoord();

            //списки границ фигур
            List<double> Xa = new List<double>();
            List<double> Xb = new List<double>();
            
            leftPoint = new PointF(852, 468);
            righPoint = new PointF();
            //вычисляем границы фигуры по У
            int Ymin = (int)Math.Round(l1[0].Y);
            int Ymax = Ymin;
            Ymin = minmax(l1, Ymin, 1);
            Ymin = minmax(l2, Ymin, 1);
            Ymax = minmax(l1, Ymax, 2);
            Ymax = minmax(l2, Ymax, 2);
            
            //для У в границах многоугольника
            for (int Y = Ymin; Y < Ymax; Y++)
            {
                //чистим списки
                Xa.Clear();
                Xb.Clear();
                //считаем число вершин пересекающихся со строкой
                Xa = cross(l1, Y);
                Xb = cross(l2, Y);
                if (Xa.Count() != 0 || Xb.Count() != 0)
                    drawTMO(Xa, Xb, Y);
            }
        }

        //пересечение фигуры со строкой У
        private List<double> cross(List<PointF> l, int y)
        {
            List<double> X = new List<double>();
            double x;
            int n = l.Count - 1;
            for (int i = 0; i < n; i++)
            {
                //критерий пересечения строки с многоугольником
                if (((l[i].Y < y) && (l[i + 1].Y >= y)) || ((l[i].Y >= y) && (l[i + 1].Y < y)))
                {
                    //вычисляем Х и записываем его в список
                    x = (y - l[i].Y) * (l[i + 1].X - l[i].X) / (l[i + 1].Y - l[i].Y) + l[i].X;
                    X.Add(x);
                }
            }
            X.Sort();
            return X;
        }

        private double[,] Sort(double[,] M)
        {
            double temp, tpQ;
            for (int i = 0; i < M.Length / 2 - 1; i++)
            {
                for (int j = i + 1; j < M.Length / 2; j++)
                {
                    if (M[i,0] > M[j,0])
                    {
                        temp = M[i,0];
                        tpQ = M[i,1];
                        M[i,0] = M[j,0];
                        M[i,1] = M[j,1];
                        M[j,0] = temp;
                        M[j,1] = tpQ;
                    }
                }
            }
            return M;
        }

        //рисуем ТМО
        private void drawTMO(List<double> lf1, List<double> lf2, int y)
        {
            List<double> Xrl = new List<double>();
            List<double> Xrr = new List<double>();
            //массив приращения пороговых функций
            double[] setQ;
            //рабочий массив итоговых значений
            double[,] M = new double[lf1.Count+lf2.Count, 2];

            //объединение
            if (num == 2)
            {
                setQ = new double[3];
                setQ[0] = 1;
                setQ[1] = 2;
                setQ[2] = 3;
            }
            //разность А-В
            else
            {
                setQ = new double[2];
                setQ[0] = 2; 
                setQ[1] = 2;
            }

            //переписываем значения в итоговый массив
            int n = lf1.Count();
            for (int i = 0; i < n; i += 2)
            {
                M[i, 0] = lf1[i];
                M[i, 1] = 2;
                M[i + 1, 0] = lf1[i + 1];
                M[i + 1, 1] = -2;
            }

            n += lf2.Count();
            for (int i = lf1.Count; i < n; i += 2)
            {
                M[i, 0] = lf2[i - lf1.Count];
                M[i, 1] = 1;
                M[i + 1, 0] = lf2[i + 1 - lf1.Count];
                M[i + 1, 1] = -1;
            }

            //сортируем массив
            M = Sort(M);

            double Q = 0, x, Qn;
            //если первый элемент массива правая граница сегмента
            if (M[0,0] >= 0 && M[0,1] < 0)
            {
                //добавляем левую границу
                Xrl.Add(0);
                Q = -M[0,1];
            }
            //внос значений в списки левых и правых границ
            for (int i = 0; i < n; i++)
            {
                x = M[i,0];
                Qn = Q + M[i,1];
                if (!set(Q, setQ) && set(Qn, setQ))
                {
                    Xrl.Add(x);
                }
                if (set(Q, setQ) && !set(Qn, setQ))
                {
                    Xrr.Add(x);
                }
                Q = Qn;
            }

            if (set(Q, setQ))
                Xrr.Add(854);
            //рисуем линию
            for (int i = 0; i < Xrl.Count(); i++)
            {
                g.DrawLine(p, (int)Xrl[i] + 1, y, (int)Xrr[i], y);
                if (righPoint.Y < y)
                    righPoint.Y = y;
                if (righPoint.X < Xrr[Xrr.Count - 1])
                    righPoint.X = (float)Xrr[Xrr.Count - 1];
                if (leftPoint.Y > y)
                    leftPoint.Y = y;
                if (leftPoint.X > Xrl[0])
                    leftPoint.X = (float)Xrl[0];
            }
        }

        //функция, выясняющая принадлежит ли значение массиву
        private Boolean set(double q, double[] sq)
        {
            for (int i = 0; i < sq.Length; i++)
                if (sq[i] == q)
                    return true;
            return false;
        }
        
        public override void getGran()
        {
            centrePoint.X = leftPoint.X + (righPoint.X - leftPoint.X) / 2;
            centrePoint.Y = leftPoint.Y + (righPoint.Y - leftPoint.Y) / 2;
        }

        public override bool choice(int mX, int mY, List<PointF> pointPng)
        {
            if (f1.choice(mX, mY, pointPng))
                return true;
            if (f2.choice(mX, mY, pointPng))
                return true;
            return false;
        }

        public override void Mv(int dx, int dy)
        {
            f1.Mv(dx, dy);
            f2.Mv(dx, dy);
        }

        public override void Spf(PointF cetr)
        {
            f1.Spf(centrePoint);
            f2.Spf(centrePoint);
        }
        public override void Spс(PointF cetr)
        {
            f1.Spс(cetr);
            f2.Spс(cetr);
        }
        
        public override void Rc(Point p1, MouseEventArgs p2, PointF cetr)
        {
            f1.Rc(p1, p2, cetr);
            f2.Rc(p1, p2, cetr);
        }

    }
}
