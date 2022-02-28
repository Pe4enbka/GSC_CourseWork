using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CourseWork
{
    class Bezier : Figure
    {
        public Bezier(Graphics gr, Pen pn, List<Point> Lp)
        {
            int n = Lp.Count - 1;
            List<double> Factorial = new List<double>();
            Factorial.Add(1);
            for (int j = 1; j <= n; j++)
                Factorial.Add(Factorial[j - 1] * j);
            g = gr;
            p = new Pen(pn.Color);
            
            double dt, t, xt, yt, xPred, yPred, J;
            int i;

            //шаг табуляции
            dt = 0.001; t = dt;
            //начальные значения предыдущей точки
            xPred = Lp[0].X; yPred = Lp[0].Y;
            listPoint.Add(new Point((int)xPred, (int)yPred));
            double end = 1 + dt / 2;
            while (t < end)
            {
                //текущие координаты
                xt = 0; yt = 0;
                //номер точки в списке
                i = 0;
                while (i <= n)
                {
                    //полином берштейна
                    J = pow(t, i) * pow(1 - t, n - i) * Factorial[n] / (Factorial[i] * Factorial[n - i]);
                    //изменение текущих координат
                    xt = xt + Lp[i].X * J;
                    yt = yt + Lp[i].Y * J;
                    //изменение номера точки
                    i++;
                }
                //добавляем координаты точек линии
                listPoint.Add(new Point((int)xt, (int)yt));
                //увеличиваем шаг
                t = t + dt;
                //меняем значение предыдущей точки
                xPred = xt; yPred = yt;
            }
        }
        //вычисление степени
        private double pow(double osn, int st)
        {
            double rez = 1;
            for (int i = 0; i < st; i++)
                rez *= osn;
            return rez;
        }

        public override void draw()
        {
            List<PointF> lt = newCoord();
            for (int i = 0; i < listPoint.Count - 1; i++)
                g.DrawLine(p, lt[i].X, lt[i].Y, lt[i + 1].X, lt[i + 1].Y);
        }

        public override bool choice(int mX, int mY, List<PointF> P)
        {
            P.Add(leftPoint);
            P.Add(new PointF(righPoint.X, leftPoint.Y));
            P.Add(righPoint);
            P.Add(new PointF(leftPoint.X, righPoint.Y));
            P.Add(P[0]);
            return base.choice(mX, mY, P);
        }
    }
}
