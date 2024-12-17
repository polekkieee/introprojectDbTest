# Buddy Fit Project 
Introproject Informatica <br>UU 2024-2025 <br> Group 6

## Project description
BuddyFit is all about staying fit. We all know the struggle, you wanna work out but simply do not have the motivation to. No worries, we have found a way to keep you motivated.  A Fit Buddy will accompany you on your fitness journey to keep you motivated.

Users can create an account and select a virtual pet to join them on their fitness journey.

Once logged in, registered users can access a session page where they can log their workout sessions. Completing a session earns coins, which can be spent in the store on items like food and costumes. Keeping your pet happy requires feeding it regularly, making every workout rewarding and fun.

## Instructions 
1. Install ```ASP.Net & web development.```
    1) Go to **Visual Studio Installer** <br> (This is a different program than Visual Studio so look it up on your computer instead of in Visual Studio)
    2)  Your version of Visual Studio should appear under '_Installed_'. Click on **Modify**.
    3) Check whether ASP.Net & web development (under 'Web & Cloud') is installed. If not, please install it.
2. Download the packages in Visual Studio.
    1) Go to **Tools** -> **NuGet Package Manager** -> **Manage NuGet Packages for Solution**
    2) Go to _Browse_ and make sure you have donwloaded the following packages:
        -  ```SendGrid```
        - ```Microsoft.EntityFrameworkCore.Sqlserver```
        - ```Microsoft.EntityFrameworkCore```
        - ```Microsoft.EntityFrameworkCore.Tools```
3. Run the complete [SQL script](https://git.science.uu.nl/jazzmex/introproject/-/tree/main/BuddyFitProject/sql?ref_type=heads) we have included in our repo.
4. That's it! Click _start without debugging_ in Visual Studio and a website will appear in your browser (localhost). 

## Overview of codebase structure
All project files are located in the ```BuddyFitProject``` folder. Open the solution file to run the project. We have organized the files into the following structure:

> _note: <br>if something is not mentioned in the following list, it probably means that it already came with the framwework and we haven't changed anything ourselves_

### Components
- [ ] _Layout_ contains the code for the navigation bar and UI elementst that are shared across the pages
- [ ] _Pages_ contains the individual webpages
- [ ] _Services_ contains the services which are used to fetch and add data from and to a certain table from the database
    - ```UserService.cs``` adds a new user to the database

### Data
- [ ] ```BuddyFitDbContext.cs``` creates the different models
- [ ] _Models_ contains C# classes that represent database table structures.

### SQL
- [ ] ```Create FitBuddy Complete``` is the file that creates the database entirely. It defines the different tables and inserts initial values, like the items for the store

### txt
- [ ] _FitBuddyDatabase_ explains the structure of database tables and their relationships

### wwwroot
- [ ] _Clothing_ contains the costumes
- [ ] _Food_ contains the food items
- [ ]  _Pets_ contains the images of the pets
- [ ] _PetWithClothes_ contains the images of pets wearing costumes <br>(currently not in use)

## Known Issues
- We know that sometimes running the project will take some time. This is due to the images that need to be loaded. No worries if it takes 15-25 seconds before the website appears.
- Logged out, but you're still on a page that's only accessible to logged in users? Simply refresh the site in your browser and you should be led back to the home screen.
- It may happen that the connection string to the database is incorrect. Follow the steps to fix this:
    1. Look up **SQL SERVER OBJECT EXPLORER** in Visual Studio 
    2. Go to **SQL Server** -> **(localdb)\MSSQLLocalDB(......)**
    3. Click on **Databases**
    4. Right-click on ```FitBuddy_Db``` and check out the **properties**
    5. The **properties** will appear on the bottom-right of your screen
    6. Go to ```Connection String``` and copy your connection string
    7. Go to the file [appsettings.json](https://git.science.uu.nl/jazzmex/introproject/-/blob/main/BuddyFitProject/appsettings.json) and replace the default connection string. <br> Make sure you paste the connection string in between the ```""```
    8. Run the website again, it should work now

## Contact Information
For any questions, please send an e-mail to:<br> j.s.zhang@students.uu.nl
