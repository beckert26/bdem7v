import pytest
import System
import json
import User
import Staff
import Professor
import os

#tests that professor can properly add student to a course
def test_add_student(grading_system):
    grading_system.login('goggins', 'augurrox')
    name='yted91'
    course='databases'
    grading_system.usr.add_student(name,course)
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
