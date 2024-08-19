using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cmpt291UI
{
    public partial class ReceiptList : Form
    {
        SqlCommand cmd;

        public ReceiptList()
        {
            InitializeComponent();

            this.Size = new Size(1600, 850);

            // connect to database
            SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
            con.Open();

            string query = "SELECT * FROM rentaltransactions, customers WHERE rentaltransactions.cusID = " +EmployeeLoginScreen.bookThisCustomerID+ " " +
                "AND rentaltransactions.cusid = customers.cusid";

            SqlDataAdapter adapter = new SqlDataAdapter(query, con);

            // insert data from extracted sql
            DataTable rentalTransactionsList = new DataTable();
            adapter.Fill(rentalTransactionsList);

            dataGridView1.DataSource = rentalTransactionsList;

            con.Dispose();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // check if the input is an int
            int parsedValue;

            string queryWhere = "SELECT * FROM rentaltransactions, customers WHERE rentaltransactions.cusID = " + EmployeeLoginScreen.bookThisCustomerID + " " +
                "AND rentaltransactions.cusid = customers.cusid AND ";
            string query = "SELECT * FROM rentaltransactions, customers WHERE rentaltransactions.cusID = " + EmployeeLoginScreen.bookThisCustomerID + " " +
                "AND rentaltransactions.cusid = customers.cusid";
            bool searchBarUsed = false;
            bool lastSearchBar = false;



            // TODO
            if (!string.IsNullOrEmpty(TransactionIDSearch.Text))
            {
                if (!int.TryParse(TransactionIDSearch.Text, out parsedValue))
                {
                    MessageBox.Show("Transaction ID is a number only field");
                    return;
                }
                searchBarUsed = true;
                queryWhere = queryWhere + "transID = " + TransactionIDSearch.Text + " AND ";
            }
            if (!string.IsNullOrEmpty(lastXMonths.Text))
            {
                if (!int.TryParse(lastXMonths.Text, out parsedValue))
                {
                    MessageBox.Show("Last X Months is a number only field");
                    return;
                }
                //searchBarUsed = true;
                // workout the math here, this is wrong atm
                //queryWhere = queryWhere + "transID = " + lastXMonths.Text + " AND ";
            }
            if (!string.IsNullOrEmpty(lastXYears.Text))
            {
                if (!int.TryParse(lastXYears.Text, out parsedValue))
                {
                    MessageBox.Show("Last X Years is a number only field");
                    return;
                }
                //searchBarUsed = true;
                //lastSearchBar = true;
                // workout the math here
                //queryWhere = queryWhere + "transID = " + lastXYears.Text + "";
            }

            // connect to database
            SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
            con.Open();
            DataTable rentalTransactionsList = new DataTable();

            // last search bar is used, does not include ' AND '
            if (lastSearchBar == true)
            {
                SqlDataAdapter adapter = new SqlDataAdapter(queryWhere, con);
                adapter.Fill(rentalTransactionsList);
            }
            // includes ' AND ', we must remove last 5 chars
            else if (searchBarUsed == true)
            {
                int stringLength = queryWhere.Length;
                string queryWhereSubString = queryWhere.Substring(0, stringLength - 5);
                SqlDataAdapter adapter = new SqlDataAdapter(queryWhereSubString, con);
                adapter.Fill(rentalTransactionsList);
            }
            // search bar was never used, refresh the list
            else
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.Fill(rentalTransactionsList);
            }

            dataGridView1.DataSource = rentalTransactionsList;

            con.Dispose();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (EmployeeLoginScreen.customerFormUsed == true)
            {
                // query customer information and receipt list
            }

            SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
            con.Open();

            string query = "SELECT * FROM rentaltransactions WHERE cusID = " + EmployeeLoginScreen.bookThisCustomerID + " AND " +
                "transID = " + transactionsIDSelect.Text + "";
            
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable rentalTransactionsList = new DataTable();
            adapter.Fill(rentalTransactionsList);
            // RentalTransactions(transID, rentalCost, rentedFromDay, rentedFromMonth, rentedFromYear,
            // returnToDay, returnToMonth, returnToYear, employeeNum, cusID, carVIN, branchNum, branchDropoff
            
            if (rentalTransactionsList.Rows.Count > 0)
            {
                // get the car vin from transactions, link it to car and cartypes and get all the necessary info
                // check if car is available from rentaltransactions
                String query2 = "SELECT * FROM car, cartypes WHERE carvin = '" + rentalTransactionsList.Rows[0]["carVIN"].ToString() + "' AND " +
                    "car.carTypeID = cartypes.carTypeID";
                SqlDataAdapter sda = new SqlDataAdapter(query2, con);
                DataTable dtable2 = new DataTable();
                sda.Fill(dtable2);

                EmployeeLoginScreen.bookThisCustomerDailyCost = dtable2.Rows[0]["dailyCost"].ToString();
                EmployeeLoginScreen.bookThisCustomerWeeklyCost = dtable2.Rows[0]["weeklyCost"].ToString();
                EmployeeLoginScreen.bookThisCustomerMonthlyCost = dtable2.Rows[0]["monthlyCost"].ToString();

                // rental info
                EmployeeLoginScreen.bookThisCarVIN = dtable2.Rows[0]["carVIN"].ToString();
                EmployeeLoginScreen.bookThisEmployeeID = rentalTransactionsList.Rows[0]["employeeNum"].ToString();
                EmployeeLoginScreen.bookThisDateFromDD = rentalTransactionsList.Rows[0]["rentedFromDay"].ToString();
                EmployeeLoginScreen.bookThisDateFromMM = rentalTransactionsList.Rows[0]["rentedFromMonth"].ToString();
                EmployeeLoginScreen.bookThisDateFromYYYY = rentalTransactionsList.Rows[0]["rentedFromYear"].ToString();
                EmployeeLoginScreen.bookThisDateToDD = rentalTransactionsList.Rows[0]["returnToDay"].ToString();
                EmployeeLoginScreen.bookThisDateToMM = rentalTransactionsList.Rows[0]["returnToMonth"].ToString();
                EmployeeLoginScreen.bookThisDateToYYYY = rentalTransactionsList.Rows[0]["returnToYear"].ToString();

                EmployeeLoginScreen.bookThisTransactionID = rentalTransactionsList.Rows[0]["transID"].ToString();
                EmployeeLoginScreen.bookThisCustomerID = rentalTransactionsList.Rows[0]["cusID"].ToString();
                EmployeeLoginScreen.bookThisBranchPickUp = rentalTransactionsList.Rows[0]["branchNum"].ToString();
                EmployeeLoginScreen.bookThisBranchDropOff = rentalTransactionsList.Rows[0]["branchDropoff"].ToString();

                TransactionsReceipt transactionReceiptFormCustomerSide = new TransactionsReceipt();
                transactionReceiptFormCustomerSide.Show();
            }
            else
            {
                MessageBox.Show("Invalid Transaction ID");
            }

            con.Dispose();
            con.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }


        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
