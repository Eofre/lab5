using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lab5.Objects
{
    class Player : BaseObject
    {
        public Player(float x, float y, float angle) : base(x, y, angle)
        {
        }
        public override void Render(Graphics graphics)
        {
            graphics.FillRectangle(new SolidBrush(Color.DarkOliveGreen), -30, -20, 60, 40);
            graphics.DrawEllipse(new Pen(Color.Black, 2), -15, -15, 30, 30);
            graphics.DrawEllipse(new Pen(Color.Black, 4), 0, 0, 40, 0);

        }

    }
}
