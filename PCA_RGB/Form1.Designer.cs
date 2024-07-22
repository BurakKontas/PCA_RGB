namespace PCA_RGB
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
            this.image1 = new System.Windows.Forms.PictureBox();
            this.LoadImage1 = new System.Windows.Forms.Button();
            this.LoadImage2 = new System.Windows.Forms.Button();
            this.image2 = new System.Windows.Forms.PictureBox();
            this.PCA_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.image1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.image2)).BeginInit();
            this.SuspendLayout();
            // 
            // image1
            // 
            this.image1.Location = new System.Drawing.Point(12, 43);
            this.image1.Name = "image1";
            this.image1.Size = new System.Drawing.Size(375, 395);
            this.image1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.image1.TabIndex = 0;
            this.image1.TabStop = false;
            // 
            // LoadImage1
            // 
            this.LoadImage1.Location = new System.Drawing.Point(145, 12);
            this.LoadImage1.Name = "LoadImage1";
            this.LoadImage1.Size = new System.Drawing.Size(75, 23);
            this.LoadImage1.TabIndex = 1;
            this.LoadImage1.Text = "LoadImage1";
            this.LoadImage1.UseVisualStyleBackColor = true;
            this.LoadImage1.Click += new System.EventHandler(this.LoadImage1_Click);
            // 
            // LoadImage2
            // 
            this.LoadImage2.Location = new System.Drawing.Point(570, 12);
            this.LoadImage2.Name = "LoadImage2";
            this.LoadImage2.Size = new System.Drawing.Size(75, 23);
            this.LoadImage2.TabIndex = 2;
            this.LoadImage2.Text = "LoadImage2";
            this.LoadImage2.UseVisualStyleBackColor = true;
            this.LoadImage2.Click += new System.EventHandler(this.LoadImage2_Click);
            // 
            // image2
            // 
            this.image2.Location = new System.Drawing.Point(413, 41);
            this.image2.Name = "image2";
            this.image2.Size = new System.Drawing.Size(375, 395);
            this.image2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.image2.TabIndex = 3;
            this.image2.TabStop = false;
            // 
            // PCA_Button
            // 
            this.PCA_Button.Location = new System.Drawing.Point(363, 12);
            this.PCA_Button.Name = "PCA_Button";
            this.PCA_Button.Size = new System.Drawing.Size(75, 23);
            this.PCA_Button.TabIndex = 4;
            this.PCA_Button.Text = "PCA";
            this.PCA_Button.UseVisualStyleBackColor = true;
            this.PCA_Button.Click += new System.EventHandler(this.PCA_Button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PCA_Button);
            this.Controls.Add(this.image2);
            this.Controls.Add(this.LoadImage2);
            this.Controls.Add(this.LoadImage1);
            this.Controls.Add(this.image1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.image1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.image2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox image1;
        private System.Windows.Forms.Button LoadImage1;
        private System.Windows.Forms.Button LoadImage2;
        private System.Windows.Forms.PictureBox image2;
        private System.Windows.Forms.Button PCA_Button;
    }
}

