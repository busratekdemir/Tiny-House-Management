CREATE TABLE ReservationLog (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ReservationId INT,
    DeletedAt DATETIME DEFAULT GETDATE(),
    DeletedBy NVARCHAR(100) DEFAULT SYSTEM_USER
);

