﻿using System.Windows.Forms;

namespace FortniteSquadOverlayClient
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
            this.consoleLogTextBox = new System.Windows.Forms.TextBox();
            this.previewPictureBox = new System.Windows.Forms.PictureBox();
            this.previewLabel = new System.Windows.Forms.Label();
            this.squadmate1GearPictureBox = new System.Windows.Forms.PictureBox();
            this.squadmate2GearPictureBox = new System.Windows.Forms.PictureBox();
            this.squadmate3GearPictureBox = new System.Windows.Forms.PictureBox();
            this.squadmate1NameLabel = new System.Windows.Forms.Label();
            this.squadmate2NameLabel = new System.Windows.Forms.Label();
            this.squadmate3NameLabel = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.debugOverlayCheckbox = new System.Windows.Forms.CheckBox();
            this.updateNoticeLinkLabel = new System.Windows.Forms.LinkLabel();
            this.infoTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.previewTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.editConfigButton = new System.Windows.Forms.Button();
            this.squadmatesTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.squadmate2ArrowTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.squadmate2DownButton = new System.Windows.Forms.Button();
            this.squadmate2UpButton = new System.Windows.Forms.Button();
            this.squadmate1ArrowTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.squadmate1DownButton = new System.Windows.Forms.Button();
            this.squadmate3ArrowTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.squadmate3UpButton = new System.Windows.Forms.Button();
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.squadmate1GearPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.squadmate2GearPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.squadmate3GearPictureBox)).BeginInit();
            this.infoTableLayoutPanel.SuspendLayout();
            this.previewTableLayoutPanel.SuspendLayout();
            this.squadmatesTableLayoutPanel.SuspendLayout();
            this.squadmate2ArrowTableLayoutPanel.SuspendLayout();
            this.squadmate1ArrowTableLayoutPanel.SuspendLayout();
            this.squadmate3ArrowTableLayoutPanel.SuspendLayout();
            this.mainTableLayoutPanel.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // consoleLogTextBox
            // 
            this.mainTableLayoutPanel.SetColumnSpan(this.consoleLogTextBox, 2);
            this.consoleLogTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consoleLogTextBox.Location = new System.Drawing.Point(3, 241);
            this.consoleLogTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.consoleLogTextBox.Multiline = true;
            this.consoleLogTextBox.Name = "consoleLogTextBox";
            this.consoleLogTextBox.ReadOnly = true;
            this.consoleLogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.consoleLogTextBox.Size = new System.Drawing.Size(778, 200);
            this.consoleLogTextBox.TabIndex = 2;
            this.consoleLogTextBox.WordWrap = false;
            // 
            // previewPictureBox
            // 
            this.previewPictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.previewPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewPictureBox.Location = new System.Drawing.Point(70, 0);
            this.previewPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.previewPictureBox.Name = "previewPictureBox";
            this.previewPictureBox.Size = new System.Drawing.Size(280, 80);
            this.previewPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.previewPictureBox.TabIndex = 12;
            this.previewPictureBox.TabStop = false;
            // 
            // previewLabel
            // 
            this.previewLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewLabel.Location = new System.Drawing.Point(3, 0);
            this.previewLabel.Name = "previewLabel";
            this.previewLabel.Size = new System.Drawing.Size(64, 80);
            this.previewLabel.TabIndex = 14;
            this.previewLabel.Text = "Preview:";
            this.previewLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // squadmate1GearPictureBox
            // 
            this.squadmate1GearPictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.squadmate1GearPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.squadmate1GearPictureBox.Location = new System.Drawing.Point(80, 0);
            this.squadmate1GearPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.squadmate1GearPictureBox.Name = "squadmate1GearPictureBox";
            this.squadmate1GearPictureBox.Size = new System.Drawing.Size(308, 79);
            this.squadmate1GearPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.squadmate1GearPictureBox.TabIndex = 15;
            this.squadmate1GearPictureBox.TabStop = false;
            // 
            // squadmate2GearPictureBox
            // 
            this.squadmate2GearPictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.squadmate2GearPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.squadmate2GearPictureBox.Location = new System.Drawing.Point(80, 79);
            this.squadmate2GearPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.squadmate2GearPictureBox.Name = "squadmate2GearPictureBox";
            this.squadmate2GearPictureBox.Size = new System.Drawing.Size(308, 79);
            this.squadmate2GearPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.squadmate2GearPictureBox.TabIndex = 16;
            this.squadmate2GearPictureBox.TabStop = false;
            // 
            // squadmate3GearPictureBox
            // 
            this.squadmate3GearPictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.squadmate3GearPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.squadmate3GearPictureBox.Location = new System.Drawing.Point(80, 158);
            this.squadmate3GearPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.squadmate3GearPictureBox.Name = "squadmate3GearPictureBox";
            this.squadmate3GearPictureBox.Size = new System.Drawing.Size(308, 80);
            this.squadmate3GearPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.squadmate3GearPictureBox.TabIndex = 17;
            this.squadmate3GearPictureBox.TabStop = false;
            // 
            // squadmate1NameLabel
            // 
            this.squadmate1NameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.squadmate1NameLabel.Location = new System.Drawing.Point(0, 0);
            this.squadmate1NameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.squadmate1NameLabel.Name = "squadmate1NameLabel";
            this.squadmate1NameLabel.Size = new System.Drawing.Size(80, 79);
            this.squadmate1NameLabel.TabIndex = 19;
            this.squadmate1NameLabel.Text = "squadmate1";
            this.squadmate1NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // squadmate2NameLabel
            // 
            this.squadmate2NameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.squadmate2NameLabel.Location = new System.Drawing.Point(0, 79);
            this.squadmate2NameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.squadmate2NameLabel.Name = "squadmate2NameLabel";
            this.squadmate2NameLabel.Size = new System.Drawing.Size(80, 79);
            this.squadmate2NameLabel.TabIndex = 20;
            this.squadmate2NameLabel.Text = "squadmate2";
            this.squadmate2NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // squadmate3NameLabel
            // 
            this.squadmate3NameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.squadmate3NameLabel.Location = new System.Drawing.Point(0, 158);
            this.squadmate3NameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.squadmate3NameLabel.Name = "squadmate3NameLabel";
            this.squadmate3NameLabel.Size = new System.Drawing.Size(80, 80);
            this.squadmate3NameLabel.TabIndex = 21;
            this.squadmate3NameLabel.Text = "squadmate3";
            this.squadmate3NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // notifyIcon
            // 
            this.notifyIcon.Text = "FortniteSquadOverlay";
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // debugOverlayCheckbox
            // 
            this.debugOverlayCheckbox.AutoSize = true;
            this.debugOverlayCheckbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.debugOverlayCheckbox.Location = new System.Drawing.Point(178, 3);
            this.debugOverlayCheckbox.Name = "debugOverlayCheckbox";
            this.debugOverlayCheckbox.Size = new System.Drawing.Size(169, 34);
            this.debugOverlayCheckbox.TabIndex = 1;
            this.debugOverlayCheckbox.Text = "Debug overlay";
            this.debugOverlayCheckbox.UseVisualStyleBackColor = true;
            // 
            // updateNoticeLinkLabel
            // 
            this.updateNoticeLinkLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateNoticeLinkLabel.Location = new System.Drawing.Point(356, 441);
            this.updateNoticeLinkLabel.Name = "updateNoticeLinkLabel";
            this.updateNoticeLinkLabel.Size = new System.Drawing.Size(422, 20);
            this.updateNoticeLinkLabel.TabIndex = 3;
            this.updateNoticeLinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.updateNoticeLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.updateNoticeLinkLabel_LinkClicked);
            // 
            // infoTableLayoutPanel
            // 
            this.infoTableLayoutPanel.ColumnCount = 2;
            this.infoTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.infoTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.infoTableLayoutPanel.Controls.Add(this.previewTableLayoutPanel, 0, 2);
            this.infoTableLayoutPanel.Controls.Add(this.debugOverlayCheckbox, 1, 0);
            this.infoTableLayoutPanel.Controls.Add(this.editConfigButton, 0, 0);
            this.infoTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoTableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.infoTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.infoTableLayoutPanel.Name = "infoTableLayoutPanel";
            this.infoTableLayoutPanel.RowCount = 3;
            this.infoTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.infoTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.infoTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.infoTableLayoutPanel.Size = new System.Drawing.Size(350, 238);
            this.infoTableLayoutPanel.TabIndex = 0;
            // 
            // previewTableLayoutPanel
            // 
            this.previewTableLayoutPanel.ColumnCount = 2;
            this.infoTableLayoutPanel.SetColumnSpan(this.previewTableLayoutPanel, 2);
            this.previewTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.previewTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.previewTableLayoutPanel.Controls.Add(this.previewPictureBox, 1, 0);
            this.previewTableLayoutPanel.Controls.Add(this.previewLabel, 0, 0);
            this.previewTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewTableLayoutPanel.Location = new System.Drawing.Point(0, 158);
            this.previewTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.previewTableLayoutPanel.Name = "previewTableLayoutPanel";
            this.previewTableLayoutPanel.RowCount = 1;
            this.previewTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.previewTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.previewTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.previewTableLayoutPanel.Size = new System.Drawing.Size(350, 80);
            this.previewTableLayoutPanel.TabIndex = 0;
            // 
            // editConfigButton
            // 
            this.editConfigButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editConfigButton.Location = new System.Drawing.Point(3, 3);
            this.editConfigButton.Name = "editConfigButton";
            this.editConfigButton.Size = new System.Drawing.Size(169, 34);
            this.editConfigButton.TabIndex = 0;
            this.editConfigButton.Text = "Edit Config";
            this.editConfigButton.UseVisualStyleBackColor = true;
            this.editConfigButton.Click += new System.EventHandler(this.editConfigButton_Click);
            // 
            // squadmatesTableLayoutPanel
            // 
            this.squadmatesTableLayoutPanel.ColumnCount = 3;
            this.squadmatesTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.squadmatesTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.squadmatesTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.squadmatesTableLayoutPanel.Controls.Add(this.squadmate2ArrowTableLayoutPanel, 2, 1);
            this.squadmatesTableLayoutPanel.Controls.Add(this.squadmate1ArrowTableLayoutPanel, 2, 0);
            this.squadmatesTableLayoutPanel.Controls.Add(this.squadmate1GearPictureBox, 1, 0);
            this.squadmatesTableLayoutPanel.Controls.Add(this.squadmate3NameLabel, 0, 2);
            this.squadmatesTableLayoutPanel.Controls.Add(this.squadmate3GearPictureBox, 1, 2);
            this.squadmatesTableLayoutPanel.Controls.Add(this.squadmate2NameLabel, 0, 1);
            this.squadmatesTableLayoutPanel.Controls.Add(this.squadmate2GearPictureBox, 1, 1);
            this.squadmatesTableLayoutPanel.Controls.Add(this.squadmate1NameLabel, 0, 0);
            this.squadmatesTableLayoutPanel.Controls.Add(this.squadmate3ArrowTableLayoutPanel, 2, 2);
            this.squadmatesTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.squadmatesTableLayoutPanel.Location = new System.Drawing.Point(353, 3);
            this.squadmatesTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.squadmatesTableLayoutPanel.Name = "squadmatesTableLayoutPanel";
            this.squadmatesTableLayoutPanel.RowCount = 3;
            this.squadmatesTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.squadmatesTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.squadmatesTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.squadmatesTableLayoutPanel.Size = new System.Drawing.Size(428, 238);
            this.squadmatesTableLayoutPanel.TabIndex = 1;
            // 
            // squadmate2ArrowTableLayoutPanel
            // 
            this.squadmate2ArrowTableLayoutPanel.ColumnCount = 1;
            this.squadmate2ArrowTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.squadmate2ArrowTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.squadmate2ArrowTableLayoutPanel.Controls.Add(this.squadmate2DownButton, 0, 1);
            this.squadmate2ArrowTableLayoutPanel.Controls.Add(this.squadmate2UpButton, 0, 0);
            this.squadmate2ArrowTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.squadmate2ArrowTableLayoutPanel.Location = new System.Drawing.Point(388, 79);
            this.squadmate2ArrowTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.squadmate2ArrowTableLayoutPanel.Name = "squadmate2ArrowTableLayoutPanel";
            this.squadmate2ArrowTableLayoutPanel.RowCount = 2;
            this.squadmate2ArrowTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.squadmate2ArrowTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.squadmate2ArrowTableLayoutPanel.Size = new System.Drawing.Size(40, 79);
            this.squadmate2ArrowTableLayoutPanel.TabIndex = 1;
            // 
            // squadmate2DownButton
            // 
            this.squadmate2DownButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.squadmate2DownButton.Location = new System.Drawing.Point(3, 39);
            this.squadmate2DownButton.Margin = new System.Windows.Forms.Padding(3, 0, 3, 6);
            this.squadmate2DownButton.Name = "squadmate2DownButton";
            this.squadmate2DownButton.Size = new System.Drawing.Size(34, 34);
            this.squadmate2DownButton.TabIndex = 1;
            this.squadmate2DownButton.Text = "↓";
            this.squadmate2DownButton.UseVisualStyleBackColor = true;
            this.squadmate2DownButton.Visible = false;
            this.squadmate2DownButton.Click += new System.EventHandler(this.squadmate2DownButton_Click);
            // 
            // squadmate2UpButton
            // 
            this.squadmate2UpButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.squadmate2UpButton.Location = new System.Drawing.Point(3, 6);
            this.squadmate2UpButton.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.squadmate2UpButton.Name = "squadmate2UpButton";
            this.squadmate2UpButton.Size = new System.Drawing.Size(34, 33);
            this.squadmate2UpButton.TabIndex = 0;
            this.squadmate2UpButton.Text = "↑";
            this.squadmate2UpButton.UseVisualStyleBackColor = true;
            this.squadmate2UpButton.Visible = false;
            this.squadmate2UpButton.Click += new System.EventHandler(this.squadmate2UpButton_Click);
            // 
            // squadmate1ArrowTableLayoutPanel
            // 
            this.squadmate1ArrowTableLayoutPanel.ColumnCount = 1;
            this.squadmate1ArrowTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.squadmate1ArrowTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.squadmate1ArrowTableLayoutPanel.Controls.Add(this.squadmate1DownButton, 0, 1);
            this.squadmate1ArrowTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.squadmate1ArrowTableLayoutPanel.Location = new System.Drawing.Point(388, 0);
            this.squadmate1ArrowTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.squadmate1ArrowTableLayoutPanel.Name = "squadmate1ArrowTableLayoutPanel";
            this.squadmate1ArrowTableLayoutPanel.RowCount = 2;
            this.squadmate1ArrowTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.squadmate1ArrowTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.squadmate1ArrowTableLayoutPanel.Size = new System.Drawing.Size(40, 79);
            this.squadmate1ArrowTableLayoutPanel.TabIndex = 0;
            // 
            // squadmate1DownButton
            // 
            this.squadmate1DownButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.squadmate1DownButton.Location = new System.Drawing.Point(3, 39);
            this.squadmate1DownButton.Margin = new System.Windows.Forms.Padding(3, 0, 3, 6);
            this.squadmate1DownButton.Name = "squadmate1DownButton";
            this.squadmate1DownButton.Size = new System.Drawing.Size(34, 34);
            this.squadmate1DownButton.TabIndex = 0;
            this.squadmate1DownButton.Text = "↓";
            this.squadmate1DownButton.UseVisualStyleBackColor = true;
            this.squadmate1DownButton.Visible = false;
            this.squadmate1DownButton.Click += new System.EventHandler(this.squadmate1DownButton_Click);
            // 
            // squadmate3ArrowTableLayoutPanel
            // 
            this.squadmate3ArrowTableLayoutPanel.ColumnCount = 1;
            this.squadmate3ArrowTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.squadmate3ArrowTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.squadmate3ArrowTableLayoutPanel.Controls.Add(this.squadmate3UpButton, 0, 0);
            this.squadmate3ArrowTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.squadmate3ArrowTableLayoutPanel.Location = new System.Drawing.Point(388, 158);
            this.squadmate3ArrowTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.squadmate3ArrowTableLayoutPanel.Name = "squadmate3ArrowTableLayoutPanel";
            this.squadmate3ArrowTableLayoutPanel.RowCount = 2;
            this.squadmate3ArrowTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.squadmate3ArrowTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.squadmate3ArrowTableLayoutPanel.Size = new System.Drawing.Size(40, 80);
            this.squadmate3ArrowTableLayoutPanel.TabIndex = 2;
            // 
            // squadmate3UpButton
            // 
            this.squadmate3UpButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.squadmate3UpButton.Location = new System.Drawing.Point(3, 6);
            this.squadmate3UpButton.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.squadmate3UpButton.Name = "squadmate3UpButton";
            this.squadmate3UpButton.Size = new System.Drawing.Size(34, 34);
            this.squadmate3UpButton.TabIndex = 0;
            this.squadmate3UpButton.Text = "↑";
            this.squadmate3UpButton.UseVisualStyleBackColor = true;
            this.squadmate3UpButton.Visible = false;
            this.squadmate3UpButton.Click += new System.EventHandler(this.squadmate3UpButton_Click);
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.ColumnCount = 2;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Controls.Add(this.consoleLogTextBox, 0, 1);
            this.mainTableLayoutPanel.Controls.Add(this.updateNoticeLinkLabel, 1, 2);
            this.mainTableLayoutPanel.Controls.Add(this.squadmatesTableLayoutPanel, 1, 0);
            this.mainTableLayoutPanel.Controls.Add(this.infoTableLayoutPanel, 0, 0);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.Padding = new System.Windows.Forms.Padding(3);
            this.mainTableLayoutPanel.RowCount = 3;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(784, 464);
            this.mainTableLayoutPanel.TabIndex = 29;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(94, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(93, 22);
            this.toolStripMenuItem1.Text = "test";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(784, 464);
            this.Controls.Add(this.mainTableLayoutPanel);
            this.Name = "MainForm";
            this.Text = "FortniteSquadOverlay";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.squadmate1GearPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.squadmate2GearPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.squadmate3GearPictureBox)).EndInit();
            this.infoTableLayoutPanel.ResumeLayout(false);
            this.infoTableLayoutPanel.PerformLayout();
            this.previewTableLayoutPanel.ResumeLayout(false);
            this.squadmatesTableLayoutPanel.ResumeLayout(false);
            this.squadmate2ArrowTableLayoutPanel.ResumeLayout(false);
            this.squadmate1ArrowTableLayoutPanel.ResumeLayout(false);
            this.squadmate3ArrowTableLayoutPanel.ResumeLayout(false);
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.mainTableLayoutPanel.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private TextBox consoleLogTextBox;
        private PictureBox previewPictureBox;
        private Label previewLabel;
        private PictureBox squadmate1GearPictureBox;
        private PictureBox squadmate2GearPictureBox;
        private PictureBox squadmate3GearPictureBox;
        private Label squadmate1NameLabel;
        private Label squadmate2NameLabel;
        private Label squadmate3NameLabel;
        private NotifyIcon notifyIcon;
        private CheckBox debugOverlayCheckbox;
        private LinkLabel updateNoticeLinkLabel;
        private TableLayoutPanel infoTableLayoutPanel;
        private TableLayoutPanel previewTableLayoutPanel;
        private TableLayoutPanel squadmatesTableLayoutPanel;
        private TableLayoutPanel mainTableLayoutPanel;
        private TableLayoutPanel squadmate2ArrowTableLayoutPanel;
        private Button squadmate2DownButton;
        private Button squadmate2UpButton;
        private TableLayoutPanel squadmate1ArrowTableLayoutPanel;
        private Button squadmate1DownButton;
        private TableLayoutPanel squadmate3ArrowTableLayoutPanel;
        private Button squadmate3UpButton;
        private Button editConfigButton;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
    }
}

