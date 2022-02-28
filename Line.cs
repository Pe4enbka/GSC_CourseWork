using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CourseWork
{
    class Line : Figure
    {
        public Line(Graphics gr, Pen pn, List<Point> l)
        {
            g = gr;
            p = new Pen(pn.Color);
            listPoint.Add(l[0]);
            listPoint.Add(l[1]);
        }
        public override void draw()
        {
            List<PointF> lt = newCoord();
            ProcDrawLine(p, (int)lt[0].X, (int)lt[0].Y, (int)lt[1].X, (int)lt[1].Y);
        }

        // Визуализация отрезка 
        void ProcDrawLine(Pen DrPen, int x1, int y1, int x2, int y2)
        {
            int x, y, dx, dy, Sx = 0, Sy = 0;
            int F = 0, Fx = 0, dFx = 0, Fy = 0, dFy = 0;
            dx = x2 - x1;
            dy = y2 - y1;

            Sx = Math.Sign(dx);
            Sy = Math.Sign(dy);

            if (Sx > 0) dFx = dy;
            else dFx = -dy;
            if (Sy > 0) dFy = dx;
            else dFy = -dx;

            x = x1; y = y1;
            F = 0;

            if (Math.Abs(dx) >= Math.Abs(dy)) // угол наклона <= 45 градусов 
            {
                do
                { //Вывести пиксель с координатами х, у 
                    g.DrawRectangle(DrPen, x, y, 1, 1);

                    if (x == x2) break;
                    Fx = F + dFx;
                    F = Fx - dFy;
                    x = x + Sx;
                    if (Math.Abs(Fx) < Math.Abs(F)) F = Fx;
                    else y = y + Sy;
                } while (true);
            }
            else // угол наклона > 45 градусов 
            {
                do
                { //Вывести пиксель с координатами х, у 
                    g.DrawRectangle(DrPen, x, y, 1, 1);

                    if (y == y2) break;
                    Fy = F + dFy;
                    F = Fy - dFx;
                    y = y + Sy;
                    if (Math.Abs(Fy) < Math.Abs(F)) F = Fy;
                    else x = x + Sx;
                } while (true);
            }
        }

        public override void getGran()
        {
            List<PointF> l = newCoord();
            if (l[0].X > l[1].X)
            {
                leftPoint.X = l[1].X - 1;
                righPoint.X = l[0].X + 1;
            }
            else
            {
                leftPoint.X = l[0].X - 1;
                righPoint.X = l[1].X + 1;
            }
            if (l[0].Y > l[1].Y)
            {
                leftPoint.Y = l[1].Y - 1;
                righPoint.Y = l[0].Y + 1;
            }
            else
            {
                leftPoint.Y = l[0].Y - 1;
                righPoint.Y = l[1].Y + 1;
            }
            centrePoint.X = leftPoint.X + (righPoint.X - leftPoint.X) / 2;
            centrePoint.Y = leftPoint.Y + (righPoint.Y - leftPoint.Y) / 2;
        }

        public override bool choice(int mX, int mY, List<PointF> P)
        {
            P.Add(leftPoint);
            P.Add(new PointF(righPoint.X, leftPoint.Y));
            P.Add(righPoint);
            P.Add(new PointF(leftPoint.X, righPoint.Y));
            P.Add(leftPoint);
            return base.choice(mX, mY, P);
        }
    }
}
