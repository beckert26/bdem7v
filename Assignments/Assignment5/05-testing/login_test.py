import pytest
import System
import Student
import os
import json

#tests that the correct user is created

#TA question how do we verify the correct user
def test_login(grading_system):
    username = 'akend3'
    password =  '123454321'
    grading_system.login(username,password)
    path=os.getcwd()+"/Data/users.json"
    with open(path) as json_file:
        data=json.load(json_file)
        assert grading_system.usr.name=='akend3' and grading_system.usr.password=='123454321' and grading_system.usr.courses==data[username]['courses'] and grading_system.usr.all_courses==grading_system.courses and grading_system.usr.users==grading_system.users and type(grading_system.usr)==Student.Student

@pytest.fixture
def grading_system():
    gradingSystem = System.System()
    gradingSystem.load_data()
    return gradingSystem
