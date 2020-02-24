import pytest
import System
import json
import User
import Student

#tests that check grades returns the proper grade
def test_check_grades(grading_system):
    grading_system.login('hdjsr7', 'pass1234')
    course='software_engineering'
    grades=grading_system.usr.check_grades(course)
    #assert grades[0][1]==100 and grades[1][1]==100
    assert grades[0]==['assignment1',100] and grades[1]==['assignment2', 100]

@pytest.fixture
def grading_system():
    gradingSystem = System.System()
    gradingSystem.load_data()
    return gradingSystem
