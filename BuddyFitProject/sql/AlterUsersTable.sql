-- Add new highscore columns to Users table
ALTER TABLE [dbo].[Users]
ADD [highscore_1] INT NULL,
    [highscore_2] INT NULL,
    [highscore_3] INT NULL;
