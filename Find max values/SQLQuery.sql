CREATE TABLE Position (
    JobID INT PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL
);


CREATE TABLE Branch (
    BranchID INT PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL
);


CREATE TABLE Product (
    ProductID INT PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL,
    PurchasePrice int NOT NULL,
    SalePrice int NOT NULL
);


CREATE TABLE Employee (
    EmployeeID INT PRIMARY KEY,
    Surname NVARCHAR(50) NOT NULL,
    Name NVARCHAR(50) NOT NULL,
    DadName NVARCHAR(50) NOT NULL,
    JobID INT,
    Salary INT NOT NULL,
    EmpJobID int REFERENCES Position(JobID)
);


CREATE TABLE Sales (
    SaleID INT PRIMARY KEY,
    ProductID INT,
    EmployeeID INT,
    BranchID INT,
    SaleDate DATE,
    SalesProductID int REFERENCES Product(ProductID),
    SalesEmployeeID int REFERENCES Employee(EmployeeID),
    SalesBranchID int REFERENCES Branch(BranchID)
);




--INSERT

INSERT INTO Position (JobID, Name) VALUES
(1, 'Manager'),
(2, 'Salesperson');

INSERT INTO Branch (BranchID, Name) VALUES
(1, 'Main Branch'),
(2, 'Second Branch');

INSERT INTO Product (ProductID, Name, PurchasePrice, SalePrice) VALUES
(1, 'Product A', 50, 100),
(2, 'Product B', 40, 80);


INSERT INTO Employee (EmployeeID, Surname, Name, DadName, JobID, Salary) VALUES
(1, 'Dave', 'Bob', 'Winston', 1, 1500),
(2, 'Shimada', 'Hanzo', 'Ivan', 2, 3000);

INSERT INTO Sales (SaleID, ProductID, EmployeeID, BranchID, SaleDate) VALUES
(1, 1, 1, 1, '2023-11-01'),
(2, 2, 2, 2, '2023-11-02'),
(3, 1, 2, 1, '2023-11-02'),
(4, 1, 1, 2, '2023-11-02');


--Queries

--Query1
SELECT
    E.Surname AS EmployeeSurname,
    E.Name AS EmployeeName,
    E.DadName AS EmployeeDadName,
    P.Name AS ProductName,
    P.PurchasePrice,
    P.SalePrice,
    B.Name AS BranchName
FROM
    Sales S
JOIN
    Employee E ON S.EmployeeID = E.EmployeeID
JOIN
    Product P ON S.ProductID = P.ProductID
JOIN
    Branch B ON S.BranchID = B.BranchID;
--Query 2
SELECT
    SUM(P.SalePrice) AS TotalSales
FROM
    Sales S
JOIN
    Product P ON S.ProductID = P.ProductID;
--Query 3

SELECT
    SUM(P.SalePrice) AS TotalSalesCurrentMonth
FROM
    Sales S
JOIN
    Product P ON S.ProductID = P.ProductID
WHERE
    MONTH(S.SaleDate) = MONTH(GETDATE());


--Query 4

SELECT
    E.EmployeeID,
    E.Surname AS EmployeeSurname,
    E.Name AS EmployeeName,
    P.ProductID,
    P.Name AS ProductName
FROM
    Employee E
JOIN
    Sales S ON E.EmployeeID = S.EmployeeID
JOIN
    Product P ON S.ProductID = P.ProductID;

--Query 5

SELECT
    B.BranchID,
    B.Name AS BranchName,
    COUNT(S.ProductID) AS TotalProductsSoldToday
FROM
    Branch B
JOIN
    Sales S ON B.BranchID = S.BranchID
WHERE
    CONVERT(DATE, S.SaleDate) = CONVERT(DATE, GETDATE())
GROUP BY
    B.BranchID, B.Name
HAVING
    COUNT(S.ProductID) = (SELECT MAX(ProductCount) FROM (
                            SELECT
                                B1.BranchID,
                                COUNT(S1.ProductID) AS ProductCount
                            FROM
                                Branch B1
                            JOIN
                                Sales S1 ON B1.BranchID = S1.BranchID
                            WHERE
                                CONVERT(DATE, S1.SaleDate) = CONVERT(DATE, GETDATE())
                            GROUP BY
                                B1.BranchID
                          ) AS Subcount);
