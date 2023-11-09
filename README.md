# 12FactorMicroservicePolley
This C# application a implements an API call to the Mapquest API in a microservice architecture, trying to follow at least 8 of the 12 factors highlighted on https://12factor.net/

To start the service, docker runtime needs to be available. Then you just need to run the command "docker compose up" in the folder that the compose.yaml file resides in. If you want
to change any variables (DB Connection Data), you can do that manually in the compose.yaml file via the given Environment Variables.

After starting the container, the service can accessed by sending a request to http://localhost:40080/. Port can differ, if it is changed in the compose.yaml file.

## Currently implemented features:
### GetRouteData
#### Parameters:<br>
	start: start location as a string<br>
	end: target location as a string

Example request: http://localhost:40080/GetRouteData?start=Wien&end=Eisenstadt
