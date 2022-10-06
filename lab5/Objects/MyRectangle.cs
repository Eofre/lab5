using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace lab5.Objects
{
    class MyRectangle : BaseObject
    {
        public Action<MyRectangle> WantsRemove;
        public int count = 200;
        public MyRectangle(float x, float y, float angle) : base(x, y, angle)
        {
        }
        public override void Render(Graphics graphics)
        {
            graphics.FillRectangle(new SolidBrush(Color.Yellow), -25, -15, 35, 25);
            graphics.DrawRectangle(new Pen(Color.Red, 2), -25, -15, 35, 25);
            if (count > 0)
            {
                graphics.DrawString(
                    $"{count}%",
                    new Font("Verdana", 6),
                    new SolidBrush(Color.Indigo),
                    10, 10
                    );
                count--;
            }
            else
            {
                WantsRemove?.Invoke(this);
            }
        }
        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(0, -5, 25, 10);
            return path;
        }
    }
}
