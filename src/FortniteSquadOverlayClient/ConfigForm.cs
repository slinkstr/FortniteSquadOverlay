using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FortniteSquadOverlayClient
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
            PropagateTooltips(this.Controls);
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            ConfigLoadFields();
            autorunCheckBox.Checked = AutorunEnabled();
            Program.MainWindow.SetAlwaysOnTop(false);
        }

        // ****************************************************************************************************
        // HELPER METHODS
        // ****************************************************************************************************
        private static bool AutorunEnabled()
        {
            string startupFolder = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            var proc = System.Diagnostics.Process.GetCurrentProcess();
            var shortcut = Path.Combine(startupFolder, proc.ProcessName + ".lnk");
            if (File.Exists(shortcut))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void AutorunSet(bool enabled)
        {
            string startupFolder = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            var proc = System.Diagnostics.Process.GetCurrentProcess();
            var shortcut = Path.Combine(startupFolder, proc.ProcessName + ".lnk");

            if (enabled)
            {
                CreateShortcut(shortcut, proc.MainModule.FileName);
            }
            else
            {
                File.Delete(shortcut);
            }
        }

        private void ConfigLoadFields()
        {
            var cfg = Program.Config;

            secretKeyTextBoxEx.Text             = cfg.SecretKey;
            uploadEndpointTextBoxEx.Text        = cfg.UploadEndpoint;
            imageLocationTextBoxEx.Text         = cfg.ImageLocation;
            uploadIntervalNumericUpDown.Value   = MiscUtil.MinMax((int)uploadIntervalNumericUpDown.Minimum,   cfg.UploadInterval,   (int)uploadIntervalNumericUpDown.Maximum);
            downloadIntervalNumericUpDown.Value = MiscUtil.MinMax((int)downloadIntervalNumericUpDown.Minimum, cfg.DownloadInterval, (int)downloadIntervalNumericUpDown.Maximum);
            hudScaleNumericUpDown.Value         = MiscUtil.MinMax((int)hudScaleNumericUpDown.Minimum,         cfg.HudScale,         (int)hudScaleNumericUpDown.Maximum);
            overlayOpacityNumericUpDown.Value   = cfg.OverlayOpacity;
            showConsoleCheckBox.Checked         = cfg.ShowConsole;
            enableOverlayCheckBox.Checked       = cfg.EnableOverlay;
            minimizeToTrayCheckBox.Checked      = cfg.MinimizeToTray;
            startMinimizedCheckBox.Checked      = cfg.StartMinimized;
            alwaysOnTopCheckBox.Checked         = cfg.AlwaysOnTop;
        }

        private bool ConfigSaveFields()
        {
            try
            {
                var cfg = new Config(Program.Config)
                {
                    SecretKey        = secretKeyTextBoxEx.Text,
                    UploadEndpoint   = uploadEndpointTextBoxEx.Text,
                    ImageLocation    = imageLocationTextBoxEx.Text,
                    UploadInterval   = (int)uploadIntervalNumericUpDown.Value,
                    DownloadInterval = (int)downloadIntervalNumericUpDown.Value,
                    HudScale         = (int)hudScaleNumericUpDown.Value,
                    OverlayOpacity   = (int)overlayOpacityNumericUpDown.Value,
                    ShowConsole      = showConsoleCheckBox.Checked,
                    EnableOverlay    = enableOverlayCheckBox.Checked,
                    MinimizeToTray   = minimizeToTrayCheckBox.Checked,
                    StartMinimized   = startMinimizedCheckBox.Checked,
                    AlwaysOnTop      = alwaysOnTopCheckBox.Checked,
                };
                
                cfg.Save();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, Program.ProgramName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private static void CreateShortcut(string dest, string targetFile)
        {
            // https://stackoverflow.com/a/19914018
            Type t = Type.GetTypeFromCLSID(new Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8")); //Windows Script Host Shell Object
            dynamic shell = Activator.CreateInstance(t);
            try
            {
                var lnk = shell.CreateShortcut(dest);
                try
                {
                    string icon = targetFile.Replace("\\", "/") + ", 0";
                    lnk.TargetPath = targetFile;
                    lnk.IconLocation = icon;
                    lnk.WorkingDirectory = Path.GetDirectoryName(targetFile);
                    lnk.Save();
                }
                finally
                {
                    Marshal.FinalReleaseComObject(lnk);
                }
            }
            finally
            {
                Marshal.FinalReleaseComObject(shell);
            }
        }

        private void PropagateTooltips(Control.ControlCollection controls, string tooltip = "")
        {
            if (controls == null)
            {
                return;
            }

            foreach (Control control in controls)
            {
                string curToolTip = toolTip1.GetToolTip(control);
                if (string.IsNullOrWhiteSpace(curToolTip))
                {
                    if (!string.IsNullOrWhiteSpace(tooltip))
                    {
                        toolTip1.SetToolTip(control, tooltip);
                    }
                }
                PropagateTooltips(control.Controls, curToolTip);
            }
        }

        // ****************************************************************************************************
        // CONTROL EVENT HANDLERS
        // ****************************************************************************************************
        private void ConfigForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.MainWindow.ShowHideConsole(Program.Config.ShowConsole);
            Program.MainWindow.SetAlwaysOnTop(Program.Config.AlwaysOnTop);
        }

        private void autostartCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            AutorunSet(checkBox.Checked);
        }

        private void openFileLocationButton_Click(object sender, EventArgs e)
        {
            Program.Config.OpenFolder();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void imageLocationTextBoxEx_TextChanged(object sender, EventArgs e)
        {
            TextBoxEx textBox = (TextBoxEx)sender;
            if (MiscUtil.imageLocationRegex.Match(textBox.Text).Success)
            {
                textBox.BorderColor = Color.Green;
            }
            else
            {
                textBox.BorderColor = Color.Red;
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            Program.Config.Load();
            ConfigLoadFields();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(!ConfigSaveFields()) { return; }
            Program.Config.Load();
            Close();
        }

        private void uploadEndpointTextBoxEx_TextChanged(object sender, EventArgs e)
        {
            TextBoxEx textBox = (TextBoxEx)sender;
            if (MiscUtil.uploadEndpointRegex.Match(textBox.Text).Success)
            {
                textBox.BorderColor = Color.Green;
            }
            else
            {
                textBox.BorderColor = Color.Red;
            }
        }
    }

    // https://stackoverflow.com/a/39420512
    public class TextBoxEx : TextBox
    {
        const int WM_NCPAINT = 0x85;
        const uint RDW_INVALIDATE = 0x1;
        const uint RDW_IUPDATENOW = 0x100;
        const uint RDW_FRAME = 0x400;
        [DllImport("user32.dll")]
        static extern IntPtr GetWindowDC(IntPtr hWnd);
        [DllImport("user32.dll")]
        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        [DllImport("user32.dll")]
        static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprc, IntPtr hrgn, uint flags);
        Color borderColor = Color.Blue;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                RedrawWindow(Handle, IntPtr.Zero, IntPtr.Zero,
                    RDW_FRAME | RDW_IUPDATENOW | RDW_INVALIDATE);
            }
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCPAINT && BorderColor != Color.Transparent &&
                BorderStyle == System.Windows.Forms.BorderStyle.Fixed3D)
            {
                var hdc = GetWindowDC(this.Handle);
                using (var g = Graphics.FromHdcInternal(hdc))
                using (var p = new Pen(BorderColor))
                {
                    g.DrawRectangle(p, new Rectangle(0, 0, Width - 1, Height - 1));
                }
                ReleaseDC(this.Handle, hdc);
            }
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            RedrawWindow(Handle, IntPtr.Zero, IntPtr.Zero,
                   RDW_FRAME | RDW_IUPDATENOW | RDW_INVALIDATE);
        }
    }
}
