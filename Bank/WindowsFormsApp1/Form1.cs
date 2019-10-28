using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=LAPTOP-DEBHPUIG;Initial Catalog=BankDatabase;Integrated Security=True;Pooling=False";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            MessageBox.Show("Connection Open  !");
            


            SqlCommand command;
            SqlDataReader dataReader;
            String sql, Output = "";

            sql = "Select * from [Table]";
            //sql1 = "Insert into [Table] (AccountId,FirstName,LastName,Money) values(4, ' " + "Krzysztof" + ' " "Krawczyk" + "100000")
            command = new SqlCommand(sql, cnn);

            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0) + " " + dataReader.GetValue(1) + " " + dataReader.GetValue(2) + " " + dataReader.GetValue(3) + "\n";
            }

            MessageBox.Show(Output);

            dataReader.Close();
            command.Dispose();
            cnn.Close();
        }

    }
}
