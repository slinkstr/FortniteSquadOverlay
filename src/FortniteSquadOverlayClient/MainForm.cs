using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FortniteSquadOverlayClient
{
    public partial class MainForm : Form
    {
        private int _consoleHeight;
        private bool _firstShow = true;

        public MainForm()
        {
            InitializeComponent();
            _consoleHeight = consoleLogTextBox.Size.Height;
            Text += " v" + Program.Updater.CurrentVersion();
            Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
            notifyIcon.Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }
        
        protected override bool ShowWithoutActivation
        {
            get
            {
                if (_firstShow)
                {
                    _firstShow = false;
                    return Program.Config.StartMinimized;
                }
                return false;
            }
        }

        // ****************************************************************************************************
        // HELPER METHODS
        // ****************************************************************************************************

        public void Log(string message)
        {
            message = message.Replace("\n", Environment.NewLine) + Environment.NewLine;
            if (consoleLogTextBox.InvokeRequired)
            {
                consoleLogTextBox.Invoke(new MethodInvoker(delegate { consoleLogTextBox.AppendText(message); }));
            }
            else
            {
                consoleLogTextBox.AppendText(message);
            }
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
            SetControlProperty(previewLabel, "ContextMenuStrip", string.IsNullOrWhiteSpace(name) ? null : contextMenuStrip1);

        }

        public void SetSelfGear(Bitmap bmp)
        {
            SetControlProperty(previewPictureBox, "Image", bmp);
            SetControlProperty(previewPictureBox, "ContextMenuStrip", bmp == null ? null : contextMenuStrip1);
        }

        public void SetSquadGear(int index, Bitmap bmp)
        {
            switch (index)
            {
                case 0:
                    SetControlProperty(squadmate1GearPictureBox, "Image", bmp);
                    SetControlProperty(squadmate1GearPictureBox, "ContextMenuStrip", bmp == null ? null : contextMenuStrip1);
                    break;
                case 1:
                    SetControlProperty(squadmate2GearPictureBox, "Image", bmp);
                    SetControlProperty(squadmate2GearPictureBox, "ContextMenuStrip", bmp == null ? null : contextMenuStrip1);
                    break;
                case 2:
                    SetControlProperty(squadmate3GearPictureBox, "Image", bmp);
                    SetControlProperty(squadmate3GearPictureBox, "ContextMenuStrip", bmp == null ? null : contextMenuStrip1);
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
                    SetControlProperty(squadmate1NameLabel, "ContextMenuStrip", string.IsNullOrWhiteSpace(name) ? null : contextMenuStrip1);
                    break;
                case 1:
                    SetControlProperty(squadmate2NameLabel, "Text", name);
                    SetControlProperty(squadmate2NameLabel, "ContextMenuStrip", string.IsNullOrWhiteSpace(name) ? null : contextMenuStrip1);
                    break;
                case 2:
                    SetControlProperty(squadmate3NameLabel, "Text", name);
                    SetControlProperty(squadmate3NameLabel, "ContextMenuStrip", string.IsNullOrWhiteSpace(name) ? null : contextMenuStrip1);
                    break;
                default:
                    throw new Exception("Invalid index in SetSquadName");
            }
        }

        public void SetUpdateNotice(string text)
        {
            SetControlProperty(updateNoticeLinkLabel, "Text", text);
            SetControlProperty(updateNoticeLinkLabel, "LinkArea", new LinkArea(0, updateNoticeLinkLabel.Text.Length));
            SetControlProperty(updateNoticeLinkLabel, "LinkVisited", false);
            //SetControlProperty(updateNoticeLinkLabel, "Tag", url);
        }

        public void ShowHideConsole(bool showConsole)
        {
            if (!Visible)
            {
                return;
            }
            if (consoleLogTextBox.Visible == showConsole)
            {
                return;
            }

            int tableRow = mainTableLayoutPanel.GetRow(consoleLogTextBox);
            consoleLogTextBox.Visible = showConsole;
            mainTableLayoutPanel.RowStyles[tableRow].Height = showConsole ? _consoleHeight : 0;
            Size = new System.Drawing.Size(Size.Width, Size.Height + (showConsole ? _consoleHeight : _consoleHeight * -1));
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
            if (Program.CurrentSquad.Count < max + 1) { return; }
            (Program.CurrentSquad[indexA], Program.CurrentSquad[indexB]) = (Program.CurrentSquad[indexB], Program.CurrentSquad[indexA]);
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
            ShowHideConsole(Program.Config.ShowConsole);
            SetAlwaysOnTop(Program.Config.AlwaysOnTop);
            if (Program.Config.StartMinimized)
            {
                WindowState = FormWindowState.Minimized;
                MinimizeToTray();
            }
        }
        
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized && Program.Config.MinimizeToTray)
            {
                MinimizeToTray();
            }
        }

        private void editConfigButton_Click(object sender, EventArgs e)
        {
            FormCollection forms = Application.OpenForms;
            foreach (Form form in forms)
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
            if (e.Button == MouseButtons.Left)
            {
                UnminimizeFromTray();
            }
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
            var taskDialog = TaskDialog.ShowDialog(new TaskDialogPage
            {
                Caption = "Update",
                Heading = "Download update?",
                Buttons =
                {
                    new TaskDialogButton
                    {
                        Text = "One-click update",
                        Tag = "oneclick",
                    },
                    new TaskDialogButton
                    {
                        Text = "Open in browser",
                        Tag = "open",
                    },
                    new TaskDialogButton
                    {
                        Text = "Cancel",
                        Tag = "cancel",
                    }
                }
            });
            
            switch((string)taskDialog.Tag)
            {
                case "cancel":  return;
                case "open":
                    MiscUtil.OpenInDefaultBrowser("https://github.com/slinkstr/FortniteSquadOverlay/releases/latest");
                    break;
                case "oneclick":
                {
                    Application.UseWaitCursor = true;
                    updateNoticeLinkLabel.Enabled = false;
                    updateNoticeLinkLabel.LinkVisited = true;
                    Task.Run(async () =>
                    {
                        await Program.Updater.Update();
                        Application.UseWaitCursor = false;
                        SetControlProperty(updateNoticeLinkLabel, "Enabled", true);
                    });
                } break;
            }
        }

        private FortnitePlayer FortniterAtUiIndex(int uiIndex)
        {
            if (uiIndex == 0)
            {
                return Program.LocalPlayer;
            }

            Label control = null;
            switch (uiIndex)
            {
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
            var fortniter = Program.CurrentSquad.FirstOrDefault(x => x.Name == control.Text);
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
            MiscUtil.OpenInDefaultBrowser("https://fortnitetracker.com/profile/search?q=" + fortniter.UserId);
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

        private void debugOverlayCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Program.DebugMode = ((CheckBox)sender).Checked;
        }
    }
}
