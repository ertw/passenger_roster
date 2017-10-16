## Passenger Roster

This is a toy CRUD application for learning ~~Microsoft product names~~ C# on dotnet Core 2.0 with ASP.net MVC. I also got a chance to practice test driven development with Xunit, learn about the repository pattern for database access with Entity Framework, get my VPS and Docker configurations dialed in, and practice test driven development with Xunit.

##### Tools:
* Docker, Docker Swarm, Alpine Linux, CoreOS Container Linux
* C# 6.0, dotnet Core 2, Postgres, Entity Framework Core, shell scripts

##### Project requirements:
Build a cruise line passenger management system.
* Store passenger number, first name, last name, and phone number;
* Allow users to create, read, update and delete passengers;
* Frontend doesn't need to pretty, just make it work.

#### Status
Basic JSON API
- [x] Implement create
- [x] Implement read
- [x] Implement read all
- [ ] Implement update
- [ ] Implement delete

Persistant storage
- [x] Connect to Postgres
- [x] Add Entity Framework
- [x] Implement repository pattern
- [x] Add Automapper

Frontend
- [ ] Implement landing page
- [ ] Implement create
- [ ] Implement read by ID
- [ ] Implement read all
- [ ] Implement update
- [ ] Implement delete

Testing
- [x] Add Xunit
- [x] Test create
- [ ] Test read
- [ ] Test read All
- [ ] Test update
- [ ] Test delete

Devops
- [x] Configure env vars for creds
- [x] Dockerize dotnet core sdk
- [x] Set up continuous build for dev
- [x] Configure Docker Stack for production
- [ ] Write development documentation
- [ ] Dockerize dotnet core production
- [ ] Set up continuous build for production
- [ ] Configure Docker Stack for production
- [ ] Write deployment documentation

## Development setup
Clone the repo:

`git clone`

Run the Docker stack:


...there will be some included shell script for this...
