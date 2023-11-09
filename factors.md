## Fullfilled factors (amount: 8):
#### I. Codebase - One codebase tracked in revision control, many deploys:
Codebase tracked via Git repository (Link: https://github.com/Bigpolshark/12FactorMicroservicePolley)

#### II. Dependencies - Explicitly declare and isolate dependencies
Dependency injection is used for DataLayer and BusinessLayer implemenations

#### III. Config - Store config in the environment
Control environment variables for DB Connection Data and the API key via the docker compose

#### IV. Backing services - Treat backing services as attached resources
Database is easily swapable by changing the DB Connection Data defined in the dockerfile. Different API  providers would need to be tested, 
but could also be replaced in the same manner, if they are implemented in the solution.

#### V. Build, release, run - Strictly separate build and run stages
The Microservice is Build locally. Afterwards it is released by publishing the image on dockerhub (image: bigpolshark/image12factormicroservicepolley:latest). 
The Run stage is initialized by running the command "docker compose up" using the docker-compose.yml

#### VI. Processes - Execute the app as one or more stateless processes
The devloped Microservice is stateless. Information about previous calls is saved in a database to reduce redundant API calls.

#### VII. Port binding - Export services via port binding
The port binding is handled via Docker, binding open ports on the host to open ports on the container. Port 80 (http) and 443 (https) are used in the 
container (defined in Dockerfile). The port binding on the host site is: 40080:80 and 40443:443, as defined in the docker-compose.yaml.

#### XI. Logs - Treat logs as event streams
Logs are outputted to the standard output


## Potential factors (amount: 1):
#### X. Dev/prod parity - Keep development, staging, and production as similar as possible
Because the process is simple, and there is no real split of Dev/Prod environment for this service, this Factor should be fullfilled, as the same 
backing services are used throughout every step.


## Unused/Unsure factors (amount: 3):
#### VIII. Concurrency - Scale out via the process model
Because the microservice is simple, using workers for long running processes was not considered

#### IX. Disposability - Maximize robustness with fast startup and graceful shutdown
Docker should gracefully shuts down the web portion, but the BusinessLogic is not explicitly handled 

#### XII. Admin processes - Run admin/management tasks as one-off processes
Because the microservice is simple, admin procceses are not considered















