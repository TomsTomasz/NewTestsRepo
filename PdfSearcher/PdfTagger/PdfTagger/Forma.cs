using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PdfTagger
{
    public partial class Forma : Form
    {
        public Forma()
        {
            InitializeComponent();
            richTextBox2.Multiline = true;
            richTextBox2.WordWrap = false;
            richTextBox2.ScrollBars = RichTextBoxScrollBars.Both;
        }

        private void Forma_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            string filePath;
            opf.Filter = "PDF Files(*.PDF)|*.PDF|All Files(*.*)|*.*";


            if (opf.ShowDialog() == DialogResult.OK)
            {
                filePath = opf.FileName.ToString();
                textBox1.Text = opf.FileName;


                string strText = string.Empty;

                try
                {
                    PdfReader reader = new PdfReader(filePath);

                    for (int page = 1; page <= reader.NumberOfPages; page++)
                    {
                        ITextExtractionStrategy its = new iTextSharp.text.pdf.parser.LocationTextExtractionStrategy();
                        string s = PdfTextExtractor.GetTextFromPage(reader, page, its);

                        s = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(s)));
                        strText = strText + s;
                        richTextBox2.Text = strText;

                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void axAcroPDF1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] words = txtSearch.Text.Split(',');
            foreach (string word in words)
            {
                int startIndex = 0;
                while (startIndex < richTextBox2.TextLength)
                {
                    int wordStartIndex = richTextBox2.Find(word, startIndex, RichTextBoxFinds.None);
                    if (wordStartIndex != -1)
                    {
                        richTextBox2.SelectionStart = wordStartIndex;
                        richTextBox2.SelectionLength = word.Length;
                        richTextBox2.SelectionBackColor = Color.Yellow;
                    }
                    else
                        break;
                    startIndex += wordStartIndex + word.Length;
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            richTextBox2.SelectionStart = 0;
            richTextBox2.SelectAll();
            richTextBox2.SelectionBackColor = Color.White;
        }
    }
}
