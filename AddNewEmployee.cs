using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cmpt291UI
{
    public partial class AddNewEmployee : Form
    {
        bool firstClickDD = true;
        bool firstClickMM = true;
        bool firstClickYYYY = true;
        bool firstClickConNum = true;
        bool firstClickPostalCode = true;

        SqlCommand cmd;

        public AddNewEmployee()
        {
            InitializeComponent();

            this.Size = new Size(800, 650);

            // this is used to get new employee number for primary key
            // connect to database
            SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
            con.Open();

            SqlCommand cmd = new SqlCommand();

            // find max int in customer for primary key, then increment by 1
            cmd = new SqlCommand("SELECT MAX(employeeNum) FROM Employees", con);
            var getValue = cmd.ExecuteScalar();

            int newEmployeePrimaryKey = Convert.ToInt32(getValue);
            newEmployeePrimaryKey++;

            EmployeeIDBox.Text = newEmployeePrimaryKey.ToString();

            con.Close();
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            firstNameBox.Clear();
            lastNameBox.Clear();
            DOBDD.Clear();
            contactNumberBox.Clear();
            streetBox.Clear();
            cityBox.Clear();
            provinceBox.Clear();
            postalCodeBox.Clear();
            countryBox.Clear();
            passwordBox.Clear();
            branchNumberBox.Clear();
            DOBMM.Clear();
            DOBYYYY.Clear();

            // this is used to get new employee number for primary key
            // connect to database
            SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
            con.Open();

            SqlCommand cmd = new SqlCommand();

            // find max int in customer for primary key, then increment by 1
            cmd = new SqlCommand("SELECT MAX(employeeNum) FROM Employees", con);
            var getValue = cmd.ExecuteScalar();

            int newEmployeePrimaryKey = Convert.ToInt32(getValue);
            newEmployeePrimaryKey++;

            EmployeeIDBox.Text = newEmployeePrimaryKey.ToString();

            con.Close();
        }

        // submit button
        private void button1_Click(object sender, EventArgs e)
        {
            // check to see all textboxes are filled in
            if (string.IsNullOrEmpty(firstNameBox.Text))
            {
                MessageBox.Show("First Name box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(lastNameBox.Text))
            {
                MessageBox.Show("Last Name box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(DOBDD.Text))
            {
                MessageBox.Show("DOB Day box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(DOBMM.Text))
            {
                MessageBox.Show("DOB Month box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(DOBYYYY.Text))
            {
                MessageBox.Show("DOB Year box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(contactNumberBox.Text))
            {
                MessageBox.Show("Contact Number box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(EmployeeIDBox.Text))
            {
                MessageBox.Show("Employee ID box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(streetBox.Text))
            {
                MessageBox.Show("Street box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(cityBox.Text))
            {
                MessageBox.Show("City box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(provinceBox.Text))
            {
                MessageBox.Show("Province box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(postalCodeBox.Text))
            {
                MessageBox.Show("Postal Code box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(countryBox.Text))
            {
                MessageBox.Show("Country box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(branchNumberBox.Text))
            {
                MessageBox.Show("Branch Number box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(passwordBox.Text))
            {
                MessageBox.Show("Password box, empty");
                return;
            }

            // also check to ensure some boxes are int, DOB needs to be int, etc
            int parsedValue;
            if (!int.TryParse(DOBDD.Text, out parsedValue))
            {
                MessageBox.Show("DOB Day is a number only field");
                return;
            }
            else if (!int.TryParse(DOBMM.Text, out parsedValue))
            {
                MessageBox.Show("DOB Month is a number only field");
                return;
            }
            else if (!int.TryParse(DOBYYYY.Text, out parsedValue))
            {
                MessageBox.Show("DOB Year is a number only field");
                return;
            }
            else if (!int.TryParse(EmployeeIDBox.Text, out parsedValue))
            {
                MessageBox.Show("Operator ID is a number only field");
                return;
            }
            
            else if (!int.TryParse(branchNumberBox.Text, out parsedValue))
            {
                MessageBox.Show("Branch Number is a number only field");
                return;
            }

            // this is used to get new employee number for primary key
            // connect to database
            SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
            con.Open();

            SqlCommand cmd = new SqlCommand();

            // find max int in employee for primary key, then increment by 1
            cmd = new SqlCommand("SELECT MAX(employeeNum) FROM Employees", con);
            var getValue = cmd.ExecuteScalar();

            int newEmployeePrimaryKey = Convert.ToInt32(getValue);
            newEmployeePrimaryKey++;

            EmployeeIDBox.Text = newEmployeePrimaryKey.ToString();

            con.Close();

            // connect to database
            con.Open();

            cmd = new SqlCommand("INSERT INTO employees values(" + newEmployeePrimaryKey + "," +
            " '" + firstNameBox.Text + "'," +
            " '" + lastNameBox.Text + "', " +
            " " + DOBDD.Text + "," +
            " " + DOBMM.Text + "," +
            " " + DOBYYYY.Text + "," +
            " '" + contactNumberBox.Text + "'," +
            " '" + streetBox.Text + "'," +
            " '" + cityBox.Text + "'," +
            " '" + provinceBox.Text + "'," +
            " '" + postalCodeBox.Text + "'," +
            " '" + countryBox.Text + "'," +
            " '" + passwordBox.Text + "'," +
            " " + branchNumberBox.Text + ")", con);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Employee has been inserted");

            con.Close();

            firstNameBox.Clear();
            lastNameBox.Clear();
            DOBDD.Clear();
            contactNumberBox.Clear();
            streetBox.Clear();
            cityBox.Clear();
            provinceBox.Clear();
            postalCodeBox.Clear();
            countryBox.Clear();
            passwordBox.Clear();
            branchNumberBox.Clear();
            DOBMM.Clear();
            DOBYYYY.Clear();

            con.Open();

            // find max int in employee for primary key, then increment by 1
            cmd = new SqlCommand("SELECT MAX(employeeNum) FROM Employees", con);
            getValue = cmd.ExecuteScalar();

            newEmployeePrimaryKey = Convert.ToInt32(getValue);
            newEmployeePrimaryKey++;

            EmployeeIDBox.Text = newEmployeePrimaryKey.ToString();

            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {
            if (firstClickDD)
            {
                DOBDD.Text = string.Empty;
                DOBDD.ForeColor = Color.Black;
                firstClickDD = false;
            }
        }

        private void richTextBox23_TextChanged(object sender, EventArgs e)
        {
            if (firstClickMM)
            {
                DOBMM.Text = string.Empty;
                DOBMM.ForeColor = Color.Black;
                firstClickMM = false;
            }
        }

        private void richTextBox24_TextChanged(object sender, EventArgs e)
        {
            if (firstClickYYYY)
            {
                DOBYYYY.Text = string.Empty;
                DOBYYYY.ForeColor = Color.Black;
                firstClickYYYY = false;
            }
        }

        private void richTextBox5_TextChanged(object sender, EventArgs e)
        {
            if (firstClickConNum)
            {
                contactNumberBox.Text = string.Empty;
                contactNumberBox.ForeColor = Color.Black;
                firstClickConNum = false;
            }
        }

        private void richTextBox9_TextChanged(object sender, EventArgs e)
        {
            if (firstClickPostalCode)
            {
                postalCodeBox.Text = string.Empty;
                postalCodeBox.ForeColor = Color.Black;
                firstClickPostalCode = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
