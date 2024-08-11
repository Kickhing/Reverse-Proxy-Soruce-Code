

# FireSocks Reverse Proxy

FireSocks is a C# Windows Forms application that allows users to manage and configure proxy servers. It provides interface for setting up proxy listeners, viewing active connections, and creating proxy client executables tailored to specific configurations.

## Features

- **Proxy Management**: Easily configure and manage multiple proxies with the ability to start, stop, and monitor active connections.
- **Custom Proxy Client Builder**: Generate custom proxy client executables with specified host addresses, ports, and optional features.
- **Intuitive UI**:  interface with clear status updates, configurable options, and real-time feedback on proxy usage.


## Getting Started

### Prerequisites

- .NET Framework 4.8 or later
- Visual Studio 2022
- C#

### Installation

1. **Clone the repository**

2. **Open the project in Visual Studio**:

3. **Build the project**:
   Build the solution to restore NuGet packages and compile the project.

4. **Run the application**:
   Start the application by running the project through Visual Studio.

### Usage

#### Starting a Proxy Listener

1. Navigate to **Configuration Form** by clicking on the appropriate menu option.
2. Enter the desired ports and validate the configuration.
3. Click **Start Listener** to begin the proxy service.

#### Viewing Active Proxies

- Active proxies will be displayed in the main interface with real-time updates on their status and usage.

#### Building a Proxy Client

1. Open **Build Proxy ** through the menu.
2. Specify the output path, host address, and port for the proxy client.
3. Click **Build** to generate the proxy client executable.

### Advanced Features

- **Custom ListView Control**: A specialized list view control is used to display proxy information with enhanced features.
- **Resource Management**: Modify and manage binary resources for generating custom proxy clients.


## Screenshots


![reverseproxy](https://github.com/user-attachments/assets/2242714c-3657-488f-9f33-3d04139a044b)

![image](https://github.com/user-attachments/assets/60557a92-cb29-43e4-bc82-4d708b1dd302)

![r-p-build](https://github.com/user-attachments/assets/c1bfa24e-4e23-497b-830f-0e25c114b9aa)

### Contributions

Leave a Star on this Repo

### License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

