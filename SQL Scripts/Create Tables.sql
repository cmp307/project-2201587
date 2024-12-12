-- Department Table
CREATE TABLE CMP307.Department (
		DepartmentID INT PRIMARY KEY IDENTITY(1,1),
		DepartmentName VARCHAR(100) NOT NULL
);
GO

-- Employee Table
CREATE TABLE CMP307.Employee (
		EmployeeID INT PRIMARY KEY IDENTITY(1,1),
		FirstName VARCHAR(100) NOT NULL,
		LastName VARCHAR(100) NOT NULL,
		Email VARCHAR(255) NOT NULL UNIQUE,
		DepartmentID INT FOREIGN KEY REFERENCES CMP307.Department(DepartmentID),
		Password VARCHAR(255) NOT NULL,
);
GO

-- Asset Table
CREATE TABLE CMP307.Asset (
		AssID INT PRIMARY KEY IDENTITY(1,1),
		SystemName VARCHAR(255) NOT NULL,
		Model VARCHAR(255) NOT NULL,
		Manufacturer VARCHAR(255) NOT NULL,
		Type VARCHAR(100) NOT NULL,
		IPAddress VARCHAR(15),
		PurchaseDate DATE,
		Notes VARCHAR(512),
		EmployeeID INT FOREIGN KEY REFERENCES CMP307.Employee(EmployeeID),
);
GO

-- Software Table
CREATE TABLE CMP307.Software (
		SoftID int PRIMARY KEY IDENTITY(1,1),
		OSname varchar(225) NOT NULL,
		Version varchar(225) NOT NULL,
		manufacturer varchar(225) NOT NULL
);
GO

-- Links Table
CREATE TABLE CMP307.Links (
		AssID int NOT NULL FOREIGN KEY REFERENCES CMP307.Asset(AssID),
		SoftID int NOT NULL FOREIGN KEY REFERENCES CMP307.Software(SoftID),
		Date date NOT NULL,
		Active bit NOT NULL
);
GO