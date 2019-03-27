### Setting up the project:

Before start the project you need to configure environment:

- In "appsettings.json" setup "DefaultConnection" for your SQLEXPRESS instance. The file located in "PersonManager/backend/PM.Web/appsettings.json"
- Build Backend solution. Visual Studio have to install all backend dependencies.
- Open package manager console and type this command "Update-database". This command will create a database and apply all migrations.
- Open your cmd and go to the "frontend" folder located in "PersonManager/Frontend" and do this command. 
- 
```sh
$ npm install -d
```

- After installation will be finished you need to build frontend using this command.

```sh
$ ng build --watch
```

- Run the server using Visual Studio.

After this steps website will be opened in your browser.