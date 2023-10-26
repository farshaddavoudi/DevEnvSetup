# **_DevEnvSetup:_** My Personal Windows Development Environment Toolkit

Welcome to DevEnvSetup, a repository designed to automate the setup of my personal Windows development environment. While Initially created to fulfill my own needs, I'm sharing it here because I wanted to provide a comprehensive solution and assist others in configuring their development environments.

## What's Included:

**Chocolatey-Powered Installation**: DevEnvSetup includes scripts for installing a curated set of essential applications on Windows using the *Chocolatey Package Manager*. This ensures that I have the tools I need for coding without the manual hassle. This includes a wide range of applications such as Visual Studio, MSSM, VS Code, Notepad++, .NET SDKs and Runtimes, MongoDBCompass, pgAdmin4, Docker Desktop, git, Postman, and many more.

**Docker Compose Configuration**: I've also included Docker Compose configurations for orchestrating various services such as Redis, PostgreSQL, MongoDB, Seq and RabbitMQ, simplifying container-based development and testing.

## Getting Started:

### Chocolatey Installation:
For using Chocolatey to install essential applications, please follow these steps:

1. Visit the [Chocolatey Package Manager website](https://chocolatey.org/) to install Chocolatey if you haven't already.
2. After Chocolatey is installed, open your *PowerShell* in Administrator mode and follow the instructions below to install all the required packages you see in the included file. You can customize the package list to match your preferences.

   ```shell
   choco install package1
   choco install package2
   ...
   ```
### Docker Compose Setup:
For setting up Docker Compose and managing the Docker-based services, you can do the following:

1. If you followed the Chocolatey installation instructions above, *Docker Desktop* should already be installed.
2. To orchestrate and start the services defined in the Docker Compose file, use the following command:

  ```shell
   docker-compose up -d
   ```

> ### 💡 Change of Resources (maximum CPU/Memory allocation) for Docker Desktop WSL2 on Windows:
> First of all, Docker Desktop uses the dynamic memory allocation feature in WSL 2 to improve resource consumption. This means Docker Desktop only uses the required amount of CPU and memory resources it needs, while allowing CPU and memory-intensive tasks such as building a container, to run much faster. But there are some limits imposed for maximum system CPU/Memory usage of Docker Desktop which are changing in different versions.
>
> Here we cannot change the Docker Desktop settings as it is limited by the WSL2 resources, so instead we have to change the WSL2 resources.
To do it, just change the ``` .wslconfig ``` as you wish and put it in the ``` %UserProfile% ``` directory (which WSL2 can use by convention). shutdown the WSL2 (``` wsl --shutdown ```) and after 10 seconds, start it again and you are good to go.
>
> ### 💡 Fixing Redis WARNING Memory Overcommit Issue on [Stack Overflow](https://stackoverflow.com/a/77345711/6581893)


Feel free to customize the Docker Compose file to add or remove services as needed.


You are welcome to fork, customize, or use this repository as a reference for your own development environment setup. Your feedback and contributions are welcome!
