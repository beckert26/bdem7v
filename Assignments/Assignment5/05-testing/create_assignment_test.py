import pytest
import System
import json
import User
import Staff
import os

#tests that assignment has been properly created
def test_create_assignment(grading_system):
    grading_system.login('cmhbf5', 'bestTA')
    assignment_name='assignment3'
    due_date='04/01/20'
    course='cloud_computing'
    grading_system.usr.create_assignment(assignment_name, due_date, course)
    os.getcwd()
    path=os.getcwd()+"/Data/courses.json"
    with open(path) as json_file:
        data=json.load(json_file)
        assert assignment_name in data[course]['assignments'] and due_date in data[course]['assignments'][assignment_name]['due_date']

@pytest.fixture
def grading_system():
    gradingSystem = System.System()
    gradingSystem.load_data()
    return gradingSystem
