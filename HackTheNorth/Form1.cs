using System.Collections.Generic;
using System.Text;

namespace HackTheNorth
{
    public partial class MainForm : Form
    {
        Dictionary<string, string> convMaps;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            convMaps = new Dictionary<string, string>();
            convMaps.Add("sqrt()", "\u221a");
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}