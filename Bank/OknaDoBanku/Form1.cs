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

namespace OknaDoBanku
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-DEBHPUIG;Initial Catalog=BankDatabase;Integrated Security=True;Pooling=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into [Table] values (@FirstName,@LastName,@Pesel)", con);


            cmd.Parameters.AddWithValue("@FirstName", textBox1.Text);
            cmd.Parameters.AddWithValue("@LastName", textBox2.Text);
            cmd.Parameters.AddWithValue("@Pesel", double.Parse(textBox3.Text));
            //cmd.Parameters.AddWithValue("@AccountId", int.Parse(textBox4.Text));
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Dodanie konta zakonczylo sie sukcesem");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        public void button2_Click(object sender, EventArgs e)
        {


            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-DEBHPUIG;Initial Catalog=BankDatabase;Integrated Security=True;Pooling=False");
            con.Open();

            SqlCommand cmd = new SqlCommand("Delete [Table] where AccountId=@AccountId", con);
            //cmd.Parameters.AddWithValue("@AccountId", int.Parse(textBox4.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Usuwanie konta zakonczylo sie sukcesem");
        }

        public void button3_Click(object sender, EventArgs e)
        {
            Show();
        }
    }
}
