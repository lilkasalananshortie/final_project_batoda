CREATE TABLE MemberInfo (
    BodyNumber INT IDENTITY(1,1) PRIMARY KEY,
    MembershipType VARCHAR(20) CHECK (MembershipType IN ('Operator', 'Driver')) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    FirstName VARCHAR(50) NOT NULL,
    MiddleInitial CHAR(1),
    Birthdate DATE NOT NULL,
    TricycleBrand VARCHAR(50),
    TricycleModel VARCHAR(50),
    ContactNumber VARCHAR(11) UNIQUE CHECK (ContactNumber LIKE '09%' AND LEN(ContactNumber) = 11),
    ChassisNumber VARCHAR(50) UNIQUE,
    EngineNumber VARCHAR(50) UNIQUE,
    PlateNumber VARCHAR(20) UNIQUE,
    TaxBalance DECIMAL(10,2) DEFAULT 0,
    MemberStatus VARCHAR(10) CHECK (MemberStatus IN ('Active', 'Inactive')),
    PenaltyLevel INT DEFAULT 0 CHECK (PenaltyLevel BETWEEN 0 AND 3),
    SuspensionDays INT DEFAULT 0,
    DaysRemaining INT DEFAULT 0
);


INSERT INTO MemberInfo 
(MembershipType, LastName, FirstName, MiddleInitial, Birthdate, TricycleBrand, TricycleModel, ContactNumber, ChassisNumber, EngineNumber, PlateNumber, TaxBalance, MemberStatus, PenaltyLevel, SuspensionDays, DaysRemaining)
VALUES
('Operator', 'Dela Cruz', 'Mark', 'A', '1999-05-12', 'Honda', 'TMX125', '09123456780', 'CH001A', 'EN001A', 'ABC123', 0, 'Active', 0, 0, 0),
('Driver', 'Santos', 'Juan', 'B', '1998-03-02', 'Yamaha', 'MioSporty', '09987654321', 'CH002B', 'EN002B', 'XYZ456', 0, 'Active', 1, 0, 0),
('Operator', 'Reyes', 'Maria', 'C', '1995-07-20', 'Suzuki', 'Smash115', '09111111111', 'CH003C', 'EN003C', 'DEF789', 100.50, 'Inactive', 2, 2, 1),
('Driver', 'Garcia', 'Jose', 'D', '1997-01-14', 'Honda', 'Wave110', '09122222222', 'CH004D', 'EN004D', 'GHI321', 0, 'Active', 0, 0, 0),
('Operator', 'Lopez', 'Ana', 'E', '1996-09-05', 'Kawasaki', 'Barako175', '09133333333', 'CH005E', 'EN005E', 'JKL654', 50.75, 'Active', 1, 0, 0),
('Driver', 'Torres', 'Paulo', 'F', '1999-11-30', 'Yamaha', 'Crypton110', '09144444444', 'CH006F', 'EN006F', 'MNO987', 0, 'Active', 0, 0, 0),
('Operator', 'Mendoza', 'Ella', 'G', '2000-02-10', 'Honda', 'TMX125', '09155555555', 'CH007G', 'EN007G', 'PQR159', 0, 'Active', 3, 2, 1),
('Driver', 'Bautista', 'Rico', 'H', '1998-06-08', 'Suzuki', 'Smash115', '09166666666', 'CH008H', 'EN008H', 'STU753', 0, 'Inactive', 0, 0, 0),
('Operator', 'Fernandez', 'Lea', 'I', '1995-10-22', 'Yamaha', 'MioSporty', '09177777777', 'CH009I', 'EN009I', 'VWX951', 120.00, 'Active', 1, 0, 0),
('Driver', 'Cruz', 'Allan', 'J', '1994-04-15', 'Kawasaki', 'Barako175', '09188888888', 'CH010J', 'EN010J', 'YZA852', 0, 'Active', 0, 0, 0),
('Operator', 'Ramos', 'Joana', 'K', '1997-12-01', 'Honda', 'TMX125', '09199999999', 'CH011K', 'EN011K', 'BCD753', 0, 'Active', 2, 2, 0),
('Driver', 'Aquino', 'Leo', 'L', '1996-08-25', 'Yamaha', 'Crypton110', '09200000000', 'CH012L', 'EN012L', 'EFG456', 0, 'Inactive', 0, 0, 0),
('Operator', 'Domingo', 'Grace', 'M', '1999-01-11', 'Suzuki', 'Smash115', '09211111111', 'CH013M', 'EN013M', 'HIJ987', 0, 'Active', 0, 0, 0),
('Driver', 'Villanueva', 'Carl', 'N', '1998-05-09', 'Kawasaki', 'Barako175', '09222222222', 'CH014N', 'EN014N', 'KLM369', 0, 'Active', 1, 0, 0),
('Operator', 'Gomez', 'Nina', 'O', '1997-07-19', 'Honda', 'Wave110', '09233333333', 'CH015O', 'EN015O', 'NOP159', 80.00, 'Active', 2, 2, 1),
('Driver', 'Castro', 'Jay', 'P', '1995-02-28', 'Suzuki', 'Smash115', '09244444444', 'CH016P', 'EN016P', 'QRS753', 0, 'Active', 0, 0, 0),
('Operator', 'Perez', 'Rina', 'Q', '1999-03-14', 'Yamaha', 'MioSporty', '09255555555', 'CH017Q', 'EN017Q', 'TUV951', 0, 'Active', 1, 0, 0),
('Driver', 'Navarro', 'Earl', 'R', '1998-09-23', 'Kawasaki', 'Barako175', '09266666666', 'CH018R', 'EN018R', 'WXY852', 0, 'Active', 0, 0, 0),
('Operator', 'Padilla', 'May', 'S', '1996-06-02', 'Honda', 'TMX125', '09277777777', 'CH019S', 'EN019S', 'ZAB753', 0, 'Inactive', 0, 0, 0),
('Driver', 'Lim', 'Tony', 'T', '1997-11-08', 'Suzuki', 'Smash115', '09288888888', 'CH020T', 'EN020T', 'CDE159', 0, 'Active', 0, 0, 0);
