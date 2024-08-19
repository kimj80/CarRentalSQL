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
    public partial class LoginScreen : Form
    {
        public static string databasePath = "Data Source=DESKTOP-SG96S0F;Initial Catalog=cmpt291v3.0;Integrated Security=True;Encrypt=False";
        public static string employeeLoggedIn;

        public LoginScreen()
        {
            InitializeComponent();
        }
        private void Login_Click(object sender, EventArgs e)
        {
            String employeeNum, user_password;

            employeeNum = employeeNumBox.Text;
            employeeLoggedIn = employeeNumBox.Text;
            user_password = passwordBox.Text;

            try
            {
                SqlConnection conn = new SqlConnection(databasePath);
                String query = "SELECT * FROM Employees where employeeNum = '"+employeeNumBox.Text+"' AND password = '"+ passwordBox.Text+"'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if (dtable.Rows.Count > 0)
                {
                    employeeNum = employeeNumBox.Text;
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
            AddNewEmployee addNewEmployeeForm = new AddNewEmployee();
            addNewEmployeeForm.Show();
        }
    }

}
