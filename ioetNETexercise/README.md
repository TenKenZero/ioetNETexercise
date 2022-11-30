# IOET .NET Core Software Developer - Coding exercise

Author: Lenin Carrasco Aponte
Date: 30/11/2022

**OVERVIEW**
This application was developed as a coding exercise for a recruiting process for a .NET developer.
It calculates the total payment amount for each worker from a given list based on the number of
worked hours and the hourly fee according to this table:

Monday - Friday
00:01 - 09:00 = 25 USD
09:01 - 18:00 = 15 USD
18:01 - 00:00 = 20 USD

Saturday and Sunday
00:01 - 09:00 = 30 USD
09:01 - 18:00 = 20 USD
18:01 - 00:00 = 25 USD

**INPUT**
This should be a .txt file given as parameter at the execution of the program (File's fullpath).
The file should contain one or several lines containing the name of the employees and the schedule 
they worked, indicating the days and hours.
For example:
RENE=MO10:00-12:00,TU10:00-12:00,TH01:00-03:00,SA14:00-18:00,SU20:00-21:00
ASTRID=MO10:00-12:00,TH12:00-14:00,SU20:00-21:00

**INPUT CONSTRAINTS**
* If the input file is not specified at the execution of the program, a default file will be used (data.txt).
* There should be no blank spaces in the lines
* The name of the employee must be followed by the symbol "="
* An employee can work over two shifts in a row, as long as the first worked shift not be the last 
available shift in the day (third daily shift). It means an employee can't work from one day to another.
* An employee can't work three shifts in a row
* If a day is not in the proper format, its hours won't be counted

**OUTPUT:**
* Total worked hours by employee
* How much the employee has to be paid

**COMPILING INSTRUCTIONS:**
Download the project from the repository
Open the 'ioetNETexercise.sln' file with Visual Studio (.NET 6.0)
Compile the project or solution. A copy of 'data.txt' and 'README.md' files will be copied in the output folder

**EXECUTING INSTRUCTIONS**
Once compiled, you can execute the program through either Visual Studio or the compiled file.

**Executing the compiled file:**
You should execute the program following by the full path and name of the input file.
"C:\User > <Output Directory>\ioetNETexercise.exe <File Directory>\<File Name>.txt"
Or without input file
"C:\User > <Output Directory>\ioetNETexercise.exe"

For example:
"C:\User > C:\Users\User\Documents\ioetNETexercise\ioetNETexercise.exe C:\Users\Lenin\Documents\data.txt"
Or
"C:\User > C:\Users\User\Documents\ioetNETexercise\ioetNETexercise.exe"

**Executing with Visual Studio:**
Just execute the project with the F5 key.
Optionally could set the full path and name of the input file in the Debugging options.

**EXPLANATION OF THE SOLUTION**
**Architecture:**
The main execution is in the 'Program.cs' file. It receives the input file and creates Employee objects
to calculate and show their total amounts.
**Models:**
There is a class Shift (Shift.cs) used as a data model to create and keep shift objects (Needs: Day 
(Working or weekend day), starting hour, ending hour, fee per hour)
The main object is the class Employee (Employee.cs) which contains the data model to create 
Employee objects.
**Services:**
The EmployeeService class has the functions to calculate the total worked hours and the total 
payment amount per Employee.

**Approach:**
The solution was developed following the SOLID principles for Object Oriented Programming.
The classes Employee and Shift are used as data models to structure objects.
The calculus operations are made by a service class, following the principle of single responsibility