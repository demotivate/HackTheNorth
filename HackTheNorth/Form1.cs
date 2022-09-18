using System.Collections.Generic;
using System.Text;

namespace HackTheNorth
{
    public partial class MainForm : Form
    {
        // stores strings to be detected and its corresponding mathematical symbol
        Dictionary<string, string> convMaps = new Dictionary<string, string>();

        // builds up a string if program suspects for itself to detect a desired string, then will be used to find symbol in dictionary
        string currWord = "";

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // adds strings and corresponding mathematical symbols to dictionary
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


        /* CALLED WHEN richTextBox1.Text IS CHANGED
         * HANDLES CONVERTING RAW STRING TO DESIRED SYMBOLS
         * 
         * fullText is variable of richTextBox1's text
         * 
         * fullText.Length is checked to be of 0 length to prevent index out of range error
         * 
         * isSus method is ran and set in a conditional to determine whether a character is suspicious of leading to a mathematical symbol,
         *  and if so, adds the character to currWord
         *  
         * if currWord is not empty, then the program is currently suspecting of a lead to a mathematical symbol, adds current character to
         *  currWord and is used as index in convMaps.
         *  
         * if the string is correspondent to mathematical symbol, add mathematical symbol, else, first add the character that wasn't outputted
         *  due to suspicion, then, in a general case:
         *  
         * add the current character to output
         */
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            string fullText = richTextBox1.Text;
            if (fullText.Length == 0)
            {
                richTextBox2.Text = "";
                return;
            }
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
                if(fullText.Length >= 2) richTextBox2.Text += fullText[fullText.Length - 2];
            }
            richTextBox2.Text += fullText[fullText.Length - 1];
        }

        /* CHECKS IF CURRENT CHAR IS SUSPICIOUS OF LEADING TO ONE OF THE DESIRED STRINGS
         * 
         * first checks if length of str is 0 to prevent index out of range error
         * 
         * returns if the last character of the string matches to anyone of the first characters in the dictionary's strings
         */
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

        /* MAKES SURE richTextBox2.Text IS IN SYNC WITH richTextBox1, ESPECIALLY IF USER BACKSPACES
         * 
         * checks if richTextBox1.Text is shorter than richTextBox2.Text (it shouldn't be shorter)
         * 
         * if the above is true, remove the last two characters of richTextBox2.Text
         */
        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length < realTextLength(richTextBox2.Text))
            {
                string newStr = "";
                for(int i = 0; i < richTextBox2.Text.Length-2; i++)
                {
                    newStr += richTextBox2.Text[i];
                }
                richTextBox2.Text = newStr;
            }
        }

        /* GET LENGTH OF richTextBox2.Text IF IT WAS THE RAW STRING
         * 
         * int res is defined and will be what is returned
         * 
         * loops through every character in str, if is one of the math symbols, res = res+2, else, res++
         */
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