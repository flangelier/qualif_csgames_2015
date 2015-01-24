namespace qualifcs
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
            this.txtpath = new System.Windows.Forms.TextBox();
            this.btnload = new System.Windows.Forms.Button();
            this.lstBoxPart = new System.Windows.Forms.ListBox();
            this.lstboxCompe = new System.Windows.Forms.ListBox();
            this.btnAssign = new System.Windows.Forms.Button();
            this.btnRetirer = new System.Windows.Forms.Button();
            this.btnHoraire = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtpath
            // 
            this.txtpath.Location = new System.Drawing.Point(12, 12);
            this.txtpath.Name = "txtpath";
            this.txtpath.Size = new System.Drawing.Size(100, 20);
            this.txtpath.TabIndex = 2;
            this.txtpath.Text = "config.json";
            // 
            // btnload
            // 
            this.btnload.Location = new System.Drawing.Point(118, 12);
            this.btnload.Name = "btnload";
            this.btnload.Size = new System.Drawing.Size(75, 23);
            this.btnload.TabIndex = 3;
            this.btnload.Text = "load";
            this.btnload.UseVisualStyleBackColor = true;
            this.btnload.Click += new System.EventHandler(this.btnload_Click);
            // 
            // lstBoxPart
            // 
            this.lstBoxPart.FormattingEnabled = true;
            this.lstBoxPart.Location = new System.Drawing.Point(12, 56);
            this.lstBoxPart.Name = "lstBoxPart";
            this.lstBoxPart.Size = new System.Drawing.Size(234, 316);
            this.lstBoxPart.TabIndex = 4;
            this.lstBoxPart.DoubleClick += new System.EventHandler(this.lstBoxPart_DoubleClick);
            // 
            // lstboxCompe
            // 
            this.lstboxCompe.FormattingEnabled = true;
            this.lstboxCompe.Location = new System.Drawing.Point(425, 56);
            this.lstboxCompe.Name = "lstboxCompe";
            this.lstboxCompe.Size = new System.Drawing.Size(234, 316);
            this.lstboxCompe.TabIndex = 5;
            this.lstboxCompe.DoubleClick += new System.EventHandler(this.lstboxCompe_DoubleClick);
            // 
            // btnAssign
            // 
            this.btnAssign.Location = new System.Drawing.Point(313, 97);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(75, 23);
            this.btnAssign.TabIndex = 6;
            this.btnAssign.Text = "Assigne";
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // btnRetirer
            // 
            this.btnRetirer.Location = new System.Drawing.Point(313, 126);
            this.btnRetirer.Name = "btnRetirer";
            this.btnRetirer.Size = new System.Drawing.Size(75, 23);
            this.btnRetirer.TabIndex = 7;
            this.btnRetirer.Text = "Retire";
            this.btnRetirer.UseVisualStyleBackColor = true;
            this.btnRetirer.Click += new System.EventHandler(this.btnRetirer_Click);
            // 
            // btnHoraire
            // 
            this.btnHoraire.Location = new System.Drawing.Point(304, 189);
            this.btnHoraire.Name = "btnHoraire";
            this.btnHoraire.Size = new System.Drawing.Size(75, 23);
            this.btnHoraire.TabIndex = 8;
            this.btnHoraire.Text = "horaire";
            this.btnHoraire.UseVisualStyleBackColor = true;
            this.btnHoraire.Click += new System.EventHandler(this.btnHoraire_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(199, 12);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 9;
            this.btnExport.Text = "export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 494);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnHoraire);
            this.Controls.Add(this.btnRetirer);
            this.Controls.Add(this.btnAssign);
            this.Controls.Add(this.lstboxCompe);
            this.Controls.Add(this.lstBoxPart);
            this.Controls.Add(this.btnload);
            this.Controls.Add(this.txtpath);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtpath;
        private System.Windows.Forms.Button btnload;
        private System.Windows.Forms.ListBox lstBoxPart;
        private System.Windows.Forms.ListBox lstboxCompe;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.Button btnRetirer;
        private System.Windows.Forms.Button btnHoraire;
        private System.Windows.Forms.Button btnExport;

    }
}

