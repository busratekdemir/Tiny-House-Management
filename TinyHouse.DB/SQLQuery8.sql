CREATE TABLE HouseLog (
    Id INT PRIMARY KEY IDENTITY(1,1),
    HouseId INT,
    OwnerId INT,
    AddedAt DATETIME DEFAULT GETDATE()
);
