using System.Collections.Generic;
using System.Text;

namespace HackTheNorth
{
    public partial class MainForm : Form
    {
        Dictionary<string, string> convMaps = new Dictionary<string, string>();
        string currWord = "";

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            convMaps.Add("pi", "\u03c0");

            convMaps.Add("^0", "\u2070");
            convMaps.Add("^1", "\u00b9");
            convMaps.Add("^2", "\u00b2");
            convMaps.Add("^3", "\u00b3");
            convMaps.Add("^4", "\u2074");
            convMaps.Add("^5", "\u2075");
            convMaps.Add("^6", "\u2076");
            convMaps.Add("^7", "\u2077");
            convMaps.Add("^8", "\u2078");
            convMaps.Add("^9", "\u2079");

            convMaps.Add("aP", "\u03b1");
            convMaps.Add("bT", "\u03b2");
            convMaps.Add("gM", "\u03b3");
            convMaps.Add("zT", "\u03b4");

            convMaps.Add("+-", "\u00b1");
            convMaps.Add("/=", "\u2260");
            convMaps.Add("<=", "\u2264");
            convMaps.Add(">=", "\u2265");
            convMaps.Add("~=", "\u2248");
            convMaps.Add("fN", "\u221E");

            convMaps.Add("_0", "\u2080");
            convMaps.Add("_1", "\u2081");
            convMaps.Add("_2", "\u2082");
            convMaps.Add("_3", "\u2083");
            convMaps.Add("_4", "\u2084");
            convMaps.Add("_5", "\u2085");
            convMaps.Add("_6", "\u2086");
            convMaps.Add("_7", "\u2087");
            convMaps.Add("_8", "\u2088");
            convMaps.Add("_9", "\u2089");
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            string fullText = richTextBox1.Text;
            if (isSus(fullText))
            {
                currWord += fullText[fullText.Length - 1];
                return;
            }
            if (currWord.Length > 0)
            {
                currWord += fullText[fullText.Length - 1];
                if (convMaps.ContainsKey(currWord))
                {
                    richTextBox2.Text += convMaps[currWord];
                    currWord = "";
                    return;
                }
                currWord = "";
            }
            richTextBox2.Text += fullText[fullText.Length - 1];
        }

        private bool isSus(string str)
        {
            int len = str.Length;
            if (len == 0) return false;
            char last = str[len - 1];
            return last == '^' ||
                last == 'p' ||
                last == 'a' ||
                last == 'b' ||
                last == 'g' ||
                last == 'z' ||
                last == '/' ||
                last == '_' ||
                last == '+' ||
                last == '<' ||
                last == '>' ||
                last == '~' ||
                last == 'f';
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            //...
            if (richTextBox1.Text.Length < realTextLength(richTextBox2.Text))
            {
                richTextBox2.Text = richTextBox1.Text;
            }
        }

        private int realTextLength(string str)
        {
            int res = 0;
            foreach (char chr in str)
            {
                if (convMaps.ContainsValue(chr.ToString()))
                {
                    res += 2;
                }
                else
                {
                    res++;
                }
            }
            return res;
        }
    }
}