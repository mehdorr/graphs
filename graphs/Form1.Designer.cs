namespace graphs
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
            this.pboxGraph = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDraw = new System.Windows.Forms.Button();
            this.btnSnowflake = new System.Windows.Forms.Button();
            this.btnFern = new System.Windows.Forms.Button();
            this.tbarXmin = new System.Windows.Forms.TrackBar();
            this.tbarXmax = new System.Windows.Forms.TrackBar();
            this.tbarYmin = new System.Windows.Forms.TrackBar();
            this.tbarYmax = new System.Windows.Forms.TrackBar();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbarDepth = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pboxGraph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarXmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarXmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarYmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarYmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarDepth)).BeginInit();
            this.SuspendLayout();
            // 
            // pboxGraph
            // 
            this.pboxGraph.BackColor = System.Drawing.Color.White;
            this.pboxGraph.Dock = System.Windows.Forms.DockStyle.Top;
            this.pboxGraph.Location = new System.Drawing.Point(0, 0);
            this.pboxGraph.Name = "pboxGraph";
            this.pboxGraph.Size = new System.Drawing.Size(484, 384);
            this.pboxGraph.TabIndex = 0;
            this.pboxGraph.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 393);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "X min";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 426);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "X max";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(106, 393);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Y min";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(107, 426);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Y max";
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(208, 390);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(75, 27);
            this.btnDraw.TabIndex = 9;
            this.btnDraw.Text = "Draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // btnSnowflake
            // 
            this.btnSnowflake.Location = new System.Drawing.Point(208, 419);
            this.btnSnowflake.Name = "btnSnowflake";
            this.btnSnowflake.Size = new System.Drawing.Size(75, 27);
            this.btnSnowflake.TabIndex = 10;
            this.btnSnowflake.Text = "Snowflake";
            this.btnSnowflake.UseVisualStyleBackColor = true;
            this.btnSnowflake.Click += new System.EventHandler(this.btnSnowflake_Click);
            // 
            // btnFern
            // 
            this.btnFern.Location = new System.Drawing.Point(289, 390);
            this.btnFern.Name = "btnFern";
            this.btnFern.Size = new System.Drawing.Size(75, 27);
            this.btnFern.TabIndex = 11;
            this.btnFern.Text = "Fern";
            this.btnFern.UseVisualStyleBackColor = true;
            this.btnFern.Click += new System.EventHandler(this.btnFern_Click);
            // 
            // tbarXmin
            // 
            this.tbarXmin.AutoSize = false;
            this.tbarXmin.LargeChange = 1;
            this.tbarXmin.Location = new System.Drawing.Point(43, 393);
            this.tbarXmin.Minimum = 1;
            this.tbarXmin.Name = "tbarXmin";
            this.tbarXmin.Size = new System.Drawing.Size(57, 16);
            this.tbarXmin.TabIndex = 12;
            this.tbarXmin.Value = 2;
            // 
            // tbarXmax
            // 
            this.tbarXmax.AutoSize = false;
            this.tbarXmax.LargeChange = 1;
            this.tbarXmax.Location = new System.Drawing.Point(44, 427);
            this.tbarXmax.Minimum = 1;
            this.tbarXmax.Name = "tbarXmax";
            this.tbarXmax.Size = new System.Drawing.Size(57, 16);
            this.tbarXmax.TabIndex = 13;
            this.tbarXmax.Value = 2;
            // 
            // tbarYmin
            // 
            this.tbarYmin.AutoSize = false;
            this.tbarYmin.LargeChange = 1;
            this.tbarYmin.Location = new System.Drawing.Point(145, 393);
            this.tbarYmin.Minimum = 1;
            this.tbarYmin.Name = "tbarYmin";
            this.tbarYmin.Size = new System.Drawing.Size(57, 16);
            this.tbarYmin.TabIndex = 14;
            this.tbarYmin.Value = 3;
            // 
            // tbarYmax
            // 
            this.tbarYmax.AutoSize = false;
            this.tbarYmax.LargeChange = 1;
            this.tbarYmax.Location = new System.Drawing.Point(145, 427);
            this.tbarYmax.Minimum = 1;
            this.tbarYmax.Name = "tbarYmax";
            this.tbarYmax.Size = new System.Drawing.Size(57, 16);
            this.tbarYmax.TabIndex = 15;
            this.tbarYmax.Value = 3;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(397, 390);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 53);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save as Image";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbarDepth
            // 
            this.tbarDepth.AutoSize = false;
            this.tbarDepth.LargeChange = 1;
            this.tbarDepth.Location = new System.Drawing.Point(289, 419);
            this.tbarDepth.Maximum = 5;
            this.tbarDepth.Minimum = 1;
            this.tbarDepth.Name = "tbarDepth";
            this.tbarDepth.Size = new System.Drawing.Size(75, 16);
            this.tbarDepth.TabIndex = 17;
            this.tbarDepth.Value = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(286, 438);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Snowflake Depth";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 451);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbarDepth);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbarYmax);
            this.Controls.Add(this.tbarYmin);
            this.Controls.Add(this.tbarXmax);
            this.Controls.Add(this.tbarXmin);
            this.Controls.Add(this.btnFern);
            this.Controls.Add(this.btnSnowflake);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pboxGraph);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Graphs";
            ((System.ComponentModel.ISupportInitialize)(this.pboxGraph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarXmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarXmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarYmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarYmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarDepth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pboxGraph;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.Button btnSnowflake;
        private System.Windows.Forms.Button btnFern;
        private System.Windows.Forms.TrackBar tbarXmin;
        private System.Windows.Forms.TrackBar tbarXmax;
        private System.Windows.Forms.TrackBar tbarYmin;
        private System.Windows.Forms.TrackBar tbarYmax;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TrackBar tbarDepth;
        private System.Windows.Forms.Label label5;
    }
}

