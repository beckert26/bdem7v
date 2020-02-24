import pytest
import System

#Tests if program can handle correct password
def test_check_password(grading_system):
    username = 'cmhbf5'
    password1 =  'bestTA'
    password2 = 'BESTTA'
    password3 = 'bestTA '
    assert grading_system.check_password(username,password1)==True and grading_system.check_password(username,password2)==False and grading_system.check_password(username,password3)==False
 
@pytest.fixture
def grading_system():
    gradingSystem = System.System()
    gradingSystem.load_data()
    return gradingSystem
