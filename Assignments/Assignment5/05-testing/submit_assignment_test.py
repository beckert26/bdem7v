import pytest
import System
import json
import User
import Student
import os

#tests that student can properly submit assignment
def test_submit_assignment(grading_system):
    grading_system.login('hdjsr7', 'pass1234')
    course='cloud_computing'
    assignment_name='assignment1'
    submission='Blahhhhh'
    submission_date='03/01/20'
    grading_system.usr.submit_assignment(course, assignment_name, submission, submission_date)
    os.getcwd()
    path=os.getcwd()+"/Data/users.json"
    with open(path) as json_file:
        data=json.load(json_file)
        assert data[grading_system.usr.name]['courses'][course][assignment_name]['submission']=='Blahhhhh' and data[grading_system.usr.name]['courses'][course][assignment_name]['submission_date']=='03/01/20' and data[grading_system.usr.name]['courses'][course][assignment_name]['ontime']==False

@pytest.fixture
def grading_system():
    gradingSystem = System.System()
    gradingSystem.load_data()
    return gradingSystem
