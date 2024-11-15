#!/bin/bash

# Detect if we're in WSL
if grep -qi microsoft /proc/version; then
    echo "WSL detected, using Windows dotnet..."
    DOTNET="/mnt/c/Program Files/dotnet/dotnet.exe"
else
    echo "Using local dotnet..."
    DOTNET="dotnet"
fi

# Build the solution
"$DOTNET" build PowerToys-Run-Teams-Plugin.sln

# Run tests if requested
if [ "$1" = "test" ]; then
    "$DOTNET" test PowerToys-Run-Teams-Plugin.sln
fi 