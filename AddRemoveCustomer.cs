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
    public partial class AddRemoveCustomer : Form
    {
        SqlCommand cmd;

        public AddRemoveCustomer()
        {
            InitializeComponent();

            WindowState = FormWindowState.Maximized;

            // connect to database
            SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
            con.Open();

            // search through database
            string query = "SELECT CusID as CustomerID, OperatorID, Firstname, Lastname, DOBDay, DOBMonth, DOBYear, ContactNum as ContactNumber, Street, City, Province, PostalCode, Country FROM customers";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable customers = new DataTable();
            adapter.Fill(customers);
            dataGridView1.DataSource = customers;
            con.Dispose();
            con.Close();
        }

        private void AddCustomer_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void TopClearButton(object sender, EventArgs e)
        {
            searchCustomerIDBox.Clear();
            searchOperatorIDBox.Clear();
            searchFirstNameBox.Clear();
            searchLastNameBox.Clear();
            DOBDD.Clear();
            DOBMM.Clear();
            DOBYYYY.Clear();
            searchContactNumberBox.Clear();

            searchCustomerIDBox.Focus();
        }

        private void AddButton(object sender, EventArgs e)
        {
            // add customer, switch forms
            AddNewCustomer addNewCustomerForm = new AddNewCustomer();
            addNewCustomerForm.Show();
        }

        private void RemoveButton(object sender, EventArgs e)
        {
            // remove customer, switch forms
            DeleteCustomer deleteCustomerForm = new DeleteCustomer();
            deleteCustomerForm.Show();
        }

        private void SearchButton(object sender, EventArgs e)
        {
            // check if the input is an int
            int parsedValue;

            // this used for where statement if search bar is used
            string queryWhere = "SELECT CusID as CustomerID, OperatorID, Firstname, Lastname, DOBDay, DOBMonth, DOBYear, ContactNum as ContactNumber, Street, City, Province, PostalCode, Country FROM customers WHERE ";
            
            string query = "SELECT CusID as CustomerID, OperatorID, Firstname, Lastname, DOBDay, DOBMonth, DOBYear, ContactNum as ContactNumber, Street, City, Province, PostalCode, Country FROM customers";
            bool searchBarUsed = false;
            bool lastSearchBar = false;

            if (!string.IsNullOrEmpty(searchCustomerIDBox.Text))
            {
                if (!int.TryParse(searchCustomerIDBox.Text, out parsedValue))
                {
                    MessageBox.Show("Customer ID is a number only field");
                    return;
                }
                searchBarUsed = true;
                queryWhere = queryWhere + "cusid = " + searchCustomerIDBox.Text + " AND ";
            }
            if (!string.IsNullOrEmpty(searchOperatorIDBox.Text))
            {
                if (!int.TryParse(searchOperatorIDBox.Text, out parsedValue))
                {
                    MessageBox.Show("Operator ID is a number only field");
                    return;
                }
                searchBarUsed = true;
                queryWhere = queryWhere + "operatorID = " + searchOperatorIDBox.Text + " AND ";
            }
            if (!string.IsNullOrEmpty(searchFirstNameBox.Text))
            {
                searchBarUsed = true;
                queryWhere = queryWhere + "firstname = '" + searchFirstNameBox.Text + "' AND ";
            }
            if (!string.IsNullOrEmpty(searchLastNameBox.Text))
            {
                searchBarUsed = true;
                queryWhere = queryWhere + "lastname = '" + searchLastNameBox.Text + "' AND ";
            }
            if (!string.IsNullOrEmpty(DOBDD.Text))
            {
                if (!int.TryParse(DOBDD.Text, out parsedValue))
                {
                    MessageBox.Show("DOB Day is a number only field");
                    return;
                }
                searchBarUsed = true;
                queryWhere = queryWhere + "DOBDay = " + DOBDD.Text + " AND ";
            }
            if (!string.IsNullOrEmpty(DOBMM.Text))
            {
                if (!int.TryParse(DOBMM.Text, out parsedValue))
                {
                    MessageBox.Show("DOB Month is a number only field");
                    return;
                }
                searchBarUsed = true;
                queryWhere = queryWhere + "DOBMonth = " + DOBMM.Text + " AND ";
            }
            if (!string.IsNullOrEmpty(DOBYYYY.Text))
            {
                if (!int.TryParse(DOBYYYY.Text, out parsedValue))
                {
                    MessageBox.Show("DOB Year is a number only field");
                    return;
                }
                searchBarUsed = true;
                queryWhere = queryWhere + "DOBYear = " + DOBYYYY.Text + " AND ";
            }
            if (!string.IsNullOrEmpty(searchContactNumberBox.Text))
            {
                searchBarUsed = true;
                lastSearchBar = true;
                queryWhere = queryWhere + "contactNum = '" + searchContactNumberBox.Text + "'";
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
                string queryWhereSubString = queryWhere.Substring(0, stringLength-5);
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void carsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddRemoveVehicle addVehicleForm = new AddRemoveVehicle();
            addVehicleForm.Show();
            this.Close();
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // connect to database
                SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
                con.Open();

                // search through database
                string query = "SELECT CusID as CustomerID, OperatorID, Firstname, Lastname, DOBDay, DOBMonth, DOBYear, ContactNum as ContactNumber, Street, City, Province, PostalCode, Country FROM customers";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
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

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddRemoveEmployee addRemoveEmployeeForm = new AddRemoveEmployee();
            addRemoveEmployeeForm.Show();
            this.Close();
        }

        private void carsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EmployeeMainWindowBook employeeMainWindowBookForm = new EmployeeMainWindowBook();
            employeeMainWindowBookForm.Show();
            this.Close();
        }

        private void rentalTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RentalTransactionWindowAddRemove rentalTransactionForm = new RentalTransactionWindowAddRemove();
            rentalTransactionForm.Show();
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

        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // add customer, switch forms
            AddNewCustomer addNewCustomerForm = new AddNewCustomer();
            addNewCustomerForm.Show();
        }

        private void removeCustomreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // remove customer, switch forms
            DeleteCustomer deleteCustomerForm = new DeleteCustomer();
            deleteCustomerForm.Show();
        }

        private void addEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewEmployee addEmployeeForm = new AddNewEmployee();
            addEmployeeForm.Show();
        }

        private void removeEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteEmployee deleteEmployeeForm = new DeleteEmployee();
            deleteEmployeeForm.Show();
        }

        private void addTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void searchCustomerIDBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void RemoveBottomButton_Click(object sender, EventArgs e)
        {
            // check if textbox is filled
            if (!string.IsNullOrEmpty(CustomerIDRemoveBox.Text))
            {
                // check if the input is an int
                int parsedValue;
                if (!int.TryParse(CustomerIDRemoveBox.Text, out parsedValue))
                {
                    MessageBox.Show("Customer ID is a number only field");
                    return;
                }

                // connect to database
                SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
                con.Open();

                // must implement deleting all rental transactions related to customer before deleting customer
                // because of foreign keys, for now customer can be deleted given they never rented a vehicle
                
                // delete works for customer that never made a rental purchase

                cmd = new SqlCommand("DELETE FROM customers WHERE cusID = " + CustomerIDRemoveBox.Text + "", con);
                int rows = cmd.ExecuteNonQuery();

                // check if customerId exists in database
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

            CustomerIDRemoveBox.Clear();

            CustomerIDRemoveBox.Focus();
        }

        private void customToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomReports customReportsForm = new CustomReports();
            customReportsForm.Show();
        }
    }
}
