# Project Variables
PROJECT_NAME ?= SolarCoffee
ORG_NAME ?= SolarCoffee
REPO_NAME ?= SolarCoffee

.PHONY: migrations db

migrations: 
	cd ./SolarCoffe.Data && dotnet ef --startup-project ../SolarCofee.Web/ migrations add $(mname) && cd ..

db:
	cd./SolarCoffee.Data && dotnet ef --startup-project ../SolarCoffee.Web/ database update && cd ..
