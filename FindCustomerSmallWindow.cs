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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Cmpt291UI
{
    public partial class FindCustomerSmallWindow : Form
    {
        SqlCommand cmd;

        public FindCustomerSmallWindow()
        {
            InitializeComponent();

            // width x height
            this.Size = new Size(800, 800);

            SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
            con.Open();

            string query = "SELECT CusID as CustomerID, OperatorID, Firstname, Lastname, DOBDay, DOBMonth, DOBYear, ContactNum as ContactNumber FROM customers";

            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable customerList = new DataTable();
            adapter.Fill(customerList);

            dataGridView1.DataSource = customerList;

            con.Close();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddNewCustomer addNewCustomerForm = new AddNewCustomer();
            addNewCustomerForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int parsedValue;

            // check if textbox is filled
            if (!string.IsNullOrEmpty(customerIDSelectedBox.Text))
            {
                // also check box input is int
                if (!int.TryParse(customerIDSelectedBox.Text, out parsedValue))
                {
                    MessageBox.Show("Customer ID is a number only field");
                    return;
                }

                // connect to database
                SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
                con.Open();

                String query = "SELECT cusid FROM customers WHERE cusid = " + customerIDSelectedBox.Text + "";

                SqlDataAdapter sda = new SqlDataAdapter(query, con);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if (dtable.Rows.Count > 0)
                {
                    EmployeeLoginScreen.bookThisCustomerID = customerIDSelectedBox.Text;

                    // page that needed to be loaded next
                    TransactionPaymentWindow transactionPaymentForm = new TransactionPaymentWindow();
                    transactionPaymentForm.Show();
                    // might have to use hide, test and remember this
                    this.Close();

                    con.Dispose();
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Error: No Customer ID exists in Database");
                }
            }
            else
            {
                MessageBox.Show("Error: No Customer ID detected in textbox");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // this used for where statement if search bar is used
            string queryWhere = "SELECT CusID as CustomerID, OperatorID, Firstname, Lastname, DOBDay, DOBMonth, DOBYear, ContactNum as ContactNumber FROM customers WHERE ";
            
            string query = "SELECT CusID as CustomerID, OperatorID, Firstname, Lastname, DOBDay, DOBMonth, DOBYear, ContactNum as ContactNumber FROM customers";
            bool searchBarUsed = false;
            bool lastSearchBar = false;

            if (!string.IsNullOrEmpty(firstNameSearchBox.Text))
            {
                searchBarUsed = true;
                queryWhere = queryWhere + "firstName = '" + firstNameSearchBox.Text + "' AND ";
            }
            if (!string.IsNullOrEmpty(lastNameSearchBox.Text))
            {
                searchBarUsed = true;
                queryWhere = queryWhere + "lastName = '" + lastNameSearchBox.Text + "' AND ";
            }
            if (!string.IsNullOrEmpty(contactNumberSearchBox.Text))
            {
                searchBarUsed = true;
                lastSearchBar = true;
                queryWhere = queryWhere + "contactNum = '" + contactNumberSearchBox.Text + "'";
            }
            // connect to database
            SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
            con.Open();
            DataTable customerList = new DataTable();

            // last search bar is used, does not include ' AND '
            if (lastSearchBar == true)
            {
                SqlDataAdapter adapter = new SqlDataAdapter(queryWhere, con);
                adapter.Fill(customerList);
            }
            // includes ' AND ', we must remove last 5 chars
            else if (searchBarUsed == true)
            {
                int stringLength = queryWhere.Length;
                string queryWhereSubString = queryWhere.Substring(0, stringLength - 5);
                SqlDataAdapter adapter = new SqlDataAdapter(queryWhereSubString, con);
                adapter.Fill(customerList);
            }
            // search bar was never used, refresh the list
            else
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.Fill(customerList);
            }

            dataGridView1.DataSource = customerList;

            con.Dispose();
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
            con.Open();

            string query = "SELECT CusID as CustomerID, OperatorID, Firstname, Lastname, DOBDay, DOBMonth, DOBYear, ContactNum as ContactNumber FROM customers";

            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable customerList = new DataTable();
            adapter.Fill(customerList);

            dataGridView1.DataSource = customerList;

            con.Close();
        }
    }
}
