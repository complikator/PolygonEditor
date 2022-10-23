using PolygonEditor.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
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
            try
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
            catch (Exception ex)
            {
                messageError(ex.Message);
            }
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                messageError(ex.Message);
            }
        }

        private void messageError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                manager.screenCatcher.MouseMove(e.X, e.Y);
            }
            catch(Exception ex)
            {
                messageError(ex.Message);
            }
        }

        private void AddRemoveVertexRadio_CheckedChanged(Object sender, EventArgs e)
        {
            if (addRemoveVertexRadio.Checked)
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

        private void MoveElementsRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (moveElementsRadio.Checked)
            {
                manager.ChangeMode(Mode.MoveElements);
            }
        }

        private void MovePolygonRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (movePolygonRadio.Checked)
            {
                manager.ChangeMode(Mode.MovePolygon);
            }
        }

        private void perpendicularRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (perpendicularRadio.Checked)
            {
                manager.ChangeMode(Mode.AddConstraints);
            }
        }

        private void removeConstraintsRadio_CheckedChanged(object sender, EventArgs e)
        {
            manager.ChangeMode(Mode.RemoveConstraints);
        }

        private void canvas_SizeChanged(object sender, EventArgs e)
        {
            manager.ReinstallBoard();
        }

        private void bresenhamDrawingRadio_CheckedChanged(object sender, EventArgs e)
        {
            manager.ChangeDrawingType(DrawingType.Bresenham);
        }

        private void libraryDrawingRadio_CheckedChanged(object sender, EventArgs e)
        {
            manager.ChangeDrawingType(DrawingType.Library);
        }

    }
}
