using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Cmpt291UI
{
    public partial class TransactionsReceipt : Form
    {
        SqlCommand cmd;

        public TransactionsReceipt()
        {
            InitializeComponent();

            this.Size = new Size(1650, 1750);

            // fill in customer info with cusid
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

            // fill in car info with carvin
            String query2 = "SELECT * FROM car WHERE carvin = '" + EmployeeLoginScreen.bookThisCarVIN + "'";
            sda = new SqlDataAdapter(query2, con);
            DataTable dtable2 = new DataTable();
            sda.Fill(dtable2);
            // vehicle info
            carVINBox.Text = EmployeeLoginScreen.bookThisCarVIN;

            // breaks here from receipt list cus side to transaction receipt
            carMakeBox.Text = dtable2.Rows[0]["brand"].ToString();
            carModelBox.Text = dtable2.Rows[0]["model"].ToString();
            carYearBox.Text = dtable2.Rows[0]["year"].ToString();
            carMileageBox.Text = dtable2.Rows[0]["mileage"].ToString();
            carColorBox.Text = dtable2.Rows[0]["color"].ToString();
            branchPickUpBox.Text = dtable2.Rows[0]["branchPickup"].ToString();

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

            employeeIDBox.Text = EmployeeLoginScreen.bookThisEmployeeID;
            transactionsIDBox.Text = EmployeeLoginScreen.bookThisTransactionID;
            customerIDBox.Text = EmployeeLoginScreen.bookThisCustomerID;

            // fill in customer info with cusid
            con.Open();
            String query3 = "SELECT * FROM rentaltransactions WHERE " +
                "transid = " + EmployeeLoginScreen.bookThisTransactionID + "";
            sda = new SqlDataAdapter(query3, con);
            DataTable dtable3 = new DataTable();
            sda.Fill(dtable3);

            branchPickUpBox.Text = dtable3.Rows[0]["branchNum"].ToString();
            branchDropOffBox.Text = dtable3.Rows[0]["branchDropOff"].ToString();

            // get the total number of days
            string totalDateFrom = EmployeeLoginScreen.bookThisDateFromYYYY + "/" + EmployeeLoginScreen.bookThisDateFromMM + "/" + EmployeeLoginScreen.bookThisDateFromDD;
            string totalDateTo = EmployeeLoginScreen.bookThisDateToYYYY + "/" + EmployeeLoginScreen.bookThisDateToMM + "/" + EmployeeLoginScreen.bookThisDateToDD;

            DateTime dt1 = DateTime.ParseExact(totalDateFrom, "yyyy/M/d", CultureInfo.InvariantCulture);
            DateTime dt2 = DateTime.ParseExact(totalDateTo, "yyyy/M/d", CultureInfo.InvariantCulture);

            int totalNumberOfDays = (dt2 - dt1).Days;

            // we will be giving customers 31 days when they rent a month
            totalDaysRentedBox.Text = totalNumberOfDays.ToString();

            int totalNumberOfMonths, totalNumberOfWeeks, totalMonthlyCost;


            String query4 = "SELECT dailycost, weeklycost, monthlycost FROM cartypes, car WHERE carvin = '" + EmployeeLoginScreen.bookThisCarVIN + "' AND " +
                "car.carTypeID = cartypes.carTypeID";
            sda = new SqlDataAdapter(query4, con);
            DataTable dtable4 = new DataTable();
            sda.Fill(dtable4);

            if (totalNumberOfDays >= 31)
            {
                totalNumberOfMonths = totalNumberOfDays / 31;
                totalNumberOfDays = totalNumberOfDays - (totalNumberOfMonths * 31);
                // calculate monthly portion
                var costMonthly = Convert.ToInt32(dtable4.Rows[0]["monthlycost"]);
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
            var costWeekly = Convert.ToInt32(dtable4.Rows[0]["weeklycost"]);
            int totalWeeklyCost = totalNumberOfWeeks * costWeekly;

            // calculate daily cost of days
            var costDaily = Convert.ToInt32(dtable4.Rows[0]["dailyCost"]);
            int totalDayCost = totalNumberOfDays * costDaily;

            //add them all up
            int totalBalance = totalMonthlyCost + totalWeeklyCost + totalDayCost;
            totalBalanceBox.Text = totalBalance.ToString();


        }



        private void ExitButton_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {

        }
    }
}
