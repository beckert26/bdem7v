import pytest
import System
import json
import User
import Staff
import os

#tests that grade has been properly changed
def test_change_grade(grading_system):
    grading_system.login('cmhbf5', 'bestTA')
    user='yted91'
    course='software_engineering'
    assignment='assignment1'
    grade=75
    grading_system.usr.change_grade(user,course, assignment, grade)
    os.getcwd()
    path=os.getcwd()+"/Data/users.json"
    with open(path) as json_file:
        data=json.load(json_file)
        assert data[user]['courses'][course][assignment]['grade']==75

@pytest.fixture
def grading_system():
    gradingSystem = System.System()
    gradingSystem.load_data()
    return gradingSystem
