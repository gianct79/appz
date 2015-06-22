/*
* Copyleft 1979-2015 GTO Inc. All rights reversed.
*/

namespace checkBook
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileOpenMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem0 = new System.Windows.Forms.ToolStripSeparator();
            this.fileSaveMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.filePrintMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.fileExitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.checkGridView = new System.Windows.Forms.DataGridView();
            this.checkbookBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Place = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PayTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkbookBindingSource)).BeginInit();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(624, 24);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileOpenMenu,
            this.toolStripMenuItem0,
            this.fileSaveMenu,
            this.toolStripMenuItem1,
            this.filePrintMenu,
            this.toolStripMenuItem2,
            this.fileExitMenu});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(37, 20);
            this.fileMenu.Text = "File";
            // 
            // fileOpenMenu
            // 
            this.fileOpenMenu.Name = "fileOpenMenu";
            this.fileOpenMenu.Size = new System.Drawing.Size(108, 22);
            this.fileOpenMenu.Text = "Open";
            this.fileOpenMenu.Click += new System.EventHandler(this.fileOpenMenu_Click);
            // 
            // toolStripMenuItem0
            // 
            this.toolStripMenuItem0.Name = "toolStripMenuItem0";
            this.toolStripMenuItem0.Size = new System.Drawing.Size(105, 6);
            // 
            // fileSaveMenu
            // 
            this.fileSaveMenu.Name = "fileSaveMenu";
            this.fileSaveMenu.Size = new System.Drawing.Size(108, 22);
            this.fileSaveMenu.Text = "Save";
            this.fileSaveMenu.Click += new System.EventHandler(this.fileSaveMenu_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(105, 6);
            // 
            // filePrintMenu
            // 
            this.filePrintMenu.Name = "filePrintMenu";
            this.filePrintMenu.Size = new System.Drawing.Size(108, 22);
            this.filePrintMenu.Text = "Print...";
            this.filePrintMenu.Click += new System.EventHandler(this.filePrintMenu_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(105, 6);
            // 
            // fileExitMenu
            // 
            this.fileExitMenu.Name = "fileExitMenu";
            this.fileExitMenu.Size = new System.Drawing.Size(108, 22);
            this.fileExitMenu.Text = "Exit";
            this.fileExitMenu.Click += new System.EventHandler(this.fileExitMenu_Click);
            // 
            // checkGridView
            // 
            this.checkGridView.AutoGenerateColumns = false;
            this.checkGridView.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.checkGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.checkGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.Value,
            this.Date,
            this.Place,
            this.PayTo});
            this.checkGridView.DataSource = this.checkbookBindingSource;
            this.checkGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkGridView.Location = new System.Drawing.Point(0, 24);
            this.checkGridView.Name = "checkGridView";
            this.checkGridView.Size = new System.Drawing.Size(624, 235);
            this.checkGridView.TabIndex = 5;
            this.checkGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.checkGridView_DataError);
            // 
            // checkbookBindingSource
            // 
            this.checkbookBindingSource.CurrentChanged += new System.EventHandler(this.checkbookBindingSource_CurrentChanged);
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusBar.Location = new System.Drawing.Point(0, 259);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(624, 22);
            this.statusBar.TabIndex = 6;
            this.statusBar.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(39, 17);
            this.statusLabel.Text = "Status";
            // 
            // Number
            // 
            this.Number.DataPropertyName = "Number";
            this.Number.HeaderText = "Number";
            this.Number.MaxInputLength = 20;
            this.Number.MinimumWidth = 20;
            this.Number.Name = "Number";
            // 
            // Value
            // 
            this.Value.DataPropertyName = "Value";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.Value.DefaultCellStyle = dataGridViewCellStyle1;
            this.Value.HeaderText = "Value";
            this.Value.MaxInputLength = 10;
            this.Value.Name = "Value";
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.Date.DefaultCellStyle = dataGridViewCellStyle2;
            this.Date.HeaderText = "Date";
            this.Date.MaxInputLength = 10;
            this.Date.Name = "Date";
            // 
            // Place
            // 
            this.Place.DataPropertyName = "Place";
            this.Place.HeaderText = "Place";
            this.Place.MaxInputLength = 20;
            this.Place.MinimumWidth = 50;
            this.Place.Name = "Place";
            this.Place.Width = 150;
            // 
            // PayTo
            // 
            this.PayTo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PayTo.DataPropertyName = "PayTo";
            this.PayTo.HeaderText = "PayTo";
            this.PayTo.MaxInputLength = 100;
            this.PayTo.Name = "PayTo";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 281);
            this.Controls.Add(this.checkGridView);
            this.Controls.Add(this.mainMenu);
            this.Controls.Add(this.statusBar);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "Checkbook";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkbookBindingSource)).EndInit();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem fileSaveMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem0;
        private System.Windows.Forms.ToolStripMenuItem fileOpenMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem filePrintMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem fileExitMenu;
        private System.Windows.Forms.DataGridView checkGridView;
        private System.Windows.Forms.BindingSource checkbookBindingSource;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Place;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayTo;
    }
}
