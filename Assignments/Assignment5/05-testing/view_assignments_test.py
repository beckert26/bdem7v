import pytest
import System
import json
import User
import Student

#tests that view assignments reuturns the correct assignment info
def test_view_assignments(grading_system):
    grading_system.login('hdjsr7', 'pass1234')
    course='databases'
    assignments= grading_system.usr.view_assignments(course)
    assert assignments[0]==['assignment1',"1/6/20"] and assignments[1]==['assignment2','2/6/20']
    
@pytest.fixture
def grading_system():
    gradingSystem = System.System()
    gradingSystem.load_data()
    return gradingSystem
