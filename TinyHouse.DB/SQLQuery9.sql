CREATE TRIGGER trg_IlanEklendi
ON TinyHouses
AFTER INSERT
AS
BEGIN
    INSERT INTO HouseLog (HouseId, OwnerId)
    SELECT Id, OwnerId FROM INSERTED;
END;
