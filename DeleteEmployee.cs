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
    public partial class DeleteEmployee : Form
    {
        SqlCommand cmd;
        public DeleteEmployee()
        {
            InitializeComponent();

            this.Size = new Size(800, 650);

            // connect to database
            SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
            con.Open();

            // search through database
            string query = "SELECT employeeNum as EmployeeNumber, Firstname, Lastname, DOBDay, DOBMonth, DOBYear, contactNum as ContactNumber, Street, City, Province, PostalCode, Country, workAtBranchNum as Branch FROM employees";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dtable = new DataTable();
            adapter.Fill(dtable);
            dataGridView1.DataSource = dtable;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // check if textbox is filled
            if (!string.IsNullOrEmpty(removeEmployeeIDBox.Text))
            {
                // also check to ensure box is filled in as int
                int parsedValue;
                if (!int.TryParse(removeEmployeeIDBox.Text, out parsedValue))
                {
                    MessageBox.Show("Employee ID is a number only field");
                    return;
                }

                // connect to database
                SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
                con.Open();

                // must implement deleting all rental transactions related to customer before deleting customer
                // because of foreign keys, for now customer can be deleted given they never rented a vehicle

                cmd = new SqlCommand("DELETE FROM employees WHERE employeenum = '" + removeEmployeeIDBox.Text + "'", con);
                int rows = cmd.ExecuteNonQuery();

                // check if employee ID exists in database
                if (rows > 0)
                {
                    MessageBox.Show("Employee ID has been deleted, updating table");

                    // refresh database and show table
                    string query = "SELECT employeeNum as EmployeeNumber, Firstname, Lastname, DOBDay, DOBMonth, DOBYear, contactNum as ContactNumber, Street, City, Province, PostalCode, Country, workAtBranchNum as Branch FROM employees";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable dtable = new DataTable();
                    adapter.Fill(dtable);
                    dataGridView1.DataSource = dtable;
                }
                else
                {
                    MessageBox.Show("Error: No Employee ID exists in Database");
                }

                con.Close();
            }
            else
            {
                MessageBox.Show("Error: No Employee ID detected in textbox");
            }

            removeEmployeeIDBox.Clear();

            removeEmployeeIDBox.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string queryWhere = "SELECT employeeNum as EmployeeNumber, Firstname, Lastname, DOBDay, DOBMonth, DOBYear, contactNum as ContactNumber, Street, City, Province, PostalCode, Country, workAtBranchNum as Branch FROM employees WHERE ";
            string query = "SELECT employeeNum as EmployeeNumber, Firstname, Lastname, DOBDay, DOBMonth, DOBYear, contactNum as ContactNumber, Street, City, Province, PostalCode, Country, workAtBranchNum as Branch FROM employees";
            bool searchBarUsed = false;
            bool lastSearchBar = false;

            if (!string.IsNullOrEmpty(firstNameSearchBox.Text))
            {
                searchBarUsed = true;
                queryWhere = queryWhere + "firstName = " + firstNameSearchBox.Text + " AND ";
            }
            if (!string.IsNullOrEmpty(lastNameSearchBox.Text))
            {
                searchBarUsed = true;
                queryWhere = queryWhere + "lastName = " + lastNameSearchBox.Text + " AND ";
            }
            if (!string.IsNullOrEmpty(contactNumberSearchBox.Text))
            {
                searchBarUsed = true;
                lastSearchBar = true;
                queryWhere = queryWhere + "contactNum = " + contactNumberSearchBox.Text + "'";
            }
            // connect to database
            SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
            con.Open();
            DataTable employeeSearch = new DataTable();

            // last search bar is used, does not include ' AND '
            if (lastSearchBar == true)
            {
                // insert data from extracted sql
                SqlDataAdapter adapter = new SqlDataAdapter(queryWhere, con);
                adapter.Fill(employeeSearch);
            }
            // includes ' AND ', we must remove last 5 chars
            else if (searchBarUsed == true)
            {
                int stringLength = queryWhere.Length;
                string queryWhereSubString = queryWhere.Substring(0, stringLength - 5);
                // insert data from extracted sql
                SqlDataAdapter adapter = new SqlDataAdapter(queryWhereSubString, con);
                adapter.Fill(employeeSearch);
            }
            // search bar was never used, refresh the list
            else
            {
                // fill data table
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.Fill(employeeSearch);
            }

            dataGridView1.DataSource = employeeSearch;

            con.Dispose();
            con.Close();
        }

        private void DeleteEmployee_Load(object sender, EventArgs e)
        {

        }
    }
}
