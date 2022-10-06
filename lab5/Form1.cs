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
        public Form1()
        {
            InitializeComponent();
            myRect = new MyRectangle(100, 100, 0);
        }

        private void pbMain_Click(object sender, EventArgs e)
        {

        }

        private void pbMain_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            graphics.Clear(Color.White);
            var matrix = graphics.Transform;
            matrix.Translate(myRect.X, myRect.Y); 
            graphics.Transform = matrix;
            myRect.Render(graphics);
        }
    }
}
