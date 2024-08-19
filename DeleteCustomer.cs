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

namespace Cmpt291UI
{
    public partial class DeleteCustomer : Form
    {
        bool firstClickConNum = true;

        SqlCommand cmd;
        public DeleteCustomer()
        {
            InitializeComponent();

            this.Size = new Size(800, 650);

            // connect to database
            SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
            con.Open();

            // search through database
            string query = "SELECT CusID as CustomerID, OperatorID, Firstname, Lastname, DOBDay, DOBMonth, DOBYear, ContactNum as ContactNumber, Street, City, Province, PostalCode, Country FROM customers";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dtable = new DataTable();
            adapter.Fill(dtable);
            dataGridView1.DataSource = dtable;
            con.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // check if textbox is filled
            if (!string.IsNullOrEmpty(removeCustomerIDBox.Text))
            {
                // also check to ensure box is filled in as int
                int parsedValue;
                if (!int.TryParse(removeCustomerIDBox.Text, out parsedValue))
                {
                    MessageBox.Show("Customer ID is a number only field");
                    return;
                }

                // connect to database
                SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
                con.Open();

                // must implement deleting all rental transactions related to customer before deleting customer
                // because of foreign keys, for now customer can be deleted given they never rented a vehicle

                cmd = new SqlCommand("DELETE FROM customers WHERE cusID = " + removeCustomerIDBox.Text + "", con);
                int rows = cmd.ExecuteNonQuery();

                // check if customer ID exists in database
                if (rows > 0)
                {
                    MessageBox.Show("Customer ID has been deleted, updating table");

                    // refresh database and show on table
                    string query = "SELECT CusID as CustomerID, OperatorID, Firstname, Lastname, DOBDay, DOBMonth, DOBYear, ContactNum as ContactNumber, Street, City, Province, PostalCode, Country FROM customers";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable customers = new DataTable();
                    adapter.Fill(customers);
                    dataGridView1.DataSource = customers;
                }
                else
                {
                    MessageBox.Show("Error: No Customer ID exists in Database");
                }

                con.Close();
            }
            else
            {
                MessageBox.Show("Error: No Customer ID detected in textbox");
            }

            removeCustomerIDBox.Clear();

            removeCustomerIDBox.Focus();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string queryWhere = "SELECT CusID as CustomerID, OperatorID, Firstname, Lastname, DOBDay, DOBMonth, DOBYear, ContactNum as ContactNumber, Street, City, Province, PostalCode, Country FROM customers WHERE ";
            string query = "SELECT CusID as CustomerID, OperatorID, Firstname, Lastname, DOBDay, DOBMonth, DOBYear, ContactNum as ContactNumber, Street, City, Province, PostalCode, Country FROM customers";
            bool searchBarUsed = false;
            bool lastSearchBar = false;

            if (!string.IsNullOrEmpty(firstNameSearchBox.Text))
            {
                searchBarUsed = true;
                queryWhere = queryWhere + "firstName = '" + firstNameSearchBox.Text + "' AND ";
            }
            if (!string.IsNullOrEmpty(firstNameSearchBox.Text))
            {
                searchBarUsed = true;
                queryWhere = queryWhere + "lastName = '" + lastNameSearchBox.Text + "' AND ";
            }
            if (!string.IsNullOrEmpty(firstNameSearchBox.Text))
            {
                searchBarUsed = true;
                lastSearchBar = true;
                queryWhere = queryWhere + "contactNum = '" + contactNumberSearchBox.Text + "'";
            }
            // connect to database
            SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
            con.Open();
            DataTable customers = new DataTable();

            // last search bar is used, does not include ' AND '
            if (lastSearchBar == true)
            {
                SqlDataAdapter adapter = new SqlDataAdapter(queryWhere, con);
                adapter.Fill(customers);
            }
            // includes ' AND ', we must remove last 5 chars
            else if (searchBarUsed == true)
            {
                int stringLength = queryWhere.Length;
                string queryWhereSubString = queryWhere.Substring(0, stringLength - 5);
                SqlDataAdapter adapter = new SqlDataAdapter(queryWhereSubString, con);
                adapter.Fill(customers);
            }
            // search bar was never used, refresh the list
            else
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.Fill(customers);
            }

            dataGridView1.DataSource = customers;

            con.Dispose();
            con.Close();
        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {
            if (firstClickConNum)
            {
                contactNumberSearchBox.Text = string.Empty;
                contactNumberSearchBox.ForeColor = Color.Black;
                firstClickConNum = false;
            }
        }
    }
}
