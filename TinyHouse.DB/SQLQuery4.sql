CREATE PROCEDURE sp_KullaniciyiPasifYap
    @UserId INT
AS
BEGIN
    UPDATE Users
    SET IsActive = 0
    WHERE Id = @UserId
END
