Configuration ?= Release
.DEFAULT_GOAL := test

all: clean build test pack

clean:
	dotnet clean

build:
	dotnet build -c $(Configuration)

test: build
	dotnet test --no-build -c $(Configuration)

pack: build
	dotnet pack --no-build -c $(Configuration)