# DevEnvSetup: My Personal Windows Development Environment Toolkit

Welcome to DevEnvSetup, a repository designed to automate the setup of my personal Windows development environment. While initially created for my own needs, I'm sharing it here because I wanted to have it in one integrated place and to assist others in configuring their development environments.

# What's Included:

**Chocolatey-Powered Installation**: DevEnvSetup includes scripts for installing a curated set of essential applications on Windows using the *Chocolatey Package Manager*. This ensures that I have the tools I need for coding without the manual hassle.

**Docker Compose Configuration**: I've also included Docker Compose configurations for orchestrating various services such as Redis, SQL Server, PostgreSQL, MongoDB, and RabbitMQ, simplifying container-based development and testing.

# Getting Started:

### Chocolatey Installation:
For using Chocolatey to install essential applications, please follow these steps:

1. Visit the [Chocolatey Package Manager website](https://chocolatey.org/) to install Chocolatey if you haven't already.
2. After Chocolatey is installed, open your *PowerShell* in Administrator mode and follow the instructions below to install all the required packages you see in the included file. You can customize the package list to match your preferences.

   ```shell
   choco install package1
   choco install package2
   ...
   ```

Feel free to fork, customize, or use this repository as a reference for your own development environment setup. Your feedback and contributions are welcome!
