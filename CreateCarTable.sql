CREATE TABLE CarTypes (
    CarTypeID INT PRIMARY KEY,
	CarType VARCHAR(50),
	CarEngine VARCHAR(50),
	CarTrim VARCHAR(50),
    DailyCost DECIMAL(9, 2),
    WeeklyCost DECIMAL(9, 2),
    MonthlyCost DECIMAL(9, 2)
);

CREATE TABLE Car (
    CarVIN VARCHAR(17) PRIMARY KEY,
    CarTypeID INT,
	Brand VARCHAR(50),
    Model VARCHAR(50),
    Year INT,
    Color VARCHAR(20),
    Mileage INT,
    LastTuneUp INT,
    Condition VARCHAR(20),
	BranchPickup INT,
    FOREIGN KEY (CarTypeID) REFERENCES CarTypes(CarTypeID)
);

CREATE TABLE Branches (
    BranchNum INT PRIMARY KEY,
    Name VARCHAR(100),
    ContactNum VARCHAR(15),
    Street VARCHAR(100),
    City VARCHAR(50),
    Province VARCHAR(50),
    PostalCode VARCHAR(10),
    Country VARCHAR(50)
);

CREATE TABLE Employees (
    EmployeeNum INT PRIMARY KEY,
    FirstName VARCHAR(50),
	LastName VARCHAR(50),
	DOBDay INT,
	DOBMonth INT,
	DOBYear INT,
    ContactNum VARCHAR(15),
    Street VARCHAR(100),
    City VARCHAR(50),
    Province VARCHAR(50),
    PostalCode VARCHAR(10),
    Country VARCHAR(50),
	Password VARCHAR(50),
	WorkAtBranchNum INT
);

CREATE TABLE Customers (
    CusID INT PRIMARY KEY,
	OperatorID  INT,
    FirstName VARCHAR(50),
	LastName VARCHAR(50),
	DOBDay INT,
	DOBMonth INT,
	DOBYear INT,
    ContactNum VARCHAR(15),
    Street VARCHAR(100),
    City VARCHAR(50),
    Province VARCHAR(50),
    PostalCode VARCHAR(10),
    Country VARCHAR(50),
	Password VARCHAR(50)
);

CREATE TABLE RentalTransactions (
    TransID INT PRIMARY KEY,
	RentalCost INT,
	RentedFromDay INT,
	RentedFromMonth INT,
	RentedFromYear INT,
	ReturnToDay INT,
	ReturnToMonth INT,
	ReturnToYear INT,
    EmployeeNum INT,
    CusID INT,
    CarVIN VARCHAR(17),
    BranchNum INT,
	BranchDropoff INT,
    FOREIGN KEY (EmployeeNum) REFERENCES Employees(EmployeeNum),	
    FOREIGN KEY (CarVIN) REFERENCES Car(CarVIN),
    FOREIGN KEY (BranchNum) REFERENCES Branches(BranchNum)
);

