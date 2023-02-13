﻿using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FortniteOverlay
{
    public partial class Form1 : Form
    {
        private int consoleHeight;
        private bool firstShow;

        public Form1()
        {
            InitializeComponent();
            consoleHeight = consoleLogTextBox.Size.Height;
            Text += " v" + Application.ProductVersion;
            Icon = Icon.ExtractAssociatedIcon(AppDomain.CurrentDomain.FriendlyName);
            notifyIcon.Icon = Icon.ExtractAssociatedIcon(AppDomain.CurrentDomain.FriendlyName);
            firstShow = true;
        }
        
        protected override bool ShowWithoutActivation
        {
            get
            {
                if(firstShow)
                {
                    firstShow = false;
                    return Program.config.StartMinimized;
                }
                return false;
            }
        }

        // ****************************************************************************************************
        // HELPER METHODS
        // ****************************************************************************************************
        public ProgramOptions CurrentProgramOptions()
        {
            return new ProgramOptions()
            {
                DebugOverlay = debugOverlayCheckbox.Checked
            };
        }

        public void Log(string message)
        {
            message = $"[{DateTime.Now}] {message.Replace("\n", Environment.NewLine)}" + Environment.NewLine;
            if (consoleLogTextBox.InvokeRequired)
            {
                consoleLogTextBox.Invoke(new MethodInvoker(delegate { consoleLogTextBox.AppendText(message); }));
            }
            else
            {
                consoleLogTextBox.AppendText(message);
            }
            Console.Write(message);
        }

        public void LogDebug(string message)
        {
            if(!(CurrentProgramOptions().DebugOverlay))
            {
                return;
            }

            message = $"[{DateTime.Now}] {message.Replace("\n", Environment.NewLine)}" + Environment.NewLine;
            if (consoleLogTextBox.InvokeRequired)
            {
                consoleLogTextBox.Invoke(new MethodInvoker(delegate { consoleLogTextBox.AppendText(message); }));
            }
            else
            {
                consoleLogTextBox.AppendText(message);
            }
            Console.Write(message);
        }

        public void MinimizeToTray()
        {
            ShowInTaskbar = false;
            notifyIcon.Visible = true;
            WindowState = FormWindowState.Minimized;
            Hide();
        }

        public void UnminimizeFromTray()
        {
            Show();
            ShowInTaskbar = true;
            notifyIcon.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        public void SetAlwaysOnTop(bool ontop)
        {
            TopMost = ontop;
        }

        public static void SetControlProperty(Control control, string propertyName, object data)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new MethodInvoker(delegate { control.GetType().GetProperty(propertyName).SetValue(control, data); }));
            }
            else
            {
                control.GetType().GetProperty(propertyName).SetValue(control, data);
            }
        }

        public void SetSelfName(string name)
        {
            SetControlProperty(previewLabel, "Text", name);
            if(string.IsNullOrWhiteSpace(name)) { SetControlProperty(previewLabel, "ContextMenuStrip", null); }
            else                                { SetControlProperty(previewLabel, "ContextMenuStrip", contextMenuStrip1); }

        }

        public void SetSelfGear(Bitmap bmp)
        {
            SetControlProperty(previewPictureBox, "Image", bmp);
            if(bmp == null) { SetControlProperty(previewPictureBox, "ContextMenuStrip", null); }
            else            { SetControlProperty(previewPictureBox, "ContextMenuStrip", contextMenuStrip1); }
        }

        public void SetSquadGear(int index, Bitmap bmp)
        {
            switch (index)
            {
                case 0:
                    SetControlProperty(squadmate1GearPictureBox, "Image", bmp);
                    if(bmp == null) { SetControlProperty(squadmate1GearPictureBox, "ContextMenuStrip", null); }
                    else            { SetControlProperty(squadmate1GearPictureBox, "ContextMenuStrip", contextMenuStrip1); }
                    break;
                case 1:
                    SetControlProperty(squadmate2GearPictureBox, "Image", bmp);
                    if(bmp == null) { SetControlProperty(squadmate2GearPictureBox, "ContextMenuStrip", null); }
                    else            { SetControlProperty(squadmate2GearPictureBox, "ContextMenuStrip", contextMenuStrip1); }
                    break;
                case 2:
                    SetControlProperty(squadmate3GearPictureBox, "Image", bmp);
                    if(bmp == null) { SetControlProperty(squadmate3GearPictureBox, "ContextMenuStrip", null); }
                    else            { SetControlProperty(squadmate3GearPictureBox, "ContextMenuStrip", contextMenuStrip1); }
                    break;
                default:
                    throw new Exception("Invalid index in SetSquadGear");
            }
        }

        public void SetSquadName(int index, string name)
        {
            switch (index)
            {
                case 0:
                    SetControlProperty(squadmate1NameLabel, "Text", name);
                    if(string.IsNullOrWhiteSpace(name)) { SetControlProperty(squadmate1NameLabel, "ContextMenuStrip", null); }
                    else                                { SetControlProperty(squadmate1NameLabel, "ContextMenuStrip", contextMenuStrip1); }
                    break;
                case 1:
                    SetControlProperty(squadmate2NameLabel, "Text", name);
                    if(string.IsNullOrWhiteSpace(name)) { SetControlProperty(squadmate2NameLabel, "ContextMenuStrip", null); }
                    else                                { SetControlProperty(squadmate2NameLabel, "ContextMenuStrip", contextMenuStrip1); }
                    break;
                case 2:
                    SetControlProperty(squadmate3NameLabel, "Text", name);
                    if(string.IsNullOrWhiteSpace(name)) { SetControlProperty(squadmate3NameLabel, "ContextMenuStrip", null); }
                    else                                { SetControlProperty(squadmate3NameLabel, "ContextMenuStrip", contextMenuStrip1); }
                    break;
                default:
                    throw new Exception("Invalid index in SetSquadName");
            }
        }

        public void SetUpdateNotice(string text, string url = "")
        {
            updateNoticeLinkLabel.Text = text;
            updateNoticeLinkLabel.LinkArea = string.IsNullOrWhiteSpace(url) ? new LinkArea(0, 0) : new LinkArea(0, updateNoticeLinkLabel.Text.Length);
            updateNoticeLinkLabel.Tag = url;
            updateNoticeLinkLabel.LinkVisited = false;
        }

        public void ShowHideConsole(bool showConsole)
        {
            if (consoleLogTextBox.Visible == showConsole)
            {
                return;
            }

            int tableRow = mainTableLayoutPanel.GetRow(consoleLogTextBox);
            consoleLogTextBox.Visible = showConsole;
            mainTableLayoutPanel.RowStyles[tableRow].Height = showConsole ? consoleHeight : 0;
            Size = new Size(Size.Width, Size.Height + (showConsole ? consoleHeight : consoleHeight * -1));
        }

        public void ShowHideSortButtons(int squadmates)
        {
            SetControlProperty(squadmate1DownButton, "Visible", (squadmates > 1));
            SetControlProperty(squadmate2UpButton,   "Visible", (squadmates > 1));
            SetControlProperty(squadmate2DownButton, "Visible", (squadmates > 2));
            SetControlProperty(squadmate3UpButton,   "Visible", (squadmates > 2));
        }

        private static void SwapSquad(int indexA, int indexB)
        {
            var max = indexA > indexB ? indexA : indexB;
            if (Program.fortniters.Count < max + 1) { return; }
            var temp = Program.fortniters[indexA];
            Program.fortniters[indexA] = Program.fortniters[indexB];
            Program.fortniters[indexB] = temp;
            Program.UpdateFormElements();
        }

        // ****************************************************************************************************
        // CONTROL EVENT HANDLERS
        // ****************************************************************************************************
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            notifyIcon.Icon = null;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ShowHideConsole(Program.config.ShowConsole);
            SetAlwaysOnTop(Program.config.AlwaysOnTop);
            if(Program.config.StartMinimized)
            {
                WindowState = FormWindowState.Minimized;
                MinimizeToTray();
            }
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized && Program.config.MinimizeToTray)
            {
                MinimizeToTray();
            }
        }

        private void editConfigButton_Click(object sender, EventArgs e)
        {
            FormCollection forms = Application.OpenForms;
            foreach(Form form in forms)
            {
                if (form.Name == "ConfigForm")
                {
                    form.Focus();
                    return;
                }
            }

            new ConfigForm().Show();
        }
        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                UnminimizeFromTray();
            }
        }
        private void showConsoleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var visible = ((CheckBox)sender).Checked;

            mainTableLayoutPanel.RowStyles[1].Height = (visible ? consoleHeight : 0);
            Size = new Size(Size.Width, Size.Height + (visible ? consoleHeight : consoleHeight * -1));
        }

        private void squadmate1DownButton_Click(object sender, EventArgs e)
        {
            SwapSquad(0, 1);
        }
        private void squadmate2DownButton_Click(object sender, EventArgs e)
        {
            SwapSquad(1, 2);
        }
        private void squadmate2UpButton_Click(object sender, EventArgs e)
        {
            SwapSquad(0, 1);
        }
        private void squadmate3UpButton_Click(object sender, EventArgs e)
        {
            SwapSquad(1, 2);
        }

        private void updateNoticeLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var label = (LinkLabel)sender;
            updateNoticeLinkLabel.LinkVisited = true;
            System.Diagnostics.Process.Start(label.Tag.ToString());
        }

        private Fortniter FortniterAtUiIndex(int uiIndex)
        {
            Label control = null;
            switch (uiIndex)
            {
                case 0:
                    control = previewLabel;
                    break;
                case 1:
                    control = squadmate1NameLabel;
                    break;
                case 2:
                    control = squadmate2NameLabel;
                    break;
                case 3:
                    control = squadmate3NameLabel;
                    break;
                default:
                    throw new Exception("Invalid index given to CopyName");
            }
            if(control == previewLabel)
            {
                return Program.localPlayer;
            }
            var fortniter = Program.fortniters.FirstOrDefault(x => x.Name == control.Text);
            return fortniter;
        }

        private void CopyName(object sender, EventArgs e, int index)
        {
            var fortniter = FortniterAtUiIndex(index);
            if (fortniter == null)
            {
                return;
            }
            Clipboard.SetText(fortniter.Name);
        }

        private void CopyUID(object sender, EventArgs e, int index)
        {
            var fortniter = FortniterAtUiIndex(index);
            if (fortniter == null)
            {
                return;
            }
            Clipboard.SetText(fortniter.UserId);
        }

        private void CopyImage(object sender, EventArgs e, int index)
        {
            var fortniter = FortniterAtUiIndex(index);
            if (fortniter == null)
            {
                return;
            }
            Clipboard.SetDataObject(fortniter.GearImage);
        }

        private void OpenTracker(object sender, EventArgs e, int index)
        {
            var fortniter = FortniterAtUiIndex(index);
            if (fortniter == null)
            {
                return;
            }
            System.Diagnostics.Process.Start("https://fortnitetracker.com/profile/search?q=" + fortniter.UserId);
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ToolStripMenuItem copyName    = new ToolStripMenuItem("Copy &name");
            ToolStripMenuItem copyUid     = new ToolStripMenuItem("Copy &UID");
            ToolStripMenuItem copyImage   = new ToolStripMenuItem("Copy &image");
            ToolStripMenuItem openTracker = new ToolStripMenuItem("Open in &FortniteTracker");

            var src = contextMenuStrip1.SourceControl;
            var index = src.Name.StartsWith("preview") ? 0 : int.Parse(src.Name.Substring(9, 1));

            copyName.Click += (snd, evtargs) => CopyName(snd, evtargs, index);
            copyUid.Click += (snd, evtargs) => CopyUID(snd, evtargs, index);
            copyImage.Click += (snd, evtargs) => CopyImage(snd, evtargs, index);
            openTracker.Click += (snd, evtargs) => OpenTracker(snd, evtargs, index);

            contextMenuStrip1.Items.Clear();
            contextMenuStrip1.Items.Add(copyName);
            contextMenuStrip1.Items.Add(copyUid);
            if (src is PictureBox && ((PictureBox)src).Image != null)
            {
                contextMenuStrip1.Items.Add(copyImage);
            }
            contextMenuStrip1.Items.Add(openTracker);
        }
    }

    public class ProgramOptions
    {
        public bool DebugOverlay;
    }
}
