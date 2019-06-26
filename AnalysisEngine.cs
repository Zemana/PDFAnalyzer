using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PDFAnalyzer
{
    class AnalysisEngine 
    {
        Main main;

        //forms for analysis reports: they are for ondemand and real-time analysis and for ondemand folder analysis
        static ReportMain reportMain;
        static Report reportWindow;
        //string for reports
        static string reportString = "";

        //infected or not?
        static bool infected = false;
        static int threshold = 0;
       
        double entropy = 0;
        bool obfuscated = false;

        public AnalysisEngine(Main main)
        {
            this.main = main;

            reportMain = new ReportMain();
            reportMain.Show();
            reportMain.Visible = false;

            reportWindow = new Report();
            reportWindow.Show();
            reportWindow.Visible = false;
        }
        #region Analysis
        public void AnalysisFolder(string directory)
        {
            string[] files = Directory.GetFiles(directory, "*.pdf", SearchOption.AllDirectories);
            foreach (var f in files)
            {
                ScanFolder(f, directory);
            }

            reportWindow.Visible = true;
            reportWindow.SetText(reportString);
        }

        //method to count numbers of most suspicious patterns
        public int Count(string content, string g)
        {
            int t = 0;
            int q = 0;

            while ((t = content.IndexOf(g, t)) != -1)
            {
                t += g.Length;
                q++;
            };

            return q;
        }

        static void Show()
        {
            //method to open form for analysis report (realtime)
            reportMain.SetText(reportString);
            reportMain.Visible = true;
        }

        //delegate method for manage threads
        public delegate void Del();
        Del object1 = new Del(Show);
        //engine used for PDF analysis (folder analysis), the program loops through all files of a folder and analyze them
        public void ScanFolder(string path, string directory)
        {
            try
            {
                directory = Path.GetDirectoryName(path);
                string originalPath = path;
                File.Move(path, Path.Combine(directory, Path.GetFileNameWithoutExtension(path) + ".txt"));
                string stringText = File.ReadAllText(Path.Combine(directory, Path.GetFileNameWithoutExtension(path) + ".txt"));


                Scan(stringText, path);

                File.Move(Path.Combine(directory, Path.GetFileNameWithoutExtension(path) + ".txt"), originalPath);
                if (infected == true)
                {
                    main.QuarantineFile(originalPath);
                }

                try
                {
                    string dir1 = main.GetQuarantine();
                    string[] files = Directory.GetFiles(dir1, "*.blocked", SearchOption.AllDirectories);
                    foreach (var f in files)
                    {
                        if (!(main.getListbox().Items.Contains(f)))
                            main.getListbox().Items.Add(f);

                    }
                }
                catch (IOException e)
                {
                    MessageBox.Show(e.Message);
                }

                infected = false;
                threshold = 0;
            }

            catch (IOException e1)
            {
                MessageBox.Show(e1.Message);
            }
        }
        //engine used for ondemand PDF analysis
        public void ScanOnDemand(string path)
        {
            try
            {
                string directory = Path.GetDirectoryName(path);
                string originalPath = path;
                System.IO.File.Move(path, Path.Combine(directory, Path.GetFileNameWithoutExtension(path) + ".txt"));
                string str = File.ReadAllText(Path.Combine(directory, Path.GetFileNameWithoutExtension(path) + ".txt"));
                Scan(str, path);
                Show();

                File.Move(Path.Combine(directory, Path.GetFileNameWithoutExtension(path) + ".txt"), originalPath);
                if (infected == true)
                {
                    main.QuarantineFile(originalPath);

                }

                try
                {
                    string quarantineFolder = main.GetQuarantine();
                    string[] files = Directory.GetFiles(quarantineFolder, "*.blocked", SearchOption.AllDirectories);
                    foreach (var f in files)
                    {
                        if (!(main.getListbox().Items.Contains(f)))
                            main.getListbox().Items.Add(f);

                    }
                }
                catch (IOException e)
                {
                    MessageBox.Show(e.Message);
                }


                infected = false;
                threshold = 0;
            }

            catch (IOException e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        public void Scan(string stringText, string path)
        {
            reportString += Environment.NewLine + "File analyzed: " + path + Environment.NewLine;

            for (int i = 0; i < Constants.INDICATORS_ONE.Length; i++)
            {
                if (Count(stringText, Constants.INDICATORS_ONE[i]) >= 1)
                {
                    threshold++;
                    reportString += Constants.INDICATORS_ONE[i] + " " + Count(stringText, Constants.INDICATORS_ONE[i]) + Environment.NewLine;
                }
            }

            for (int i = 0; i < Constants.INDICATORS_TWO.Length; i++)
            {
                if (Count(stringText, Constants.INDICATORS_TWO[i]) >= 2)
                {
                    threshold++;
                    reportString += Constants.INDICATORS_TWO[i] + " " + Count(stringText, Constants.INDICATORS_ONE[i]) + Environment.NewLine;

                }
            }
            if (Count(stringText, Constants.INDICATORS_THREE[0]) >= 3)
            {
                threshold++;
                reportString += Constants.INDICATORS_THREE[0] + " " + Count(stringText, Constants.INDICATORS_ONE[0]) + Environment.NewLine;

            }


            entropy = ShannonEntropy(stringText);
            if (entropy > 5 && stringText.Contains("ASCIIHex"))
            {
                obfuscated = true;
                reportString += "This file is obfuscated.";
            }
            else
            {
                obfuscated = false;
                reportString += "";
            }

            if (threshold >= 2)
            {
                infected = true;
                reportString += "This file is suspicious." + Environment.NewLine;
            }
            else
            {
                reportString += "This file is clean." + Environment.NewLine;
            }

            if (main.InvokeRequired)
            {
                main.Invoke(object1);
            }
        }
        #endregion

        #region EventHandler
        public void RealtimeProtection(string path)
        {

            string directory = Path.GetDirectoryName(path);
            string originalPath = path;
            try
            {
                File.Move(path, Path.Combine(directory, Path.GetFileNameWithoutExtension(path) + ".txt"));

                string str = File.ReadAllText(Path.Combine(directory, Path.GetFileNameWithoutExtension(path) + ".txt"));

                Scan(str, path);

                Show();
                System.IO.File.Move(Path.Combine(directory, Path.GetFileNameWithoutExtension(path) + ".txt"), originalPath);
                if (infected == true)
                {
                    main.QuarantineFile(originalPath);

                }
                try
                {
                    string quarantineFolder = main.GetQuarantine();
                    string[] files = Directory.GetFiles(quarantineFolder, "*.blocked", SearchOption.AllDirectories);
                    foreach (var f in files)
                    {
                        if (!(main.getListbox().Items.Contains(f)))
                            main.getListbox().Items.Add(f);
                    }
                }
                catch (IOException e) { MessageBox.Show(e.Message); }

            }

            catch (IOException e1)
            {
                MessageBox.Show(e1.Message);
            }

            infected = false;
            threshold = 0;
        }
        #endregion

        #region Entropy

        //https://codereview.stackexchange.com/a/909
        /// <summary>
        /// returns bits of entropy represented in a given string, per 
        /// http://en.wikipedia.org/wiki/Entropy_(information_theory) 
        /// </summary>
        public static double ShannonEntropy(string s)
        {
            var map = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (!map.ContainsKey(c))
                    map.Add(c, 1);
                else
                    map[c] += 1;
            }

            double result = 0.0;
            int len = s.Length;
            foreach (var item in map)
            {
                var frequency = (double)item.Value / len;
                result -= frequency * (Math.Log(frequency) / Math.Log(2));
            }
            return result;
        }
        #endregion

    }
}
