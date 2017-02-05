namespace e_meni
{
    partial class internet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(internet));
            this.home = new System.Windows.Forms.Button();
            this.igrica = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // home
            // 
            this.home.BackColor = System.Drawing.Color.Transparent;
            this.home.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("home.BackgroundImage")));
            this.home.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.home.FlatAppearance.BorderSize = 0;
            this.home.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.home.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.home.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.home.Location = new System.Drawing.Point(356, 491);
            this.home.Name = "home";
            this.home.Size = new System.Drawing.Size(84, 69);
            this.home.TabIndex = 0;
            this.home.UseVisualStyleBackColor = false;
            this.home.Click += new System.EventHandler(this.home_Click);
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
            this.igrica.Location = new System.Drawing.Point(506, 491);
            this.igrica.Name = "igrica";
            this.igrica.Size = new System.Drawing.Size(86, 69);
            this.igrica.TabIndex = 1;
            this.igrica.UseVisualStyleBackColor = false;
            this.igrica.Click += new System.EventHandler(this.igrica_Click);
            // 
            // internet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(944, 602);
            this.Controls.Add(this.igrica);
            this.Controls.Add(this.home);
            this.MaximizeBox = false;
            this.Name = "internet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button home;
        private System.Windows.Forms.Button igrica;
    }
}