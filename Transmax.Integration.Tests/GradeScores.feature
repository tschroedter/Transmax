# Todo missing column, line with text ==> can't do it here because SpecFlow detects illegal table format
# Todo add code to use real testdata files

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

Scenario: Given Example With One Score Missing
    Given Given the source file contains the following:
    | FirstName | Surname | Score |
    | Ted       | Bundy   | 88    |
    | Allan     | Smith   | 85    |
    | Madison   | King    | 83    |
    | Francis   | Smith   | 85    |
    | Joe       | Cool    |       |
    When the file is graded
    Then the destination file should contain the following:
    | Surname | FirstName | Score       |
    | Bundy   | Ted       | 88          |
    | Smith   | Allan     | 85          |
    | Smith   | Francis   | 85          |
    | King    | Madison   | 83          |
    | Cool    | Joe       | -2147483648 |

Scenario: Given Example With One Score Invalid
    Given Given the source file contains the following:
    | FirstName | Surname | Score |
    | Ted       | Bundy   | 88    |
    | Allan     | Smith   | 85    |
    | Madison   | King    | 83    |
    | Francis   | Smith   | 85    |
    | Joe       | Cool    | abcde |
    When the file is graded
    Then the destination file should contain the following:
    | Surname | FirstName | Score       |
    | Bundy   | Ted       | 88          |
    | Smith   | Allan     | 85          |
    | Smith   | Francis   | 85          |
    | King    | Madison   | 83          |
    | Cool    | Joe       | -2147483648 |

