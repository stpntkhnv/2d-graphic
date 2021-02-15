
namespace _2d_graphic.Windows
{
    partial class Fill
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
            this.picturebox = new System.Windows.Forms.PictureBox();
            this.Filling = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // picturebox
            // 
            this.picturebox.Location = new System.Drawing.Point(3, 3);
            this.picturebox.Name = "picturebox";
            this.picturebox.Size = new System.Drawing.Size(1896, 1046);
            this.picturebox.TabIndex = 1;
            this.picturebox.TabStop = false;
            this.picturebox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picturebox_MouseClick);
            this.picturebox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picturebox_MouseMove);
            // 
            // Filling
            // 
            this.Filling.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Filling.Location = new System.Drawing.Point(1660, 936);
            this.Filling.Name = "Filling";
            this.Filling.Size = new System.Drawing.Size(232, 93);
            this.Filling.TabIndex = 2;
            this.Filling.Text = "Залить";
            this.Filling.UseVisualStyleBackColor = true;
            this.Filling.Click += new System.EventHandler(this.Filling_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(1324, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(1324, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "label2";
            // 
            // Fill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Indigo;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Filling);
            this.Controls.Add(this.picturebox);
            this.Name = "Fill";
            this.Text = "Fill";
            this.Leave += new System.EventHandler(this.Fill_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.picturebox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picturebox;
        private System.Windows.Forms.Button Filling;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}