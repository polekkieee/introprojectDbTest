-- Insert data into Achievements table
INSERT INTO Achievements (
    name, description, condition_type, condition_value, reward_type, reward_value
)
VALUES
('Reach Pet Level 10', 
 'Reach level 10 with your pet to unlock this achievement and earn a 1000 coin reward.',
 'level', 
 10, 
 'coins', 
 '1000'), 

('Reach Pet Level 50', 
 'Reach level 50 with your pet to unlock this achievement and earn a 2000 coin reward.',
 'level', 
 50, 
 'coins', 
 '2000'),

('Reach Pet Level 100', 
 'Reach level 100 with your pet to unlock this achievement and earn a 5000 coin reward.',
 'level', 
 100, 
 'coins', 
 '5000'),

('Complete 100 Minutes of Exercise', 
 'Complete a total of 100 minutes of exercise to unlock this achievement and earn a 1000 coin reward.',
 'exercise', 
 100, 
 'coins', 
 '1000'),

('Complete 500 Minutes of Exercise', 
 'Complete a total of 500 minutes of exercise to unlock this achievement and earn a 2000 coin reward.',
 'exercise', 
 500, 
 'coins', 
 '2000'),

('Complete 1000 Minutes of Exercise', 
 'Complete a total of 1000 minutes of exercise to unlock this achievement and earn a 5000 coin reward.',
 'exercise', 
 1000, 
 'coins', 
 '5000'),

('Complete 50 Elements in Your Scheme', 
 'Complete 50 elements in your personalized scheme to unlock this achievement and earn a 1000 coin reward.',
 'scheme', 
 50, 
 'coins', 
 '1000'),

('Complete 200 Elements in Your Scheme', 
 'Complete 200 elements in your personalized scheme to unlock this achievement and earn a 2000 coin reward.',
 'scheme', 
 200, 
 'coins', 
 '2000'),

('Complete 500 Elements in Your Scheme', 
 'Complete 500 elements in your personalized scheme to unlock this achievement and earn a 25000 coin reward.',
 'scheme', 
 500, 
 'coins', 
 '25000'),

('Score 100 in FlappyBuddy', 
 'Score 100 points in the FlappyBuddy mini-game to unlock this achievement and earn a 1000 coin reward.',
 'game1', 
 100, 
 'coins', 
 '1000'),
 
('Complete Game2 Achievement', 
 'Complete the challenge in Game2 to unlock this achievement and earn a reward.',
 'game2', 
 0,  
 'coins', 
 '0'),

('Complete Game3 Achievement', 
 'Complete the challenge in Game3 to unlock this achievement and earn a reward.',
 'game3', 
 0, 
 'coins', 
 '0');
