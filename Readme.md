# SmartEnroll
Smart Enroll System is a cutting-edge enrollment management tool crafted in C# to simplify user registration and authentication. It's a console program, making it user-friendly with straightforward login and registration features. You interact with it using simple keyboard inputs and outputs on your computer screen.

This application gives you a command-line interface to easily log in or register. When you successfully log in, a cool progress bar animation shows up. For registration, your details are safely stored in a CSV file. It's all about making things smooth and hassle-free!

## Table of Contents
- [Introduction](#smartenroll)
- [Features](#features)
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [Usage](#usage)
- [Reporting Bugs and Issues](#reporting-bugs-and-issues)
- [Contributing](#contributing)
- [License](#license)

### Features

**User Interface(UI)** - "MainBox" and "DrawTextBox" draw rectangular boxes on the console, with DrawTextBox specifically designed for text. While "SelectChoice" displays a menu, letting the user choose from given options with a message and status information.

**User Roles** - During registration, users have the option to specify their roles, such as "User" or "Admin."

**login Function** - Users can log in by entering their username and password, with password input being masked for security.

**Register Function** -  To register, users are required to input their first name, last name, and password. The registration details are then stored in a CSV file.

**Animate Progress Bar** - A progress bar animation is displayed upon successful login.

**Message and notifications** - Informative messages are presented for various scenarios, including successful login, incorrect passwords, and when a user is not found.

**ValidatingSection** - The application validates user credentials during login and checks for existing usernames during registration.

**file management** -  The program reads a CSV file ("users.csv") to confirm the existence of a username and validate the entered password for a given username. 

### Prerequisites

Microsoft.VisualBasic

Figgle ASCII Art and System.Speech.Synthesis - To use the program, start by downloading necessary third-party libraries like Figgle for ASCII art and Speech for text-to-speech. Open the terminal and enter the following commands: "dotnet add package Figgle" and "dotnet add package Speech."

### Getting Started

### Usage
Use this system to enhance and streamline the process of user enrollment and authentication.  

### Reporting Bugs and Issues
If you encounter any issues or bugs, please follow these steps to report them:

1. Check if the issue has already been reported by searching [issues](https://github.com/your-username/your-project/issues).

2. If it hasn't been reported, create a new issue with the following information:

    - **Title**: A concise, descriptive title for the issue.
    
    - **Description**: A detailed description of the issue, including the steps to reproduce it.

    - **Expected Behavior**: What you expected to happen.

    - **Actual Behavior**: What actually happened.

    - **Environment**: Your operating system, version of the project, relevant dependencies, etc.

    - **Code Snippet / Stack Trace**: If applicable, include a code snippet or stack trace that demonstrates the issue.

3. If you can, provide a fix or a suggestion for resolving the issue.

4. Be responsive to any follow-up questions or requests for additional information from maintainers.

### Contributing
Contributions to the SmartEnroll System have been made by a group of Computer Science students from Group 2. If you come across any issues or have suggestions for improvement, please feel free to open an issue or create a pull request. However, please note that, as of now, we are not accepting additional contributors.

### License

Copyright © 2023 SmartEnroll.org

The content of this repository is bound by the following licenses:

- The computer software is licensed under the (LICENSE.md) license.
- The learning resources in the ---- directory including their subdirectories thereon are copyright © 2023 SmartEnroll.org