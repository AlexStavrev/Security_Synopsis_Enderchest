# Security_Synopsis_Enderchest
## Project Setup:
MsSQL Database named Enderchest is needed which can be created using the provided SQL Scripts in the repository files.

## Web API Config
To run the Web API, a secret JWT key is required. This is stored in .NET user secrets and is unique for everyone.
To add that user secrets run those commands in the project terminal (E.g. VS Terminal)
1) `dotnet user-secrets init --project WebAPI`
2) `dotnet user-secrets set "JWTSecretKey" "<key-value>" --project WebAPI`

Key value (<key-value>) has to be a secure key (string) and can easily be generated using git bash for example
Git Bash command:  `openssl rand -base64 32`

## Running the project
The project requires the database, the WebAPI and the UI to be running. The UI is created in Winforms, making it possible to run it only on Windows machines.
In case of failure to connect to the database, the connection string in `WebAPI/appsettings.Development.json` on line 9 can be changed to `    "DefaultConnection": "Data Source=.;Initial Catalog=EnderChest;Integrated Security=True;"`
