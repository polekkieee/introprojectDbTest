USE [FitBuddyDb]
GO

CREATE TABLE [dbo].[Users]
(
	[UserName] VARCHAR(50) NOT NULL PRIMARY KEY, 
    [Password] VARCHAR(50) NOT NULL, 
    [Email] VARCHAR(50) NOT NULL
)
