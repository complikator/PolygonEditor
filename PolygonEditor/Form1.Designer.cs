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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.addPolygonRadio = new System.Windows.Forms.RadioButton();
            this.AddRemoveVertexRadio = new System.Windows.Forms.RadioButton();
            this.MoveElementsRadio = new System.Windows.Forms.RadioButton();
            this.MovePolygonRadio = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.radioButtonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.Controls.Add(this.canvas, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.White;
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(3, 3);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(644, 444);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonsPanel);
            this.groupBox1.Location = new System.Drawing.Point(653, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(144, 222);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mode";
            // 
            // radioButtonsPanel
            // 
            this.radioButtonsPanel.ColumnCount = 1;
            this.radioButtonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.radioButtonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.radioButtonsPanel.Controls.Add(this.addPolygonRadio, 0, 0);
            this.radioButtonsPanel.Controls.Add(this.AddRemoveVertexRadio, 0, 1);
            this.radioButtonsPanel.Controls.Add(this.MoveElementsRadio, 0, 2);
            this.radioButtonsPanel.Controls.Add(this.MovePolygonRadio, 0, 3);
            this.radioButtonsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonsPanel.Location = new System.Drawing.Point(3, 16);
            this.radioButtonsPanel.Name = "radioButtonsPanel";
            this.radioButtonsPanel.RowCount = 4;
            this.radioButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.radioButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.radioButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.radioButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.radioButtonsPanel.Size = new System.Drawing.Size(138, 203);
            this.radioButtonsPanel.TabIndex = 0;
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
            // AddRemoveVertexRadio
            // 
            this.AddRemoveVertexRadio.AutoSize = true;
            this.AddRemoveVertexRadio.Location = new System.Drawing.Point(3, 53);
            this.AddRemoveVertexRadio.Name = "AddRemoveVertexRadio";
            this.AddRemoveVertexRadio.Size = new System.Drawing.Size(122, 17);
            this.AddRemoveVertexRadio.TabIndex = 1;
            this.AddRemoveVertexRadio.TabStop = true;
            this.AddRemoveVertexRadio.Text = "Add/Remove Vertex";
            this.AddRemoveVertexRadio.UseVisualStyleBackColor = true;
            this.AddRemoveVertexRadio.CheckedChanged += new System.EventHandler(this.AddRemoveVertexRadio_CheckedChanged);
            // 
            // MoveElementsRadio
            // 
            this.MoveElementsRadio.AutoSize = true;
            this.MoveElementsRadio.Location = new System.Drawing.Point(3, 103);
            this.MoveElementsRadio.Name = "MoveElementsRadio";
            this.MoveElementsRadio.Size = new System.Drawing.Size(98, 17);
            this.MoveElementsRadio.TabIndex = 2;
            this.MoveElementsRadio.TabStop = true;
            this.MoveElementsRadio.Text = "Move Elements";
            this.MoveElementsRadio.UseVisualStyleBackColor = true;
            this.MoveElementsRadio.CheckedChanged += new System.EventHandler(this.MoveElementsRadio_CheckedChanged);
            // 
            // MovePolygonRadio
            // 
            this.MovePolygonRadio.AutoSize = true;
            this.MovePolygonRadio.Location = new System.Drawing.Point(3, 153);
            this.MovePolygonRadio.Name = "MovePolygonRadio";
            this.MovePolygonRadio.Size = new System.Drawing.Size(93, 17);
            this.MovePolygonRadio.TabIndex = 3;
            this.MovePolygonRadio.TabStop = true;
            this.MovePolygonRadio.Text = "Move Polygon";
            this.MovePolygonRadio.UseVisualStyleBackColor = true;
            this.MovePolygonRadio.CheckedChanged += new System.EventHandler(this.MovePolygonRadio_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.radioButtonsPanel.ResumeLayout(false);
            this.radioButtonsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel radioButtonsPanel;
        private System.Windows.Forms.RadioButton addPolygonRadio;
        private System.Windows.Forms.RadioButton AddRemoveVertexRadio;
        private System.Windows.Forms.RadioButton MoveElementsRadio;
        private System.Windows.Forms.RadioButton MovePolygonRadio;
    }
}

