using System.Windows.Forms;

namespace FortniteSquadOverlayClient
{
    partial class OverlayForm
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

        // https://stackoverflow.com/a/72831565
        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_EX_LAYERED = 0x80000;
                const int WS_EX_TRANSPARENT = 0x20;
                const int WS_EX_TOOLWINDOW = 0x80;
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= WS_EX_LAYERED;
                cp.ExStyle |= WS_EX_TRANSPARENT;
                cp.ExStyle |= WS_EX_TOOLWINDOW;
                return cp;
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            debugPictureBox = new System.Windows.Forms.PictureBox();
            squadmateGearPictureBox2 = new System.Windows.Forms.PictureBox();
            squadmateGearPictureBox1 = new System.Windows.Forms.PictureBox();
            squadmateGearPictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)debugPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)squadmateGearPictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)squadmateGearPictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)squadmateGearPictureBox3).BeginInit();
            SuspendLayout();
            // 
            // debugPictureBox
            // 
            debugPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            debugPictureBox.BackColor = System.Drawing.Color.Lime;
            debugPictureBox.Location = new System.Drawing.Point(0, 0);
            debugPictureBox.Margin = new System.Windows.Forms.Padding(0);
            debugPictureBox.Name = "debugPictureBox";
            debugPictureBox.Size = new System.Drawing.Size(1920, 1080);
            debugPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            debugPictureBox.TabIndex = 5;
            debugPictureBox.TabStop = false;
            // 
            // squadmateGearPictureBox2
            // 
            squadmateGearPictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            squadmateGearPictureBox2.BackColor = System.Drawing.Color.Lime;
            squadmateGearPictureBox2.Location = new System.Drawing.Point(0, 92);
            squadmateGearPictureBox2.Margin = new System.Windows.Forms.Padding(0);
            squadmateGearPictureBox2.Name = "squadmateGearPictureBox2";
            squadmateGearPictureBox2.Size = new System.Drawing.Size(373, 92);
            squadmateGearPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            squadmateGearPictureBox2.TabIndex = 3;
            squadmateGearPictureBox2.TabStop = false;
            // 
            // squadmateGearPictureBox1
            // 
            squadmateGearPictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            squadmateGearPictureBox1.BackColor = System.Drawing.Color.Lime;
            squadmateGearPictureBox1.Location = new System.Drawing.Point(0, 0);
            squadmateGearPictureBox1.Margin = new System.Windows.Forms.Padding(0);
            squadmateGearPictureBox1.Name = "squadmateGearPictureBox1";
            squadmateGearPictureBox1.Size = new System.Drawing.Size(373, 92);
            squadmateGearPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            squadmateGearPictureBox1.TabIndex = 2;
            squadmateGearPictureBox1.TabStop = false;
            // 
            // squadmateGearPictureBox3
            // 
            squadmateGearPictureBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            squadmateGearPictureBox3.BackColor = System.Drawing.Color.Lime;
            squadmateGearPictureBox3.Location = new System.Drawing.Point(0, 184);
            squadmateGearPictureBox3.Margin = new System.Windows.Forms.Padding(0);
            squadmateGearPictureBox3.Name = "squadmateGearPictureBox3";
            squadmateGearPictureBox3.Size = new System.Drawing.Size(373, 92);
            squadmateGearPictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            squadmateGearPictureBox3.TabIndex = 4;
            squadmateGearPictureBox3.TabStop = false;
            // 
            // OverlayForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Lime;
            ClientSize = new System.Drawing.Size(1920, 1080);
            Controls.Add(squadmateGearPictureBox3);
            Controls.Add(squadmateGearPictureBox2);
            Controls.Add(squadmateGearPictureBox1);
            Controls.Add(debugPictureBox);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "OverlayForm";
            TopMost = true;
            TransparencyKey = System.Drawing.Color.Lime;
            Resize += OverlayForm_Resize;
            ((System.ComponentModel.ISupportInitialize)debugPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)squadmateGearPictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)squadmateGearPictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)squadmateGearPictureBox3).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.PictureBox debugPictureBox;
        private System.Windows.Forms.PictureBox squadmateGearPictureBox2;
        private System.Windows.Forms.PictureBox squadmateGearPictureBox1;
        private System.Windows.Forms.PictureBox squadmateGearPictureBox3;
    }
}