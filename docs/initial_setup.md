# Selecting Project Architechture

## Primary Architechture 

As primary architechture we are following modular-monolithic architechture to build the backend of this project, so that it can be easily converted into microservice architechture if the user base is increases.

Below modules we have found which we can develop separately

- User Module
- Solve Review Module
- Dashboard Module
- Admin Module

## Secondary Architechture and Patterns

We have found that if the coupling is less and dependency is one way it create a great impact on the application that we will develop, like it increases code maintainability, and concern of separation. For this we have choose `clean-architechture` to be maintain in each module with `repository-pattern`. And to communicate with each module we will be using `event-driven-architechture`.

## Setting up Backend and Folder Structure

```bash
dotnet new webapi -o backend
```

```bash
/backend
├── Properties
│   └── launchSettings.json
├── backend.csproj
├── bin
│   └── Debug
├── build
├── obj
│   └── Debug
├── src
│   ├── API
│   └── Modules
│       ├── Admin
│       ├── Dashboard
│       ├── SolveReview
│       └── Users
└── tests
```

## Setting up Frontend and Folder Structure

```bash
npm create vite@latest frontend -- --template react
```

```bash
/frontend
├── eslint.config.js
├── index.html
├── node_modules
├── package-lock.json
├── package.json
├── public
├── src
└── vite.config.js
```

