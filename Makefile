SOURCE_DIRECTORY := $(dir $(realpath $(lastword $(MAKEFILE_LIST))))

Configuration ?= Release
Output ?= "$(SOURCE_DIRECTORY)artifacts"
NUGET_SOURCE ?= "https://api.nuget.org/v3/index.json"
NUGET_API_KEY ?= ""

all: clean build test pack

clean:
	dotnet clean && rm -rf $(Output)

build:
	dotnet build -c $(Configuration)

test: build
	dotnet test --no-build -c $(Configuration)

pack: test
	dotnet pack --no-build -c $(Configuration) -o $(Output)

push: pack
	for nupkg in `ls $(Output)/*.nupkg`; do \
		dotnet nuget push $$nupkg -s $(NUGET_SOURCE) -k $(NUGET_API_KEY); \
	done

.DEFAULT_GOAL := test
