import pytest
import System

#Tests that passwords don't have special characters
def test_check_password(grading_system):
    username = 'calyam'
    password1 =  '#yeet'
    assert grading_system.check_password(username,password1)==False
 
@pytest.fixture
def grading_system():
    gradingSystem = System.System()
    gradingSystem.load_data()
    return gradingSystem
