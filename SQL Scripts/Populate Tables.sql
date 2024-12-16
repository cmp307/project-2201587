-- Insert sample data into Department Table
INSERT INTO CMP307.Department (DepartmentName)
VALUES 
    ('Human Resources'),
    ('Finance'),
    ('IT Support'),
    ('Operations'),
    ('Marketing');
GO

-- Insert sample data into Employee Table
INSERT INTO CMP307.Employee (FirstName, LastName, Email, DepartmentID, Password)
VALUES 
    ('John', 'Doe', 'johndoe@example.com', 1, 'password123'),
    ('Jane', 'Smith', 'janesmith@example.com', 2, 'pass456'),
    ('Robert', 'Brown', 'robertbrown@example.com', 3, 'securepass789'),
    ('Alice', 'Johnson', 'alicejohnson@example.com', 4, 'alicepassword'),
    ('Emily', 'Davis', 'emilydavis@example.com', 5, 'emilypass123');
GO

-- Insert sample data into Asset Table
INSERT INTO CMP307.Asset (SystemName, Model, Manufacturer, Type, IPAddress, PurchaseDate, Notes, EmployeeID)
VALUES 
    ('Dell Precision', 'Precision 5550', 'Dell', 'Laptop', '192.168.1.10', '2022-01-15', 'Assigned to John Doe', 1),
    ('HP EliteDesk', 'EliteDesk 800', 'HP', 'Desktop', '192.168.1.11', '2021-12-01', 'Used by Jane Smith in Finance', 2),
    ('MacBook Pro', 'MacBook Pro 14"', 'Apple', 'Laptop', '192.168.1.12', '2023-03-10', 'Robert Brown''s main device', 3),
    ('Surface Pro', 'Surface Pro 7', 'Microsoft', 'Tablet', '192.168.1.13', '2022-05-20', 'Used by Alice Johnson for R&D', 4),
    ('iPad Air', 'iPad Air 4', 'Apple', 'Tablet', NULL, '2020-09-05', 'Assigned to Marketing team', 5);
GO

