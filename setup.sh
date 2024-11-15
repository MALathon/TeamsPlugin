#!/bin/bash

# Create the PowerToys plugin directory structure
mkdir -p src/modules/launcher/Plugins/Microsoft.PowerToys.Run.Plugin.Teams/{Images,Properties}
mkdir -p src/modules/launcher/Plugins/Microsoft.PowerToys.Run.Plugin.Teams.UnitTests

# Create GitHub Actions directory
mkdir -p .github/workflows

# Create initial files
touch .gitignore
touch README.md
touch src/modules/launcher/Plugins/Microsoft.PowerToys.Run.Plugin.Teams/DynamicPlugin.props
touch src/modules/launcher/Plugins/Microsoft.PowerToys.Run.Plugin.Teams/plugin.json
touch src/modules/launcher/Plugins/Microsoft.PowerToys.Run.Plugin.Teams/Main.cs
touch src/modules/launcher/Plugins/Microsoft.PowerToys.Run.Plugin.Teams/Properties/AssemblyInfo.cs

# Initialize git repository
git init

# Download Teams icons (you'll need to replace these URLs with actual icon URLs)
curl -k -o src/modules/launcher/Plugins/Microsoft.PowerToys.Run.Plugin.Teams/Images/teams.dark.png "https://raw.githubusercontent.com/microsoft/PowerToys/main/src/modules/launcher/Plugins/Microsoft.PowerToys.Run.Plugin.Teams/Images/teams.dark.png"
curl -k -o src/modules/launcher/Plugins/Microsoft.PowerToys.Run.Plugin.Teams/Images/teams.light.png "https://raw.githubusercontent.com/microsoft/PowerToys/main/src/modules/launcher/Plugins/Microsoft.PowerToys.Run.Plugin.Teams/Images/teams.light.png" 