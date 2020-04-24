import pytest
import System
import json
import User
import Staff
import Professor
import os

#tests that TAs can't see students grades if they aren't in a class they TA
#since 'cmhbf5 doesn't TA databases he should see the databases or comp_sci grade of the student
def test_check_grades_staff(grading_system):
    grading_system.login('cmhbf5', 'bestTA')
    name='akend3'
    course='databases'
    grades=grading_system.usr.check_grades(name, course)
    assert grades==[]

@pytest.fixture
def grading_system():
    gradingSystem = System.System()
    gradingSystem.load_data()
    return gradingSystem
