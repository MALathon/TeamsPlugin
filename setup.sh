#!/bin/bash

# Create necessary directories
mkdir -p src/modules/launcher/Plugins/Microsoft.PowerToys.Run.Plugin.Teams/Images
mkdir -p src/modules/launcher/Plugins/Microsoft.PowerToys.Run.Plugin.Teams.UnitTests
mkdir -p .github/workflows
mkdir -p nuget-local-feed

# Copy PowerToys DLLs if needed
if [ ! -f "nuget-local-feed/Wox.Plugin.dll" ]; then
    echo "Copying PowerToys DLLs..."
    cp "$LOCALAPPDATA/Microsoft/PowerToys/Wox.Plugin.dll" nuget-local-feed/
fi

# Create .gitignore if it doesn't exist
if [ ! -f ".gitignore" ]; then
    echo "Creating .gitignore..."
    cat > .gitignore << 'EOL'
## .NET
bin/
obj/
*.user
*.suo
*.userprefs
*.lock.json
.vs/

## Visual Studio Code
.vscode/*
!.vscode/settings.json
!.vscode/tasks.json
!.vscode/launch.json
!.vscode/extensions.json

## Build results
[Dd]ebug/
[Rr]elease/
x64/
build/
[Bb]in/
[Oo]bj/

## Local NuGet Feed
nuget-local-feed/
EOL
fi

# Build the solution
echo "Building solution..."
dotnet restore
dotnet build

# Run tests
echo "Running tests..."
dotnet test

echo "Setup complete!"