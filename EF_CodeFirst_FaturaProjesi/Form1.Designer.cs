namespace EF_CodeFirst_FaturaProjesi
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tanımlamalarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerDefinitionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unitDefinitionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.urunDefinitionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cityDefinitionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.countyDefinitionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ınvoiceTransactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewEditSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createInvoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tanımlamalarToolStripMenuItem,
            this.ınvoiceTransactionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(612, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tanımlamalarToolStripMenuItem
            // 
            this.tanımlamalarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customerDefinitionsToolStripMenuItem,
            this.unitDefinitionsToolStripMenuItem,
            this.urunDefinitionsToolStripMenuItem,
            this.cityDefinitionsToolStripMenuItem,
            this.countyDefinitionsToolStripMenuItem});
            this.tanımlamalarToolStripMenuItem.Name = "tanımlamalarToolStripMenuItem";
            this.tanımlamalarToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.tanımlamalarToolStripMenuItem.Text = "Support Tables";
            // 
            // customerDefinitionsToolStripMenuItem
            // 
            this.customerDefinitionsToolStripMenuItem.Name = "customerDefinitionsToolStripMenuItem";
            this.customerDefinitionsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.customerDefinitionsToolStripMenuItem.Text = "Customer Definitions";
            this.customerDefinitionsToolStripMenuItem.Click += new System.EventHandler(this.customerDefinitionsToolStripMenuItem_Click);
            // 
            // unitDefinitionsToolStripMenuItem
            // 
            this.unitDefinitionsToolStripMenuItem.Name = "unitDefinitionsToolStripMenuItem";
            this.unitDefinitionsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.unitDefinitionsToolStripMenuItem.Text = "Unit Definitions";
            this.unitDefinitionsToolStripMenuItem.Click += new System.EventHandler(this.unitDefinitionsToolStripMenuItem_Click);
            // 
            // urunDefinitionsToolStripMenuItem
            // 
            this.urunDefinitionsToolStripMenuItem.Name = "urunDefinitionsToolStripMenuItem";
            this.urunDefinitionsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.urunDefinitionsToolStripMenuItem.Text = "Product Definitions";
            this.urunDefinitionsToolStripMenuItem.Click += new System.EventHandler(this.urunDefinitionsToolStripMenuItem_Click);
            // 
            // cityDefinitionsToolStripMenuItem
            // 
            this.cityDefinitionsToolStripMenuItem.Name = "cityDefinitionsToolStripMenuItem";
            this.cityDefinitionsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.cityDefinitionsToolStripMenuItem.Text = "City Definitions";
            this.cityDefinitionsToolStripMenuItem.Click += new System.EventHandler(this.cityDefinitionsToolStripMenuItem_Click);
            // 
            // countyDefinitionsToolStripMenuItem
            // 
            this.countyDefinitionsToolStripMenuItem.Name = "countyDefinitionsToolStripMenuItem";
            this.countyDefinitionsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.countyDefinitionsToolStripMenuItem.Text = "County Definitions";
            this.countyDefinitionsToolStripMenuItem.Click += new System.EventHandler(this.countyDefinitionsToolStripMenuItem_Click);
            // 
            // ınvoiceTransactionsToolStripMenuItem
            // 
            this.ınvoiceTransactionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createInvoiceToolStripMenuItem,
            this.viewEditSearchToolStripMenuItem});
            this.ınvoiceTransactionsToolStripMenuItem.Name = "ınvoiceTransactionsToolStripMenuItem";
            this.ınvoiceTransactionsToolStripMenuItem.Size = new System.Drawing.Size(127, 20);
            this.ınvoiceTransactionsToolStripMenuItem.Text = "Invoice Transactions";
            // 
            // viewEditSearchToolStripMenuItem
            // 
            this.viewEditSearchToolStripMenuItem.Name = "viewEditSearchToolStripMenuItem";
            this.viewEditSearchToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.viewEditSearchToolStripMenuItem.Text = "Search / View / Edit";
            this.viewEditSearchToolStripMenuItem.Click += new System.EventHandler(this.viewEditSearchToolStripMenuItem_Click);
            // 
            // createInvoiceToolStripMenuItem
            // 
            this.createInvoiceToolStripMenuItem.Name = "createInvoiceToolStripMenuItem";
            this.createInvoiceToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.createInvoiceToolStripMenuItem.Text = "Create Invoice";
            this.createInvoiceToolStripMenuItem.Click += new System.EventHandler(this.createInvoiceToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 532);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tanımlamalarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerDefinitionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unitDefinitionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem urunDefinitionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cityDefinitionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem countyDefinitionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ınvoiceTransactionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createInvoiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewEditSearchToolStripMenuItem;
    }
}

