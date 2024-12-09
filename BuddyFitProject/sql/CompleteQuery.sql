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
    clothing NVARCHAR(50) NOT NULL,
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

-- Insert Exercises
INSERT INTO Exercises (name, coins_pm)
VALUES 
('Push-up', 150),
('Plank', 100),
('Burpees', 200),
('Jumping Jacks', 100),
('Bench Press', 50),
('Dumbbell Rows', 30),
('Curls', 30),
('Pull-up', 50),
('Leg Press', 30),
('Walking', 20),
('Cycling', 20),
('Swimming', 50),
('Running', 60),
('Sprinting', 100),
('Wallsits', 70),
('Rope Jumping', 120),
('Stair Walking', 140);
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

-- Insert Items
INSERT INTO Items (name, type, price) VALUES 
('Military Outfit', 'outfit', 5000),
('Cat In Suit', 'outfit', 8000),
('Cat In Tutu', 'outfit', 1000),
('Pyjamas Cat', 'outfit', 2000),
('Banana', 'food', 50),
('Apple', 'food', 50),
('Strawberry', 'food', 150),
('Tomato', 'food', 100);
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

