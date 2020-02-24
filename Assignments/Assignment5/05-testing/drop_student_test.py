import pytest
import System
import json
import User
import Staff
import Professor
import os

#tests that professor can properly drop student
def test_drop_student(grading_system):
    name='hdjsr7'
    course="databases"
    grading_system.login('goggins', 'augurrox')
    grading_system.usr.drop_student(name,course)
    os.getcwd()
    path=os.getcwd()+"/Data/users.json"
    with open(path) as json_file:
        data=json.load(json_file)
        assert 'databases' not in data[name]['courses']

@pytest.fixture
def grading_system():
    gradingSystem = System.System()
    gradingSystem.load_data()
    return gradingSystem
