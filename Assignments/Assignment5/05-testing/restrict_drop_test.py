import pytest
import System
import json
import User
import Staff
import Professor
import os

#tests that professor that doesn't teach course can't drop student
def test_drop_student(grading_system):
    grading_system.login('saab', 'boomr345')
    name='hdjsr7'
    course="databases"
    grading_system.usr.drop_student(name,course)
    os.getcwd()
    path=os.getcwd()+"/Data/users.json"
    with open(path) as json_file:
        data=json.load(json_file)
        assert 'databases' in data[name]['courses']

@pytest.fixture
def grading_system():
    gradingSystem = System.System()
    gradingSystem.load_data()
    return gradingSystem
