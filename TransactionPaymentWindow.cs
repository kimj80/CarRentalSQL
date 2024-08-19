using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Cmpt291UI
{
    public partial class TransactionPaymentWindow : Form
    {
        SqlCommand cmd;
        public TransactionPaymentWindow()
        {
            InitializeComponent();
            
            this.Size = new Size(1650, 1750);

            SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
            String query = "SELECT * FROM customers WHERE cusID = " + EmployeeLoginScreen.bookThisCustomerID + "";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable dtable = new DataTable();
            sda.Fill(dtable);

            // customer info
            customerIDBox.Text = EmployeeLoginScreen.bookThisCustomerID;
            customerNameBox.Text = dtable.Rows[0]["firstname"].ToString();
            operatorIDBox.Text = dtable.Rows[0]["operatorID"].ToString();
            addressBox.Text = dtable.Rows[0]["street"].ToString();
            contactNumberBox.Text = dtable.Rows[0]["contactNum"].ToString();

            String query2 = "SELECT * FROM car WHERE carvin = '" + EmployeeLoginScreen.bookThisCarVIN + "'";
            sda = new SqlDataAdapter(query2, con);

            DataTable dtable2 = new DataTable();
            sda.Fill(dtable2);

            // vehicle info
            carVINBox.Text = EmployeeLoginScreen.bookThisCarVIN;
            carMakeBox.Text = dtable2.Rows[0]["brand"].ToString();
            carModelBox.Text = dtable2.Rows[0]["model"].ToString();
            carYearBox.Text = dtable2.Rows[0]["year"].ToString();
            carMileageBox.Text = dtable2.Rows[0]["mileage"].ToString();
            carColorBox.Text = dtable2.Rows[0]["color"].ToString();
            branchPickUpBox.Text = dtable2.Rows[0]["branchPickup"].ToString();
            branchDropOffBox.Text = dtable2.Rows[0]["branchPickup"].ToString();

            // rental info
            dateFromDDBox.Text = EmployeeLoginScreen.bookThisDateFromDD;
            dateFromMMBox.Text = EmployeeLoginScreen.bookThisDateFromMM;
            dateFromYYYYBox.Text = EmployeeLoginScreen.bookThisDateFromYYYY;
            dateToDDBox.Text = EmployeeLoginScreen.bookThisDateToDD;
            dateToMMBox.Text = EmployeeLoginScreen.bookThisDateToMM;
            dateToYYYYBox.Text = EmployeeLoginScreen.bookThisDateToYYYY;

            // payment info
            dailyCostBox.Text = EmployeeLoginScreen.bookThisCustomerDailyCost;
            weeklyCostBox.Text = EmployeeLoginScreen.bookThisCustomerWeeklyCost;
            monthlyCostBox.Text = EmployeeLoginScreen.bookThisCustomerMonthlyCost;

            // get the total number of days
            string totalDateFrom = EmployeeLoginScreen.bookThisDateFromYYYY + "/" + EmployeeLoginScreen.bookThisDateFromMM + "/" + EmployeeLoginScreen.bookThisDateFromDD;
            string totalDateTo = EmployeeLoginScreen.bookThisDateToYYYY + "/" + EmployeeLoginScreen.bookThisDateToMM + "/" + EmployeeLoginScreen.bookThisDateToDD;

            DateTime dt1 = DateTime.ParseExact(totalDateFrom, "yyyy/M/d", CultureInfo.InvariantCulture);
            DateTime dt2 = DateTime.ParseExact(totalDateTo, "yyyy/M/d", CultureInfo.InvariantCulture);

            int totalNumberOfDays = (dt2 - dt1).Days;

            // we will be giving customers 31 days when they rent a month
            totalDaysRentedBox.Text = totalNumberOfDays.ToString();

            int totalNumberOfMonths, totalNumberOfWeeks, totalMonthlyCost;

            con = new SqlConnection(EmployeeLoginScreen.databasePath);
            String query3 = "SELECT dailycost, weeklycost, monthlycost FROM cartypes, car WHERE carvin = '" + EmployeeLoginScreen.bookThisCarVIN + "' AND " +
                "car.carTypeID = cartypes.carTypeID";
            sda = new SqlDataAdapter(query3, con);
            DataTable dtable3 = new DataTable();
            sda.Fill(dtable3);

            if (totalNumberOfDays >= 31)
            {
                totalNumberOfMonths = totalNumberOfDays / 31;
                totalNumberOfDays = totalNumberOfDays - (totalNumberOfMonths * 31);
                // calculate monthly portion
                var costMonthly = Convert.ToInt32(dtable3.Rows[0]["monthlycost"]);
                totalMonthlyCost = totalNumberOfMonths * costMonthly;
            }
            else
            {
                totalNumberOfMonths = 0;
                totalMonthlyCost = 0;
            }

            if (totalNumberOfDays >= 7)
            {
                totalNumberOfWeeks = totalNumberOfDays / 7;
                totalNumberOfDays = totalNumberOfDays - (totalNumberOfWeeks * 7);
            }
            else
            {
                totalNumberOfWeeks = 0;
            }
            // calculate the weekly portion
            var costWeekly = Convert.ToInt32(dtable3.Rows[0]["weeklycost"]);
            int totalWeeklyCost = totalNumberOfWeeks * costWeekly;

            // calculate daily cost of days
            var costDaily = Convert.ToInt32(dtable3.Rows[0]["dailyCost"]);
            int totalDayCost = totalNumberOfDays * costDaily;

            //add them all up
            int totalBalance = totalMonthlyCost + totalWeeklyCost + totalDayCost;
            totalBalanceBox.Text = totalBalance.ToString();

            employeeIDBox.Text = EmployeeLoginScreen.bookThisEmployeeID;

            con.Open();

            SqlCommand cmd = new SqlCommand();

            // find max int for transid for primary key, then increment by 1
            cmd = new SqlCommand("SELECT MAX(transid) FROM rentaltransactions", con);
            var getValue = cmd.ExecuteScalar();

            int newTransIDPrimaryKey = Convert.ToInt32(getValue);
            newTransIDPrimaryKey++;

            transactionsIDBox.Text = newTransIDPrimaryKey.ToString();

            con.Close();
        }

        private void TransactionPaymentWindow_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // check if the input is an int
            int parsedValue;

            // check if texboxes are all filled and not empty
            if (string.IsNullOrEmpty(customerNameBox.Text))
            {
                MessageBox.Show("Customer Name box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(operatorIDBox.Text))
            {
                // also check box input is int
                if (!int.TryParse(operatorIDBox.Text, out parsedValue))
                {
                    MessageBox.Show("Operator ID is a number only field");
                    return;
                }
                MessageBox.Show("Operator ID box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(addressBox.Text))
            {
                MessageBox.Show("Address box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(contactNumberBox.Text))
            {
                MessageBox.Show("Contact Number box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(carVINBox.Text))
            {
                MessageBox.Show("Car VIN box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(carMakeBox.Text))
            {
                MessageBox.Show("Car Make box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(carModelBox.Text))
            {
                MessageBox.Show("Car Model box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(carYearBox.Text))
            {
                // also check box input is int
                if (!int.TryParse(carYearBox.Text, out parsedValue))
                {
                    MessageBox.Show("Car year is a number only field");
                    return;
                }
                MessageBox.Show("Car Year box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(carMileageBox.Text))
            {
                // also check box input is int
                if (!int.TryParse(carMileageBox.Text, out parsedValue))
                {
                    MessageBox.Show("Car Mileage is a number only field");
                    return;
                }
                MessageBox.Show("Car Mileage box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(carColorBox.Text))
            {
                MessageBox.Show("Car Color box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(dateFromDDBox.Text))
            {
                // also check box input is int
                if (!int.TryParse(dateFromDDBox.Text, out parsedValue))
                {
                    MessageBox.Show("Car Date-From Day is a number only field");
                    return;
                }
                MessageBox.Show("Car Date-From Day box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(dateFromMMBox.Text))
            {
                // also check box input is int
                if (!int.TryParse(dateFromMMBox.Text, out parsedValue))
                {
                    MessageBox.Show("Car Date-From Month is a number only field");
                    return;
                }
                MessageBox.Show("Car Date-From Month box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(dateFromYYYYBox.Text))
            {
                // also check box input is int
                if (!int.TryParse(dateFromYYYYBox.Text, out parsedValue))
                {
                    MessageBox.Show("Car Date-From Year is a number only field");
                    return;
                }
                MessageBox.Show("Car Date-From Year box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(dateToDDBox.Text))
            {
                // also check box input is int
                if (!int.TryParse(dateToDDBox.Text, out parsedValue))
                {
                    MessageBox.Show("Car Date-To Day is a number only field");
                    return;
                }
                MessageBox.Show("Car Date-To Day box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(dateToMMBox.Text))
            {
                // also check box input is int
                if (!int.TryParse(dateToMMBox.Text, out parsedValue))
                {
                    MessageBox.Show("Car Date-To Month is a number only field");
                    return;
                }
                MessageBox.Show("Car Date-To Month box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(dateToYYYYBox.Text))
            {
                // also check box input is int
                if (!int.TryParse(dateToYYYYBox.Text, out parsedValue))
                {
                    MessageBox.Show("Car Date-To Year is a number only field");
                    return;
                }
                MessageBox.Show("Car Date-To Year box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(totalDaysRentedBox.Text))
            {
                // also check box input is int
                if (!int.TryParse(totalDaysRentedBox.Text, out parsedValue))
                {
                    MessageBox.Show("Car Total Days Rented is a number only field");
                    return;
                }
                MessageBox.Show("Car Total Days Rented box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(dailyCostBox.Text))
            {
                // also check box input is int
                if (!int.TryParse(dailyCostBox.Text, out parsedValue))
                {
                    MessageBox.Show("Daily Cost is a number only field");
                    return;
                }
                MessageBox.Show("Daily Cost box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(weeklyCostBox.Text))
            {
                // also check box input is int
                if (!int.TryParse(weeklyCostBox.Text, out parsedValue))
                {
                    MessageBox.Show("Weekly Cost is a number only field");
                    return;
                }
                MessageBox.Show("Weekly Cost box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(monthlyCostBox.Text))
            {
                // also check box input is int
                if (!int.TryParse(monthlyCostBox.Text, out parsedValue))
                {
                    MessageBox.Show("Monthly Cost is a number only field");
                    return;
                }
                MessageBox.Show("Monthly Cost box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(totalBalanceBox.Text))
            {
                // also check box input is int
                if (!int.TryParse(totalBalanceBox.Text, out parsedValue))
                {
                    MessageBox.Show("Total Balance Cost is a number only field");
                    return;
                }
                MessageBox.Show("Total Balance Cost box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(employeeIDBox.Text))
            {
                // also check box input is int
                if (!int.TryParse(employeeIDBox.Text, out parsedValue))
                {
                    MessageBox.Show("Employee ID is a number only field");
                    return;
                }
                MessageBox.Show("Employee ID box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(customerIDBox.Text))
            {
                // also check box input is int
                if (!int.TryParse(customerIDBox.Text, out parsedValue))
                {
                    MessageBox.Show("Customer ID is a number only field");
                    return;
                }
                MessageBox.Show("Customer ID box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(transactionsIDBox.Text))
            {
                // also check box input is int
                if (!int.TryParse(transactionsIDBox.Text, out parsedValue))
                {
                    MessageBox.Show("Transactions ID is a number only field");
                    return;
                }
                MessageBox.Show("Transactions ID box, empty");
                return;
            }
            else if (string.IsNullOrEmpty(branchPickUpBox.Text))
            {
                // also check box input is int
                if (!int.TryParse(branchPickUpBox.Text, out parsedValue))
                {
                    MessageBox.Show("Branch Pick Up is a number only field");
                    return;
                }
                MessageBox.Show("Branch Pick Up, empty");
                return;
            }
            else if (string.IsNullOrEmpty(branchDropOffBox.Text))
            {
                // also check box input is int
                if (!int.TryParse(branchDropOffBox.Text, out parsedValue))
                {
                    MessageBox.Show("Branch Drop Off is a number only field");
                    return;
                }
                MessageBox.Show("Branch Drop Off box, empty");
                return;
            }

            SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            // INSERT INTO RentalTransactions(transID, rentalCost, rentedFromDay, rentedFromMonth, rentedFromYear,
            // returnToDay, returnToMonth, returnToYear, employeeNum, cusID, carVIN, branchNum, branchDropoff)
            cmd = new SqlCommand("INSERT INTO RentalTransactions values(" + transactionsIDBox.Text + ", " +
            " " + totalBalanceBox.Text + ", " +
            " " + dateFromDDBox.Text + "," +
            " " + dateFromMMBox.Text + "," +
            " " + dateFromYYYYBox.Text + "," +
            " " + dateToDDBox.Text + "," +
            " " + dateToMMBox.Text + "," +
            " " + dateToYYYYBox.Text + "," +
            " " + employeeIDBox.Text + "," +
            " " + customerIDBox.Text + "," +
            " '" + carVINBox.Text + "'," +
            " " + branchPickUpBox.Text + "," +
            " " + branchDropOffBox.Text + ")", con);
            cmd.ExecuteNonQuery();

            EmployeeLoginScreen.bookThisTransactionID = transactionsIDBox.Text;

            MessageBox.Show("Transaction has been inserted");

            TransactionsReceipt transactionReceiptForm = new TransactionsReceipt();
            transactionReceiptForm.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void weeklyCostBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
