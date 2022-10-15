using PolygonEditor.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolygonEditor
{
    public partial class Form1 : Form
    {
        Manager manager;
        public Form1()
        {
            InitializeComponent();

            manager = new Manager(canvas);
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                manager.screenCatcher.LeftMouseDown(e.X, e.Y);
            }
            if (e.Button == MouseButtons.Right)
            {
                manager.screenCatcher.RightMouseDown(e.X, e.Y);
            }
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                manager.screenCatcher.LeftMouseUp(e.X, e.Y);
            }
            if (e.Button == MouseButtons.Right)
            {
                manager.screenCatcher.RightMouseUp(e.X, e.Y);
            }
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void AddRemoveVertexRadio_CheckedChanged(Object sender, EventArgs e)
        {
            if (AddRemoveVertexRadio.Checked)
            {
                manager.ChangeMode(Mode.AddRemoveVertex);
            }
        }

        private void addPolygonRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (addPolygonRadio.Checked)
            {
                manager.ChangeMode(Mode.AddPolygon);
            }
        }
    }
}
