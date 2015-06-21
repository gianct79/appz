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
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSaveMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSaveAsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.filePrintMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.fileExitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.editAddMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.editDeleteMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.checkListView = new System.Windows.Forms.ListView();
            this.checkNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.checkDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.checkValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.checkPay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.checkFormView = new System.Windows.Forms.Panel();
            this.textDate = new System.Windows.Forms.DateTimePicker();
            this.textPayTo = new System.Windows.Forms.TextBox();
            this.textValue = new System.Windows.Forms.TextBox();
            this.textNumber = new System.Windows.Forms.TextBox();
            this.labelPayTo = new System.Windows.Forms.Label();
            this.labelValue = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelNumber = new System.Windows.Forms.Label();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.checkFormView.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.editMenu});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(404, 24);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileSaveMenu,
            this.fileSaveAsMenu,
            this.toolStripMenuItem1,
            this.filePrintMenu,
            this.toolStripMenuItem2,
            this.fileExitMenu});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(37, 20);
            this.fileMenu.Text = "File";
            // 
            // fileSaveMenu
            // 
            this.fileSaveMenu.Name = "fileSaveMenu";
            this.fileSaveMenu.Size = new System.Drawing.Size(123, 22);
            this.fileSaveMenu.Text = "Save";
            // 
            // fileSaveAsMenu
            // 
            this.fileSaveAsMenu.Name = "fileSaveAsMenu";
            this.fileSaveAsMenu.Size = new System.Drawing.Size(123, 22);
            this.fileSaveAsMenu.Text = "Save As...";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(120, 6);
            // 
            // filePrintMenu
            // 
            this.filePrintMenu.Name = "filePrintMenu";
            this.filePrintMenu.Size = new System.Drawing.Size(123, 22);
            this.filePrintMenu.Text = "Print...";
            this.filePrintMenu.Click += new System.EventHandler(this.filePrintMenu_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(120, 6);
            // 
            // fileExitMenu
            // 
            this.fileExitMenu.Name = "fileExitMenu";
            this.fileExitMenu.Size = new System.Drawing.Size(123, 22);
            this.fileExitMenu.Text = "Exit";
            this.fileExitMenu.Click += new System.EventHandler(this.fileExitMenu_Click);
            // 
            // editMenu
            // 
            this.editMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editAddMenu,
            this.editDeleteMenu});
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(39, 20);
            this.editMenu.Text = "Edit";
            // 
            // editAddMenu
            // 
            this.editAddMenu.Name = "editAddMenu";
            this.editAddMenu.Size = new System.Drawing.Size(152, 22);
            this.editAddMenu.Text = "Add";
            this.editAddMenu.Click += new System.EventHandler(this.editAddMenu_Click);
            // 
            // editDeleteMenu
            // 
            this.editDeleteMenu.Name = "editDeleteMenu";
            this.editDeleteMenu.Size = new System.Drawing.Size(152, 22);
            this.editDeleteMenu.Text = "Delete";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.checkListView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.checkFormView);
            this.splitContainer1.Size = new System.Drawing.Size(404, 275);
            this.splitContainer1.SplitterDistance = 138;
            this.splitContainer1.TabIndex = 3;
            // 
            // checkListView
            // 
            this.checkListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.checkNumber,
            this.checkDate,
            this.checkValue,
            this.checkPay});
            this.checkListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkListView.FullRowSelect = true;
            this.checkListView.GridLines = true;
            this.checkListView.Location = new System.Drawing.Point(0, 0);
            this.checkListView.Name = "checkListView";
            this.checkListView.Size = new System.Drawing.Size(402, 136);
            this.checkListView.TabIndex = 0;
            this.checkListView.UseCompatibleStateImageBehavior = false;
            this.checkListView.View = System.Windows.Forms.View.Details;
            this.checkListView.VirtualMode = true;
            this.checkListView.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.checkListView_RetrieveVirtualItem);
            this.checkListView.SelectedIndexChanged += new System.EventHandler(this.checkListView_SelectedIndexChanged);
            // 
            // checkNumber
            // 
            this.checkNumber.Text = "Number";
            // 
            // checkDate
            // 
            this.checkDate.Text = "Date";
            this.checkDate.Width = 73;
            // 
            // checkValue
            // 
            this.checkValue.Text = "Value (R$)";
            this.checkValue.Width = 89;
            // 
            // checkPay
            // 
            this.checkPay.Text = "Pay To";
            this.checkPay.Width = 139;
            // 
            // checkFormView
            // 
            this.checkFormView.AutoScroll = true;
            this.checkFormView.Controls.Add(this.textDate);
            this.checkFormView.Controls.Add(this.textPayTo);
            this.checkFormView.Controls.Add(this.textValue);
            this.checkFormView.Controls.Add(this.textNumber);
            this.checkFormView.Controls.Add(this.labelPayTo);
            this.checkFormView.Controls.Add(this.labelValue);
            this.checkFormView.Controls.Add(this.labelDate);
            this.checkFormView.Controls.Add(this.labelNumber);
            this.checkFormView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkFormView.Location = new System.Drawing.Point(0, 0);
            this.checkFormView.Name = "checkFormView";
            this.checkFormView.Size = new System.Drawing.Size(402, 131);
            this.checkFormView.TabIndex = 0;
            // 
            // textDate
            // 
            this.textDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.textDate.Location = new System.Drawing.Point(64, 37);
            this.textDate.Name = "textDate";
            this.textDate.Size = new System.Drawing.Size(100, 20);
            this.textDate.TabIndex = 5;
            // 
            // textPayTo
            // 
            this.textPayTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textPayTo.Location = new System.Drawing.Point(64, 89);
            this.textPayTo.Name = "textPayTo";
            this.textPayTo.Size = new System.Drawing.Size(327, 20);
            this.textPayTo.TabIndex = 7;
            this.textPayTo.Leave += new System.EventHandler(this.textPayTo_Leave);
            // 
            // textValue
            // 
            this.textValue.Location = new System.Drawing.Point(64, 63);
            this.textValue.Name = "textValue";
            this.textValue.Size = new System.Drawing.Size(100, 20);
            this.textValue.TabIndex = 6;
            // 
            // textNumber
            // 
            this.textNumber.Location = new System.Drawing.Point(64, 11);
            this.textNumber.Name = "textNumber";
            this.textNumber.Size = new System.Drawing.Size(100, 20);
            this.textNumber.TabIndex = 4;
            // 
            // labelPayTo
            // 
            this.labelPayTo.AutoSize = true;
            this.labelPayTo.Location = new System.Drawing.Point(11, 96);
            this.labelPayTo.Name = "labelPayTo";
            this.labelPayTo.Size = new System.Drawing.Size(40, 13);
            this.labelPayTo.TabIndex = 3;
            this.labelPayTo.Text = "Pay to:";
            // 
            // labelValue
            // 
            this.labelValue.AutoSize = true;
            this.labelValue.Location = new System.Drawing.Point(10, 70);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(37, 13);
            this.labelValue.TabIndex = 2;
            this.labelValue.Text = "Value:";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(11, 43);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(33, 13);
            this.labelDate.TabIndex = 1;
            this.labelDate.Text = "Date:";
            // 
            // labelNumber
            // 
            this.labelNumber.AutoSize = true;
            this.labelNumber.Location = new System.Drawing.Point(11, 18);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Size = new System.Drawing.Size(47, 13);
            this.labelNumber.TabIndex = 0;
            this.labelNumber.Text = "Number:";
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 299);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(404, 22);
            this.statusBar.TabIndex = 4;
            this.statusBar.Text = "Ready";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 321);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "Checkbook";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.checkFormView.ResumeLayout(false);
            this.checkFormView.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem fileSaveMenu;
        private System.Windows.Forms.ToolStripMenuItem fileSaveAsMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem filePrintMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem fileExitMenu;
        private System.Windows.Forms.ToolStripMenuItem editMenu;
        private System.Windows.Forms.ToolStripMenuItem editAddMenu;
        private System.Windows.Forms.ToolStripMenuItem editDeleteMenu;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView checkListView;
        private System.Windows.Forms.ColumnHeader checkNumber;
        private System.Windows.Forms.ColumnHeader checkDate;
        private System.Windows.Forms.ColumnHeader checkValue;
        private System.Windows.Forms.ColumnHeader checkPay;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.Panel checkFormView;
        private System.Windows.Forms.DateTimePicker textDate;
        private System.Windows.Forms.TextBox textPayTo;
        private System.Windows.Forms.TextBox textValue;
        private System.Windows.Forms.TextBox textNumber;
        private System.Windows.Forms.Label labelPayTo;
        private System.Windows.Forms.Label labelValue;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelNumber;
    }
}
