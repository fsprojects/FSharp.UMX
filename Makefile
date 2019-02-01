SOURCE_DIRECTORY := $(dir $(realpath $(lastword $(MAKEFILE_LIST))))

Configuration ?= Release
Output ?= "$(SOURCE_DIRECTORY)/artifacts"
.DEFAULT_GOAL := test

all: clean build test pack

clean:
	dotnet clean && rm -rf $(Output)

build:
	dotnet build -c $(Configuration)

test: build
	dotnet test --no-build -c $(Configuration)

pack: build
	dotnet pack --no-build -c $(Configuration) -o $(Output)