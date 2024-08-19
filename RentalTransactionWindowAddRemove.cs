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
    public partial class RentalTransactionWindowAddRemove : Form
    {
        SqlCommand cmd;
        public RentalTransactionWindowAddRemove()
        {
            InitializeComponent();

            WindowState = FormWindowState.Maximized;

            SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
            con.Open();

            string query = "SELECT * FROM rentaltransactions";

            SqlDataAdapter adapter = new SqlDataAdapter(query, con);

            // insert data from extracted sql
            DataTable rentalTransactionsList = new DataTable();
            adapter.Fill(rentalTransactionsList);

            dataGridView1.DataSource = rentalTransactionsList;

            con.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DeleteRentalTransaction(object sender, EventArgs e)
        {
            // check if the input is an int
            int parsedValue;

            if (!string.IsNullOrEmpty(TransactionsIDDeleteBox.Text))
            {
                if (!int.TryParse(TransactionsIDDeleteBox.Text, out parsedValue))
                {
                    MessageBox.Show("Transaction ID is a number only field");
                    return;
                }
                // connect to database
                SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
                con.Open();

                cmd = new SqlCommand("DELETE FROM rentalTransactions WHERE transID = " + TransactionsIDDeleteBox.Text + "", con);
                int rows = cmd.ExecuteNonQuery();

                // check if employee id existed in database
                if (rows > 0)
                {
                    MessageBox.Show("Transactions ID has been deleted, updating table");

                    // refresh database and show on table
                    string query = "SELECT * FROM rentaltransactions";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable rentalTransactionsList = new DataTable();
                    adapter.Fill(rentalTransactionsList);
                    dataGridView1.DataSource = rentalTransactionsList;
                }
                else
                {
                    MessageBox.Show("Error: No Transactions ID exists in Database");
                }

                con.Close();
            }
            else
            {
                MessageBox.Show("Error: No Transactions ID detected in box");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // check if the input is an int
            int parsedValue;

            // this used for where statement if search bar is used
            string queryWhere = "SELECT * FROM rentaltransactions WHERE ";

            string query = "SELECT * FROM rentaltransactions";
            bool searchBarUsed = false;
            bool lastSearchBar = false;

            if (!string.IsNullOrEmpty(branchSearchBox.Text))
            {
                if (!int.TryParse(branchSearchBox.Text, out parsedValue))
                {
                    MessageBox.Show("Branch is a number only field");
                    return;
                }
                searchBarUsed = true;
                queryWhere = queryWhere + "branchNum = " + branchSearchBox.Text + " AND ";
            }
            if (!string.IsNullOrEmpty(transactionsSearchBox.Text))
            {
                if (!int.TryParse(transactionsSearchBox.Text, out parsedValue))
                {
                    MessageBox.Show("Transaction ID is a number only field");
                    return;
                }
                searchBarUsed = true;
                queryWhere = queryWhere + "transID = " + transactionsSearchBox.Text + " AND ";
            }
            if (!string.IsNullOrEmpty(employeeIDSearchBox.Text))
            {
                if (!int.TryParse(employeeIDSearchBox.Text, out parsedValue))
                {
                    MessageBox.Show("Employee ID is a number only field");
                    return;
                }
                searchBarUsed = true;
                queryWhere = queryWhere + "employeeNum = " + employeeIDSearchBox.Text + " AND ";
            }
            if (!string.IsNullOrEmpty(customerIDSearchBox.Text))
            {
                if (!int.TryParse(customerIDSearchBox.Text, out parsedValue))
                {
                    MessageBox.Show("Customer ID is a number only field");
                    return;
                }
                searchBarUsed = true;
                queryWhere = queryWhere + "cusID = " + customerIDSearchBox.Text + " AND ";
            }
            if (!string.IsNullOrEmpty(dateFromDDSearchBox.Text))
            {
                if (!int.TryParse(dateFromDDSearchBox.Text, out parsedValue))
                {
                    MessageBox.Show("Date-From Day is a number only field");
                    return;
                }
                searchBarUsed = true;
                queryWhere = queryWhere + "rentedFromDay = " + dateFromDDSearchBox.Text + " AND ";
            }
            if (!string.IsNullOrEmpty(dateFromMMSearchBox.Text))
            {
                if (!int.TryParse(dateFromMMSearchBox.Text, out parsedValue))
                {
                    MessageBox.Show("Date-From Month is a number only field");
                    return;
                }
                searchBarUsed = true;
                queryWhere = queryWhere + "rentedFromMonth = " + dateFromMMSearchBox.Text + " AND ";
            }
            if (!string.IsNullOrEmpty(dateFromYYYYSearchBox.Text))
            {
                if (!int.TryParse(dateFromYYYYSearchBox.Text, out parsedValue))
                {
                    MessageBox.Show("Date-From Year is a number only field");
                    return;
                }
                searchBarUsed = true;
                queryWhere = queryWhere + "rentedFromYear = " + dateFromYYYYSearchBox.Text + " AND ";
            }
            if (!string.IsNullOrEmpty(dateToDDSearchBox.Text))
            {
                if (!int.TryParse(dateToDDSearchBox.Text, out parsedValue))
                {
                    MessageBox.Show("Date-To Day is a number only field");
                    return;
                }
                searchBarUsed = true;
                queryWhere = queryWhere + "returnToDay = " + dateToDDSearchBox.Text + " AND ";
            }
            if (!string.IsNullOrEmpty(dateToMMSearchBox.Text))
            {
                if (!int.TryParse(dateToMMSearchBox.Text, out parsedValue))
                {
                    MessageBox.Show("Date-To Day  is a number only field");
                    return;
                }
                searchBarUsed = true;
                queryWhere = queryWhere + "returnToMonth = " + dateToMMSearchBox.Text + " AND ";
            }
            if (!string.IsNullOrEmpty(dateToYYYYSearchBox.Text))
            {
                if (!int.TryParse(dateToYYYYSearchBox.Text, out parsedValue))
                {
                    MessageBox.Show("Date-To Day  is a number only field");
                    return;
                }
                searchBarUsed = true;
                lastSearchBar = true;
                queryWhere = queryWhere + "returnToYear = " + dateToYYYYSearchBox.Text + "";
            }

            // connect to database
            SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
            con.Open();
            DataTable rentalTransactionsList = new DataTable();

            // last search bar is used, does not include ' AND '
            if (lastSearchBar == true)
            {
                // insert data from extracted sql
                SqlDataAdapter adapter = new SqlDataAdapter(queryWhere, con);
                adapter.Fill(rentalTransactionsList);
            }
            // includes ' AND ', we must remove last 5 chars
            else if (searchBarUsed == true)
            {
                int stringLength = queryWhere.Length;
                string queryWhereSubString = queryWhere.Substring(0, stringLength - 5);
                // insert data from extracted sql
                SqlDataAdapter adapter = new SqlDataAdapter(queryWhereSubString, con);
                adapter.Fill(rentalTransactionsList);
            }
            // search bar was never used, refresh the list
            else
            {
                // insert data from extracted sql
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.Fill(rentalTransactionsList);
            }

            dataGridView1.DataSource = rentalTransactionsList;

            con.Dispose();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            branchSearchBox.Clear();
            transactionsSearchBox.Clear();
            employeeIDSearchBox.Clear();
            customerIDSearchBox.Clear();
            dateFromDDSearchBox.Clear();
            dateFromMMSearchBox.Clear();
            dateFromYYYYSearchBox.Clear();
            dateToDDSearchBox.Clear();
            dateToMMSearchBox.Clear();
            dateToYYYYSearchBox.Clear();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BookCarStrip(object sender, EventArgs e)
        {
            // page that needed to be loaded next
            EmployeeMainWindowBook employeeMainWindowBookForm = new EmployeeMainWindowBook();
            employeeMainWindowBookForm.Show();
            this.Close();
        }

        private void refreshToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                // connect to database
                SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
                con.Open();

                // search through database
                string query = "SELECT * FROM rentaltransactions";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);

                // insert data from extracted sql
                DataTable rentaltransactions = new DataTable();
                adapter.Fill(rentaltransactions);

                dataGridView1.DataSource = rentaltransactions;

                con.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            AddRemoveVehicle addVehicleForm = new AddRemoveVehicle();
            addVehicleForm.Show();
            this.Close();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
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
            try
            {
                // connect to database
                SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
                con.Open();

                // search through database
                string query = "SELECT * FROM rentaltransactions";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);

                // insert data from extracted sql
                DataTable rentaltransactions = new DataTable();
                adapter.Fill(rentaltransactions);

                dataGridView1.DataSource = rentaltransactions;

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

        private void removeCustomerToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

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
