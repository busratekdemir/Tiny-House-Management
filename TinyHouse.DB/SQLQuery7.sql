CREATE TRIGGER trg_ReservasyonSilindi
ON Reservations
AFTER DELETE
AS
BEGIN
    INSERT INTO ReservationLog (ReservationId)
    SELECT Id FROM DELETED;
END;