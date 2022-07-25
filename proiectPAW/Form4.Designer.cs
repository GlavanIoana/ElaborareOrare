
namespace proiectPAW
{
    partial class Form4
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbCod = new System.Windows.Forms.TextBox();
            this.tbNumar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbAn = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.userControl11 = new proiectPAW.UserControl1();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cod";
            // 
            // tbCod
            // 
            this.tbCod.Location = new System.Drawing.Point(139, 47);
            this.tbCod.Name = "tbCod";
            this.tbCod.Size = new System.Drawing.Size(100, 22);
            this.tbCod.TabIndex = 2;
            // 
            // tbNumar
            // 
            this.tbNumar.Location = new System.Drawing.Point(139, 89);
            this.tbNumar.Name = "tbNumar";
            this.tbNumar.Size = new System.Drawing.Size(100, 22);
            this.tbNumar.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Numar studenti";
            // 
            // tbAn
            // 
            this.tbAn.Location = new System.Drawing.Point(139, 130);
            this.tbAn.Name = "tbAn";
            this.tbAn.Size = new System.Drawing.Size(100, 22);
            this.tbAn.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Anul";
            // 
            // userControl11
            // 
            this.userControl11.Location = new System.Drawing.Point(12, 268);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(324, 170);
            this.userControl11.TabIndex = 0;
            this.userControl11.adaugareClick += new System.EventHandler(this.adaugare_click);
            this.userControl11.salvareClick += new System.EventHandler(this.salvare_click);
            this.userControl11.afisareClick += new System.EventHandler(this.afisare_click);
            this.userControl11.okClick += new System.EventHandler(this.ok_click);
            this.userControl11.Load += new System.EventHandler(this.Form4_Load);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 450);
            this.Controls.Add(this.tbAn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbNumar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbCod);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userControl11);
            this.Name = "Form4";
            this.Text = "Introducere grupa";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControl1 userControl11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCod;
        private System.Windows.Forms.TextBox tbNumar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbAn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}