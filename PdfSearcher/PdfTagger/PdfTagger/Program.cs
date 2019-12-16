using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Tesseract;
using System.Windows.Forms;

namespace PdfTagger
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.Run(new Forma());
            
        }
    }
}
