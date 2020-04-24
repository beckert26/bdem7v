import pytest
import System
import json
import User
import Staff
import Professor
import os

#tests create assignment can't overwrite a due date of  a current assignment with the same name
def test_add_assignment_duplicate(grading_system):
    grading_system.login('cmhbf5', 'bestTA')
    assignment_name='assignment1'
    due_date="04/05/20"
    course='databases'
    os.getcwd()
    path=os.getcwd()+"/Data/courses.json"
    with open(path) as json_file:
        data=json.load(json_file)
        if assignment_name in data[course]['assignments'] :
            original_due_date=data[course]['assignments'][assignment_name]['due_date']
            grading_system.usr.create_assignment(assignment_name, due_date, course)
    os.getcwd()
    path=os.getcwd()+"/Data/courses.json"
    with open(path) as json_file:
        data=json.load(json_file)
        assert original_due_date in data[course]['assignments'][assignment_name]['due_date']

@pytest.fixture
def grading_system():
    gradingSystem = System.System()
    gradingSystem.load_data()
    return gradingSystem
