using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace lab5.Objects
{
    class Marker: BaseObject
    {
        public Marker(float x, float y, float angle) : base(x, y, angle)
        {
        }
        public override void Render(Graphics graphics)
        {
            graphics.DrawLine(new Pen(Color.Red, 2), 0, -15, 0, 15);
            graphics.DrawLine(new Pen(Color.Red, 2), -15, 0, 15, 0);
            graphics.DrawEllipse(new Pen(Color.Red, 2), -10, -10, 20, 20);
        }
        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(-3, -3, 6, 6);
            return path;
        }

    }
}
