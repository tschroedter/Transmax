# Transmax
Transmax Assessment

Requirements Test for Software Developers

May be completed in C# or C++ language


Write a console app that:

* Takes as a parameter a string that represents a text file containing a list of names, and their scores
* Orders the names by their score. If scores are the same, order by their last name followed by first name
*	Creates a new text file called <input-file-name>-graded.txt with the list of sorted score and names.
*	Takes a CSV input file with the format of First Name, Surname, Score
*	Output file format is CSV with the format of Surname, First Name, Score

Example, if the input file (students.txt) contains:

TED, BUNDY, 88

ALLAN, SMITH , 85

MADISON , KING, 83

FRANCIS, SMITH, 85


Then the output file (students-graded.txt) would be:

BUNDY, TED, 88

SMITH, ALLAN, 85

SMITH, FRANCIS, 85

KING, MADISON, 83

Assessment

*	Your solution should meet the above requirements.
*	Unit tests should exist.
*	The solution should be hosted on services like https://github.com
*	Compile and unit tests should run automatically on check-in via a CI service like http://www.appveyor.com
*	Code should meet appropriate SOLID programing principles https://en.wikipedia.org/wiki/SOLID_(object-oriented_design)

Submission

*	URL link to publicly viewable code repository, or provide details to access code
*	URL link to results or screen shot of unit tests running with results  

Assumptions

*	Application should be able to handle relative and full paths file inputs
*	Output file should be in the same folder as the input file
*	Text ordering should be case-insensitive
*	The application name should be grade-scores.exe
*	Exceptions should be handle appropriately, (Candidate to defined what is appropriate)
*	Only output to the console when complied in a debug mode.
*	Tests should be concise and appropriate
*	Sorting source should be descending order
*	Sorting names should be ascending order

