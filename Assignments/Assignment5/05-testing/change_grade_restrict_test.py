import pytest
import System
import json
import User
import Staff
import os

#tests that grade can't be changed by a TA who doesn't TA the course
def test_change_grade(grading_system):
    grading_system.login('cmhbf5', 'bestTA')
    user='hdjsr7'
    course='databases'
    assignment='assignment1'
    grade=0
    grading_system.usr.change_grade(user,course, assignment, grade)
    os.getcwd()
    path=os.getcwd()+"/Data/users.json"
    with open(path) as json_file:
        data=json.load(json_file)
        assert data[user]['courses'][course][assignment]['grade']==100

@pytest.fixture
def grading_system():
    gradingSystem = System.System()
    gradingSystem.load_data()
    return gradingSystem
