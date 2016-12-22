using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace DemoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    /*class CustomerDao
    {
        public static ObservableCollection<Customer> GetCustomers()
        {
            string sql = @"SELECT * FROM [Customers]";
            return AdoData.ReadList(sql, MakeDataObject);
        }


        private static Func<IDataReader, Customer> MakeDataObject = reader =>
                 new Customer
                 {
                     FullName = reader["FullName"].ToString(),
                     Email = reader["EmailAddress"].ToString(),
                     Password = reader["Password"].ToString(),
                     CustomerID = Convert.ToInt32(reader["CustomerId"])
                 };

    }*/



    public partial class MainWindow : Window
    {

        SqlConnection conn =
            new SqlConnection
            (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename
=C:\users\ns5\documents\visual studio 2015\Projects\DemoApp\DemoApp\DemoDB.mdf;Integrated Security=True");

      /*  public class Student
        {
            public int id { get; set; }
            public string fn { get; set; }
            public string ln { get; set; }
            public int age { get; set; }
            public int rno { get; set; }


        }
        */





        public MainWindow()
        {
            InitializeComponent();
        //    BindMyData();

        //    DataContext=Student

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BindMyData();
        }

        private void rowclick(object sender,  MouseButtonEventArgs e)
        {

            DataRowView dataRow = (DataRowView)dataGrid.SelectedItem;

            //DataRowView dataRow = (DataRowView)dataGrid.;




            //  int index = datagrid.CurrentCell.Column.DisplayIndex;

            int noa = dataGrid.Columns.Count();

            // for (int i = 0; i < noa; i++)
            // {
            string cellValue0 = dataRow.Row.ItemArray[0].ToString();
            string cellValue1 = dataRow.Row.ItemArray[1].ToString();
            string cellValue2 = dataRow.Row.ItemArray[3].ToString();
            string cellValue3 = dataRow.Row.ItemArray[4].ToString();
            //   string cellValue4 = dataRow.Row.ItemArray[4].ToString();

            //   var row = dataGrid.SelectedItem
            textBox.Text = cellValue0;
            textBox1.Text = cellValue1;
            textBox2.Text = cellValue2;
            textBox3.Text = cellValue3;


        }

        public void BindMyData()
        {
            try
            {
                conn.Open();

             //   if (ch)
                    SqlCommand comm = new SqlCommand("SELECT * FROM Student", conn);
              //  else
                //    SqlCommand comm = com;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
                dataGrid.ItemsSource = ds.Tables[0].DefaultView;
                DataGridCheckBoxColumn col1 = new DataGridCheckBoxColumn();

                col1.Header = "remove";

                dataGrid.Columns.Add(col1);

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


     /*   private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BindMyData();
        }
        */


        private void insert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand comm =
                    new SqlCommand
                    ("INSERT INTO Student VALUES(" + textBox.Text + ", '" + textBox1.Text + "', '', " + textBox2.Text + ", " + textBox3.Text + ")" , conn);

                comm.ExecuteNonQuery();

               // Window2 win = new Window2();

                //win.Show();
                //this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                conn.Close();
                BindMyData();
            }
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn.Open();

                DataRowView dataRow = (DataRowView)dataGrid.SelectedItem;

                //  int index = datagrid.CurrentCell.Column.DisplayIndex;

                int noa = dataGrid.Columns.Count();

               // for (int i = 0; i < noa; i++)
               // {
                   /* string cellValue0 = dataRow.Row.ItemArray[0].ToString();
                    string cellValue1 = dataRow.Row.ItemArray[1].ToString();
                    string cellValue2 = dataRow.Row.ItemArray[2].ToString();
                    string cellValue3 = dataRow.Row.ItemArray[3].ToString();*/
                 //   string cellValue4 = dataRow.Row.ItemArray[4].ToString();

                //   var row = dataGrid.SelectedItem
                   /* textBox.Text = cellValue0;
                    textBox1.Text = cellValue1;
                    textBox2.Text = cellValue2;
                    textBox3.Text = cellValue3;*/
                   // textBox.Text = cellValue0;
                //}

                SqlCommand comm = 
                    new SqlCommand
                    ("UPDATE Student SET Id="+ textBox.Text + ",firstName='" 
                    + textBox1.Text +"',age=" + textBox2.Text + ",rollno=" + textBox3.Text + "WHERE Id=" + textBox.Text + "", conn);
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                conn.Close();
                BindMyData();
            }
        }

        private void checkbox_checked()
        {

        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
              //  conn.Open();

                Form2 fo = new Form2();

                fo.Show();

                //.Close();



                /*SqlCommand comm = new SqlCommand("DELETE FROM Student WHERE Id=" + textBox.Text + "", conn);

                List<int> crows = new List<int>();

                

           /*     for(int i=0;i<dataGrid.Items.Count-1;i++)
                {
                
                    //   DatagridItem item = dataGrid.SelectedItem as DatagridItem;

                   // if (Convert.ToBoolean(dataGrid.Items.GetItemAt(i)) == true))


                }*/


         /*       foreach (DataRow objItem in dataGrid.Items)
                {
                    //if (objItem.ItemType != ListItemType.Header && objItem.ItemType !=
                    //ListItemType.Footer && objItem.ItemType != ListItemType.Pager)
                    //{
                        if (((CheckBox)objItem.Cells[0].FindControl("cbSelected")).Checked == true)
                        {

                            string key = ((Label)objItem.Cells[0].FindControl("key")).Text.ToString();
                        }
                    //}
                }
*/            

              /*  comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                conn.Close();
                BindMyData();
            }*/
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            

            try
            {
                conn.Open();
                SqlCommand comm  = new SqlCommand("Select * FROM Student WHERE Id=" + textBox.Text + "", conn);
                comm.ExecuteNonQuery();
                // BindMyData();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
                dataGrid.ItemsSource = ds.Tables[0].DefaultView;

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

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

            DemoApp.DemoDBDataSet demoDBDataSet = ((DemoApp.DemoDBDataSet)(this.FindResource("demoDBDataSet")));
            // Load data into the table Student. You can modify this code as needed.
            DemoApp.DemoDBDataSetTableAdapters.StudentTableAdapter demoDBDataSetStudentTableAdapter = new DemoApp.DemoDBDataSetTableAdapters.StudentTableAdapter();
            demoDBDataSetStudentTableAdapter.Fill(demoDBDataSet.Student);
            System.Windows.Data.CollectionViewSource studentViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("studentViewSource")));
            studentViewSource.View.MoveCurrentToFirst();
        }












        /*        using(SqlConnection conn = new SqlConnection()) 
        {
            conn.ConnectionString = "connection_string";
            conn.Open();


            private void insert_Click(object sender, RoutedEventArgs e)
            {

            }

            private void delete_Click(object sender, RoutedEventArgs e)
            {

            }

            private void update_Click(object sender, RoutedEventArgs e)
            {

            }

            private void search_Click(object sender, RoutedEventArgs e)
            {

            }


            conn.Close();
            conn.Dipose();

        }

        */

    }
}
