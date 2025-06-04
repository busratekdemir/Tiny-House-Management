CREATE PROCEDURE sp_RezervasyonEkle
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
