using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CourseWork
{
    class Pgn:Figure
    {
        public Pgn(Graphics gr, Pen pn, Point l, int n)
        {
            g = gr;
            p = new Pen(pn.Color);

            double R = 50, xi, yi, angle;
            for (int i = 0; i < n; i++)
            {

                angle = 2 * Math.PI * i / n;

                xi = R * Math.Cos(angle) + l.X;
                yi = R * Math.Sin(angle) + l.Y;
                listPoint.Add(new Point((int)xi, (int)yi));
            }
            listPoint.Add(listPoint[0]);
        }

        public override bool choice(int mX, int mY, List<PointF> pointPng)
        {
            pointPng = newCoord();
            return base.choice(mX, mY, pointPng);
        }
    }
}
