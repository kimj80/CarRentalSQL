using System;
using System.Collections;
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
    public partial class EmployeeLoginScreen : Form
    {
        public static string databasePath = "Data Source=DESKTOP-HGC9N31\\SQLEXPRESS;Initial Catalog=CarRental;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";
        public static string employeeLoggedIn;
        public static bool customerFormUsed = false;

        // global variable for EMPLOYEE MAIN WINDOW BOOKING
        // needs to be on this window as main windows closes from switching main windows
        // secondary windows still need to get the information if necessary
        // this will only work for one employee logged in per computer
        public static string bookThisCarVIN;
        public static string bookThisEmployeeID;
        public static string bookThisDateFromDD;
        public static string bookThisDateFromMM;
        public static string bookThisDateFromYYYY;
        public static string bookThisDateToDD;
        public static string bookThisDateToMM;
        public static string bookThisDateToYYYY;

        // global variable for FIND CUSTOMER SMALL WINDOW
        public static string bookThisCustomerID;
        public static string bookThisCustomerName;

        // global variable for RENTAL TRANSACTIONS
        public static string bookThisCustomerDailyCost;
        public static string bookThisCustomerWeeklyCost;
        public static string bookThisCustomerMonthlyCost;

        public static string bookThisTransactionID;
        public static string bookThisBranchPickUp;
        public static string bookThisBranchDropOff;

        public EmployeeLoginScreen()
        {
            InitializeComponent();
        }
        private void Login_Click(object sender, EventArgs e)
        {
            String user_password;

            employeeLoggedIn = employeeNumBox.Text;
            user_password = passwordBox.Text;

            try
            {
                SqlConnection conn = new SqlConnection(databasePath);
                conn.Open();
                String query = "SELECT * FROM Employees where employeeNum = '" + employeeNumBox.Text + "' AND password = '" + passwordBox.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);
                if (dtable.Rows.Count > 0)
                {
                    employeeLoggedIn = employeeNumBox.Text;
                    user_password = passwordBox.Text;

                    // page that needed to be loaded next
                    EmployeeMainWindowBook employeeMainWindowBookForm = new EmployeeMainWindowBook();
                    employeeMainWindowBookForm.Show();
                    this.Hide();

                    conn.Dispose();
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Invalid login details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    employeeNumBox.Clear();
                    passwordBox.Clear();
                }
            }
            catch 
            {
                MessageBox.Show("Error");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Clear_Click(object sender, EventArgs e)
        {
            employeeNumBox.Clear();
            passwordBox.Clear();

            employeeNumBox.Focus();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoginScreen_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // load addnewcustomer window
            AddNewEmployee addNewEmployeeForm = new AddNewEmployee();
            addNewEmployeeForm.Show();
        }
    }
}
