namespace EF_CodeFirst_CokaCokIliski
{
    partial class FormIliski
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
            this.cmbEgitmen = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstOgrenci = new System.Windows.Forms.ListBox();
            this.btnIliski = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbEgitmen
            // 
            this.cmbEgitmen.FormattingEnabled = true;
            this.cmbEgitmen.Location = new System.Drawing.Point(57, 15);
            this.cmbEgitmen.Name = "cmbEgitmen";
            this.cmbEgitmen.Size = new System.Drawing.Size(246, 21);
            this.cmbEgitmen.TabIndex = 0;
            this.cmbEgitmen.SelectedIndexChanged += new System.EventHandler(this.cmbEgitmen_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Eğitmen : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Öğrenci : ";
            // 
            // lstOgrenci
            // 
            this.lstOgrenci.FormattingEnabled = true;
            this.lstOgrenci.Location = new System.Drawing.Point(57, 59);
            this.lstOgrenci.Name = "lstOgrenci";
            this.lstOgrenci.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstOgrenci.Size = new System.Drawing.Size(246, 277);
            this.lstOgrenci.TabIndex = 3;
            
            // 
            // btnIliski
            // 
            this.btnIliski.Location = new System.Drawing.Point(207, 352);
            this.btnIliski.Name = "btnIliski";
            this.btnIliski.Size = new System.Drawing.Size(96, 23);
            this.btnIliski.TabIndex = 4;
            this.btnIliski.Text = "İlişkilendir";
            this.btnIliski.UseVisualStyleBackColor = true;
            this.btnIliski.Click += new System.EventHandler(this.btnIliski_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(327, 18);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(431, 357);
            this.dataGridView1.TabIndex = 5;
            // 
            // FormIliski
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 387);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnIliski);
            this.Controls.Add(this.lstOgrenci);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbEgitmen);
            this.Name = "FormIliski";
            this.Text = "FormIliski";
            this.Load += new System.EventHandler(this.FormIliski_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbEgitmen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstOgrenci;
        private System.Windows.Forms.Button btnIliski;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}