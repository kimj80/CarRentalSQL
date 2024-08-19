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
    public partial class FindCustomerInformation : Form
    {
        public static String mainCustomerIDCarryOver;

        SqlCommand cmd;

        public FindCustomerInformation()
        {
            InitializeComponent();

            WindowState = FormWindowState.Maximized;

            // connect to database
            SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
            con.Open();

            // search through database
            string query = "SELECT CusID as CustomerID, OperatorID, Firstname, Lastname, DOBDay, DOBMonth, DOBYear, ContactNum as ContactNumber, Street, City, Province, PostalCode, Country FROM customers";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);

            // insert data from extracted sql
            DataTable customers = new DataTable();
            adapter.Fill(customers);

            dataGridView1.DataSource = customers;

            con.Dispose();
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // connect to database
                SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
                con.Open();

                // search through database
                string query = "SELECT CusID as CustomerID, OperatorID, Firstname, Lastname, DOBDay, DOBMonth, DOBYear, ContactNum as ContactNumber, Street, City, Province, PostalCode, Country FROM customers"; ;
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);

                // insert data from extracted sql
                DataTable customers = new DataTable();
                adapter.Fill(customers);

                dataGridView1.DataSource = customers;

                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // check if textbox is filled
            if (!string.IsNullOrEmpty(selectCustomerIDBox.Text))
            {
                // connect to database
                SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
                con.Open();

                cmd = new SqlCommand("SELECT * FROM customers WHERE cusID = '" + selectCustomerIDBox.Text + "'", con);
                int rows = cmd.ExecuteNonQuery();

                // check if customerId exists in database
                if (rows > 0)
                {
                    mainCustomerIDCarryOver = selectCustomerIDBox.Text;

                    TransactionPaymentWindow transactionPaymentForm = new TransactionPaymentWindow();
                    transactionPaymentForm.Show();

                    con.Close();
                    this.Hide();
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

        private void button2_Click(object sender, EventArgs e)
        {
            selectCustomerIDBox.Clear();

            selectCustomerIDBox.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int parsedValue;

            string queryWhere = "SELECT CusID as CustomerID, OperatorID, Firstname, Lastname, DOBDay, DOBMonth, DOBYear, ContactNum as ContactNumber, Street, City, Province, PostalCode, Country FROM customers WHERE ";
            string query = "SELECT CusID as CustomerID, OperatorID, Firstname, Lastname, DOBDay, DOBMonth, DOBYear, ContactNum as ContactNumber, Street, City, Province, PostalCode, Country FROM customers";
            bool searchBarUsed = false;
            bool lastSearchBar = false;

            if (!string.IsNullOrEmpty(searchFirstNameBox.Text))
            {
                searchBarUsed = true;
                queryWhere = queryWhere + "firstName = " + searchFirstNameBox.Text + " AND ";
            }
            if (!string.IsNullOrEmpty(searchLastNameBox.Text))
            {
                searchBarUsed = true;
                queryWhere = queryWhere + "lastname = " + searchLastNameBox.Text + " AND ";
            }
            if (!string.IsNullOrEmpty(SearchPhoneNumberBox.Text))
            {
                searchBarUsed = true;
                queryWhere = queryWhere + "contactNum = '" + SearchPhoneNumberBox.Text + "' AND ";
            }
            if (!string.IsNullOrEmpty(searchCustomerIDBox.Text))
            {
                // also check box input is int
                if (!int.TryParse(searchCustomerIDBox.Text, out parsedValue))
                {
                    MessageBox.Show("Customer ID is a number only field");
                    return;
                }
                searchBarUsed = true;
                queryWhere = queryWhere + "cusID = '" + searchCustomerIDBox.Text + "' AND ";
            }
            if (!string.IsNullOrEmpty(searchOperatorsBox.Text))
            {
                // also check box input is int
                if (!int.TryParse(searchOperatorsBox.Text, out parsedValue))
                {
                    MessageBox.Show("Operators ID is a number only field");
                    return;
                }
                searchBarUsed = true;
                queryWhere = queryWhere + "operatorID = " + searchOperatorsBox.Text + " AND ";
            }
            if (!string.IsNullOrEmpty(searchDOBDD.Text))
            {
                // also check box input is int
                if (!int.TryParse(searchDOBDD.Text, out parsedValue))
                {
                    MessageBox.Show("Customer DOB Day is a number only field");
                    return;
                }
                searchBarUsed = true;
                queryWhere = queryWhere + "DOBDay = " + searchDOBDD.Text + " AND ";
            }
            if (!string.IsNullOrEmpty(searchDOBMM.Text))
            {
                // also check box input is int
                if (!int.TryParse(searchDOBMM.Text, out parsedValue))
                {
                    MessageBox.Show("Customer DOB Month is a number only field");
                    return;
                }
                searchBarUsed = true;
                queryWhere = queryWhere + "DOBMonth = " + searchDOBMM.Text + " AND ";
            }
            if (!string.IsNullOrEmpty(searchDOBYYYY.Text))
            {
                // also check box input is int
                if (!int.TryParse(searchDOBYYYY.Text, out parsedValue))
                {
                    MessageBox.Show("Customer DOB year is a number only field");
                    return;
                }
                searchBarUsed = true;
                lastSearchBar = true;
                queryWhere = queryWhere + "DOBYear = " + searchDOBYYYY.Text + "'";
            }

            // connect to database
            SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
            con.Open();
            DataTable customers = new DataTable();

            // last search bar is used, does not include ' AND '
            if (lastSearchBar == true)
            {
                // insert data from extracted sql
                SqlDataAdapter adapter = new SqlDataAdapter(queryWhere, con);
                adapter.Fill(customers);
            }
            // includes ' AND ', we must remove last 5 chars
            else if (searchBarUsed == true)
            {
                int stringLength = queryWhere.Length;
                string queryWhereSubString = queryWhere.Substring(0, stringLength - 5);
                // insert data from extracted sql
                SqlDataAdapter adapter = new SqlDataAdapter(queryWhereSubString, con);
                adapter.Fill(customers);
            }
            // search bar was never used, refresh the list
            else
            {
                // insert data from extracted sql
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.Fill(customers);
            }

            dataGridView1.DataSource = customers;

            con.Dispose();
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            searchFirstNameBox.Clear();
            searchLastNameBox.Clear();
            SearchPhoneNumberBox.Clear();
            searchCustomerIDBox.Clear();
            searchOperatorsBox.Clear();
            searchDOBDD.Clear();
            searchDOBMM.Clear();
            searchDOBYYYY.Clear();

            searchFirstNameBox.Focus();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void carsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddRemoveVehicle addVehicleForm = new AddRemoveVehicle();
            addVehicleForm.Show();
            this.Close();
        }

        private void customersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddRemoveCustomer addCustomerForm = new AddRemoveCustomer();
            addCustomerForm.Show();
            this.Close();
        }

        private void employeesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddRemoveEmployee addRemoveEmployeeForm = new AddRemoveEmployee();
            addRemoveEmployeeForm.Show();
            this.Close();
        }

        private void rentalTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RentalTransactionWindowAddRemove rentalTransactionForm = new RentalTransactionWindowAddRemove();
            rentalTransactionForm.Show();
            this.Close();
        }

        private void carsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeMainWindowBook employeeMainWindowBookForm = new EmployeeMainWindowBook();
            employeeMainWindowBookForm.Show();
            this.Close();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // connect to database
                SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
                con.Open();

                // search through database
                string query = "SELECT CusID as CustomerID, OperatorID, Firstname, Lastname, DOBDay, DOBMonth, DOBYear, ContactNum as ContactNumber, Street, City, Province, PostalCode, Country FROM customers";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);

                // insert data from extracted sql
                DataTable customers = new DataTable();
                adapter.Fill(customers);

                dataGridView1.DataSource = customers;

                con.Dispose();
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
