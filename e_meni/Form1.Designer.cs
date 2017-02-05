namespace e_meni
{
    partial class pocetna
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pocetna));
            this.ulaz = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ulaz
            // 
            this.ulaz.BackColor = System.Drawing.Color.Transparent;
            this.ulaz.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ulaz.BackgroundImage")));
            this.ulaz.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ulaz.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ulaz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ulaz.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ulaz.Location = new System.Drawing.Point(326, 293);
            this.ulaz.Name = "ulaz";
            this.ulaz.Size = new System.Drawing.Size(290, 80);
            this.ulaz.TabIndex = 0;
            this.ulaz.UseVisualStyleBackColor = false;
            this.ulaz.Click += new System.EventHandler(this.ulaz_Click);
            // 
            // pocetna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(944, 602);
            this.Controls.Add(this.ulaz);
            this.MaximizeBox = false;
            this.Name = "pocetna";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ulaz;
    }
}

