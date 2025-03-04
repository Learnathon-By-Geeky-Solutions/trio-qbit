# Team Trio_Qbit

## Project Name - `CodeRev`

The `CodeRev` is a web-based application designed to help programmers improve their **problem-solving** skills by tracking their habits, analyzing their `consistency`, and `prioritizing` problems for review. The platform encourages mastery over quantity by providing personalized recomendations for solve review, visualizing progress, and maintaining learning streaks. Users can log problem-solving details, track their coding journey through interactive dashboards, and receive insights on their strengths and areas for improvement. An admin panel enables monitoring of user activities and system analytics, ensuring smooth operation and engagement.

## Prerequisite

- .NET 9.0 Installed [here..](https://dotnet.microsoft.com/en-us/download)
- Docker Installed
    - [For Mac](https://docs.docker.com/desktop/setup/install/mac-install/)
    - [For Windows](http://docs.docker.com/desktop/setup/install/windows-install/)
    - [For Linux Ubuntu](http://docs.docker.com/engine/install/ubuntu/)
- Node Installed [using nvm](https://heynode.com/tutorial/install-nodejs-locally-nvm/)

## Get Started 

1. Clone the repository

```bash
git clone https://github.com/Learnathon-By-Geeky-Solutions/trio-qbit.git

```
2. Add this packages after directing to `trio-qbit` directory

```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL # because of PostGreSQL
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Swashbuckle.AspNetCore # for Swagger support 
dotnet add package Newtonsoft.Json # for Serialize string[] to JSON and Deserialize JSON to string[]
```
3. Add a `<name>.env` file into `/backend/db` directory with below contents

```env
POSTGRES_USER=<user_name>
POSTGRES_PASSWORD=<password>
POSTGRES_DB=<database_name>
POSTGRES_HOST=<host_name>
POSTGRES_PORT=<port>
```
4. Build and Run the **docker** `images` outof `docker-compose.yml` file in `/backend/db` directory

```bash
docker-compose --env-file <name>.env up -d --build
```
5. Now run the application backend after returning to `/backend` directory

```bash
dotnet watch run
```
6. Open-up a new terminal and run the database migration 

```bash
dotnet ef migrations add <migration_name> -c <context_name> -o <absolute_path_of_the_folder>
dotnet ef database update -c <context_name>
```
7. You can verify database table `Solves` by entering into the `docker-container`


**Note:** This **get-started** steps are not fully completed. As far now you can just `test` the `SolveReview` modules `/solve/add` end point of our project. And validations also not added.

## Resources

- [Initial Setup](./docs/initial_setup.md) 

## References

- [To understand .NET Core (REST Apis, CRUD, Folder Structures)](https://www.youtube.com/playlist?list=PL82C6-O4XrHfrGOCPmKmwTO7M0avXyQKc)

- [To understand .NET Core Authentication and Authorization](https://www.youtube.com/playlist?list=PLOeFnOV9YBa4yaz-uIi5T4ZW3QQGHJQXi)
- [To understand Unit Testing in .NET Core](https://www.youtube.com/watch?v=NSGy8nkTiyQ)
- [To understand clean architechture](https://www.youtube.com/watch?v=1OLSE6tX71Y)
