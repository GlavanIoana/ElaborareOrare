
namespace proiectPAW
{
    partial class MeniuPrincipal
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.afiseazaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.importDinBazaDeDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disciplineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profesoriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saliToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grupeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.afiseazaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // afiseazaToolStripMenuItem
            // 
            this.afiseazaToolStripMenuItem.Name = "afiseazaToolStripMenuItem";
            this.afiseazaToolStripMenuItem.Size = new System.Drawing.Size(79, 26);
            this.afiseazaToolStripMenuItem.Text = "Afiseaza";
            this.afiseazaToolStripMenuItem.Click += new System.EventHandler(this.afiseazaToolStripMenuItem_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(20, 57);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(75, 21);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.Text = "Manual";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(20, 103);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(68, 21);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Import";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Location = new System.Drawing.Point(31, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 164);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selectati modul de introducere a datelor";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(60, 304);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(633, 359);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 64);
            this.button2.TabIndex = 5;
            this.button2.Text = "Creare orar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importDinBazaDeDateToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(240, 28);
            // 
            // importDinBazaDeDateToolStripMenuItem
            // 
            this.importDinBazaDeDateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.disciplineToolStripMenuItem,
            this.profesoriToolStripMenuItem,
            this.saliToolStripMenuItem,
            this.grupeToolStripMenuItem});
            this.importDinBazaDeDateToolStripMenuItem.Name = "importDinBazaDeDateToolStripMenuItem";
            this.importDinBazaDeDateToolStripMenuItem.Size = new System.Drawing.Size(239, 24);
            this.importDinBazaDeDateToolStripMenuItem.Text = "Import din baza de date";
            // 
            // disciplineToolStripMenuItem
            // 
            this.disciplineToolStripMenuItem.Name = "disciplineToolStripMenuItem";
            this.disciplineToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.disciplineToolStripMenuItem.Text = "Discipline";
            this.disciplineToolStripMenuItem.Click += new System.EventHandler(this.disciplineToolStripMenuItem_Click);
            // 
            // profesoriToolStripMenuItem
            // 
            this.profesoriToolStripMenuItem.Name = "profesoriToolStripMenuItem";
            this.profesoriToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.profesoriToolStripMenuItem.Text = "Profesori";
            this.profesoriToolStripMenuItem.Click += new System.EventHandler(this.profesoriToolStripMenuItem_Click);
            // 
            // saliToolStripMenuItem
            // 
            this.saliToolStripMenuItem.Name = "saliToolStripMenuItem";
            this.saliToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.saliToolStripMenuItem.Text = "Sali";
            this.saliToolStripMenuItem.Click += new System.EventHandler(this.saliToolStripMenuItem_Click);
            // 
            // grupeToolStripMenuItem
            // 
            this.grupeToolStripMenuItem.Name = "grupeToolStripMenuItem";
            this.grupeToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.grupeToolStripMenuItem.Text = "Grupe";
            this.grupeToolStripMenuItem.Click += new System.EventHandler(this.grupeToolStripMenuItem_Click);
            // 
            // MeniuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MeniuPrincipal";
            this.Text = "MeniuPrincipal";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem afiseazaToolStripMenuItem;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem importDinBazaDeDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disciplineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profesoriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saliToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grupeToolStripMenuItem;
    }
}