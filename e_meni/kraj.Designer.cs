namespace e_meni
{
    partial class kraj
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(kraj));
            this.internet = new System.Windows.Forms.Button();
            this.igrica = new System.Windows.Forms.Button();
            this.home = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // internet
            // 
            this.internet.BackColor = System.Drawing.Color.Transparent;
            this.internet.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("internet.BackgroundImage")));
            this.internet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.internet.FlatAppearance.BorderSize = 0;
            this.internet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.internet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.internet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.internet.Location = new System.Drawing.Point(272, 457);
            this.internet.Name = "internet";
            this.internet.Size = new System.Drawing.Size(84, 68);
            this.internet.TabIndex = 1;
            this.internet.UseVisualStyleBackColor = false;
            this.internet.Click += new System.EventHandler(this.internet_Click);
            // 
            // igrica
            // 
            this.igrica.BackColor = System.Drawing.Color.Transparent;
            this.igrica.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("igrica.BackgroundImage")));
            this.igrica.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.igrica.FlatAppearance.BorderSize = 0;
            this.igrica.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.igrica.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.igrica.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.igrica.Location = new System.Drawing.Point(588, 457);
            this.igrica.Name = "igrica";
            this.igrica.Size = new System.Drawing.Size(85, 68);
            this.igrica.TabIndex = 2;
            this.igrica.UseVisualStyleBackColor = false;
            this.igrica.Click += new System.EventHandler(this.igrica_Click);
            // 
            // home
            // 
            this.home.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("home.BackgroundImage")));
            this.home.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.home.FlatAppearance.BorderSize = 0;
            this.home.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.home.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.home.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.home.Location = new System.Drawing.Point(429, 457);
            this.home.Name = "home";
            this.home.Size = new System.Drawing.Size(83, 68);
            this.home.TabIndex = 3;
            this.home.UseVisualStyleBackColor = true;
            this.home.Click += new System.EventHandler(this.home_Click);
            // 
            // kraj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(944, 602);
            this.Controls.Add(this.home);
            this.Controls.Add(this.igrica);
            this.Controls.Add(this.internet);
            this.MaximizeBox = false;
            this.Name = "kraj";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button internet;
        private System.Windows.Forms.Button igrica;
        private System.Windows.Forms.Button home;
    }
}