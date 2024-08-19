INSERT INTO CarTypes(carTypeID, carType, carEngine, carTrim, dailyCost, weeklyCost, monthlyCost) VALUES
/*Standard cars*/
(1, 'Sedan', 'Gas', 'Economy', 25.00, 150.00, 550.00), /*ex. Chev Spark*/
(2, 'Sedan', 'Gas', 'Standard', 35.00, 200.00, 750.00), /*ex. Kia Forte, Volks Jetta, Toyota Camry*/
(3, 'Sedan', 'Gas', 'Luxury', 45.00, 250.00, 925.00), /*ex. BMW 3-series*/

/*Premium cars*/
(5, 'Convertible', 'Gas', 'Standard', 55.00, 300.00, 1100.00), /*ex. Ford Mustang Convertible*/
(6, 'Sport', 'Gas', 'Standard', 60.00, 325.00, 1150.00),  /*ex. Sub BRZ, Toyota GR86, Nissan Z*/

/*SUV, Truck and Vans*/
(9, 'SUV', 'Gas', 'Economy', 40.00, 225.00, 850.00), /*ex. Ford Escape, Ford Edge, Toyota Rav4**/
(10, 'SUV', 'Gas', 'Standard', 50.00, 315.00, 1125.00), /*ex. Ford Expedition, Chev Tahoe*/
(11, 'SUV', 'Gas', 'Luxury', 65.00, 400.00, 1400.00), /*ex. BMW X5, Lincoln Navigator, Cadillac Escalade*/
(12, 'Truck', 'Gas', 'Standard', 65.00, 400.00, 1400.00), /*ex. Ford F-150*/
(13, 'Van', 'Gas', 'Standard', 50.00, 315.00, 1125.00), /*ex. Dodge Caravan */

/*Electric*/
(14, 'Sedan', 'Electric', 'Economy', 40.00, 225.00, 850.00), /*ex. Chev Volt*/
(15, 'Sedan', 'Electric', 'Standard', 50.00, 315.00, 1125.00), /*ex. Tesla 3*/
(16, 'Truck', 'Electric', 'Luxury', 65.00, 400.00, 1400.00); /*ex. Rivian Truck, Tesla Cybertruck*/

/*Remember to update branchpickup when people reserve and plan to drop it elsewhere, for customers search results ex. ON->BC, means cannot be picked up in ON the day after*/
INSERT INTO Car(carVIN, carTypeID, brand, model, year, color, mileage, lastTuneUp, condition, branchPickup) VALUES
('1HGCM82633A004352', 2, 'Honda', 'Accord', 2020, 'Black', 15000, 14000, 'Excellent', 1),
('2HNYD28265H550242', 10, 'Honda', 'Pilot', 2021, 'Orange', 12000, 10000, 'Good', 2),
('1FTFW1ET1EKF12345', 12, 'Ford', 'F-150', 2019, 'Blue', 20000, 18000, 'Good', 3),
('1C4RJFAG7FC987654', 10, 'Dodge', 'Grand Cherokee', 2023, 'Red', 5000, 4500, 'Excellent', 1),
('4F8UEFAG7FC981354', 11, 'Bmw', 'X5', 2023, 'Black', 7500, 6500, 'Excellent', 2),
('10HSIAQW7FC729127', 3, 'Bmw', '3-series', 2022, 'White', 18000, 17000, 'Excellent', 3),
('9E210KSA0X1MLZU1W', 6, 'Ford', 'Mustang', 2023, 'Grey', 5000, 4500, 'Excellent', 1),
('U8W91JKS7DQI12ISA', 5, 'Ford', 'Mustang', 2023, 'Grey', 19000, 18000, 'Fair', 2),
('LA0182JSHAICI3NAU', 12, 'Dodge', 'Ram 1500', 2022, 'Red', 40000, 38000, 'Fair', 3),
('NMAOXZ9XO2KSIAI29', 5, 'Mazda', 'Miata', 2021, 'Red', 84000, 83000, 'Fair', 1),
('5NWI1OKQMOIAOQK12', 15, 'Tesla', 'Tesla3', 2022, 'White', 5000, 4500, 'Excellent', 2),
('92KAJZUUW321283M2', 16, 'Rivian', 'R1T', 2024, 'White', 2000, 0, 'Excellent', 3),
('JSWI19SDAIQ812IW8', 12, 'Ford', 'F-150', 2023, 'Red', 18000, 16500, 'Fair', 1),
('4J0IWQJ21J1SKA9WI', 2, 'Honda', 'Civic', 2024, 'Blue', 2000, 0, 'Excellent', 2),
('902NSAI8Q231IQU8S', 1, 'VolksWagen', 'Bettle', 2019, 'White', 56000, 53000, 'Fair', 2),
('ZMIU2I1QW88SCJI21', 9, 'VolksWagen', 'Tiguan', 2023, 'Orange', 9000, 7500, 'Excellent', 1),
('3JIWQ9XAJSX9QW821', 2, 'VolksWagen', 'Golf', 2019, 'Grey', 130000, 127000, 'Fair', 3),
('9JXQW88UQWJXSUQ72', 2, 'VolksWagen', 'Passet', 2022, 'Pink', 2000, 0, 'Excellent', 1),
('6WDJKIXAY87XIWQM2', 2, 'Honda', 'Civic', 2024, 'Purple', 130000, 127000, 'Fair', 1),
('2KIDWQ98219JS1928', 16, 'Nissan', 'Leaf', 2019, 'Red', 80000, 76000, 'Fair', 3),
('KI1289JSDAY79DY21', 1, 'Honda', 'Fit', 2022, 'Orange', 9000, 7000, 'Excellent', 1),
('20J1S2U9QWDU91J21', 1, 'Chevrolet', 'Spark', 2022, 'Grey', 5000, 4500, 'Good', 2),
('29312JS9UQ7YDS719', 11, 'Cadillac', 'Escalade', 2022, 'Black', 8000, 7900, 'Excellent', 3),
('SY79D1J2812890W18', 14, 'Chevrolet', 'Volt', 2023, 'White', 12000, 11000, 'Excellent', 1),
('213J0DAS9QK21821A', 9, 'Toyota', 'Rav4', 2018, 'Tan', 140000, 138000, 'Fair', 2),
('3J890219J201SJQ12', 11, 'Lincoln', 'Navigator', 2022, 'Blue', 12000, 11000, 'Fair', 3),
('8WQDJ2199217OQO12', 13, 'Dodge', 'Caravan', 2023, 'Black', 23000, 22000, 'Fair', 1),
('79QJW91237192QOI1', 16, 'Tesla', 'CyberTruck', 2024, 'Grey', 1500, 0, 'Excellent', 2);

INSERT INTO Branches(branchNum, name, contactNum, street, city, province, postalCode, country) VALUES
(1, 'Main Branch', '123-456-7890', '123 Main St', 'Metropolis', 'ON', 'A1B 2C3', 'Canada'),
(2, 'East Branch', '321-654-0987', '456 East St', 'Smallville', 'ON', 'B2C 3D4', 'Canada'),
(3, 'West Branch', '987-654-3210', '789 West St', 'Gotham', 'ON', 'C3D 4E5', 'Canada');

INSERT INTO Employees(employeeNum, firstname, lastname, DOBDay, DOBMonth, DOBYear, contactNum, street, city, province, postalCode, country, password, workAtBranchNum) VALUES
(0, 'Virtual', 'Virtual', 0, 0, 0, '000-000-0000', 'Virtual', 'Virtual', 'CD', 'ONL INE', 'Virtual', 'Virtual', 0),
(1, 'John', 'Doe', 21, 06, 2000, '123-123-1234', '111 First St', 'Metropolis', 'ON', 'A1A 1A1', 'Canada', 'John', 1),
(2, 'Jane', 'Smith', 24, 03, 2001, '456-456-4567', '222 Second St', 'Smallville', 'ON', 'B2B 2B2', 'Canada', 'Jane', 2),
(3, 'Jim', 'Brown', 25, 12, 2002, '789-789-7890', '333 Third St', 'Gotham', 'ON', 'C3C 3C3', 'Canada', 'Jim', 3),
(4, 'Employee1', 'Employeelastname1', 10, 06, 2000, '456-715-2917', '444 Second St', 'Smallville', 'ON', 'B2B 2H2', 'Canada', 'Employee1', 1),
(5, 'Employee2', 'Employeelastname2', 21, 01, 2005, '780-286-2013', '555 Second St', 'Edmonton', 'AB', 'T3C 1H1', 'Canada', 'Employee2', 2),
(6, 'Employee3', 'Employeelastname3', 01, 09, 1995, '176-290-0214', '666 Second St', 'Vancouver', 'BC', 'Q2B 3H3', 'Canada', 'Employee3', 3),
(7, 'Employee4', 'Employeelastname4', 04, 11, 1990, '396-286-1929', '777 Second St', 'Toronto', 'ON', 'T2A 4H4', 'Canada', 'Employee4', 2),
(8, 'Employee5', 'Employeelastname5', 24, 12, 1998, '206-293-5782', '888 Second St', 'Saskatoon', 'SK', 'T2K 5H5', 'Canada', 'Employee5', 1),
(9, 'Employee6', 'Employeelastname6', 14, 08, 2010, '126-351-1923', '291 Second St', 'Saskatoon', 'SK', 'T2J 6H6', 'Canada', 'Employee6', 1),
(10, 'Employee7', 'Employeelastname7', 24, 03, 1985, '156-293-1928', '281 Second St', 'Smallville', 'ON', 'B2B 7H7', 'Canada', 'Employee7', 2),
(11, 'Employee8', 'Employeelastname8', 14, 02, 1980, '216-412-4201', '294 Second St', 'Smallville', 'ON', 'B2B 8H8', 'Canada', 'Employee8', 3),
(12, 'Employee9', 'Employeelastname9', 23, 05, 1999, '126-456-4029', '271 Second St', 'Smallville', 'ON', 'B2B 9H9', 'Canada', 'Employee9', 1);

INSERT INTO Customers (cusID, operatorID, firstname, lastname, DOBDay, DOBMonth, DOBYear, contactNum, street, city, province, postalCode, country, password) VALUES
(1, 18293421, 'Alice', 'Johnson', 11, 02, 2000, '321-321-4321', '123 Maple St', 'Metropolis', 'ON', 'A1B 2C3', 'Canada', 'Alice'),
(2, 19273213,'Bob', 'Lee', 21, 04, 2001, '654-654-7654', '456 Oak St', 'Smallville', 'ON', 'B2C 3D4', 'Canada', 'Bob'),
(3, 39102512,'Charlie', 'Lee', 17, 05, 2002, '987-987-0987', '789 Pine St', 'Gotham', 'ON', 'C3D 4E5', 'Canada', 'Charlie'),
(4, 49281613,'Cus3', 'Cus3Lastname', 17, 05, 2000, '780-111-1111', '789 Pine St', 'Edmonton', 'AB', 'C3D 4T9', 'Canada', 'Cus3'),
(5, 21942431,'Cus4', 'Cus4Lastname', 17, 05, 1995, '587-222-2222', '123 Pine St', 'Saskatoon', 'SK', 'C7H 4E5', 'Canada', 'Cus4'),
(6, 92018632,'Cus5', 'Cus5Lastname', 17, 05, 1999, '123-222-2222', '234 Pine St', 'Toronto', 'ON', 'D2D 9J5', 'Canada', 'Cus5'),
(7, 30285944,'Cus6', 'Cus6Lastname', 17, 05, 1990, '123-221-2222', '345 Pine St', 'Vancouver', 'BC', 'W2D 1L5', 'Canada', 'Cus6'),
(8, 17373009,'Cus7', 'Cus7Lastname', 17, 05, 1985, '123-223-2222', '567 Pine St', 'Vancouver', 'BC', 'T3D 4W2', 'Canada', 'Cus7'),
(9, 23464543,'Cus8', 'Cus8Lastname', 17, 05, 1980, '123-132-0987', '928 Pine St', 'Victoria', 'BC', 'T3F 2K9', 'Canada', 'Cus8'),
(10, 90981723,'Cus1', 'Cus1Lastname', 17, 05, 1975, '123-928-0987', '129 Pine St', 'Calgary', 'AB', 'U6D 6L0', 'Canada', 'Cus1');

INSERT INTO RentalTransactions(transID, rentalCost, rentedFromDay, rentedFromMonth, rentedFromYear, returnToDay, returnToMonth, returnToYear, employeeNum, cusID, carVIN, branchNum, branchDropoff) VALUES
(1, 3000, 01, 04, 2023, 01, 08, 2023, 1, 1, '1HGCM82633A004352', 1, 1),
(5, 18000, 01, 01, 2000, 01, 01, 2002, 1, 1, '1HGCM82633A004352', 1, 1),
(2, 1125, 01, 02, 2023,  01, 03, 2023, 2, 2, '2HNYD28265H550242', 2, 2),
(6, 27000, 01, 01, 2005,  01, 01, 2007, 2, 2, '2HNYD28265H550242', 2, 2),
(3, 2800, 01, 03, 2023,  01, 03, 2023, 3, 3, '1FTFW1ET1EKF12345', 3, 2),
(7, 33600, 01, 01, 2009,  01, 01, 2011, 3, 3, '1FTFW1ET1EKF12345', 3, 2),
(4, 100, 01, 04, 2023, 22, 04, 2023, 1, 3, '1C4RJFAG7FC987654', 1, 3),
(8, 13500, 01, 01, 2021, 01, 01, 2022, 1, 3, '1C4RJFAG7FC987654', 1, 3),
(9, 16800, 01, 01, 2021,  01, 01, 2022, 3, 3, '79QJW91237192QOI1', 3, 2),
(10, 13500, 01, 01, 2010,  01, 01, 2011, 3, 3, '8WQDJ2199217OQO12', 3, 2),
(11, 16800, 01, 01, 2013,  01, 01, 2014, 3, 3, '3J890219J201SJQ12', 3, 2),
(12, 10200, 01, 01, 2014,  01, 01, 2015, 3, 3, '213J0DAS9QK21821A', 3, 2),
(13, 10200, 01, 01, 2015,  01, 01, 2016, 3, 3, 'SY79D1J2812890W18', 3, 2),
(14, 16800, 01, 01, 2017,  01, 01, 2018, 3, 3, '29312JS9UQ7YDS719', 3, 2),
(15, 6600, 01, 01, 2018,  01, 01, 2019, 3, 3, '20J1S2U9QWDU91J21', 3, 2),
(16, 9000, 01, 01, 2020,  01, 01, 2021, 3, 3, '9JXQW88UQWJXSUQ72', 3, 2),
(17, 9000, 01, 01, 2021,  01, 01, 2022, 3, 3, '3JIWQ9XAJSX9QW821', 3, 2),
(18, 10200, 01, 01, 2022,  01, 01, 2023, 3, 3, 'ZMIU2I1QW88SCJI21', 3, 2),
(19, 6600, 01, 01, 2023,  01, 01, 2024, 3, 3, '902NSAI8Q231IQU8S', 3, 2),
(20, 9000, 01, 01, 2024,  01, 01, 2025, 3, 3, '4J0IWQJ21J1SKA9WI', 3, 2),
(21, 16800, 01, 01, 2025,  01, 01, 2026, 3, 3, '92KAJZUUW321283M2', 3, 2),
(22, 13500, 01, 01, 2000,  01, 01, 2001, 3, 3, '5NWI1OKQMOIAOQK12', 3, 2),
(23, 13200, 01, 01, 2001,  01, 01, 2002, 3, 3, 'U8W91JKS7DQI12ISA', 3, 2);