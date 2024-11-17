USE [FitBuddyDb]
GO

CREATE LOGIN [LiesbethLogin] 
WITH PASSWORD = '123';
GO

CREATE USER [Liesbeth] 
FOR LOGIN [LiesbethLogin] 
WITH DEFAULT_SCHEMA = dbo;
GO

GRANT CONNECT TO [Liesbeth];
GO