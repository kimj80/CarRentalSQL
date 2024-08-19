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
    public partial class EmployeeMainWindowBook : Form
    {
        SqlCommand cmd;

        // get the string from form1
        public static string carVINcarry, dateFromCarry, dateToCarry;
        public EmployeeMainWindowBook()
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

            SearchDateToYYYY.Text = "2035";
            SearchDateToMM.Text = "1";
            SearchDateToDD.Text = "1";

            // connect to database
            SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
            con.Open();

            string query2 = "SELECT * FROM employees WHERE employeenum = " + EmployeeLoginScreen.employeeLoggedIn + "";
            SqlDataAdapter adapter = new SqlDataAdapter(query2, con);
            DataTable dtable = new DataTable();
            adapter.Fill(dtable);
            SearchBranchBox.Text = dtable.Rows[0]["workAtBranchNum"].ToString();

            // search through database
            string query = "SELECT CarVIN, Brand, Model, Year, Color, Mileage, CarType, CarEngine, CarTrim, DailyCost, WeeklyCost, MonthlyCost, BranchPickup FROM car, cartypes WHERE car.CarTypeID = CarTypes.carTypeID AND car.branchpickup = '" + SearchBranchBox.Text + "'";
            adapter = new SqlDataAdapter(query, con);

            // insert data from extracted sql
            DataTable cars = new DataTable();
            adapter.Fill(cars);

            dataGridView1.DataSource = cars;


            
            con.Dispose();
            con.Close();
        }

        private void carsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookDateFromYYYY.Text = DateTime.Now.ToString("yyyy");
            BookDateFromMM.Text = DateTime.Now.ToString("MM");
            BookDateFromDD.Text = DateTime.Now.ToString("dd");

            SearchDateFromYYYY.Text = DateTime.Now.ToString("yyyy");
            SearchDateFromMM.Text = DateTime.Now.ToString("MM");
            SearchDateFromDD.Text = DateTime.Now.ToString("dd");

            SearchDateToYYYY.Text = "2035";
            SearchDateToMM.Text = "1";
            SearchDateToDD.Text = "1";

            // connect to database
            SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
            con.Open();

            string query2 = "SELECT * FROM employees WHERE employeenum = " + EmployeeLoginScreen.employeeLoggedIn + "";
            SqlDataAdapter adapter = new SqlDataAdapter(query2, con);
            DataTable dtable = new DataTable();
            adapter.Fill(dtable);
            SearchBranchBox.Text = dtable.Rows[0]["workAtBranchNum"].ToString();

            // search through database
            string query = "SELECT CarVIN, Brand, Model, Year, Color, Mileage, CarType, CarEngine, CarTrim, DailyCost, WeeklyCost, MonthlyCost, BranchPickup FROM car, cartypes WHERE car.CarTypeID = CarTypes.carTypeID AND car.branchpickup = '" + SearchBranchBox.Text + "'";
            adapter = new SqlDataAdapter(query, con);

            // insert data from extracted sql
            DataTable cars = new DataTable();
            adapter.Fill(cars);

            dataGridView1.DataSource = cars;



            con.Dispose();
            con.Close();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookDateFromYYYY.Text = DateTime.Now.ToString("yyyy");
            BookDateFromMM.Text = DateTime.Now.ToString("MM");
            BookDateFromDD.Text = DateTime.Now.ToString("dd");

            SearchDateFromYYYY.Text = DateTime.Now.ToString("yyyy");
            SearchDateFromMM.Text = DateTime.Now.ToString("MM");
            SearchDateFromDD.Text = DateTime.Now.ToString("dd");

            SearchDateToYYYY.Text = "2035";
            SearchDateToMM.Text = "1";
            SearchDateToDD.Text = "1";

            // connect to database
            SqlConnection con = new SqlConnection(EmployeeLoginScreen.databasePath);
            con.Open();

            string query2 = "SELECT * FROM employees WHERE employeenum = " + EmployeeLoginScreen.employeeLoggedIn + "";
            SqlDataAdapter adapter = new SqlDataAdapter(query2, con);
            DataTable dtable = new DataTable();
            adapter.Fill(dtable);
            SearchBranchBox.Text = dtable.Rows[0]["workAtBranchNum"].ToString();

            // search through database
            string query = "SELECT CarVIN, Brand, Model, Year, Color, Mileage, CarType, CarEngine, CarTrim, DailyCost, WeeklyCost, MonthlyCost, BranchPickup FROM car, cartypes WHERE car.CarTypeID = CarTypes.carTypeID AND car.branchpickup = '" + SearchBranchBox.Text + "'";
            adapter = new SqlDataAdapter(query, con);

            // insert data from extracted sql
            DataTable cars = new DataTable();
            adapter.Fill(cars);

            dataGridView1.DataSource = cars;



            con.Dispose();
            con.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EmployeeWindow_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void carsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddRemoveVehicle addVehicleForm = new AddRemoveVehicle();
            addVehicleForm.Show();
            this.Close();
        }

        private void customersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddRemoveCustomer addCustomerForm = new AddRemoveCustomer();
            addCustomerForm.Show();
            this.Close();
        }

        private void employeesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddRemoveEmployee addRemoveEmployeeForm = new AddRemoveEmployee();
            addRemoveEmployeeForm.Show();
            this.Close();
        }

        private void SelectBottomButton_Click(object sender, EventArgs e)
        {
            // check if car is available at the indicated time
            // save car vin
            // open new customer window to search for customer info, or add new customer info
            // check to see what branch the car is in and where the customer wants to pick it up from
            
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
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

            SearchDateToYYYY.Text = "2035";
            SearchDateToMM.Text = "1";
            SearchDateToDD.Text = "1";

            // fill in branch where employee resides/works at

            SearchBranchBox.Focus();
        }

        private void ClearBottomButton_Click_1(object sender, EventArgs e)
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

        private void SelectBottomButton_Click_1(object sender, EventArgs e)
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
                String query2 = "SELECT * FROM car, cartypes WHERE carvin = '" + bookCarVINBox.Text + "' AND " +
                    "car.carTypeID = cartypes.carTypeID";
                sda = new SqlDataAdapter(query2, con);
                DataTable dtable2 = new DataTable();
                sda.Fill(dtable2);

                EmployeeLoginScreen.bookThisCustomerDailyCost = dtable2.Rows[0]["dailyCost"].ToString();
                EmployeeLoginScreen.bookThisCustomerWeeklyCost = dtable2.Rows[0]["weeklyCost"].ToString();
                EmployeeLoginScreen.bookThisCustomerMonthlyCost = dtable2.Rows[0]["monthlyCost"].ToString();

                con.Dispose();
                con.Close();

                // lets book the car
                // assign the values from the textbox to the global variable to carry over
                EmployeeLoginScreen.bookThisCarVIN = bookCarVINBox.Text;
                EmployeeLoginScreen.bookThisEmployeeID = bookEmployeeIDBox.Text;
                EmployeeLoginScreen.bookThisDateFromDD = BookDateFromDD.Text;
                EmployeeLoginScreen.bookThisDateFromMM = BookDateFromMM.Text;
                EmployeeLoginScreen.bookThisDateFromYYYY = BookDateFromYYYY.Text;
                EmployeeLoginScreen.bookThisDateToDD = BookDateToDD.Text;
                EmployeeLoginScreen.bookThisDateToMM = BookDateToMM.Text;
                EmployeeLoginScreen.bookThisDateToYYYY = BookDateToYYYY.Text;

                // will have to eventually book, but then edit the other info as at the end the date from-to might be taken
                FindCustomerSmallWindow findCustomerSmallWindowForm = new FindCustomerSmallWindow();
                findCustomerSmallWindowForm.Show();

            }
            else
            {
                MessageBox.Show("Invalid CarVIN");
            }
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
                queryWhere = queryWhere + "cartypes.carType = '" + SearchCarTypeBox.Text + "' AND ";
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
            //CARTYPES TABLE IS NEEDED
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

        private void rentalTransactionsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            RentalTransactionWindowAddRemove rentalTransactionForm = new RentalTransactionWindowAddRemove();
            rentalTransactionForm.Show();
            this.Close();
        }

        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewCustomer addNewCustomerForm = new AddNewCustomer();
            addNewCustomerForm.Show();
        }

        private void bookDateFromBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void tableLayoutPanel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void removeEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteEmployee deleteEmployeeForm = new DeleteEmployee();
            deleteEmployeeForm.Show();
        }

        private void customToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomReports customReportsForm = new CustomReports();
            customReportsForm.Show();
        }

        private void removeCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteCustomer deleteCustomerForm = new DeleteCustomer();
            deleteCustomerForm.Show();
        }

        private void addEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewEmployee addEmployeeForm = new AddNewEmployee();
            addEmployeeForm.Show();
        }
    }
}
