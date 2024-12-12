# Buddy Fit Project 
Introproject Informatica UU 2024-2025
Group 6

## About
BuddyFit is all about staying fit. We all know the struggle, you wanna work out but simply do not have the motivation to. No worries, we have found a way to keep you motivated.  A Fit buddy will accompany you on your fit journey! 

## Instructions 
1. Install ASP.Net & web development.
    1) Go to Visual Studio Installer 
        (This is a different program than Visual Studio so look it up on your computer instead of in Visual Studio)
    2)  Your version of Visual Studio should appear under 'Installed'. Click on Modify.
    3) Check whether ASP.Net & web development (under 'Web & Cloud') is installed. 
            If not, please install it.
2. Download the packages in Visual Studio.
    1) Go to Tools -> NuGet Package Manager -> Manage NuGet Packages for Solution
    2) Go to Browse and make sure you have donwloaded the following packages:
        -  SendGrid
        -  Microsoft.EntityFrameworkCore.Sqlserver
        -  Microsoft.EntityFrameworkCore
        -  Microsoft.EntityFrameworkCore.Tools
3. Run the complete [sql script](https://git.science.uu.nl/jazzmex/introproject/-/tree/main/BuddyFitProject/sql?ref_type=heads) we have included in our repo.
4.. That's it! Click start without debugging and a website will appear in your browser (localhost). 

## Known Issues
- We know that sometimes running the project will take some time. This is due to the images that need to be loaded. No worries if it takes 15-25 seconds before the website appears.
- Logged out, but you're still on a page that's only accessible to logged in users? Simply refresh the site in your browser and you should be led back to the home screen.
- It may happen that the connection string to the database is incorrect. Follow the steps to fix this:
    1. Look up SQL SERVER OBJECT EXPLORER in Visual Studio 
    2. Go to SQL Server -> (localdb)\MSSQLLocalDB(......)
    3. Click on Databases
    4. Right-click on FitBuddy_Db and check out the properties
    5. The properties will appear on the bottom-right of your screen
    6. Go to Connection String and copy your connection string
    7. Go to the file [appsettings.json](https://git.science.uu.nl/jazzmex/introproject/-/blob/main/BuddyFitProject/appsettings.json) and replace the default connection string. 
        Make sure you paste the connection string in between the ""
    8. Run the website again, it should work now
