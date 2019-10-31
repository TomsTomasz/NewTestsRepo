using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASCII_ART
{
    public partial class Form1 : Form2
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog result = new OpenFileDialog();
            result.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (result.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = result.FileName;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Form2 anotherone = new Form2();
            anotherone.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

    }
}
