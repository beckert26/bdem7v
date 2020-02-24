import pytest
import System
import json
import User
import Student

#tests that assignment is submitted ontime
def test_check_ontime(grading_system):
    grading_system.login('hdjsr7', 'pass1234')
    sub_date1='01/02/20'
    sub_date2='01/02/99'
    due_date='01/07/20'
    assert grading_system.usr.check_ontime(sub_date1,due_date)==True and grading_system.usr.check_ontime(sub_date2,due_date)==False

@pytest.fixture
def grading_system():
    gradingSystem = System.System()
    gradingSystem.load_data()
    return gradingSystem
