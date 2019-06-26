using System;
using System.Windows.Forms;

namespace PDFAnalyzer
{
    public partial class ReportMain : Form
    {
        public ReportMain()
        {
            InitializeComponent();
            this.FormClosing += frm_FormClosing;
        }

        public void SetText(string s)
        {
            textBox1.Text += s;
        }
        private void frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
            
}
