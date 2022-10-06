using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace lab5.Objects
{
    class MyRectangle : BaseObject
    {
        public MyRectangle(float x, float y, float angle) : base(x, y, angle)
        {
        }
        public override void Render(Graphics graphics)
        {
            graphics.FillRectangle(new SolidBrush(Color.Yellow), 0, 0, 50, 30);
            graphics.DrawRectangle(new Pen(Color.Red, 2), 0, 0, 50, 30);
        }
    }
}
