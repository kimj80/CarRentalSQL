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
    public partial class AddRemoveEmployee : Form
    {
        SqlCommand cmd;
        public AddRemoveEmployee()
        {
            InitializeComponent();

            WindowState = FormWindowState.Maximized;

            try
            {
                // connect to database
                SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
                con.Open();

                // search through database
                string query = "SELECT employeeNum as EmployeeNumber, Firstname, Lastname, DOBDay, DOBMonth, DOBYear, contactNum as ContactNumber, Street, City, Province, PostalCode, Country, workAtBranchNum as Branch FROM employees";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable employees = new DataTable();
                adapter.Fill(employees);
                dataGridView1.DataSource = employees;
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
            AddNewCustomer addNewCustomerForm = new AddNewCustomer();
            addNewCustomerForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            searchEmployeeIDBox.Clear();
            searchEmployeeIDBox.Focus();
            searchBranchBox.Clear();
            searchFirstNameBox.Clear();
            searchLastNameBox.Clear();
            DOBDD.Clear();
            DOBMM.Clear();
            DOBYYYY.Clear();
            searchContactNumberBox.Clear();

            searchEmployeeIDBox.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddNewEmployee addEmployeeForm = new AddNewEmployee();
            addEmployeeForm.Show();
        }

        private void addEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewEmployee addEmployeeForm = new AddNewEmployee();
            addEmployeeForm.Show();
        }

        private void rentalTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RentalTransactionWindowAddRemove rentalTransactionForm = new RentalTransactionWindowAddRemove();
            rentalTransactionForm.Show();
            this.Close();
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddRemoveCustomer addRemoveCustomerForm = new AddRemoveCustomer();
            addRemoveCustomerForm.Show();

            this.Close();
        }

        private void removeCustomreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteCustomer deleteCustomerForm = new DeleteCustomer();
            deleteCustomerForm.Show();
        }

        private void carsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddRemoveVehicle addVehicleForm = new AddRemoveVehicle();
            addVehicleForm.Show();
            this.Close();
        }

        private void carsToolStripMenuItem1_Click(object sender, EventArgs e)
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
                string query = "SELECT employeeNum as EmployeeNumber, Firstname, Lastname, DOBDay, DOBMonth, DOBYear, contactNum as ContactNumber, Street, City, Province, PostalCode, Country, workAtBranchNum as Branch FROM employees";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable employees = new DataTable();
                adapter.Fill(employees);

                dataGridView1.DataSource = employees;

                con.Dispose();
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // connect to database
                SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
                con.Open();

                // search through database
                string query = "SELECT employeeNum as EmployeeNumber, Firstname, Lastname, DOBDay, DOBMonth, DOBYear, contactNum as ContactNumber, Street, City, Province, PostalCode, Country, workAtBranchNum as Branch FROM employees";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable employees = new DataTable();
                adapter.Fill(employees);
                dataGridView1.DataSource = employees;
                con.Dispose();
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            // check if the input is an int
            int parsedValue;

            // this used for where statement if search bar is used
            string queryWhere = "SELECT employeeNum as EmployeeNumber, Firstname, Lastname, DOBDay, DOBMonth, DOBYear, contactNum as ContactNumber, Street, City, Province, PostalCode, Country, workAtBranchNum as Branch FROM employees WHERE ";
            
            string query = "SELECT employeeNum as EmployeeNumber, Firstname, Lastname, DOBDay, DOBMonth, DOBYear, contactNum as ContactNumber, Street, City, Province, PostalCode, Country, workAtBranchNum as Branch FROM employees";
            bool searchBarUsed = false;
            bool lastSearchBar = false;

            if (!string.IsNullOrEmpty(searchEmployeeIDBox.Text))
            {
                if (!int.TryParse(searchEmployeeIDBox.Text, out parsedValue))
                {
                    MessageBox.Show("Employee ID is a number only field");
                    return;
                }
                searchBarUsed = true;
                queryWhere = queryWhere + "employeeNum = " + searchEmployeeIDBox.Text + " AND ";
            }
            if (!string.IsNullOrEmpty(searchBranchBox.Text))
            {
                if (!int.TryParse(searchBranchBox.Text, out parsedValue))
                {
                    MessageBox.Show("branch is a number only field");
                    return;
                }
                searchBarUsed = true;
                queryWhere = queryWhere + "workAtBranchNum = " + searchBranchBox.Text + " AND ";
            }
            if (!string.IsNullOrEmpty(searchFirstNameBox.Text))
            {
                searchBarUsed = true;
                queryWhere = queryWhere + "firstName = '" + searchFirstNameBox.Text + "' AND ";
            }
            if (!string.IsNullOrEmpty(searchLastNameBox.Text))
            {
                searchBarUsed = true;
                queryWhere = queryWhere + "lastName = '" + searchLastNameBox.Text + "' AND ";
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
            DataTable employeeSearch = new DataTable();

            // last search bar is used, does not include ' AND '
            if (lastSearchBar == true)
            {
                SqlDataAdapter adapter = new SqlDataAdapter(queryWhere, con);
                adapter.Fill(employeeSearch);
            }
            // includes ' AND ', we must remove last 5 chars
            else if (searchBarUsed == true)
            {
                int stringLength = queryWhere.Length;
                string queryWhereSubString = queryWhere.Substring(0, stringLength - 5);
                SqlDataAdapter adapter = new SqlDataAdapter(queryWhereSubString, con);
                adapter.Fill(employeeSearch);
            }
            // search bar was never used, refresh the list
            else
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.Fill(employeeSearch);
            }

            dataGridView1.DataSource = employeeSearch;

            con.Dispose();
            con.Close();
        }

        private void RemoveBottomButton_Click(object sender, EventArgs e)
        {
            // check if the input is an int
            int parsedValue;

            if (!string.IsNullOrEmpty(RemoveEmployeeIDBox.Text))
            {
                if (!int.TryParse(RemoveEmployeeIDBox.Text, out parsedValue))
                {
                    MessageBox.Show("Employee ID is a number only field");
                    return;
                }
                // connect to database
                SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
                con.Open();

                cmd = new SqlCommand("DELETE FROM employees WHERE employeeNum = " + RemoveEmployeeIDBox.Text + "", con);
                int rows = cmd.ExecuteNonQuery();

                // check if employee id existed in database
                if (rows > 0)
                {
                    MessageBox.Show("Employee has been deleted, updating table");

                    // refresh database and show on table
                    string query = "SELECT employeeNum as EmployeeNumber, Firstname, Lastname, DOBDay, DOBMonth, DOBYear, contactNum as ContactNumber, Street, City, Province, PostalCode, Country, workAtBranchNum as Branch FROM employees";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable employees = new DataTable();
                    adapter.Fill(employees);
                    dataGridView1.DataSource = employees;
                }
                else
                {
                    MessageBox.Show("Error: No Employee ID exists in Database");
                }

                con.Close();
            }
            else
            {
                MessageBox.Show("Error: No Employee ID detected in box");
            }
        }

        private void removeEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteEmployee deleteEmployeeForm = new DeleteEmployee();
            deleteEmployeeForm.Show();
        }

        private void customToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomReports customReportsForm = new CustomReports();
            customReportsForm.Show();
        }
    }
}
