namespace PolygonEditor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.rightPanel = new System.Windows.Forms.TableLayoutPanel();
            this.modeBox = new System.Windows.Forms.GroupBox();
            this.modePanel = new System.Windows.Forms.TableLayoutPanel();
            this.addPolygonRadio = new System.Windows.Forms.RadioButton();
            this.addRemoveVertexRadio = new System.Windows.Forms.RadioButton();
            this.moveElementsRadio = new System.Windows.Forms.RadioButton();
            this.movePolygonRadio = new System.Windows.Forms.RadioButton();
            this.perpendicularRadio = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.drawingTypeBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.libraryDrawingRadio = new System.Windows.Forms.RadioButton();
            this.bresenhamDrawingRadio = new System.Windows.Forms.RadioButton();
            this.removeConstraintsRadio = new System.Windows.Forms.RadioButton();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.rightPanel.SuspendLayout();
            this.modeBox.SuspendLayout();
            this.modePanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.drawingTypeBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.ColumnCount = 2;
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.mainPanel.Controls.Add(this.canvas, 0, 0);
            this.mainPanel.Controls.Add(this.rightPanel, 1, 0);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.RowCount = 1;
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainPanel.Size = new System.Drawing.Size(1155, 672);
            this.mainPanel.TabIndex = 0;
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.White;
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(3, 3);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(999, 666);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.SizeChanged += new System.EventHandler(this.canvas_SizeChanged);
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
            // 
            // rightPanel
            // 
            this.rightPanel.ColumnCount = 1;
            this.rightPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rightPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.rightPanel.Controls.Add(this.modeBox, 0, 0);
            this.rightPanel.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightPanel.Location = new System.Drawing.Point(1008, 3);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.RowCount = 2;
            this.rightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.rightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.rightPanel.Size = new System.Drawing.Size(144, 666);
            this.rightPanel.TabIndex = 1;
            // 
            // modeBox
            // 
            this.modeBox.Controls.Add(this.modePanel);
            this.modeBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modeBox.Location = new System.Drawing.Point(3, 3);
            this.modeBox.Name = "modeBox";
            this.modeBox.Size = new System.Drawing.Size(138, 327);
            this.modeBox.TabIndex = 0;
            this.modeBox.TabStop = false;
            this.modeBox.Text = "Mode";
            // 
            // modePanel
            // 
            this.modePanel.ColumnCount = 1;
            this.modePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.modePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.modePanel.Controls.Add(this.addPolygonRadio, 0, 0);
            this.modePanel.Controls.Add(this.addRemoveVertexRadio, 0, 1);
            this.modePanel.Controls.Add(this.moveElementsRadio, 0, 2);
            this.modePanel.Controls.Add(this.movePolygonRadio, 0, 3);
            this.modePanel.Controls.Add(this.perpendicularRadio, 0, 4);
            this.modePanel.Controls.Add(this.removeConstraintsRadio, 0, 5);
            this.modePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modePanel.Location = new System.Drawing.Point(3, 16);
            this.modePanel.Name = "modePanel";
            this.modePanel.RowCount = 6;
            this.modePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.modePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.modePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.modePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.modePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.modePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.modePanel.Size = new System.Drawing.Size(132, 308);
            this.modePanel.TabIndex = 0;
            // 
            // addPolygonRadio
            // 
            this.addPolygonRadio.AutoSize = true;
            this.addPolygonRadio.Location = new System.Drawing.Point(3, 3);
            this.addPolygonRadio.Name = "addPolygonRadio";
            this.addPolygonRadio.Size = new System.Drawing.Size(85, 17);
            this.addPolygonRadio.TabIndex = 0;
            this.addPolygonRadio.TabStop = true;
            this.addPolygonRadio.Text = "Add Polygon";
            this.addPolygonRadio.UseVisualStyleBackColor = true;
            this.addPolygonRadio.CheckedChanged += new System.EventHandler(this.addPolygonRadio_CheckedChanged);
            // 
            // addRemoveVertexRadio
            // 
            this.addRemoveVertexRadio.AutoSize = true;
            this.addRemoveVertexRadio.Location = new System.Drawing.Point(3, 54);
            this.addRemoveVertexRadio.Name = "addRemoveVertexRadio";
            this.addRemoveVertexRadio.Size = new System.Drawing.Size(126, 17);
            this.addRemoveVertexRadio.TabIndex = 1;
            this.addRemoveVertexRadio.TabStop = true;
            this.addRemoveVertexRadio.Text = "Add / Remove Vertex";
            this.addRemoveVertexRadio.UseVisualStyleBackColor = true;
            this.addRemoveVertexRadio.CheckedChanged += new System.EventHandler(this.AddRemoveVertexRadio_CheckedChanged);
            // 
            // moveElementsRadio
            // 
            this.moveElementsRadio.AutoSize = true;
            this.moveElementsRadio.Location = new System.Drawing.Point(3, 105);
            this.moveElementsRadio.Name = "moveElementsRadio";
            this.moveElementsRadio.Size = new System.Drawing.Size(98, 17);
            this.moveElementsRadio.TabIndex = 2;
            this.moveElementsRadio.TabStop = true;
            this.moveElementsRadio.Text = "Move Elements";
            this.moveElementsRadio.UseVisualStyleBackColor = true;
            this.moveElementsRadio.CheckedChanged += new System.EventHandler(this.MoveElementsRadio_CheckedChanged);
            // 
            // movePolygonRadio
            // 
            this.movePolygonRadio.AutoSize = true;
            this.movePolygonRadio.Location = new System.Drawing.Point(3, 156);
            this.movePolygonRadio.Name = "movePolygonRadio";
            this.movePolygonRadio.Size = new System.Drawing.Size(93, 17);
            this.movePolygonRadio.TabIndex = 3;
            this.movePolygonRadio.TabStop = true;
            this.movePolygonRadio.Text = "Move Polygon";
            this.movePolygonRadio.UseVisualStyleBackColor = true;
            this.movePolygonRadio.CheckedChanged += new System.EventHandler(this.MovePolygonRadio_CheckedChanged);
            // 
            // perpendicularRadio
            // 
            this.perpendicularRadio.AutoSize = true;
            this.perpendicularRadio.Location = new System.Drawing.Point(3, 207);
            this.perpendicularRadio.Name = "perpendicularRadio";
            this.perpendicularRadio.Size = new System.Drawing.Size(94, 17);
            this.perpendicularRadio.TabIndex = 4;
            this.perpendicularRadio.TabStop = true;
            this.perpendicularRadio.Text = "Add Constraint";
            this.perpendicularRadio.UseVisualStyleBackColor = true;
            this.perpendicularRadio.CheckedChanged += new System.EventHandler(this.perpendicularRadio_CheckedChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.drawingTypeBox, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 336);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(138, 327);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // drawingTypeBox
            // 
            this.drawingTypeBox.Controls.Add(this.tableLayoutPanel2);
            this.drawingTypeBox.Location = new System.Drawing.Point(3, 166);
            this.drawingTypeBox.Name = "drawingTypeBox";
            this.drawingTypeBox.Size = new System.Drawing.Size(132, 100);
            this.drawingTypeBox.TabIndex = 0;
            this.drawingTypeBox.TabStop = false;
            this.drawingTypeBox.Text = "DrawingType";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.libraryDrawingRadio, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.bresenhamDrawingRadio, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(126, 81);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // libraryDrawingRadio
            // 
            this.libraryDrawingRadio.AutoSize = true;
            this.libraryDrawingRadio.Checked = true;
            this.libraryDrawingRadio.Location = new System.Drawing.Point(3, 3);
            this.libraryDrawingRadio.Name = "libraryDrawingRadio";
            this.libraryDrawingRadio.Size = new System.Drawing.Size(56, 17);
            this.libraryDrawingRadio.TabIndex = 0;
            this.libraryDrawingRadio.TabStop = true;
            this.libraryDrawingRadio.Text = "Library";
            this.libraryDrawingRadio.UseVisualStyleBackColor = true;
            this.libraryDrawingRadio.CheckedChanged += new System.EventHandler(this.libraryDrawingRadio_CheckedChanged);
            // 
            // bresenhamDrawingRadio
            // 
            this.bresenhamDrawingRadio.AutoSize = true;
            this.bresenhamDrawingRadio.Location = new System.Drawing.Point(3, 43);
            this.bresenhamDrawingRadio.Name = "bresenhamDrawingRadio";
            this.bresenhamDrawingRadio.Size = new System.Drawing.Size(78, 17);
            this.bresenhamDrawingRadio.TabIndex = 1;
            this.bresenhamDrawingRadio.Text = "Bresenham";
            this.bresenhamDrawingRadio.UseVisualStyleBackColor = true;
            this.bresenhamDrawingRadio.CheckedChanged += new System.EventHandler(this.bresenhamDrawingRadio_CheckedChanged);
            // 
            // removeConstraintsRadio
            // 
            this.removeConstraintsRadio.AutoSize = true;
            this.removeConstraintsRadio.Location = new System.Drawing.Point(3, 258);
            this.removeConstraintsRadio.Name = "removeConstraintsRadio";
            this.removeConstraintsRadio.Size = new System.Drawing.Size(115, 17);
            this.removeConstraintsRadio.TabIndex = 5;
            this.removeConstraintsRadio.TabStop = true;
            this.removeConstraintsRadio.Text = "Remove Constraint";
            this.removeConstraintsRadio.UseVisualStyleBackColor = true;
            this.removeConstraintsRadio.CheckedChanged += new System.EventHandler(this.removeConstraintsRadio_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 672);
            this.Controls.Add(this.mainPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.rightPanel.ResumeLayout(false);
            this.modeBox.ResumeLayout(false);
            this.modePanel.ResumeLayout(false);
            this.modePanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.drawingTypeBox.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainPanel;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.TableLayoutPanel rightPanel;
        private System.Windows.Forms.GroupBox modeBox;
        private System.Windows.Forms.TableLayoutPanel modePanel;
        private System.Windows.Forms.RadioButton addPolygonRadio;
        private System.Windows.Forms.RadioButton addRemoveVertexRadio;
        private System.Windows.Forms.RadioButton moveElementsRadio;
        private System.Windows.Forms.RadioButton movePolygonRadio;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox drawingTypeBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.RadioButton libraryDrawingRadio;
        private System.Windows.Forms.RadioButton bresenhamDrawingRadio;
        private System.Windows.Forms.RadioButton perpendicularRadio;
        private System.Windows.Forms.RadioButton removeConstraintsRadio;
    }
}

