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
        MyRectangle myRect;
        List<BaseObject> objects = new List<BaseObject>();
        Player player;
        public Form1()
        {
            InitializeComponent();
            player = new Player(pbMain.Width / 2, pbMain.Height / 2, 0);
            objects.Add(player);
            objects.Add(new MyRectangle(50, 50, 0));
            objects.Add(new MyRectangle(100, 100, 45));
        }

        private void pbMain_Click(object sender, EventArgs e)
        {

        }

        private void pbMain_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            graphics.Clear(Color.White);
            foreach (var obj in objects)
            {
                graphics.Transform = myRect.GetTransform();
                obj.Render(graphics);
            }
            //myRect.Render(graphics);
        }
    }
}
