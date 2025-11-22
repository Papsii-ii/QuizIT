using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace testdb1
{
    public partial class Form1 : Form
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public Form1()
        {
            InitializeComponent();
            displayrecord();
        }

        private void displayrecord()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM tblusers";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sqlDataAdapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string username = textBox1.Text;
                string password = textBox2.Text;
                string query = "INSERT INTO tblusers VALUES ('" + username + "', '" + password + "')";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    int row = cmd.ExecuteNonQuery();
                    if (row > 0)
                    {
                        MessageBox.Show("You are registered!");
                        displayrecord();
                    }
                    else
                    {
                        MessageBox.Show("You're not registered");
                    }

                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string search = textBox3.Text;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM tblusers where username = '" + search + "'";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();
                    sqlDataAdapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];

                    DataRow row = ds.Tables[0].Rows[0];
                    textBox1.Text = row["username"].ToString();
                    textBox2.Text = row["password"].ToString();
                    textBox4.Text = row["Id"].ToString();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string id = textBox4.Text;
            string username = textBox1.Text;
            string password = textBox2.Text;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "update tblusers set username='" + username + "'where id='" + id + "' ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    int row = cmd.ExecuteNonQuery();
                    if (row > 0)
                    {
                        MessageBox.Show("Record updated!");
                        displayrecord();
                    }
                    else
                    {
                        MessageBox.Show("You're not registered");
                    }

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string id = textBox4.Text;
            string username = textBox1.Text;
            string password = textBox2.Text;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "delete from tblusers where id='"+id+"' ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    int row = cmd.ExecuteNonQuery();
                    if (row > 0)
                    {
                        MessageBox.Show("Record deleted!");
                        displayrecord();
                    }
                    else
                    {
                        MessageBox.Show("Record not deleted");
                    }

                }
            }
        }
    }
}

