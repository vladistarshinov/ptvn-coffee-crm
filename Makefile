#Project Variables
PROJECT_NAME ?= CoffeeCrmApp
ORG_NAME ?= CoffeeCrmApp
REPO_NAME ?= CoffeeCrmApp

.PHONY: migrations db

migrations: 
	cd ./CoffeeCrmApp.DAL && dotnet ef --startup-project ../CoffeeCrmApp.WEB/ migraions add $(mname) && cd ..

db: 
	cd ./CoffeeCrmApp.DAL && dotnet ef --startup-project ../CoffeeCrmApp.WEB/ database update && cd ..

