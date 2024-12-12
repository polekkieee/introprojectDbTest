# Buddy Fit Project 
Introproject Informatica UU 2024-2025
Group 6

## About

BuddyFit is all about staying fit. We all know the struggle, you wanna work out but simply do not have the motivation to. No worries, we have found a way to keep you motivated.  A Fit buddy will accompany you on your fit journey! 

## Instructions
1. Run the complete [sql script](https://git.science.uu.nl/jazzmex/introproject/-/tree/main/BuddyFitProject/sql?ref_type=heads) we have included in our repo.
2. That's it! Click start without debugging and a website will appear in your browser (localhost). 

## Known Issues
- We know that sometimes running the project will take some time. This is due to the images that need to be loaded. No worries if it takes 15-25 seconds before the website appears.
- It may happen that the connection string to the database is incorrect. Follow the steps to fix this:
    1. Look up SQL SERVER OBJECT EXPLORER in Visual Studio 
    2. Go to SQL Server -> (localdb)\MSQQLLocalDB(......)
    3. Click on Databases
    4. Right-click on FitBuddy_Db and check out the properties
    5. The properties will appear on the bottom-right of your screen
    6. Go to Connection String and copy your connection string
    7. Go to the file [appsettings.json](https://git.science.uu.nl/jazzmex/introproject/-/blob/main/BuddyFitProject/appsettings.json) and replace the default connection string. Paste you connection string in between the ""
    8. Run the website again, it should work now
- Logged out, but you're still on a page that's only accessible to logged in users? Simply refresh the site in your browser and you should be led back to the home screen.