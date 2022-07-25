
namespace proiectPAW
{
    partial class UserControl1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAdaugare = new System.Windows.Forms.Button();
            this.btnSalvare = new System.Windows.Forms.Button();
            this.btnAfisare = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAdaugare
            // 
            this.btnAdaugare.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdaugare.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdaugare.Location = new System.Drawing.Point(14, 34);
            this.btnAdaugare.Name = "btnAdaugare";
            this.btnAdaugare.Size = new System.Drawing.Size(176, 45);
            this.btnAdaugare.TabIndex = 0;
            this.btnAdaugare.Text = "Adauga";
            this.btnAdaugare.UseVisualStyleBackColor = true;
            this.btnAdaugare.Click += new System.EventHandler(this.btnAdaugare_Click);
            // 
            // btnSalvare
            // 
            this.btnSalvare.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvare.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvare.Location = new System.Drawing.Point(14, 96);
            this.btnSalvare.Name = "btnSalvare";
            this.btnSalvare.Size = new System.Drawing.Size(176, 45);
            this.btnSalvare.TabIndex = 1;
            this.btnSalvare.Text = "Salvare fisier text";
            this.btnSalvare.UseVisualStyleBackColor = true;
            this.btnSalvare.Click += new System.EventHandler(this.btnSalvare_Click);
            // 
            // btnAfisare
            // 
            this.btnAfisare.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAfisare.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAfisare.Location = new System.Drawing.Point(213, 34);
            this.btnAfisare.Name = "btnAfisare";
            this.btnAfisare.Size = new System.Drawing.Size(89, 45);
            this.btnAfisare.TabIndex = 2;
            this.btnAfisare.Text = "Afisare";
            this.btnAfisare.UseVisualStyleBackColor = true;
            this.btnAfisare.Click += new System.EventHandler(this.btnAfisare_Click);
            // 
            // btnOk
            // 
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(213, 96);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(89, 45);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnAfisare);
            this.Controls.Add(this.btnSalvare);
            this.Controls.Add(this.btnAdaugare);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(319, 170);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdaugare;
        private System.Windows.Forms.Button btnSalvare;
        private System.Windows.Forms.Button btnAfisare;
        private System.Windows.Forms.Button btnOk;
    }
}
