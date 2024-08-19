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
    public partial class CustomerWindowMainBook : Form
    {
        SqlCommand cmd;

        public CustomerWindowMainBook()
        {
            InitializeComponent();

            WindowState = FormWindowState.Maximized;

            bookEmployeeIDBox.Text = EmployeeLoginScreen.employeeLoggedIn;

            BookDateFromYYYY.Text = DateTime.Now.ToString("yyyy");
            BookDateFromMM.Text = DateTime.Now.ToString("MM");
            BookDateFromDD.Text = DateTime.Now.ToString("dd");

            SearchDateFromYYYY.Text = DateTime.Now.ToString("yyyy");
            SearchDateFromMM.Text = DateTime.Now.ToString("MM");
            SearchDateFromDD.Text = DateTime.Now.ToString("dd");

            // input the max date renting to
            SearchDateToYYYY.Text = "2035";
            SearchDateToMM.Text = "1";
            SearchDateToDD.Text = "1";

            // connect to database
            SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
            con.Open();

            // search through database
            string query = "SELECT CarVIN, Brand, Model, Year, Color, Mileage, CarType, CarEngine, CarTrim, DailyCost, WeeklyCost, MonthlyCost, BranchPickup FROM car, cartypes WHERE car.CarTypeID = CarTypes.carTypeID";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);

            // insert data from extracted sql
            DataTable cars = new DataTable();
            adapter.Fill(cars);

            dataGridView1.DataSource = cars;

            con.Dispose();
            con.Close();

            // customer branch for pickup will need to be auto filled in eventually depending on their location
        }

        private void CustomerWindowMainBook_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchBranchBox.Clear();
            SearchCarTypeBox.Clear();
            SearchCarEngineBox.Clear();
            SearchCarTrimBox.Clear();
            searchCarYearBox.Clear();
            searchDailyCostBox.Clear();
            SearchWeeklyCostBox.Clear();
            searchMonthlyCostBox.Clear();
            SearchDateFromDD.Clear();
            SearchDateFromMM.Clear();
            SearchDateFromYYYY.Clear();
            SearchDateToDD.Clear();
            SearchDateToMM.Clear();
            SearchDateToYYYY.Clear();

            SearchDateFromYYYY.Text = DateTime.Now.ToString("yyyy");
            SearchDateFromMM.Text = DateTime.Now.ToString("MM");
            SearchDateFromDD.Text = DateTime.Now.ToString("dd");

            // input the max date renting to
            SearchDateToYYYY.Text = "2035";
            SearchDateToMM.Text = "1";
            SearchDateToDD.Text = "1";

            // fill in branch where customer resides/closest too

            SearchBranchBox.Focus();
        }

        private void ClearBottomButton_Click(object sender, EventArgs e)
        {
            bookCarVINBox.Clear();
            bookEmployeeIDBox.Clear();
            BookDateFromDD.Clear();
            BookDateFromMM.Clear();
            BookDateFromYYYY.Clear();
            BookDateToDD.Clear();
            BookDateToMM.Clear();
            BookDateToYYYY.Clear();

            bookEmployeeIDBox.Text = EmployeeLoginScreen.employeeLoggedIn;

            BookDateFromYYYY.Text = DateTime.Now.ToString("yyyy");
            BookDateFromMM.Text = DateTime.Now.ToString("MM");
            BookDateFromDD.Text = DateTime.Now.ToString("dd");

            bookCarVINBox.Focus();
        }

        private void SearchTopButton_Click(object sender, EventArgs e)
        {
            // check if the input is an int
            int parsedValue;

            // this used for where statement if search bar is used
            string query = "SELECT distinct(car.CarVIN), Brand, Model, Year, Color, Mileage, CarType, CarEngine, CarTrim, DailyCost, WeeklyCost, MonthlyCost, BranchPickup FROM car, cartypes, " +
                "(SELECT distinct(car.CarVIN) from car EXCEPT (SELECT distinct(RentalTransactions.CarVIN) FROM RentalTransactions WHERE ";
            string queryWhere = "WHERE car.CarTypeID = CarTypes.carTypeID AND car.carVIN = rentalTableCarVIN.carVIN AND ";

            bool lastSearchBar = false;

            if (!string.IsNullOrEmpty(SearchBranchBox.Text))
            {
                if (!int.TryParse(SearchBranchBox.Text, out parsedValue))
                {
                    MessageBox.Show("Branch is a number only field");
                    return;
                }
                queryWhere = queryWhere + "branchPickup = " + SearchBranchBox.Text + " AND ";
            }
            if (!string.IsNullOrEmpty(SearchCarTypeBox.Text))
            {
                queryWhere = queryWhere + "CarTypes.carType = '" + SearchCarTypeBox.Text + "' AND ";
            }
            if (!string.IsNullOrEmpty(SearchCarEngineBox.Text))
            {
                queryWhere = queryWhere + "carEngine = '" + SearchCarEngineBox.Text + "' AND ";
            }
            if (!string.IsNullOrEmpty(SearchCarTrimBox.Text))
            {
                queryWhere = queryWhere + "carTrim = '" + SearchCarTrimBox.Text + "' AND ";
            }
            if (!string.IsNullOrEmpty(searchCarYearBox.Text))
            {
                if (!int.TryParse(searchCarYearBox.Text, out parsedValue))
                {
                    MessageBox.Show("Year is a number only field");
                    return;
                }
                queryWhere = queryWhere + "year >= " + searchCarYearBox.Text + " AND ";
            }
            if (!string.IsNullOrEmpty(searchDailyCostBox.Text))
            {
                if (!int.TryParse(searchDailyCostBox.Text, out parsedValue))
                {
                    MessageBox.Show("Daily Cost is a number only field");
                    return;
                }
                queryWhere = queryWhere + "dailyCost <= " + searchDailyCostBox.Text + " AND ";
            }
            if (!string.IsNullOrEmpty(SearchWeeklyCostBox.Text))
            {
                if (!int.TryParse(SearchWeeklyCostBox.Text, out parsedValue))
                {
                    MessageBox.Show("Weekly Cost is a number only field");
                    return;
                }
                queryWhere = queryWhere + "weeklyCost <= " + SearchWeeklyCostBox.Text + " AND ";
            }
            if (!string.IsNullOrEmpty(searchMonthlyCostBox.Text))
            {
                if (!int.TryParse(searchMonthlyCostBox.Text, out parsedValue))
                {
                    MessageBox.Show("Monthly Cost is a number only field");
                    return;
                }
                lastSearchBar = true;
                queryWhere = queryWhere + "monthlyCost <= " + searchMonthlyCostBox.Text + "";
            }

            //RENTALTRANSACTIONS TABLE IS NEEDED START
            //ensure all 3 From-date blocks are filled in and assign
            if (!string.IsNullOrEmpty(SearchDateFromYYYY.Text))
            {
                if (!int.TryParse(SearchDateFromYYYY.Text, out parsedValue))
                {
                    MessageBox.Show("Date-From Year is a number only field");
                    return;
                }
                if (!string.IsNullOrEmpty(SearchDateFromMM.Text))
                {
                    if (!int.TryParse(SearchDateFromMM.Text, out parsedValue))
                    {
                        MessageBox.Show("Date-From Month is a number only field");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Error: Date-From Boxes must be all filled in");
                    return;
                }

                if (!string.IsNullOrEmpty(SearchDateFromDD.Text))
                {
                    if (!int.TryParse(SearchDateFromDD.Text, out parsedValue))
                    {
                        MessageBox.Show("Date-From Day is a number only field");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Error: Date-From Boxes must be all filled in");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Else Statement in searchDateFrom: todays date");
                // input todays date
                SearchDateFromYYYY.Text = DateTime.Now.ToString("yyyy");
                SearchDateFromMM.Text = DateTime.Now.ToString("MM");
                SearchDateFromDD.Text = DateTime.Now.ToString("dd");
            }
            if (!string.IsNullOrEmpty(SearchDateToYYYY.Text))
            {
                if (!int.TryParse(SearchDateToYYYY.Text, out parsedValue))
                {
                    MessageBox.Show("Date-To Year is a number only field");
                    return;
                }
                if (!string.IsNullOrEmpty(SearchDateToMM.Text))
                {
                    if (!int.TryParse(SearchDateToMM.Text, out parsedValue))
                    {
                        MessageBox.Show("Date-To Month is a number only field");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Error: Date-To Boxes must be all filled in");
                    return;
                }
                if (!string.IsNullOrEmpty(SearchDateToDD.Text))
                {
                    if (!int.TryParse(SearchDateToDD.Text, out parsedValue))
                    {
                        MessageBox.Show("Date-To Day is a number only field");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Error: Date-To Boxes must be all filled in");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Else Statement in searchDateTo: 2035-1-1");
                // input the max date renting to, only able to rent out 10 years in advance
                SearchDateToYYYY.Text = "2035";
                SearchDateToMM.Text = "1";
                SearchDateToDD.Text = "1";
            }
            //RENTALTRANSACTIONS TABLE IS NEEDED END

            // very messy code, was in a rush, can easily condense and refactor
            // CAST(CAST(RentedFromYear as varchar(4)) + ' - ' + CAST(RentedFromMonth as varchar(2)) + ' - ' + CAST(RentedFromDay as varchar(2))AS DATETIME)
            String carDateRentFromTableInfo = "CAST(CAST(RentedFromYear as varchar(4)) + ' - ' + CAST(RentedFromMonth as varchar(2)) + ' - ' + CAST(RentedFromDay as varchar(2))AS DATETIME) >= '";

            // we will convert the numbers in the boxes back into a string
            String userSearchDateFrom = SearchDateFromYYYY.Text + " - " + SearchDateFromMM.Text + " - " + SearchDateFromDD.Text;
            query = query + carDateRentFromTableInfo + userSearchDateFrom + "' AND ";

            // get car rent-to date, then compare vs list of cars where cars rent-from
            String carDateRentToTableInfo = "CAST(CAST(ReturnToYear as varchar(4)) + ' - ' + CAST(ReturnToMonth as varchar(2)) + ' - ' + CAST(ReturnToDay as varchar(2))AS DATETIME) <= '";

            String userSearchDateTo = SearchDateToYYYY.Text + " - " + SearchDateToMM.Text + " - " + SearchDateToDD.Text;

            query = query + carDateRentToTableInfo + userSearchDateTo + "')) as rentalTableCarVIN " + queryWhere;

            // connect to database
            SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
            con.Open();
            DataTable cars = new DataTable();

            // last search bar is used, does not include ' AND '
            if (lastSearchBar == true)
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.Fill(cars);
            }
            // includes ' AND ', we must remove last 5 chars
            else
            {
                int stringLength = query.Length;
                string queryWhereSubString = query.Substring(0, stringLength - 5);
                SqlDataAdapter adapter = new SqlDataAdapter(queryWhereSubString, con);
                adapter.Fill(cars);
            }

            dataGridView1.DataSource = cars;

            con.Dispose();
            con.Close();
        }

        private void BookBottomButton_Click(object sender, EventArgs e)
        {
            // check if the input is an int
            int parsedValue;

            if (string.IsNullOrEmpty(bookCarVINBox.Text))
            {
                MessageBox.Show("Car VIN box, empty");
                return;
            }
            if (string.IsNullOrEmpty(bookEmployeeIDBox.Text))
            {
                MessageBox.Show("Employee ID box, empty");
                return;
            }
            if (string.IsNullOrEmpty(BookDateFromDD.Text))
            {
                MessageBox.Show("Book Date-From Day box, empty");
                return;
            }
            if (string.IsNullOrEmpty(BookDateFromMM.Text))
            {
                MessageBox.Show("Book Date-From Month box, empty");
                return;
            }
            if (string.IsNullOrEmpty(BookDateFromYYYY.Text))
            {
                MessageBox.Show("Book Date-From Year box, empty");
                return;
            }
            if (string.IsNullOrEmpty(BookDateToDD.Text))
            {
                MessageBox.Show("Book Date-To Day  box, empty");
                return;
            }
            if (string.IsNullOrEmpty(BookDateToMM.Text))
            {
                MessageBox.Show("Book Date-To Month box, empty");
                return;
            }
            if (string.IsNullOrEmpty(BookDateToYYYY.Text))
            {
                MessageBox.Show("Book Date-To Year box, empty");
                return;
            }

            // check if boxes are int
            if (!int.TryParse(bookEmployeeIDBox.Text, out parsedValue))
            {
                MessageBox.Show("Employee ID is a number only field");
                return;
            }
            if (!int.TryParse(BookDateFromDD.Text, out parsedValue))
            {
                MessageBox.Show("Book Date-From Day is a number only field");
                return;
            }
            if (!int.TryParse(BookDateFromMM.Text, out parsedValue))
            {
                MessageBox.Show("Book Date-From Month is a number only field");
                return;
            }
            if (!int.TryParse(BookDateFromYYYY.Text, out parsedValue))
            {
                MessageBox.Show("Book Date-From Year is a number only field");
                return;
            }
            if (!int.TryParse(BookDateToDD.Text, out parsedValue))
            {
                MessageBox.Show("Book Date-To Day is a number only field");
                return;
            }
            if (!int.TryParse(BookDateToMM.Text, out parsedValue))
            {
                MessageBox.Show("Book Date-To Month is a number only field");
                return;
            }
            if (!int.TryParse(BookDateToYYYY.Text, out parsedValue))
            {
                MessageBox.Show("Book Date-To Year is a number only field");
                return;
            }

            // check if carvin exists
            SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
            String query = "SELECT * FROM car WHERE carvin = '" + bookCarVINBox.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dtable = new DataTable();
            sda.Fill(dtable);

            if (dtable.Rows.Count > 0)
            {
                // check if car is available from rentaltransactions
                String query2 = "SELECT * FROM car, cartypes WHERE carvin = '" + bookCarVINBox.Text + "' AND car.carTypeID = cartypes.carTypeID";
                SqlDataAdapter sda2 = new SqlDataAdapter(query2, con);
                DataTable dtable2 = new DataTable();
                sda2.Fill(dtable2);

                EmployeeLoginScreen.bookThisCustomerDailyCost = dtable2.Rows[0]["dailyCost"].ToString();
                EmployeeLoginScreen.bookThisCustomerWeeklyCost = dtable2.Rows[0]["weeklyCost"].ToString();
                EmployeeLoginScreen.bookThisCustomerMonthlyCost = dtable2.Rows[0]["monthlyCost"].ToString();




                // check if car is available by date, use rental tranctions



                // assign the values from the textbox to the global variable to carry over
                EmployeeLoginScreen.bookThisCarVIN = bookCarVINBox.Text;
                EmployeeLoginScreen.bookThisEmployeeID = bookEmployeeIDBox.Text;
                EmployeeLoginScreen.bookThisDateFromDD = BookDateFromDD.Text;
                EmployeeLoginScreen.bookThisDateFromMM = BookDateFromMM.Text;
                EmployeeLoginScreen.bookThisDateFromYYYY = BookDateFromYYYY.Text;
                EmployeeLoginScreen.bookThisDateToDD = BookDateToDD.Text;
                EmployeeLoginScreen.bookThisDateToMM = BookDateToMM.Text;
                EmployeeLoginScreen.bookThisDateToYYYY = BookDateToYYYY.Text;

                // get customer information
                String query3 = "SELECT cusid FROM customers WHERE cusid = " + EmployeeLoginScreen.bookThisCustomerID + "";
                SqlDataAdapter sda3 = new SqlDataAdapter(query3, con);
                DataTable dtable3 = new DataTable();
                sda3.Fill(dtable3);

                con.Dispose();
                con.Close();

                TransactionPaymentWindow transactionPaymentWindowForm = new TransactionPaymentWindow();
                transactionPaymentWindowForm.Show();

            }
            else
            {
                con.Dispose();
                con.Close();

                MessageBox.Show("Invalid CarVIN");
            }

        }

        private void receiptListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReceiptList receiptListForm = new ReceiptList();
            receiptListForm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchBranchBox.Clear();
            SearchCarTypeBox.Clear();
            SearchCarEngineBox.Clear();
            SearchCarTrimBox.Clear();
            searchCarYearBox.Clear();
            searchDailyCostBox.Clear();
            SearchWeeklyCostBox.Clear();
            searchMonthlyCostBox.Clear();
            SearchDateFromDD.Clear();
            SearchDateFromMM.Clear();
            SearchDateFromYYYY.Clear();
            SearchDateToDD.Clear();
            SearchDateToMM.Clear();
            SearchDateToYYYY.Clear();

            SearchDateFromYYYY.Text = DateTime.Now.ToString("yyyy");
            SearchDateFromMM.Text = DateTime.Now.ToString("MM");
            SearchDateFromDD.Text = DateTime.Now.ToString("dd");

            // input the max date renting to
            SearchDateToYYYY.Text = "2035";
            SearchDateToMM.Text = "1";
            SearchDateToDD.Text = "1";

            bookCarVINBox.Clear();
            bookEmployeeIDBox.Clear();
            BookDateFromDD.Clear();
            BookDateFromMM.Clear();
            BookDateFromYYYY.Clear();
            BookDateToDD.Clear();
            BookDateToMM.Clear();
            BookDateToYYYY.Clear();

            bookEmployeeIDBox.Text = EmployeeLoginScreen.employeeLoggedIn;

            BookDateFromYYYY.Text = DateTime.Now.ToString("yyyy");
            BookDateFromMM.Text = DateTime.Now.ToString("MM");
            BookDateFromDD.Text = DateTime.Now.ToString("dd");

            // connect to database
            SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
            con.Open();

            // search through database
            string query = "SELECT CarVIN, Brand, Model, Year, Color, Mileage, CarType, CarEngine, CarTrim, DailyCost, WeeklyCost, MonthlyCost, BranchPickup FROM car, cartypes WHERE car.CarTypeID = CarTypes.carTypeID";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);

            // insert data from extracted sql
            DataTable cars = new DataTable();
            adapter.Fill(cars);

            dataGridView1.DataSource = cars;

            con.Dispose();
            con.Close();
        }
    }
}
