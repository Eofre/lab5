using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace lab5.Objects
{
    class Player : BaseObject
    {
        public Action<Marker> OnMarkerOverlap;
        public float vX, vY;
        public Player(float x, float y, float angle) : base(x, y, angle)
        {
        }
        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(-15, -15, 30, 30);
            return path;
        }
        public override void Overlap(BaseObject obj)
        {
            base.Overlap(obj);

            if (obj is Marker)
            {
                OnMarkerOverlap(obj as Marker);
            }
            
        }
        public override void Render(Graphics graphics)
        {
            graphics.FillRectangle(new SolidBrush(Color.DarkOliveGreen), -30, -20, 60, 40);
            graphics.DrawEllipse(new Pen(Color.Black, 2), -15, -15, 30, 30);
            graphics.DrawEllipse(new Pen(Color.Black, 4), 0, 0, 40, 0);

        }

    }
}
