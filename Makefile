Configuration ?= Release
DotNetExe = dotnet

.DEFAULT_GOAL := test

all: clean build test pack

clean:
	$(DotNetExe) clean

build:
	$(DotNetExe) build -c $(Configuration)

test: build
	$(DotNetExe) test --no-build -c $(Configuration)

pack: build
	$(DotNetExe) pack --no-build -c $(Configuration)