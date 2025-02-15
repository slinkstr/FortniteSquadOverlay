using System.Windows.Forms;

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
            components = new System.ComponentModel.Container();
            consoleLogTextBox = new System.Windows.Forms.TextBox();
            previewPictureBox = new System.Windows.Forms.PictureBox();
            previewLabel = new System.Windows.Forms.Label();
            squadmate1GearPictureBox = new System.Windows.Forms.PictureBox();
            squadmate2GearPictureBox = new System.Windows.Forms.PictureBox();
            squadmate3GearPictureBox = new System.Windows.Forms.PictureBox();
            squadmate1NameLabel = new System.Windows.Forms.Label();
            squadmate2NameLabel = new System.Windows.Forms.Label();
            squadmate3NameLabel = new System.Windows.Forms.Label();
            notifyIcon = new System.Windows.Forms.NotifyIcon(components);
            debugOverlayCheckbox = new System.Windows.Forms.CheckBox();
            updateNoticeLinkLabel = new System.Windows.Forms.LinkLabel();
            infoTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            previewTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            editConfigButton = new System.Windows.Forms.Button();
            squadmatesTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            squadmate2ArrowTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            squadmate2DownButton = new System.Windows.Forms.Button();
            squadmate2UpButton = new System.Windows.Forms.Button();
            squadmate1ArrowTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            squadmate1DownButton = new System.Windows.Forms.Button();
            squadmate3ArrowTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            squadmate3UpButton = new System.Windows.Forms.Button();
            mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)previewPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)squadmate1GearPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)squadmate2GearPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)squadmate3GearPictureBox).BeginInit();
            infoTableLayoutPanel.SuspendLayout();
            previewTableLayoutPanel.SuspendLayout();
            squadmatesTableLayoutPanel.SuspendLayout();
            squadmate2ArrowTableLayoutPanel.SuspendLayout();
            squadmate1ArrowTableLayoutPanel.SuspendLayout();
            squadmate3ArrowTableLayoutPanel.SuspendLayout();
            mainTableLayoutPanel.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // consoleLogTextBox
            // 
            mainTableLayoutPanel.SetColumnSpan(consoleLogTextBox, 2);
            consoleLogTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            consoleLogTextBox.Location = new System.Drawing.Point(4, 278);
            consoleLogTextBox.Margin = new System.Windows.Forms.Padding(0);
            consoleLogTextBox.Multiline = true;
            consoleLogTextBox.Name = "consoleLogTextBox";
            consoleLogTextBox.ReadOnly = true;
            consoleLogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            consoleLogTextBox.Size = new System.Drawing.Size(907, 231);
            consoleLogTextBox.TabIndex = 2;
            consoleLogTextBox.WordWrap = false;
            // 
            // previewPictureBox
            // 
            previewPictureBox.BackColor = System.Drawing.SystemColors.Control;
            previewPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            previewPictureBox.Location = new System.Drawing.Point(81, 0);
            previewPictureBox.Margin = new System.Windows.Forms.Padding(0);
            previewPictureBox.Name = "previewPictureBox";
            previewPictureBox.Size = new System.Drawing.Size(327, 92);
            previewPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            previewPictureBox.TabIndex = 12;
            previewPictureBox.TabStop = false;
            // 
            // previewLabel
            // 
            previewLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            previewLabel.Location = new System.Drawing.Point(4, 0);
            previewLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            previewLabel.Name = "previewLabel";
            previewLabel.Size = new System.Drawing.Size(73, 92);
            previewLabel.TabIndex = 14;
            previewLabel.Text = "Preview:";
            previewLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // squadmate1GearPictureBox
            // 
            squadmate1GearPictureBox.BackColor = System.Drawing.SystemColors.Control;
            squadmate1GearPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            squadmate1GearPictureBox.Location = new System.Drawing.Point(93, 0);
            squadmate1GearPictureBox.Margin = new System.Windows.Forms.Padding(0);
            squadmate1GearPictureBox.Name = "squadmate1GearPictureBox";
            squadmate1GearPictureBox.Size = new System.Drawing.Size(359, 91);
            squadmate1GearPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            squadmate1GearPictureBox.TabIndex = 15;
            squadmate1GearPictureBox.TabStop = false;
            // 
            // squadmate2GearPictureBox
            // 
            squadmate2GearPictureBox.BackColor = System.Drawing.SystemColors.Control;
            squadmate2GearPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            squadmate2GearPictureBox.Location = new System.Drawing.Point(93, 91);
            squadmate2GearPictureBox.Margin = new System.Windows.Forms.Padding(0);
            squadmate2GearPictureBox.Name = "squadmate2GearPictureBox";
            squadmate2GearPictureBox.Size = new System.Drawing.Size(359, 91);
            squadmate2GearPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            squadmate2GearPictureBox.TabIndex = 16;
            squadmate2GearPictureBox.TabStop = false;
            // 
            // squadmate3GearPictureBox
            // 
            squadmate3GearPictureBox.BackColor = System.Drawing.SystemColors.Control;
            squadmate3GearPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            squadmate3GearPictureBox.Location = new System.Drawing.Point(93, 182);
            squadmate3GearPictureBox.Margin = new System.Windows.Forms.Padding(0);
            squadmate3GearPictureBox.Name = "squadmate3GearPictureBox";
            squadmate3GearPictureBox.Size = new System.Drawing.Size(359, 93);
            squadmate3GearPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            squadmate3GearPictureBox.TabIndex = 17;
            squadmate3GearPictureBox.TabStop = false;
            // 
            // squadmate1NameLabel
            // 
            squadmate1NameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            squadmate1NameLabel.Location = new System.Drawing.Point(0, 0);
            squadmate1NameLabel.Margin = new System.Windows.Forms.Padding(0);
            squadmate1NameLabel.Name = "squadmate1NameLabel";
            squadmate1NameLabel.Size = new System.Drawing.Size(93, 91);
            squadmate1NameLabel.TabIndex = 19;
            squadmate1NameLabel.Text = "squadmate1";
            squadmate1NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // squadmate2NameLabel
            // 
            squadmate2NameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            squadmate2NameLabel.Location = new System.Drawing.Point(0, 91);
            squadmate2NameLabel.Margin = new System.Windows.Forms.Padding(0);
            squadmate2NameLabel.Name = "squadmate2NameLabel";
            squadmate2NameLabel.Size = new System.Drawing.Size(93, 91);
            squadmate2NameLabel.TabIndex = 20;
            squadmate2NameLabel.Text = "squadmate2";
            squadmate2NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // squadmate3NameLabel
            // 
            squadmate3NameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            squadmate3NameLabel.Location = new System.Drawing.Point(0, 182);
            squadmate3NameLabel.Margin = new System.Windows.Forms.Padding(0);
            squadmate3NameLabel.Name = "squadmate3NameLabel";
            squadmate3NameLabel.Size = new System.Drawing.Size(93, 93);
            squadmate3NameLabel.TabIndex = 21;
            squadmate3NameLabel.Text = "squadmate3";
            squadmate3NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // notifyIcon
            // 
            notifyIcon.Text = Program.ProgramName;
            notifyIcon.MouseClick += notifyIcon_MouseClick;
            // 
            // debugOverlayCheckbox
            // 
            debugOverlayCheckbox.AutoSize = true;
            debugOverlayCheckbox.Dock = System.Windows.Forms.DockStyle.Fill;
            debugOverlayCheckbox.Location = new System.Drawing.Point(208, 3);
            debugOverlayCheckbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            debugOverlayCheckbox.Name = "debugOverlayCheckbox";
            debugOverlayCheckbox.Size = new System.Drawing.Size(196, 40);
            debugOverlayCheckbox.TabIndex = 1;
            debugOverlayCheckbox.Text = "Debug overlay";
            debugOverlayCheckbox.UseVisualStyleBackColor = true;
            debugOverlayCheckbox.CheckedChanged += debugOverlayCheckbox_CheckedChanged;
            // 
            // updateNoticeLinkLabel
            // 
            updateNoticeLinkLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            updateNoticeLinkLabel.Location = new System.Drawing.Point(416, 509);
            updateNoticeLinkLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            updateNoticeLinkLabel.Name = "updateNoticeLinkLabel";
            updateNoticeLinkLabel.Size = new System.Drawing.Size(491, 23);
            updateNoticeLinkLabel.TabIndex = 3;
            updateNoticeLinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            updateNoticeLinkLabel.LinkClicked += updateNoticeLinkLabel_LinkClicked;
            // 
            // infoTableLayoutPanel
            // 
            infoTableLayoutPanel.ColumnCount = 2;
            infoTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            infoTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            infoTableLayoutPanel.Controls.Add(previewTableLayoutPanel, 0, 2);
            infoTableLayoutPanel.Controls.Add(debugOverlayCheckbox, 1, 0);
            infoTableLayoutPanel.Controls.Add(editConfigButton, 0, 0);
            infoTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            infoTableLayoutPanel.Location = new System.Drawing.Point(4, 3);
            infoTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            infoTableLayoutPanel.Name = "infoTableLayoutPanel";
            infoTableLayoutPanel.RowCount = 3;
            infoTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            infoTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            infoTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            infoTableLayoutPanel.Size = new System.Drawing.Size(408, 275);
            infoTableLayoutPanel.TabIndex = 0;
            // 
            // previewTableLayoutPanel
            // 
            previewTableLayoutPanel.ColumnCount = 2;
            infoTableLayoutPanel.SetColumnSpan(previewTableLayoutPanel, 2);
            previewTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            previewTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            previewTableLayoutPanel.Controls.Add(previewPictureBox, 1, 0);
            previewTableLayoutPanel.Controls.Add(previewLabel, 0, 0);
            previewTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            previewTableLayoutPanel.Location = new System.Drawing.Point(0, 183);
            previewTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            previewTableLayoutPanel.Name = "previewTableLayoutPanel";
            previewTableLayoutPanel.RowCount = 1;
            previewTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            previewTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            previewTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            previewTableLayoutPanel.Size = new System.Drawing.Size(408, 92);
            previewTableLayoutPanel.TabIndex = 0;
            // 
            // editConfigButton
            // 
            editConfigButton.Dock = System.Windows.Forms.DockStyle.Fill;
            editConfigButton.Location = new System.Drawing.Point(4, 3);
            editConfigButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            editConfigButton.Name = "editConfigButton";
            editConfigButton.Size = new System.Drawing.Size(196, 40);
            editConfigButton.TabIndex = 0;
            editConfigButton.Text = "Edit Config";
            editConfigButton.UseVisualStyleBackColor = true;
            editConfigButton.Click += editConfigButton_Click;
            // 
            // squadmatesTableLayoutPanel
            // 
            squadmatesTableLayoutPanel.ColumnCount = 3;
            squadmatesTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            squadmatesTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            squadmatesTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            squadmatesTableLayoutPanel.Controls.Add(squadmate2ArrowTableLayoutPanel, 2, 1);
            squadmatesTableLayoutPanel.Controls.Add(squadmate1ArrowTableLayoutPanel, 2, 0);
            squadmatesTableLayoutPanel.Controls.Add(squadmate1GearPictureBox, 1, 0);
            squadmatesTableLayoutPanel.Controls.Add(squadmate3NameLabel, 0, 2);
            squadmatesTableLayoutPanel.Controls.Add(squadmate3GearPictureBox, 1, 2);
            squadmatesTableLayoutPanel.Controls.Add(squadmate2NameLabel, 0, 1);
            squadmatesTableLayoutPanel.Controls.Add(squadmate2GearPictureBox, 1, 1);
            squadmatesTableLayoutPanel.Controls.Add(squadmate1NameLabel, 0, 0);
            squadmatesTableLayoutPanel.Controls.Add(squadmate3ArrowTableLayoutPanel, 2, 2);
            squadmatesTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            squadmatesTableLayoutPanel.Location = new System.Drawing.Point(412, 3);
            squadmatesTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            squadmatesTableLayoutPanel.Name = "squadmatesTableLayoutPanel";
            squadmatesTableLayoutPanel.RowCount = 3;
            squadmatesTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            squadmatesTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            squadmatesTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            squadmatesTableLayoutPanel.Size = new System.Drawing.Size(499, 275);
            squadmatesTableLayoutPanel.TabIndex = 1;
            // 
            // squadmate2ArrowTableLayoutPanel
            // 
            squadmate2ArrowTableLayoutPanel.ColumnCount = 1;
            squadmate2ArrowTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            squadmate2ArrowTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            squadmate2ArrowTableLayoutPanel.Controls.Add(squadmate2DownButton, 0, 1);
            squadmate2ArrowTableLayoutPanel.Controls.Add(squadmate2UpButton, 0, 0);
            squadmate2ArrowTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            squadmate2ArrowTableLayoutPanel.Location = new System.Drawing.Point(452, 91);
            squadmate2ArrowTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            squadmate2ArrowTableLayoutPanel.Name = "squadmate2ArrowTableLayoutPanel";
            squadmate2ArrowTableLayoutPanel.RowCount = 2;
            squadmate2ArrowTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            squadmate2ArrowTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            squadmate2ArrowTableLayoutPanel.Size = new System.Drawing.Size(47, 91);
            squadmate2ArrowTableLayoutPanel.TabIndex = 1;
            // 
            // squadmate2DownButton
            // 
            squadmate2DownButton.Dock = System.Windows.Forms.DockStyle.Fill;
            squadmate2DownButton.Location = new System.Drawing.Point(4, 45);
            squadmate2DownButton.Margin = new System.Windows.Forms.Padding(4, 0, 4, 7);
            squadmate2DownButton.Name = "squadmate2DownButton";
            squadmate2DownButton.Size = new System.Drawing.Size(39, 39);
            squadmate2DownButton.TabIndex = 1;
            squadmate2DownButton.Text = "↓";
            squadmate2DownButton.UseVisualStyleBackColor = true;
            squadmate2DownButton.Visible = false;
            squadmate2DownButton.Click += squadmate2DownButton_Click;
            // 
            // squadmate2UpButton
            // 
            squadmate2UpButton.Dock = System.Windows.Forms.DockStyle.Fill;
            squadmate2UpButton.Location = new System.Drawing.Point(4, 7);
            squadmate2UpButton.Margin = new System.Windows.Forms.Padding(4, 7, 4, 0);
            squadmate2UpButton.Name = "squadmate2UpButton";
            squadmate2UpButton.Size = new System.Drawing.Size(39, 38);
            squadmate2UpButton.TabIndex = 0;
            squadmate2UpButton.Text = "↑";
            squadmate2UpButton.UseVisualStyleBackColor = true;
            squadmate2UpButton.Visible = false;
            squadmate2UpButton.Click += squadmate2UpButton_Click;
            // 
            // squadmate1ArrowTableLayoutPanel
            // 
            squadmate1ArrowTableLayoutPanel.ColumnCount = 1;
            squadmate1ArrowTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            squadmate1ArrowTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            squadmate1ArrowTableLayoutPanel.Controls.Add(squadmate1DownButton, 0, 1);
            squadmate1ArrowTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            squadmate1ArrowTableLayoutPanel.Location = new System.Drawing.Point(452, 0);
            squadmate1ArrowTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            squadmate1ArrowTableLayoutPanel.Name = "squadmate1ArrowTableLayoutPanel";
            squadmate1ArrowTableLayoutPanel.RowCount = 2;
            squadmate1ArrowTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            squadmate1ArrowTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            squadmate1ArrowTableLayoutPanel.Size = new System.Drawing.Size(47, 91);
            squadmate1ArrowTableLayoutPanel.TabIndex = 0;
            // 
            // squadmate1DownButton
            // 
            squadmate1DownButton.Dock = System.Windows.Forms.DockStyle.Fill;
            squadmate1DownButton.Location = new System.Drawing.Point(4, 45);
            squadmate1DownButton.Margin = new System.Windows.Forms.Padding(4, 0, 4, 7);
            squadmate1DownButton.Name = "squadmate1DownButton";
            squadmate1DownButton.Size = new System.Drawing.Size(39, 39);
            squadmate1DownButton.TabIndex = 0;
            squadmate1DownButton.Text = "↓";
            squadmate1DownButton.UseVisualStyleBackColor = true;
            squadmate1DownButton.Visible = false;
            squadmate1DownButton.Click += squadmate1DownButton_Click;
            // 
            // squadmate3ArrowTableLayoutPanel
            // 
            squadmate3ArrowTableLayoutPanel.ColumnCount = 1;
            squadmate3ArrowTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            squadmate3ArrowTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            squadmate3ArrowTableLayoutPanel.Controls.Add(squadmate3UpButton, 0, 0);
            squadmate3ArrowTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            squadmate3ArrowTableLayoutPanel.Location = new System.Drawing.Point(452, 182);
            squadmate3ArrowTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            squadmate3ArrowTableLayoutPanel.Name = "squadmate3ArrowTableLayoutPanel";
            squadmate3ArrowTableLayoutPanel.RowCount = 2;
            squadmate3ArrowTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            squadmate3ArrowTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            squadmate3ArrowTableLayoutPanel.Size = new System.Drawing.Size(47, 93);
            squadmate3ArrowTableLayoutPanel.TabIndex = 2;
            // 
            // squadmate3UpButton
            // 
            squadmate3UpButton.Dock = System.Windows.Forms.DockStyle.Fill;
            squadmate3UpButton.Location = new System.Drawing.Point(4, 7);
            squadmate3UpButton.Margin = new System.Windows.Forms.Padding(4, 7, 4, 0);
            squadmate3UpButton.Name = "squadmate3UpButton";
            squadmate3UpButton.Size = new System.Drawing.Size(39, 39);
            squadmate3UpButton.TabIndex = 0;
            squadmate3UpButton.Text = "↑";
            squadmate3UpButton.UseVisualStyleBackColor = true;
            squadmate3UpButton.Visible = false;
            squadmate3UpButton.Click += squadmate3UpButton_Click;
            // 
            // mainTableLayoutPanel
            // 
            mainTableLayoutPanel.ColumnCount = 2;
            mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 408F));
            mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            mainTableLayoutPanel.Controls.Add(consoleLogTextBox, 0, 1);
            mainTableLayoutPanel.Controls.Add(updateNoticeLinkLabel, 1, 2);
            mainTableLayoutPanel.Controls.Add(squadmatesTableLayoutPanel, 1, 0);
            mainTableLayoutPanel.Controls.Add(infoTableLayoutPanel, 0, 0);
            mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            mainTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            mainTableLayoutPanel.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            mainTableLayoutPanel.RowCount = 3;
            mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 231F));
            mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            mainTableLayoutPanel.Size = new System.Drawing.Size(915, 535);
            mainTableLayoutPanel.TabIndex = 29;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItem1 });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(94, 26);
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size(93, 22);
            toolStripMenuItem1.Text = "test";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Control;
            ClientSize = new System.Drawing.Size(915, 535);
            Controls.Add(mainTableLayoutPanel);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Text = Program.ProgramName;
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            Resize += Form1_Resize;
            ((System.ComponentModel.ISupportInitialize)previewPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)squadmate1GearPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)squadmate2GearPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)squadmate3GearPictureBox).EndInit();
            infoTableLayoutPanel.ResumeLayout(false);
            infoTableLayoutPanel.PerformLayout();
            previewTableLayoutPanel.ResumeLayout(false);
            squadmatesTableLayoutPanel.ResumeLayout(false);
            squadmate2ArrowTableLayoutPanel.ResumeLayout(false);
            squadmate1ArrowTableLayoutPanel.ResumeLayout(false);
            squadmate3ArrowTableLayoutPanel.ResumeLayout(false);
            mainTableLayoutPanel.ResumeLayout(false);
            mainTableLayoutPanel.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
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
        private System.Windows.Forms.CheckBox debugOverlayCheckbox;
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

