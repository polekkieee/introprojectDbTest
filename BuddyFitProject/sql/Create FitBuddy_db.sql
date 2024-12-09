USE MASTER

-- Create the database
CREATE DATABASE FitBuddy_db;
GO

-- Use the database
USE FitBuddy_db;
GO

-- Create Users table
CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    username NVARCHAR(50) NOT NULL,
    password NVARCHAR(255) NOT NULL,
    email NVARCHAR(100) NOT NULL UNIQUE,
    age INT NOT NULL,
    gender NVARCHAR(100),
    start_condition NVARCHAR(100),
    coins INT DEFAULT 0,
    resetcode NVARCHAR(50),
    validatecode NVARCHAR(50),
    register_moment DATETIME2 DEFAULT GETDATE() NOT NULL,
);
GO

-- Create Pets table
CREATE TABLE Pets (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    userId INT UNIQUE, -- One-to-One relationship
    name NVARCHAR(50) NOT NULL,
    type NVARCHAR(50) NOT NULL,
    level INT DEFAULT 1,
    food_bar INT DEFAULT 100,
    health_bar INT DEFAULT 100,
    stamina_bar INT DEFAULT 100,
    FOREIGN KEY (userId) REFERENCES Users(Id) ON DELETE CASCADE
);
GO

-- Create Exercises table
CREATE TABLE Exercises (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(50) NOT NULL UNIQUE,
    coins_pm INT NOT NULL
);
GO

-- Create WorkoutSessions table
CREATE TABLE WorkoutSessions (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    userId INT NOT NULL,
    exerciseId INT NOT NULL,
    minutes INT NOT NULL,
    reward INT NOT NULL,
    timestamp DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (userId) REFERENCES Users(Id) ON DELETE CASCADE,
    FOREIGN KEY (exerciseId) REFERENCES Exercises(Id) ON DELETE CASCADE
);
GO

-- Create Items table
CREATE TABLE Items (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(50) NOT NULL UNIQUE,
    type NVARCHAR(50) NOT NULL,
    price INT NOT NULL
);
GO

-- Create UserInventory table
CREATE TABLE UserInventory (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    userId INT NOT NULL,
    itemId INT NOT NULL,
    quantity INT NOT NULL DEFAULT 1,
    FOREIGN KEY (userId) REFERENCES Users(Id) ON DELETE CASCADE,
    FOREIGN KEY (itemId) REFERENCES Items(Id) ON DELETE CASCADE
);
GO

-- Create Statistics table
CREATE TABLE UserStatistics (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    userId INT NOT NULL,
    exerciseId INT NOT NULL,
    total_minutes INT NOT NULL DEFAULT 0,
    total_coins INT NOT NULL DEFAULT 0,
    FOREIGN KEY (userId) REFERENCES Users(Id) ON DELETE CASCADE,
    FOREIGN KEY (exerciseId) REFERENCES Exercises(Id) ON DELETE CASCADE
);
GO
