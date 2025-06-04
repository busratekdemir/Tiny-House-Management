--1.Fonksiyon
CREATE FUNCTION fn_ToplamRezervasyonSayisi()
RETURNS INT
AS
BEGIN
    DECLARE @Sayi INT
    SELECT @Sayi = COUNT(*) FROM Reservations
    RETURN @Sayi
END
GO

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
GO
