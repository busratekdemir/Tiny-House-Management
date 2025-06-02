-- Kullanýcýlar tablosu
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(100),
    Email NVARCHAR(100) UNIQUE,
    Password NVARCHAR(100),
    Role NVARCHAR(50)
);

-- Ýlan (Tiny House) tablosu
CREATE TABLE TinyHouses (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(150),
    Description NVARCHAR(MAX),
    PricePerNight DECIMAL(10,2),
    Location NVARCHAR(100),
    OwnerId INT FOREIGN KEY REFERENCES Users(Id)
);

-- Rezervasyon tablosu
CREATE TABLE Reservations (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserId INT FOREIGN KEY REFERENCES Users(Id),
    TinyHouseId INT FOREIGN KEY REFERENCES TinyHouses(Id),
    StartDate DATE,
    EndDate DATE,
    TotalPrice DECIMAL(10,2)
);
