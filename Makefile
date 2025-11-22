dd.PHONY: clean build rebuild

# Default configuration
CONFIG ?= Debug
FRAMEWORK ?= net10.0
VERBOSITY ?= minimal

clean:
	find Api Application Domain Infrastructure -type d \( -name "obj" -o -name "bin" \) -exec rm -rf {} +
	dotnet clean Acide.Perucontrol.sln

build:
	dotnet build Acide.Perucontrol.sln --configuration $(CONFIG) --framework $(FRAMEWORK) --verbosity $(VERBOSITY) $(ARGS)

rebuild: clean build

run:
	dotnet watch run --project Web --configuration $(CONFIG) --framework $(FRAMEWORK) $(ARGS)

rerun: clean run

ef-add:
	dotnet ef migrations add "$(NAME)" --project Infrastructure --startup-project Api

ef-update:
	dotnet ef database update --project Infrastructure --startup-project Api

ef-drop:
	dotnet ef database drop  --project Infrastructure --startup-project Api

ef-reset: ef-drop ef-update

fmt:
	dotnet csharpier format .
