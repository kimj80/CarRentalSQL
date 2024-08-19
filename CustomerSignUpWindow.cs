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
    public partial class CustomerSignUpWindow : Form
    {
        bool firstClickDD = true;
        bool firstClickMM = true;
        bool firstClickYYYY = true;
        bool firstClickConNum = true;
        bool firstClickPostalCode = true;

        SqlCommand cmd;

        public CustomerSignUpWindow()
        {
            InitializeComponent();

            this.Size = new Size(800, 650);

            // used to get new customerID as primary key
            // connect to database
            SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
            con.Open();

            SqlCommand cmd = new SqlCommand();

            // find max int in customer for primary key, then increment by 1
            cmd = new SqlCommand("SELECT MAX(cusid) FROM customers", con);
            var getValue = cmd.ExecuteScalar();

            int newCusPrimaryKey = Convert.ToInt32(getValue);
            newCusPrimaryKey++;

            customerIDBox.Text = newCusPrimaryKey.ToString();

            con.Close();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
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
            else if (string.IsNullOrEmpty(operatorIDBox.Text))
            {
                MessageBox.Show("Operator ID box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(contactNumberBox.Text))
            {
                MessageBox.Show("Contact Number box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(customerIDBox.Text))
            {
                MessageBox.Show("Customer ID box, empty, please contact customer service");
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
            else if (!int.TryParse(operatorIDBox.Text, out parsedValue))
            {
                MessageBox.Show("Operator ID is a number only field");
                return;
            }

            // connect to database
            SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
            con.Open();
            SqlCommand cmd = new SqlCommand();

            // insert customer into database
            cmd = new SqlCommand("INSERT INTO customers values(" + customerIDBox.Text + "," +
                " " + operatorIDBox.Text + ", " +
                " '" + firstNameBox.Text + "', " +
                " '" + lastNameBox.Text + "'," +
                " " + DOBDD.Text + "," +
                " " + DOBMM.Text + "," +
                " " + DOBYYYY.Text + "," +
                " '" + contactNumberBox.Text + "'," +
                " '" + streetBox.Text + "'," +
                " '" + cityBox.Text + "'," +
                " '" + provinceBox.Text + "'," +
                " '" + postalCodeBox.Text + "'," +
                " '" + countryBox.Text + "'," +
                " '" + passwordBox.Text + "')", con);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Customer sign up complete");

            con.Close();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            firstNameBox.Clear();
            lastNameBox.Clear();
            DOBDD.Clear();
            operatorIDBox.Clear();
            contactNumberBox.Clear();
            streetBox.Clear();
            cityBox.Clear();
            provinceBox.Clear();
            postalCodeBox.Clear();
            countryBox.Clear();
            customerIDBox.Clear();
            passwordBox.Clear();
            DOBMM.Clear();
            DOBYYYY.Clear();

            // used to get new customerID as primary key
            // connect to database
            SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
            con.Open();

            SqlCommand cmd = new SqlCommand();

            // find max int in customer for primary key, then increment by 1
            cmd = new SqlCommand("SELECT MAX(cusid) FROM customers", con);
            var getValue = cmd.ExecuteScalar();

            int newCusPrimaryKey = Convert.ToInt32(getValue);
            newCusPrimaryKey++;

            customerIDBox.Text = newCusPrimaryKey.ToString();

            con.Close();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DOBYYYY_TextChanged(object sender, EventArgs e)
        {
            if (firstClickYYYY)
            {
                DOBYYYY.Text = string.Empty;
                DOBYYYY.ForeColor = Color.Black;
                firstClickYYYY = false;
            }
        }

        private void DOBMM_TextChanged(object sender, EventArgs e)
        {
            if (firstClickMM)
            {
                DOBMM.Text = string.Empty;
                DOBMM.ForeColor = Color.Black;
                firstClickMM = false;
            }
        }

        private void DOBDD_TextChanged(object sender, EventArgs e)
        {
            if (firstClickDD)
            {
                DOBDD.Text = string.Empty;
                DOBDD.ForeColor = Color.Black;
                firstClickDD = false;
            }
        }

        private void contactNumberBox_TextChanged(object sender, EventArgs e)
        {
            if (firstClickConNum)
            {
                contactNumberBox.Text = string.Empty;
                contactNumberBox.ForeColor = Color.Black;
                firstClickConNum = false;
            }
        }

        private void postalCodeBox_TextChanged(object sender, EventArgs e)
        {
            if (firstClickPostalCode)
            {
                postalCodeBox.Text = string.Empty;
                postalCodeBox.ForeColor = Color.Black;
                firstClickPostalCode = false;
            }
        }
    }
}
