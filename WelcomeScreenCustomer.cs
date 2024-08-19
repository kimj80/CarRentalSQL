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
    public partial class CustomerLogin : Form
    {
        public static string customerLoggedIn;

        public CustomerLogin()
        {
            InitializeComponent();

            // short cut for now, use the employee welcome screen to use global variables
            // otherwise I would have to copy and rewrite the code for customer side
            EmployeeLoginScreen employeeLoginScreenForm = new EmployeeLoginScreen();
            employeeLoginScreenForm.Hide();

            EmployeeLoginScreen.customerFormUsed = true;
        }

        private void Login_Click(object sender, EventArgs e)
        {
            String user_password;

            customerLoggedIn = customerIDBox.Text;
            user_password = customerPasswordBox.Text;

            try
            {
                SqlConnection conn = new SqlConnection(EmployeeLoginScreen.databasePath);
                String query = "SELECT * FROM Customers where cusID = '" + customerIDBox.Text + "' AND password = '" + customerPasswordBox.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if (dtable.Rows.Count > 0)
                {
                    customerLoggedIn = customerIDBox.Text;
                    user_password = customerPasswordBox.Text;
                    
                    // set up the values for logging in from customer side
                    EmployeeLoginScreen.employeeLoggedIn = "0";
                    EmployeeLoginScreen.bookThisEmployeeID = "0";
                    EmployeeLoginScreen.customerFormUsed = true;
                    EmployeeLoginScreen.bookThisCustomerID = customerIDBox.Text;

                    // page that needed to be loaded next
                    CustomerWindowMainBook customerMainWindowBookForm = new CustomerWindowMainBook();
                    customerMainWindowBookForm.Show();
                    this.Hide();

                    conn.Dispose();
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Invalid login details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    customerIDBox.Clear();
                    customerPasswordBox.Clear();
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            customerIDBox.Clear();
            customerPasswordBox.Clear();

            customerIDBox.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // add customer, switch forms
            CustomerSignUpWindow customerSignUpWindowForm = new CustomerSignUpWindow();
            customerSignUpWindowForm.Show();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CustomerLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
