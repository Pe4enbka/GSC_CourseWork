using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CourseWork
{
    class Cross : Figure
    {
        public Cross(Graphics gr, Pen pn, Point l)
        {
            g = gr;
            p = new Pen(pn.Color);

            listPoint.Add(new Point(l.X - 60, l.Y - 20));
            listPoint.Add(new Point(l.X - 20, l.Y - 20));
            listPoint.Add(new Point(l.X - 20, l.Y - 60));
            listPoint.Add(new Point(l.X + 20, l.Y - 60));
            listPoint.Add(new Point(l.X + 20, l.Y - 20));
            listPoint.Add(new Point(l.X + 60, l.Y - 20));
            listPoint.Add(new Point(l.X + 60, l.Y + 20));
            listPoint.Add(new Point(l.X + 20, l.Y + 20));
            listPoint.Add(new Point(l.X + 20, l.Y + 60));
            listPoint.Add(new Point(l.X - 20, l.Y + 60));
            listPoint.Add(new Point(l.X - 20, l.Y + 20));
            listPoint.Add(new Point(l.X - 60, l.Y + 20));
            listPoint.Add(listPoint[0]);
        }

        public override bool choice(int mX, int mY, List<PointF> pointPng)
        {
            pointPng = newCoord();
            return base.choice(mX, mY, pointPng);
        }
    }
}
