Feature: All requests and responses should be a correct data

    Scenario: Request to https://jsonplaceholder.typicode.com/users should return 200 status code
        Given a request url https://jsonplaceholder.typicode.com/users
        When a GET request has been sent
        Then the response code should equals 200

    Scenario: The request data should equal to one previously saved to the file 'data.json'
        Given a request url https://jsonplaceholder.typicode.com/users
        And a file data.json
        When a GET request has been sent
        Then the response data and data from file should be identical
        
    Scenario: Verify that a given name is in the array of Users
        Given a request url https://jsonplaceholder.typicode.com/users
        When a user with the name Leanne Graham
        Then he/she should be in the given array
        
    Scenario: Verify that requested array matching schema
        Given a file data.json
        When data has been read
        Then the response array should match schema