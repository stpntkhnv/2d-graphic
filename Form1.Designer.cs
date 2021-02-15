
namespace _2d_graphic
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.OpenFractals_button = new System.Windows.Forms.Button();
            this.OpenFill_button = new System.Windows.Forms.Button();
            this.OpenGeometricTransformation_button = new System.Windows.Forms.Button();
            this.OpenVectorButton = new System.Windows.Forms.Button();
            this.OpenOtrezkiButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OpenFractals_button
            // 
            this.OpenFractals_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OpenFractals_button.Location = new System.Drawing.Point(93, 95);
            this.OpenFractals_button.Name = "OpenFractals_button";
            this.OpenFractals_button.Size = new System.Drawing.Size(285, 80);
            this.OpenFractals_button.TabIndex = 0;
            this.OpenFractals_button.Text = "Фракталы";
            this.OpenFractals_button.UseVisualStyleBackColor = true;
            this.OpenFractals_button.Click += new System.EventHandler(this.OpenFractals_button_Click);
            // 
            // OpenFill_button
            // 
            this.OpenFill_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OpenFill_button.Location = new System.Drawing.Point(565, 95);
            this.OpenFill_button.Name = "OpenFill_button";
            this.OpenFill_button.Size = new System.Drawing.Size(285, 80);
            this.OpenFill_button.TabIndex = 1;
            this.OpenFill_button.Text = "Заливка затравкой";
            this.OpenFill_button.UseVisualStyleBackColor = true;
            this.OpenFill_button.Click += new System.EventHandler(this.OpenFill_button_Click);
            // 
            // OpenGeometricTransformation_button
            // 
            this.OpenGeometricTransformation_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OpenGeometricTransformation_button.Location = new System.Drawing.Point(1041, 95);
            this.OpenGeometricTransformation_button.Name = "OpenGeometricTransformation_button";
            this.OpenGeometricTransformation_button.Size = new System.Drawing.Size(285, 80);
            this.OpenGeometricTransformation_button.TabIndex = 2;
            this.OpenGeometricTransformation_button.Text = "Геометрические преобразования";
            this.OpenGeometricTransformation_button.UseVisualStyleBackColor = true;
            this.OpenGeometricTransformation_button.Click += new System.EventHandler(this.OpenGeometricTransformation_button_Click);
            // 
            // OpenVectorButton
            // 
            this.OpenVectorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OpenVectorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.OpenVectorButton.Location = new System.Drawing.Point(93, 231);
            this.OpenVectorButton.Name = "OpenVectorButton";
            this.OpenVectorButton.Size = new System.Drawing.Size(285, 80);
            this.OpenVectorButton.TabIndex = 3;
            this.OpenVectorButton.Text = "Вектор в растр";
            this.OpenVectorButton.UseVisualStyleBackColor = true;
            this.OpenVectorButton.Click += new System.EventHandler(this.OpenVectorButton_Click);
            // 
            // OpenOtrezkiButton
            // 
            this.OpenOtrezkiButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OpenOtrezkiButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.OpenOtrezkiButton.Location = new System.Drawing.Point(565, 231);
            this.OpenOtrezkiButton.Name = "OpenOtrezkiButton";
            this.OpenOtrezkiButton.Size = new System.Drawing.Size(285, 80);
            this.OpenOtrezkiButton.TabIndex = 4;
            this.OpenOtrezkiButton.Text = "Отсечение отрезков";
            this.OpenOtrezkiButton.UseVisualStyleBackColor = true;
            this.OpenOtrezkiButton.Click += new System.EventHandler(this.OpenOtrezkiButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Indigo;
            this.ClientSize = new System.Drawing.Size(1434, 784);
            this.Controls.Add(this.OpenOtrezkiButton);
            this.Controls.Add(this.OpenVectorButton);
            this.Controls.Add(this.OpenGeometricTransformation_button);
            this.Controls.Add(this.OpenFill_button);
            this.Controls.Add(this.OpenFractals_button);
            this.Name = "Form1";
            this.Text = "Tsikhanau Stsiapan";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OpenFractals_button;
        private System.Windows.Forms.Button OpenFill_button;
        private System.Windows.Forms.Button OpenGeometricTransformation_button;
        private System.Windows.Forms.Button OpenVectorButton;
        private System.Windows.Forms.Button OpenOtrezkiButton;
    }
}

