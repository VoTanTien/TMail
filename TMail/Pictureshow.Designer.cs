
namespace TMail
{
    partial class Pictureshow
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
            this.guna2Panel_Head = new Guna.UI2.WinForms.Guna2Panel();
            this.pictureBox_EXIT = new System.Windows.Forms.PictureBox();
            this.guna2Button_Compose = new Guna.UI2.WinForms.Guna2Button();
            this.label_Head = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.guna2Panel_Head.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_EXIT)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel_Head
            // 
            this.guna2Panel_Head.Controls.Add(this.pictureBox_EXIT);
            this.guna2Panel_Head.Controls.Add(this.guna2Button_Compose);
            this.guna2Panel_Head.Controls.Add(this.label_Head);
            this.guna2Panel_Head.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel_Head.FillColor = System.Drawing.Color.SlateBlue;
            this.guna2Panel_Head.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel_Head.Name = "guna2Panel_Head";
            this.guna2Panel_Head.Size = new System.Drawing.Size(846, 45);
            this.guna2Panel_Head.TabIndex = 3;
            // 
            // pictureBox_EXIT
            // 
            this.pictureBox_EXIT.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_EXIT.BackgroundImage = global::TMail.Properties.Resources.Exit;
            this.pictureBox_EXIT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_EXIT.Location = new System.Drawing.Point(808, 3);
            this.pictureBox_EXIT.Name = "pictureBox_EXIT";
            this.pictureBox_EXIT.Size = new System.Drawing.Size(35, 36);
            this.pictureBox_EXIT.TabIndex = 3;
            this.pictureBox_EXIT.TabStop = false;
            this.pictureBox_EXIT.Click += new System.EventHandler(this.pictureBox_EXIT_Click);
            // 
            // guna2Button_Compose
            // 
            this.guna2Button_Compose.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button_Compose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.guna2Button_Compose.BorderColor = System.Drawing.Color.Transparent;
            this.guna2Button_Compose.BorderRadius = 15;
            this.guna2Button_Compose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2Button_Compose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button_Compose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button_Compose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button_Compose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button_Compose.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button_Compose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button_Compose.ForeColor = System.Drawing.Color.White;
            this.guna2Button_Compose.Image = global::TMail.Properties.Resources.compose;
            this.guna2Button_Compose.ImageSize = new System.Drawing.Size(30, 30);
            this.guna2Button_Compose.Location = new System.Drawing.Point(980, 9);
            this.guna2Button_Compose.Name = "guna2Button_Compose";
            this.guna2Button_Compose.Size = new System.Drawing.Size(52, 43);
            this.guna2Button_Compose.TabIndex = 15;
            // 
            // label_Head
            // 
            this.label_Head.AutoSize = true;
            this.label_Head.BackColor = System.Drawing.Color.Transparent;
            this.label_Head.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Head.ForeColor = System.Drawing.Color.White;
            this.label_Head.Location = new System.Drawing.Point(347, 9);
            this.label_Head.Name = "label_Head";
            this.label_Head.Size = new System.Drawing.Size(0, 30);
            this.label_Head.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(846, 500);
            this.panel1.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(846, 500);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Pictureshow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(846, 544);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.guna2Panel_Head);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Pictureshow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pictureshow";
            this.guna2Panel_Head.ResumeLayout(false);
            this.guna2Panel_Head.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_EXIT)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel_Head;
        private System.Windows.Forms.PictureBox pictureBox_EXIT;
        private Guna.UI2.WinForms.Guna2Button guna2Button_Compose;
        private System.Windows.Forms.Label label_Head;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}