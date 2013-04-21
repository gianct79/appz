﻿/*
* Copyleft 1979-2013 GTO Inc. All rights reversed.
*/

namespace printApp
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
            this.editCreateBitmapMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.editCreateBitmapA4300Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.editCreateBitmapA4600Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.editCreateBitmapLetter300Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.editCreateBitmapLetter600Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.viewZoomMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.viewZoom25Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.viewZoom50Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.viewZoom75Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.viewZoom100Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.imageViewer = new printApp.ImageViewer();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.editMenu,
            this.viewMenu});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(493, 24);
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
            this.fileMenu.Size = new System.Drawing.Size(35, 20);
            this.fileMenu.Text = "File";
            // 
            // fileSaveMenu
            // 
            this.fileSaveMenu.Name = "fileSaveMenu";
            this.fileSaveMenu.Size = new System.Drawing.Size(125, 22);
            this.fileSaveMenu.Text = "Save";
            // 
            // fileSaveAsMenu
            // 
            this.fileSaveAsMenu.Name = "fileSaveAsMenu";
            this.fileSaveAsMenu.Size = new System.Drawing.Size(125, 22);
            this.fileSaveAsMenu.Text = "Save As...";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(122, 6);
            // 
            // filePrintMenu
            // 
            this.filePrintMenu.Name = "filePrintMenu";
            this.filePrintMenu.Size = new System.Drawing.Size(125, 22);
            this.filePrintMenu.Text = "Print...";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(122, 6);
            // 
            // fileExitMenu
            // 
            this.fileExitMenu.Name = "fileExitMenu";
            this.fileExitMenu.Size = new System.Drawing.Size(125, 22);
            this.fileExitMenu.Text = "Exit";
            this.fileExitMenu.Click += new System.EventHandler(this.fileExitMenu_Click);
            // 
            // editMenu
            // 
            this.editMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editCreateBitmapMenu});
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(37, 20);
            this.editMenu.Text = "Edit";
            // 
            // editCreateBitmapMenu
            // 
            this.editCreateBitmapMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editCreateBitmapA4300Menu,
            this.editCreateBitmapA4600Menu,
            this.editCreateBitmapLetter300Menu,
            this.editCreateBitmapLetter600Menu});
            this.editCreateBitmapMenu.Name = "editCreateBitmapMenu";
            this.editCreateBitmapMenu.Size = new System.Drawing.Size(142, 22);
            this.editCreateBitmapMenu.Text = "Create Bitmap";
            // 
            // editCreateBitmapA4300Menu
            // 
            this.editCreateBitmapA4300Menu.Name = "editCreateBitmapA4300Menu";
            this.editCreateBitmapA4300Menu.Size = new System.Drawing.Size(141, 22);
            this.editCreateBitmapA4300Menu.Tag = "0";
            this.editCreateBitmapA4300Menu.Text = "A4 300 dpi";
            this.editCreateBitmapA4300Menu.Click += new System.EventHandler(this.editCreateBitmapMenu_Click);
            // 
            // editCreateBitmapA4600Menu
            // 
            this.editCreateBitmapA4600Menu.Name = "editCreateBitmapA4600Menu";
            this.editCreateBitmapA4600Menu.Size = new System.Drawing.Size(141, 22);
            this.editCreateBitmapA4600Menu.Tag = "1";
            this.editCreateBitmapA4600Menu.Text = "A4 600 dpi";
            this.editCreateBitmapA4600Menu.Click += new System.EventHandler(this.editCreateBitmapMenu_Click);
            // 
            // editCreateBitmapLetter300Menu
            // 
            this.editCreateBitmapLetter300Menu.Name = "editCreateBitmapLetter300Menu";
            this.editCreateBitmapLetter300Menu.Size = new System.Drawing.Size(141, 22);
            this.editCreateBitmapLetter300Menu.Tag = "2";
            this.editCreateBitmapLetter300Menu.Text = "Letter 300 dpi";
            this.editCreateBitmapLetter300Menu.Click += new System.EventHandler(this.editCreateBitmapMenu_Click);
            // 
            // editCreateBitmapLetter600Menu
            // 
            this.editCreateBitmapLetter600Menu.Name = "editCreateBitmapLetter600Menu";
            this.editCreateBitmapLetter600Menu.Size = new System.Drawing.Size(141, 22);
            this.editCreateBitmapLetter600Menu.Tag = "3";
            this.editCreateBitmapLetter600Menu.Text = "Letter 600 dpi";
            this.editCreateBitmapLetter600Menu.Click += new System.EventHandler(this.editCreateBitmapMenu_Click);
            // 
            // viewMenu
            // 
            this.viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewZoomMenu});
            this.viewMenu.Name = "viewMenu";
            this.viewMenu.Size = new System.Drawing.Size(41, 20);
            this.viewMenu.Text = "View";
            // 
            // viewZoomMenu
            // 
            this.viewZoomMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewZoom25Menu,
            this.viewZoom50Menu,
            this.viewZoom75Menu,
            this.viewZoom100Menu});
            this.viewZoomMenu.Name = "viewZoomMenu";
            this.viewZoomMenu.Size = new System.Drawing.Size(152, 22);
            this.viewZoomMenu.Text = "Zoom";
            // 
            // viewZoom25Menu
            // 
            this.viewZoom25Menu.Name = "viewZoom25Menu";
            this.viewZoom25Menu.Size = new System.Drawing.Size(152, 22);
            this.viewZoom25Menu.Text = "25%";
            this.viewZoom25Menu.Click += new System.EventHandler(this.viewZoomMenu_Click);
            // 
            // viewZoom50Menu
            // 
            this.viewZoom50Menu.Name = "viewZoom50Menu";
            this.viewZoom50Menu.Size = new System.Drawing.Size(152, 22);
            this.viewZoom50Menu.Text = "50%";
            this.viewZoom50Menu.Click += new System.EventHandler(this.viewZoomMenu_Click);
            // 
            // viewZoom75Menu
            // 
            this.viewZoom75Menu.Name = "viewZoom75Menu";
            this.viewZoom75Menu.Size = new System.Drawing.Size(152, 22);
            this.viewZoom75Menu.Text = "75%";
            this.viewZoom75Menu.Click += new System.EventHandler(this.viewZoomMenu_Click);
            // 
            // viewZoom100Menu
            // 
            this.viewZoom100Menu.Name = "viewZoom100Menu";
            this.viewZoom100Menu.Size = new System.Drawing.Size(152, 22);
            this.viewZoom100Menu.Text = "100%";
            this.viewZoom100Menu.Click += new System.EventHandler(this.viewZoomMenu_Click);
            // 
            // imageViewer
            // 
            this.imageViewer.AutoScroll = true;
            this.imageViewer.AutoScrollMargin = new System.Drawing.Size(493, 376);
            this.imageViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageViewer.Image = null;
            this.imageViewer.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;
            this.imageViewer.Location = new System.Drawing.Point(0, 24);
            this.imageViewer.Name = "imageViewer";
            this.imageViewer.Size = new System.Drawing.Size(493, 376);
            this.imageViewer.TabIndex = 2;
            this.imageViewer.Text = "imageViewer";
            this.imageViewer.ZoomFactor = 1F;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 400);
            this.Controls.Add(this.imageViewer);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "Printing Sample";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem fileSaveMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem filePrintMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem fileExitMenu;
        private System.Windows.Forms.ToolStripMenuItem editMenu;
        private System.Windows.Forms.ToolStripMenuItem editCreateBitmapMenu;
        private System.Windows.Forms.ToolStripMenuItem editCreateBitmapA4300Menu;
        private System.Windows.Forms.ToolStripMenuItem editCreateBitmapA4600Menu;
        private System.Windows.Forms.ToolStripMenuItem editCreateBitmapLetter300Menu;
        private System.Windows.Forms.ToolStripMenuItem editCreateBitmapLetter600Menu;
        private System.Windows.Forms.ToolStripMenuItem fileSaveAsMenu;
        private ImageViewer imageViewer;
        private System.Windows.Forms.ToolStripMenuItem viewMenu;
        private System.Windows.Forms.ToolStripMenuItem viewZoomMenu;
        private System.Windows.Forms.ToolStripMenuItem viewZoom25Menu;
        private System.Windows.Forms.ToolStripMenuItem viewZoom50Menu;
        private System.Windows.Forms.ToolStripMenuItem viewZoom75Menu;
        private System.Windows.Forms.ToolStripMenuItem viewZoom100Menu;
    }
}

