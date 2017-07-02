Feature: GradeScores

Scenario: Given Example
    Given Given the source file contains the following:
    | FirstName | Surname | Score |
    | TED       | BUNDY   | 88    |
    | ALLAN     | SMITH   | 85    |
    | MADISON   | KING    | 83    |
    | FRANCIS   | SMITH   | 85    |
    When the file is graded
    Then the destination file should contain the following:
    | Surname | FirstName | Score |
    | BUNDY   | TED       | 88    |
    | SMITH   | ALLAN     | 85    |
    | SMITH   | FRANCIS   | 85    |
    | KING    | MADISON   | 83    |

Scenario: Given Example With Upper And Lower Case
    Given Given the source file contains the following:
    | FirstName | Surname | Score |
    | Ted       | Bundy   | 88    |
    | Allan     | Smith   | 85    |
    | Madison   | King    | 83    |
    | Francis   | Smith   | 85    |
    When the file is graded
    Then the destination file should contain the following:
    | Surname | FirstName | Score |
    | Bundy   | Ted       | 88    |
    | Smith   | Allan     | 85    |
    | Smith   | Francis   | 85    |
    | King    | Madison   | 83    |
