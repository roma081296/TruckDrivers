# TruckDrivers
Return Drivers Name Located in specific Location.


Create a REST API to GET a list of truck drivers.
Requirements:
• The API should accept one parameter:
o Location (city where the driver is located)
• The API response should be a list of truck drivers.
o The response should at least contain the first and last name of the drivers as well
as the location
o Status code 200 if everything is ok, 404 if no driver was found and 500 if an error
occurred

• The controller uses a service to get the actual data
o Use Dependency Injection to inject the service.
o There should be a unit test to test the service
• The API should be accessible via Swagger UI
• Bonus features
o Logging
