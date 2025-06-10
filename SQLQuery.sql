CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Password NVARCHAR(100) NOT NULL,
    Role NVARCHAR(50) NOT NULL,
    IsActive BIT DEFAULT 1
);

CREATE TABLE Houses (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(150) NOT NULL,
    Description NVARCHAR(MAX),
    PricePerNight DECIMAL(10, 2) NOT NULL,
    Location NVARCHAR(100) NOT NULL,
    OwnerId INT NOT NULL,
    PhotoUrls NVARCHAR(MAX),
    IsActive BIT,
    AvailableFrom DATETIME,
    AvailableTo DATETIME,
    FOREIGN KEY (OwnerId) REFERENCES Users(Id)
);

CREATE TABLE dbo.Reviews (
  Id INT IDENTITY(1,1) PRIMARY KEY,
  HouseId INT NOT NULL,
  UserId INT NOT NULL,
  Rating INT NOT NULL CHECK (Rating BETWEEN 1 AND 5),
  Text NVARCHAR(MAX) NULL,
  CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
  CONSTRAINT FK_Reviews_House FOREIGN KEY (HouseId)
    REFERENCES dbo.Houses(Id),
  CONSTRAINT FK_Reviews_User FOREIGN KEY (UserId)
    REFERENCES dbo.Users(Id)
);

CREATE TABLE Reservations (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL,
    TinyHouseId INT NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    TotalPrice DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(Id),
    FOREIGN KEY (TinyHouseId) REFERENCES TinyHouses(Id)
);

CREATE TABLE ReservationLog (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ReservationId INT,
    DeletedAt DATETIME DEFAULT GETDATE(),
    DeletedBy NVARCHAR(100) DEFAULT SYSTEM_USER
);

CREATE TABLE HouseLog (
    Id INT PRIMARY KEY IDENTITY(1,1),
    HouseId INT,
    OwnerId INT,
    AddedAt DATETIME DEFAULT GETDATE()
);

ALTER TABLE Reviews ADD Status TINYINT NOT NULL DEFAULT 0;

ALTER TABLE Reservations ADD Status TINYINT NOT NULL DEFAULT 0;

--1.Fonksiyon
CREATE FUNCTION fn_ToplamRezervasyonSayisi()
RETURNS INT
AS
BEGIN
    DECLARE @Sayi INT
    SELECT @Sayi = COUNT(*) FROM Reservations
    RETURN @Sayi
END

-- 2. Fonksiyn
CREATE FUNCTION fn_EvSahibiGeliri(@OwnerId INT)
RETURNS DECIMAL(10, 2)
AS
BEGIN
    DECLARE @Gelir DECIMAL(10, 2)
    SELECT @Gelir = ISNULL(SUM(r.TotalPrice), 0)
    FROM Reservations r
    INNER JOIN TinyHouses t ON r.TinyHouseId = t.Id
    WHERE t.OwnerId = @OwnerId
    RETURN @Gelir
END

CREATE PROCEDURE sp_KullaniciyiPasifYap
    @UserId INT
AS
BEGIN
    UPDATE Users
    SET IsActive = 0
    WHERE Id = @UserId
END

CREATE PROCEDURE sp_AddReservation
    @UserId INT,
    @TinyHouseId INT,
    @StartDate DATE,
    @EndDate DATE,
    @TotalPrice DECIMAL(10,2)
AS
BEGIN
    INSERT INTO Reservations(UserId, TinyHouseId, StartDate, EndDate, TotalPrice)
    VALUES (@UserId, @TinyHouseId, @StartDate, @EndDate, @TotalPrice)
END

CREATE TRIGGER trg_ReservasyonSilindi
ON Reservations
AFTER DELETE
AS
BEGIN
    INSERT INTO ReservationLog (ReservationId)
    SELECT Id FROM DELETED;
END;

CREATE TRIGGER trg_IlanEklendi
ON TinyHouses
AFTER INSERT
AS
BEGIN
    INSERT INTO HouseLog (HouseId, OwnerId)
    SELECT Id, OwnerId FROM INSERTED;
END;
