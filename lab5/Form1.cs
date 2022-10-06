using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lab5.Objects;

namespace lab5
{
    public partial class Form1 : Form
    {
        List<BaseObject> objects = new List<BaseObject>();
        Player player;
        Marker marker;
        MyRectangle myRectangle;
        public Form1()
        {
            InitializeComponent();
            Random randX = new Random();
            Random randY = new Random();
            player = new Player(pbMain.Width / 2, pbMain.Height / 2, 0);
            player.OnOverlap += (p, obj) =>
            {
                txtLog.Text = $"[{DateTime.Now:HH:mm:ss:ff}] Игрок пересекся с {obj}\n" + txtLog.Text;
            };
            var numb = 0;

            player.OnMarkerOverlap += (m) =>
            {
                objects.Remove(m);
                marker = null;
            };

            marker = new Marker(pbMain.Width / 2 + 50, pbMain.Height / 2 + 50, 0);


            player.OnMyRectangleOverlap += (n) =>
            {
                myRectangle = null;
                objects.Remove(n);

                numb++;
                richTextBox1.Text = "очки:" + numb.ToString();
                myRectangle = new MyRectangle(pbMain.Width / 2 + randX.Next(-400, 400), pbMain.Height / 2 + randY.Next(-300, 300), 0);
                objects.Add(myRectangle);
            };

            if (myRectangle == null)
            {
                myRectangle = new MyRectangle(pbMain.Width / 2 + randX.Next(-400, 400), pbMain.Height / 2 + randY.Next(-300, 300), 0);
                myRectangle.WantsRemove += (p) =>
                {
                    p.X = pbMain.Width / 2 + randX.Next(-150, 550);
                    p.Y = pbMain.Height / 2 + randY.Next(-20, 375);
                    p.count = 100;
                };
            }
            objects.Add(myRectangle);
            objects.Add(player);
            objects.Add(marker);
        }

        private void pbMain_Click(object sender, EventArgs e)
        {

        }

        private void pbMain_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            graphics.Clear(Color.White);
            updatePlayer();
            foreach (var obj in objects.ToList())
            {
                if (obj != player && player.Overlaps(obj, graphics))
                {
                    player.Overlap(obj);
                    obj.Overlap(player);
                }
            }

            foreach (var obj in objects)
            {
                graphics.Transform = obj.GetTransform();
                obj.Render(graphics);
            }

        }
        public void updatePlayer()
        {
            if (marker != null)
            {
                float dx = marker.X - player.X;
                float dy = marker.Y - player.Y;
                float length = (float)Math.Sqrt(dx * dx + dy * dy);
                dx /= length;
                dy /= length;


                player.vX += dx * 0.5f;
                player.vY += dy * 0.5f;


                player.Angle = 90 - (float)Math.Atan2(player.vX, player.vY) * 180 / (float)Math.PI;
            }


            player.vX += -player.vX * 0.1f;
            player.vY += -player.vY * 0.1f;


            player.X += player.vX;
            player.Y += player.vY;

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            pbMain.Invalidate();
        }

        private void pbMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (marker == null)
            {
                marker = new Marker(0, 0, 0);
                objects.Add(marker);
            }

            marker.X = e.X;
            marker.Y = e.Y;
        }

        private void pbMain_Click_1(object sender, EventArgs e)
        {

        }

       
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
