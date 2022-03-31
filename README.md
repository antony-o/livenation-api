# Introduction 
TODO: This project is a solution to the LiveNation technical test.
It aims to provide a basic api project to fulfill the test requirements.

<br/><br/><br/>

# Getting Started / Solution Notes
* The project is written using VS 2022 and .Net 6.
* The project has a Swagger UI at:  https://localhost:7092/swagger.
* I've added a postman collection in the postman folder for testing the endpoint.
 
## Prerequisites
* Unfortunately you will need VS 2022 to run this project as .Net 6 projects are only supported in VS 2022.

<br/><br/><br/>

# Technical Test Description

## The Solution:
Things we expect.
* TDD
* SOLID
* Clean code
* Clean maintainable code
* Caching, multiple requests to the same endpoint produce a cached response


## Requirements:
* Develop a .NET Web API that accepts a number range, applies a set of rules to each number in the range
* Returns the result as json
* Rules must be configurable and new rules easy to add
* Produce a summary showing how many times the following were output
    * Live
    * Nation
    * LiveNation
    * A number


## Rules:
* If no rule matches, then output the input number
* If the input number is a multiple of 3 then output “Live”
* If the input number is a multiple of 5 then output “Nation”
* If the input number is a multiple of 3 and 5 then output “LiveNation”


## Input:
1,20

## Expected Json Result:
```json
{
    "result": "1 2 Live 4 Nation Live 7 8 Live Nation 11 Live 13 14 LiveNation 16 17 Live 19 Nation",
    "summary": {
        "Live": "5",
        "Nation": "3",
        "LiveNation": "1",
        "Integer": "11"
    }
}
```

## When You’re done:
Send us your working Visual Studio solution either by drop box or github and give us the link, or zip it up and email it to us.






