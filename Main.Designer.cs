using System;

namespace PDFAnalyzer
{
    partial class Main
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.RealtimeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.AnalyzePDFButton = new System.Windows.Forms.Button();
            this.AnalyzeFolderButton = new System.Windows.Forms.Button();
            this.QuarantineButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.RestoreButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.Home = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.WhitelistButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RealtimeButton
            // 
            this.RealtimeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RealtimeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RealtimeButton.Location = new System.Drawing.Point(261, 184);
            this.RealtimeButton.Name = "RealtimeButton";
            this.RealtimeButton.Size = new System.Drawing.Size(161, 68);
            this.RealtimeButton.TabIndex = 0;
            this.RealtimeButton.Text = "Real-Time Protection: ON";
            this.RealtimeButton.UseVisualStyleBackColor = true;
            this.RealtimeButton.Click += new System.EventHandler(this.realtimeButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(387, 560);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Developed by Fabio - Jr. Malware Analyst at Zemana Ltd.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(581, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "This program in real-time checks for new PDF files (for example downloaded files)" +
    " and analyze different suspicious patterns";
            // 
            // AnalyzePDFButton
            // 
            this.AnalyzePDFButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AnalyzePDFButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnalyzePDFButton.Location = new System.Drawing.Point(15, 184);
            this.AnalyzePDFButton.Name = "AnalyzePDFButton";
            this.AnalyzePDFButton.Size = new System.Drawing.Size(161, 68);
            this.AnalyzePDFButton.TabIndex = 3;
            this.AnalyzePDFButton.Text = "Analyze a PDF";
            this.AnalyzePDFButton.UseVisualStyleBackColor = true;
            this.AnalyzePDFButton.Click += new System.EventHandler(this.analyzePDFButton_Click);
            // 
            // AnalyzeFolderButton
            // 
            this.AnalyzeFolderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AnalyzeFolderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnalyzeFolderButton.Location = new System.Drawing.Point(503, 184);
            this.AnalyzeFolderButton.Name = "AnalyzeFolderButton";
            this.AnalyzeFolderButton.Size = new System.Drawing.Size(161, 68);
            this.AnalyzeFolderButton.TabIndex = 4;
            this.AnalyzeFolderButton.Text = "Analyze a folder of PDFs";
            this.AnalyzeFolderButton.UseVisualStyleBackColor = true;
            this.AnalyzeFolderButton.Click += new System.EventHandler(this.analyzeFolderButton_Click);
            // 
            // QuarantineButton
            // 
            this.QuarantineButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.QuarantineButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuarantineButton.Location = new System.Drawing.Point(15, 333);
            this.QuarantineButton.Name = "QuarantineButton";
            this.QuarantineButton.Size = new System.Drawing.Size(161, 58);
            this.QuarantineButton.TabIndex = 5;
            this.QuarantineButton.Text = "Quarantine";
            this.QuarantineButton.UseVisualStyleBackColor = true;
            this.QuarantineButton.Click += new System.EventHandler(this.quarantineButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(652, 459);
            this.listBox1.TabIndex = 6;
            this.listBox1.Visible = false;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // RestoreButton
            // 
            this.RestoreButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RestoreButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RestoreButton.Location = new System.Drawing.Point(503, 508);
            this.RestoreButton.Name = "RestoreButton";
            this.RestoreButton.Size = new System.Drawing.Size(161, 34);
            this.RestoreButton.TabIndex = 7;
            this.RestoreButton.Text = "Restore";
            this.RestoreButton.UseVisualStyleBackColor = true;
            this.RestoreButton.Visible = false;
            this.RestoreButton.Click += new System.EventHandler(this.restoreButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButton.Location = new System.Drawing.Point(261, 508);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(161, 34);
            this.DeleteButton.TabIndex = 8;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Visible = false;
            this.DeleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // Home
            // 
            this.Home.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Home.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Home.Location = new System.Drawing.Point(15, 508);
            this.Home.Name = "Home";
            this.Home.Size = new System.Drawing.Size(161, 34);
            this.Home.TabIndex = 9;
            this.Home.Text = "Home";
            this.Home.UseVisualStyleBackColor = true;
            this.Home.Visible = false;
            this.Home.Click += new System.EventHandler(this.home_Button);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(201, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(298, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "Analyzing folder, please wait..";
            this.label3.Visible = false;
            // 
            // WhitelistButton
            // 
            this.WhitelistButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WhitelistButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WhitelistButton.Location = new System.Drawing.Point(261, 333);
            this.WhitelistButton.Name = "WhitelistButton";
            this.WhitelistButton.Size = new System.Drawing.Size(161, 58);
            this.WhitelistButton.TabIndex = 11;
            this.WhitelistButton.Text = "Clear whitelist";
            this.WhitelistButton.UseVisualStyleBackColor = true;
            this.WhitelistButton.Click += new System.EventHandler(this.whitelistButton_Click);
            // 
            // label4
            // 
            this.label4.Image = global::PDFAnalyzer.Properties.Resources.download;
            this.label4.Location = new System.Drawing.Point(238, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(215, 60);
            this.label4.TabIndex = 12;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(676, 582);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.WhitelistButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Home);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.RestoreButton);
            this.Controls.Add(this.QuarantineButton);
            this.Controls.Add(this.AnalyzeFolderButton);
            this.Controls.Add(this.AnalyzePDFButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RealtimeButton);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PDFAnalyzer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        #endregion

        private System.Windows.Forms.Button RealtimeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Button AnalyzePDFButton;
        private System.Windows.Forms.Button AnalyzeFolderButton;
        private System.Windows.Forms.Button QuarantineButton;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button RestoreButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button Home;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button WhitelistButton;
        private System.Windows.Forms.Label label4;
    }
}

