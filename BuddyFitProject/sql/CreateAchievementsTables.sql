-- Create Achievements table to store achievements, their conditions, and rewards
CREATE TABLE Achievements (
    Id INT PRIMARY KEY IDENTITY(1,1),            -- Unique ID for each achievement
    name VARCHAR(100),                            -- Name of the achievement (e.g., "Reach pet level 10")
    description TEXT,                             -- Description of the achievement
    condition_type VARCHAR(50),                   -- Type of condition (e.g., 'level', 'exercise')
    condition_value INT,                         -- Condition value (e.g., 'level 10')
    reward_type VARCHAR(50),                      -- Type of reward (e.g., 'coins', 'items')
    reward_value VARCHAR(50)                      -- Value of the reward (e.g., '100' coins)
);

-- Create UserAchievements table to track user achievements and whether they have been unlocked
CREATE TABLE UserAchievements (
    Id INT PRIMARY KEY IDENTITY(1,1),            -- Unique ID for each user achievement entry
    userId INT,                                  -- Reference to the user
    achievementId INT,                           -- Reference to the achievement
    unlocked BIT DEFAULT 0,                      -- If the achievement is unlocked (0 = False, 1 = True)
    FOREIGN KEY (userId) REFERENCES Users(Id),   -- Link to the Users table (make sure Users table exists)
    FOREIGN KEY (achievementId) REFERENCES Achievements(Id)  -- Link to the Achievements table
);
