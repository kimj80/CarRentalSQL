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
    public partial class AddRemoveVehicle : Form
    {
        SqlCommand cmd;
        public AddRemoveVehicle()
        {
            InitializeComponent();

            WindowState = FormWindowState.Maximized;

            // connect to database
            SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
            con.Open();

            // search through database
            string query = "SELECT * FROM car";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dtable = new DataTable();
            adapter.Fill(dtable);
            dataGridView1.DataSource = dtable;
            con.Close();
        }

        private void AddVehicle_Load(object sender, EventArgs e)
        {

        }

        private void ToolBarDatabaseCars(object sender, EventArgs e)
        {
            EmployeeMainWindowBook employeeMainWindowBookForm = new EmployeeMainWindowBook();
            employeeMainWindowBookForm.Show();
            this.Close();
        }

        private void SearchCarButton(object sender, EventArgs e)
        {

        }

        private void DeleteCarButton_Click(object sender, EventArgs e)
        {
            // check if textbox is filled
            if (!string.IsNullOrEmpty(deleteCarVINtxt.Text))
            {
                // connect to database
                SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
                con.Open();

                cmd = new SqlCommand("DELETE FROM car WHERE CarVIN = '" + deleteCarVINtxt.Text + "'", con);
                int rows = cmd.ExecuteNonQuery();

                // check if car vin exists in database
                if (rows > 0)
                {
                    MessageBox.Show("Car VIN has been deleted, updating table");

                    // refresh database and show on table
                    String query = "SELECT * FROM car";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable dtable = new DataTable();
                    adapter.Fill(dtable);
                    dataGridView1.DataSource = dtable;
                }
                else
                {
                    MessageBox.Show("Error: No Car VIN exists in Database");
                }

                con.Close();
            }
            else
            {
                MessageBox.Show("Error: No Car VIN detected in Box");
            }
        }

        private void refreshToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                // connect to database
                SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
                con.Open();

                // search through database
                string query = "SELECT * FROM car";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable cars = new DataTable();
                adapter.Fill(cars);
                dataGridView1.DataSource = cars;
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

        private void customersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddRemoveCustomer addRemoveCustomerForm = new AddRemoveCustomer();
            addRemoveCustomerForm.Show();

            this.Close();
        }

        private void carsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // connect to database
                SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
                con.Open();

                // search through database
                string query = "SELECT * FROM car";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable cars = new DataTable();
                adapter.Fill(cars);
                dataGridView1.DataSource = cars;
                con.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void employeesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddRemoveEmployee addRemoveEmployeeForm = new AddRemoveEmployee();
            addRemoveEmployeeForm.Show();
            this.Close();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            addCarVINtxt.Clear();
            addCarTypeIDtxt.Clear();
            addCarBrandtxt.Clear();
            addCarModeltxt.Clear();
            addCarYeartxt.Clear();
            addCarColortxt.Clear();
            addCarMileagetxt.Clear();
            addCarLastTuneUptxt.Clear();
            addCarConditiontxt.Clear();
            addCarBranchLocationtxt.Clear();

            addCarVINtxt.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            searchCarVINtxt.Clear();
            searchCarTypeIDtxt.Clear();
            searchCarBrandtxt.Clear();
            searchCarModeltxt.Clear();
            searchCarYeartxt.Clear();
            searchCarColortxt.Clear();
            searchCarMileagetxt.Clear();
            searchCarLastTuneUptxt.Clear();
            searchCarConditiontxt.Clear();
            searchCarBranchLocationtxt.Clear();

            searchCarVINtxt.Focus();
        }

        private void addCarVINtxt_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // check if the input is an int
            int parsedValue;

            // check if texboxes are all filled and not empty
            if (string.IsNullOrEmpty(addCarVINtxt.Text))
            {
                MessageBox.Show("Car VIN box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(addCarTypeIDtxt.Text))
            {
                MessageBox.Show("Car Type ID box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(addCarBrandtxt.Text))
            {
                MessageBox.Show("Car Brand box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(addCarModeltxt.Text))
            {
                MessageBox.Show("Car Model box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(addCarYeartxt.Text))
            {
                MessageBox.Show("Car Year box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(addCarColortxt.Text))
            {
                MessageBox.Show("Car Color box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(addCarMileagetxt.Text))
            {
                MessageBox.Show("Car Mileage box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(addCarLastTuneUptxt.Text))
            {
                MessageBox.Show("Car Last Tune up box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(addCarConditiontxt.Text))
            {
                MessageBox.Show("Car Condition box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(addCarBranchLocationtxt.Text))
            {
                MessageBox.Show("Car Branch Location box, empty");
                return;
            }

            // Check to see if the boxes are all valid, make sure int boxes are int
            if (!int.TryParse(addCarTypeIDtxt.Text, out parsedValue))
            {
                MessageBox.Show("Car Type ID is a number only field");
                return;
            }
            else if (!int.TryParse(addCarYeartxt.Text, out parsedValue))
            {
                MessageBox.Show("Car Year is a number only field");
                return;
            }
            else if (!int.TryParse(addCarMileagetxt.Text, out parsedValue))
            {
                MessageBox.Show("Car Mileage is a number only field");
                return;
            }
            else if (!int.TryParse(addCarLastTuneUptxt.Text, out parsedValue))
            {
                MessageBox.Show("Car Last Tune Up is a number only field");
                return;
            }
            else if (!int.TryParse(addCarBranchLocationtxt.Text, out parsedValue))
            {
                MessageBox.Show("Car Branch Location is a number only field");
                return;
            }

            // connect to database
            SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
            con.Open();

            cmd = new SqlCommand("INSERT INTO car values('" + addCarVINtxt.Text + "'," +
                " " + addCarTypeIDtxt.Text + "," +
                " '" + addCarBrandtxt.Text + "', " +
                " '" + addCarModeltxt.Text + "'," +
                " " + addCarYeartxt.Text + "," +
                " '" + addCarColortxt.Text + "'," +
                " " + addCarMileagetxt.Text + "," +
                " " + addCarLastTuneUptxt.Text + "," +
                " '" + addCarConditiontxt.Text + "'," +
                " " + addCarBranchLocationtxt.Text + ")", con);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Car has been inserted, updating table");

            // search through database
            string query = "SELECT * FROM car";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dtable = new DataTable();
            adapter.Fill(dtable);
            dataGridView1.DataSource = dtable;

            con.Close();

            addCarVINtxt.Clear();
            addCarTypeIDtxt.Clear();
            addCarBrandtxt.Clear();
            addCarModeltxt.Clear();
            addCarYeartxt.Clear();
            addCarColortxt.Clear();
            addCarMileagetxt.Clear();
            addCarLastTuneUptxt.Clear();
            addCarConditiontxt.Clear();
            addCarBranchLocationtxt.Clear();

            addCarVINtxt.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // check if the input is an int
            int parsedValue;

            // this used for where statement if search bar is used
            string queryWhere = "SELECT * FROM car WHERE ";
            
            string query = "SELECT * FROM car";
            bool searchBarUsed = false;
            bool lastSearchBar = false;

            if (!string.IsNullOrEmpty(searchCarVINtxt.Text))
            {
                searchBarUsed = true;
                queryWhere = queryWhere + "carVIN = '" + searchCarVINtxt.Text + "' AND ";
            }
            if (!string.IsNullOrEmpty(searchCarTypeIDtxt.Text))
            {
                if (!int.TryParse(searchCarTypeIDtxt.Text, out parsedValue))
                {
                    MessageBox.Show("Car Type ID is a number only field");
                    return;
                }
                searchBarUsed = true;
                queryWhere = queryWhere + "carTypeID = " + searchCarTypeIDtxt.Text + " AND ";
            }
            if (!string.IsNullOrEmpty(searchCarBrandtxt.Text))
            {
                searchBarUsed = true;
                queryWhere = queryWhere + "brand = '" + searchCarBrandtxt.Text + "' AND ";
            }
            if (!string.IsNullOrEmpty(searchCarModeltxt.Text))
            {
                searchBarUsed = true;
                queryWhere = queryWhere + "model = '" + searchCarModeltxt.Text + "' AND ";
            }
            if (!string.IsNullOrEmpty(searchCarYeartxt.Text))
            {
                if (!int.TryParse(searchCarYeartxt.Text, out parsedValue))
                {
                    MessageBox.Show("Car Year is a number only field");
                    return;
                }
                searchBarUsed = true;
                queryWhere = queryWhere + "year <= " + searchCarYeartxt.Text + " AND ";
            }
            if (!string.IsNullOrEmpty(searchCarColortxt.Text))
            {
                searchBarUsed = true;
                queryWhere = queryWhere + "color = '" + searchCarColortxt.Text + "' AND ";
            }
            if (!string.IsNullOrEmpty(searchCarMileagetxt.Text))
            {
                if (!int.TryParse(searchCarMileagetxt.Text, out parsedValue))
                {
                    MessageBox.Show("Car Mileage is a number only field");
                    return;
                }
                searchBarUsed = true;
                queryWhere = queryWhere + "mileage >= " + searchCarMileagetxt.Text + " AND ";
            }
            if (!string.IsNullOrEmpty(searchCarLastTuneUptxt.Text))
            {
                if (!int.TryParse(searchCarLastTuneUptxt.Text, out parsedValue))
                {
                    MessageBox.Show("Car Last Tune Up is a number only field");
                    return;
                }
                // TODO
                // this will need to be relooked at, the logic is not there
                searchBarUsed = true;
                queryWhere = queryWhere + "lastTuneUp <= " + searchCarLastTuneUptxt.Text + " AND ";
                // I will need to redo this, I want to eventually make car mileage - last tune up = result
                // so 5000 would show cars that had tune ups within 5000 km.
            }
            if (!string.IsNullOrEmpty(searchCarConditiontxt.Text))
            {
                searchBarUsed = true;
                queryWhere = queryWhere + "condition = '" + searchCarConditiontxt.Text + "' AND ";
            }
            if (!string.IsNullOrEmpty(searchCarBranchLocationtxt.Text))
            {
                if (!int.TryParse(searchCarBranchLocationtxt.Text, out parsedValue))
                {
                    MessageBox.Show("Car Branch Location is a number only field");
                    return;
                }
                searchBarUsed = true;
                lastSearchBar = true;
                queryWhere = queryWhere + "branchpickup = " + searchCarBranchLocationtxt.Text + "";
            }

            // connect to database
            SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
            con.Open();
            DataTable dtable = new DataTable();

            // last search bar is used, does not include ' AND '
            if (lastSearchBar == true)
            {
                SqlDataAdapter adapter = new SqlDataAdapter(queryWhere, con);
                adapter.Fill(dtable);
            }
            // includes ' AND ', we must remove last 5 chars
            else if (searchBarUsed == true)
            {
                int stringLength = queryWhere.Length;
                string queryWhereSubString = queryWhere.Substring(0, stringLength - 5);
                SqlDataAdapter adapter = new SqlDataAdapter(queryWhereSubString, con);
                adapter.Fill(dtable);
            }
            // search bar was never used, refresh the list
            else
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.Fill(dtable);
            }

            dataGridView1.DataSource = dtable;

            con.Dispose();
            con.Close();
        }

        private void rentalTransactionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RentalTransactionWindowAddRemove rentalTransactionForm = new RentalTransactionWindowAddRemove();
            rentalTransactionForm.Show();
            this.Close();
        }

        private void addEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewEmployee addEmployeeForm = new AddNewEmployee();
            addEmployeeForm.Show();
        }

        private void addCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewCustomer addNewCustomerForm = new AddNewCustomer();
            addNewCustomerForm.Show();
        }

        private void removeCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteCustomer deleteCustomerForm = new DeleteCustomer();
            deleteCustomerForm.Show();
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
