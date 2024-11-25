-- Step 1: Check for invalid Timestamp values and set them to NULL
UPDATE [dbo].[Table]
SET [Timestamp] = NULL
WHERE ISDATE([Timestamp]) = 0;

-- Step 2: Rename the column 'ExcerseId' to 'ExerciseId'
EXEC sp_rename '[dbo].[Table].[ExcerseId]', 'ExerciseId', 'COLUMN';

-- Step 3: Alter the 'Timestamp' column to DATETIME2(7)
ALTER TABLE [dbo].[Table]
ALTER COLUMN [Timestamp] DATETIME2(7) NULL;
GO