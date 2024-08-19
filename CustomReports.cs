using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cmpt291UI
{
    public partial class CustomReports : Form
    {
        SqlCommand cmd;

        public CustomReports()
        {
            InitializeComponent();
        }

        private void CustomReports_Load(object sender, EventArgs e)
        {

        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string searchQuery = "SELECT ";
            if (!string.IsNullOrEmpty(selectBox.Text))
            {
                searchQuery = searchQuery + selectBox.Text;
            }
            else
            {
                return;
            }
            if (!string.IsNullOrEmpty(fromBox.Text))
            {
                searchQuery = searchQuery + " FROM " + fromBox.Text;
            }
            else
            {
                return;
            }
            if (!string.IsNullOrEmpty(whereBox.Text))
            {
                searchQuery = searchQuery + " WHERE " + whereBox.Text;
            }

            // connect to database
            SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
            con.Open();
            DataTable dtable = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(searchQuery, con);
            adapter.Fill(dtable);

            dataGridView1.DataSource = dtable;

            con.Dispose();
            con.Close();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void carsNeverRentedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string query = "SELECT Car.CarVIN, Car.Brand, Car.Model, Car.Year, Car.Color " +
                "FROM Car LEFT JOIN RentalTransactions ON Car.CarVIN = RentalTransactions.CarVIN " +
                "WHERE RentalTransactions.CarVIN IS NULL";

            // connect to database
            SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
            con.Open();
            DataTable carsNeverRented = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            adapter.Fill(carsNeverRented);

            dataGridView1.DataSource = carsNeverRented;

            con.Dispose();
            con.Close();
        }

        private void customersRented1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string query = "SELECT Customers.CusID, Customers.FirstName, Customers.LastName, COUNT(RentalTransactions.TransID) AS RentalCount " +
                "FROM Customers JOIN RentalTransactions ON Customers.CusID = RentalTransactions.CusID " +
                "GROUP BY Customers.CusID, Customers.FirstName, Customers.LastName " +
                "HAVING COUNT(RentalTransactions.TransID) > 1";

            // connect to database
            SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
            con.Open();
            DataTable dtable = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            adapter.Fill(dtable);

            dataGridView1.DataSource = dtable;

            con.Dispose();
            con.Close();
        }

        private void topBranchRentalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string query = "SELECT TOP 1 Branches.Name, Branches.City, COUNT(RentalTransactions.TransID) AS TotalRentals " +
                "FROM Branches JOIN RentalTransactions ON Branches.BranchNum = RentalTransactions.BranchNum " +
                "GROUP BY Branches.Name, Branches.City, Branches.BranchNum " +
                "ORDER BY TotalRentals DESC";

            // connect to database
            SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
            con.Open();
            DataTable dtable = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            adapter.Fill(dtable);

            dataGridView1.DataSource = dtable;

            con.Dispose();
            con.Close();
        }

        private void customerSpentMostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string query = "SELECT TOP 1 Customers.CusID, Customers.FirstName, Customers.LastName, SUM(RentalTransactions.RentalCost) AS TotalSpent " +
                "FROM Customers JOIN RentalTransactions ON Customers.CusID = RentalTransactions.CusID " +
                "GROUP BY Customers.CusID, Customers.FirstName, Customers.LastName " +
                "ORDER BY TotalSpent DESC;";


            // connect to database
            SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
            con.Open();
            DataTable dtable = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            adapter.Fill(dtable);

            dataGridView1.DataSource = dtable;

            con.Dispose();
            con.Close();
        }
    }
}
