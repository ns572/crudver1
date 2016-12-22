using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace DemoApp
{
    public partial class Form2 : Form
    {
        //private object conn;

          SqlConnection conn =
              new SqlConnection
              (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename
  =C:\users\ns5\documents\visual studio 2015\Projects\DemoApp\DemoApp\DemoDB.mdf;Integrated Security=True");


        public Form2()
        {
            InitializeComponent();
            BindMyData2();
        }

        public void BindMyData2()
        {
            try
            {
                conn.Open();

                //   if (ch)
                //            SqlCommand comm = new SqlCommand("SELECT * FROM Student", conn);
                //  else
                //    SqlCommand comm = com;
                // DataSet ds = new DataSet();
                // SqlDataAdapter da = new SqlDataAdapter(comm);
                // da.Fill(ds);
                // dataGrid.ItemsSource = ds.Tables[0].DefaultView;
                DataGridViewCheckBoxColumn col1 = new DataGridViewCheckBoxColumn();

                col1.Name = "remove";

                col1.HeaderText = "remove";

                dataGridView1.Columns.Add(col1);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                conn.Close();
            }
        }







        private void button1_Click(object sender, EventArgs e)
        {

            List<DataGridViewRow> toDelete = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool s = Convert.ToBoolean(row.Cells[5].Value);

                if (s == true)
                {
                    toDelete.Add(row);
                }
            }

            foreach (DataGridViewRow row in toDelete)
            {
                dataGridView1.Rows.Remove(row);
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'demoDBDataSet.Student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.demoDBDataSet.Student);

        }

        private void back_Click(object sender, EventArgs e)
        {
           // MainWindow win = new MainWindow();

           // win.Show();

            this.Close();
        }

       /* private void Form2_Load_1(object sender, EventArgs e)
        {

        }*/
    }
}
