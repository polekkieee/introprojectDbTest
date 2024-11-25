CREATE TABLE [dbo].[WorkoutSession] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [UserId]     INT           NOT NULL,
    [ExerciseId] INT           NULL,
    [Minutes]    INT           NULL,
    [Reward]     INT           NULL,
    [Timestamp]  DATETIME2 (7) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

