using System;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Windows.Forms;

namespace PDFAnalyzer
{
    public partial class Main : Form
    {
        private static readonly FileSystemWatcher realtime = new FileSystemWatcher();
        //forms for analysis reports: they are for ondemand and real-time analysis and for ondemand folder analysis
        private static ReportMain reportMain;
        private static Report reportWindow;

        private string quarantine = "";

        private AnalysisEngine engine;
        #region UI
        public ListBox getListbox()
        {
            return this.listBox1;
        }
      
        public void EnableOrDisableUI(bool state) {
            if(state == true)
            {
                label3.Visible = false;
                this.Update();
                this.RealtimeButton.Enabled = true;
                this.AnalyzePDFButton.Enabled = true;
                this.AnalyzeFolderButton.Enabled = true;
                this.QuarantineButton.Enabled = true;
                this.RestoreButton.Enabled = true;
                this.DeleteButton.Enabled = true;
                this.Home.Enabled = true;
                this.WhitelistButton.Enabled = true;
            }
            else
            {
                label3.Visible = true;
                this.Update();
                this.RealtimeButton.Enabled = false;
                this.AnalyzePDFButton.Enabled = false;
                this.AnalyzeFolderButton.Enabled = false;
                this.QuarantineButton.Enabled = false;
                this.RestoreButton.Enabled = false;
                this.DeleteButton.Enabled = false;
                this.Home.Enabled = false;
                this.WhitelistButton.Enabled = false;
            }
        }
        private void home_Button(object sender, EventArgs e)
        {
            RealtimeButton.Visible = true;
            AnalyzePDFButton.Visible = true;
            AnalyzeFolderButton.Visible = true;
            QuarantineButton.Visible = true;
            RestoreButton.Visible = false;
            DeleteButton.Visible = false;
            Home.Visible = false;
            label2.Visible = true;
            listBox1.Visible = false;
            WhitelistButton.Visible = true;
            label4.Visible = true;

        }

        #endregion

        #region Analysis
        private void analyzeFolderButton_Click(object sender, EventArgs e)
        {
            realtime.EnableRaisingEvents = false;

            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK && !(IsDirectoryEmpty(folderDialog.SelectedPath)))
                {
                    EnableOrDisableUI(false);
                    engine.AnalysisFolder(folderDialog.SelectedPath);
                    EnableOrDisableUI(true);
                }

                realtime.EnableRaisingEvents = true;
            }
        }

        public bool IsDirectoryEmpty(string directory)
        {
            return !Directory.EnumerateFileSystemEntries(directory).Any();
        }

        private void analyzePDFButton_Click(object sender, EventArgs e)
        {
            realtime.EnableRaisingEvents = false;

            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                engine.ScanOnDemand(file.FileName);

            }

            realtime.EnableRaisingEvents = true;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                realtime.EnableRaisingEvents = false;

                File.Delete(listBox1.SelectedItem.ToString());
                listBox1.Items.Remove(listBox1.SelectedItem);

                realtime.EnableRaisingEvents = true;
                MessageBox.Show("The PDF was deleted.");
            }
            catch (NullReferenceException e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void whitelistButton_Click(object sender, EventArgs e)
        {
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\PDFAnalyzerWhitelist.txt", "");
            MessageBox.Show("The whitelist is now empty.");
            Application.Restart();
        }

        public void QuarantineFile(string originalPath)
        {
            File.Move(originalPath, Path.Combine(Path.GetDirectoryName(originalPath), Path.GetFileNameWithoutExtension(originalPath) + ".blocked"));
            string newPath = Path.Combine(Path.GetDirectoryName(originalPath), Path.GetFileNameWithoutExtension(originalPath) + ".blocked");

            File.Move(newPath, quarantine + Path.GetFileName(newPath));
        }

        public string GetQuarantine()
        {
            return quarantine;
        }
        private void quarantineButton_Click(object sender, EventArgs e)
        {
            RealtimeButton.Visible = false;
            AnalyzePDFButton.Visible = false;
            AnalyzeFolderButton.Visible = false;
            QuarantineButton.Visible = false;
            label2.Visible = false;
            RestoreButton.Visible = true;
            DeleteButton.Visible = true;
            Home.Visible = true;
            listBox1.Visible = true;
            WhitelistButton.Visible = false;
            label4.Visible = false;
        }

        private void restoreButton_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    //prevent realtime events while we restore files from quarantine
                    realtime.EnableRaisingEvents = false;

                    realtime.Changed -= OnPDFChange;
                    realtime.Created -= OnPDFChange;
                    string originalPath = listBox1.SelectedItem.ToString();

                    File.AppendAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\PDFAnalyzerWhitelist.txt", originalPath);

                    File.Move(originalPath, Path.Combine(Path.GetDirectoryName(originalPath), Path.GetFileNameWithoutExtension(originalPath) + ".pdf"));

                    File.Move(Path.Combine(Path.GetDirectoryName(originalPath), Path.GetFileNameWithoutExtension(originalPath) + ".pdf"), Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), Path.GetFileNameWithoutExtension(originalPath) + ".pdf"));
                    listBox1.Items.Remove(listBox1.SelectedItem);

                    MessageBox.Show("The PDF was restored on Desktop");
                }
                catch (IOException e1)
                {
                    MessageBox.Show(e1.Message);
                }

                //we re-turn on realtime protection
                realtime.Changed += OnPDFChange;
                realtime.Created += OnPDFChange;
                realtime.EnableRaisingEvents = true;
            }
            catch(NullReferenceException e2)
            {
                MessageBox.Show(e2.Message);
            }
          
        }
        #endregion

        #region EventHandler
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        private void StartRealtimeProtection()
        {
            realtime.Path = "c:\\";

            realtime.NotifyFilter = NotifyFilters.LastAccess
                                     | NotifyFilters.LastWrite
                                     | NotifyFilters.FileName
                                     | NotifyFilters.DirectoryName;
            //all pdf files
            realtime.Filter = "*.pdf";

            realtime.Changed += OnPDFChange;
            realtime.Created += OnPDFChange;

            realtime.EnableRaisingEvents = true;
            realtime.IncludeSubdirectories = true;
        }

        //event handled when a new file is created or changed
        private void OnPDFChange(object source, FileSystemEventArgs e)
        {
            //the engine gets all strings from the PDF analyzed and checks for suspicious patterns (this engine is used by realtime protection)
            realtime.Changed -= OnPDFChange;
            engine.RealtimeProtection(e.FullPath);
            realtime.Changed += OnPDFChange;
        }

        private void realtimeButton_Click(object sender, EventArgs e)
        {
            //turn on or off realtime protection button
            if (realtime.EnableRaisingEvents == true)
            {
                realtime.EnableRaisingEvents = false;
                RealtimeButton.Text = "Real-Time Protection: OFF";
            }
            else
            {
                realtime.EnableRaisingEvents = true;
                RealtimeButton.Text = "Real-Time Protection: ON";
            }
        }
        #endregion

        public Main()
        {
            InitializeComponent();
            engine = new AnalysisEngine(this);
            StartRealtimeProtection();

            quarantine = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\QuarantinePDFAnalyze\\";
            if (!Directory.Exists(quarantine))
            {
                Directory.CreateDirectory(quarantine);
            }

            try
            {
                string dir = quarantine;
                string[] files = Directory.GetFiles(dir, "*.blocked", SearchOption.AllDirectories);
                foreach (var f in files)
                {
                    listBox1.Items.Add(f);
                }
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message);
            }

            reportMain = new ReportMain();
            reportMain.Show();
            reportMain.Visible = false;

            reportWindow = new Report();
            reportWindow.Show();
            reportWindow.Visible = false;
        }
    }
}
