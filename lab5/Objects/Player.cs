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
        public Action<MyRectangle> OnMyRectangleOverlap;
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
            else if (obj is MyRectangle)
            {
                OnMyRectangleOverlap(obj as MyRectangle);
            }

        }
        public override void Render(Graphics graphics)
        {
            
            graphics.DrawEllipse(new Pen(Color.Blue, 2), -15, -15, 30, 30);
            graphics.DrawEllipse(new Pen(Color.Black, 3), 0, 0, 30, 0);

        }

    }
}
